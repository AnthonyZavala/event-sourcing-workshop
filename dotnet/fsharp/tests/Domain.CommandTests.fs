namespace Domain

open System
open Xunit

module CommandTests =

    let Given state:InventoryItem = state
    let When command state = Aggregate.Execute command state
    let Then (expectedEvent: InventoryEvent) (actualEvents: InventoryEvent List) = Assert.Equal<List<InventoryEvent>>([expectedEvent], actualEvents)

    let rdm = Random();

    let aggregateId = Guid.NewGuid()
    let name = "Item 1"

    [<Fact>]
    let ``Given initial inventory item, When Create command, Then Created event`` () =
        Given Aggregate.Initialize
        |> When (Create (aggregateId, name))
        |> Then (Created (aggregateId, name))
    
    [<Fact>]
    let ``Given existing inventory item, When Stock command, Then Stocked event`` () =
        let rdmStock = rdm.Next()
               
        Given { Id = Guid.NewGuid(); Name = "Test"; Count = rdm.Next(); Active = false; }
        |> When (Activate) // TODO: execute stock command to create stocked event
        |> Then (Stocked rdmStock)
    
    [<Fact>]
    let ``Given inventory item, When Sell command, Then Sold event`` () =
        let rdmStock = rdm.Next()

        Given { Id = Guid.NewGuid(); Name = "Test"; Count = rdmStock; Active = true; } 
        |> When (Activate) // TODO: execute sell command to create sold event
        |> Then (Sold rdmStock)

    [<Fact>]
    let ``Given inventory item, When Deactivate command, Then Deactivated event`` () =
        Given { Id = Guid.NewGuid(); Name = "Test"; Count = 0; Active = true; }
        |> When Activate // TODO: execute deactivate command to activate the item
        |> Then Deactivated

    [<Fact>]
    let ``Given inventory item, When Activate command, Then Activated event`` () =
        Given { Id = Guid.NewGuid(); Name = "Test"; Count = 0; Active = false; }
        |> When Deactivate // TODO: execute activate command to activate the item
        |> Then Activated

    // [<Fact>]
    // let ``Given sold out inventory item, When Sell command, Then Errored event`` () =
    //     let rdmStock = rdm.Next()
    //     let state = { Id = Guid.NewGuid(); Name = "Test"; Count = 0; Active = true; }
    //     let command = Sell rdmStock

    //     Given state
    //     |> When command
    //     |> Then (Errored (command, state))
