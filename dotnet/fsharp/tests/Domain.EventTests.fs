namespace Domain

open System
open Xunit

module EventTests =

    let Given state:InventoryItem = state
    let When event state = Aggregate.Apply state event
    let Then (actualState: InventoryItem) (expectedState: InventoryItem) = Assert.Equal(expectedState, actualState)

    let rdm = Random();

    [<Fact>]
    let ``Given initial inventory item, When Created event, Then Created inventory item`` () =
        let initialState = Aggregate.Initialize
        let aggregateId = Guid.NewGuid()
        let name = "Test"

        Given initialState
        |> When (Created (aggregateId, name))
        |> Then { initialState with Id = aggregateId; Name = name }

    [<Fact>]
    let ``Given inventory item, When Stocked event, Then inventory count incremented`` () =
        let initialState = { Id = Guid.NewGuid(); Name = null; Count = 0; Active = false; }
        let stockedCount = rdm.Next()

        Given initialState
        |> When (Stocked stockedCount)
        |> Then { initialState with Count = stockedCount }

    [<Fact>]
    let ``Given inventory item, When Sold event, Then inventory count decremented`` () =
        let initialState = { Id = Guid.NewGuid(); Name = null; Count = 10; Active = false; }
        let soldCount = rdm.Next(10)

        Given initialState
        |> When (Sold soldCount)
        |> Then { initialState with Count = (initialState.Count - soldCount) }

    [<Fact>]
    let ``Given inventory item, When Deactivated event, Then inventory item inactive`` () =
        let initialState = { Id = Guid.NewGuid(); Name = null; Count = 0; Active = true; }

        Given initialState
        |> When (Deactivated)
        |> Then { initialState with Active = false }

    [<Fact>]
    let ``Given inventory item, When Activated event, Then inventory item active`` () =
        let initialState = { Id = Guid.NewGuid(); Name = null; Count = 0; Active = false; }

        Given initialState
        |> When (Activated)
        |> Then { initialState with Active = true }
