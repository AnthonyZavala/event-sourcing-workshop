module Domain

open System
open EventSourcing

// Record
type InventoryItem =
    { Id: Guid
      Name: string
      Count: int
      Active: bool }
    with static member Initialize = 
            { Id = Guid.Empty
              Name = null
              Count = 0
              Active = false }

// Discriminated Union
type InventoryCommand =
    | Create of inventoryId: Guid * name: string
    | Stock of count: int
    | Sell of count: int
    | Activate
    | Deactivate

// Discriminated Union
type InventoryEvent =
    | Created of inventoryId: Guid * name: string
    | Stocked of count: int
    | Sold of count: int
    | Deactivated
    | Activated
    | Errored of command: InventoryCommand * state: InventoryItem

// Pattern Matching
let private apply (state: InventoryItem) event =
    match event with
    | Created (inventoryId, name)
        -> { state with Id = inventoryId; Name = name; }
    | Stocked count
        -> { state with Count = state.Count + count; }
    | Sold count when state.Count - count >= 0
        -> { state with Count = state.Count - count; }
    | Deactivated
        -> { state with Active = false; }
    | Activated
        -> { state with Active = true; }
    | _ -> state

// Pattern Matching
let private execute command (state: InventoryItem) =
    match command with
    | Create (inventoryId, name) when state.Id = Guid.Empty && state.Name |> isNull
        -> [ Created (inventoryId, name) ]
    | Stock count when state.Id <> Guid.Empty && count > 0
        -> [ Stocked count ]
    | Sell count when state.Id <> Guid.Empty && state.Count - count >= 0 && state.Active && count > 0
        -> [ Sold count ]
    | Deactivate when state.Id <> Guid.Empty && state.Active
        -> [ Deactivated ]
    | Activate when state.Id <> Guid.Empty && not state.Active
        -> [ Activated ]
    | _ -> [ Errored (command, state) ]

let Aggregate =
    { Initialize = InventoryItem.Initialize
      Apply = apply
      Execute = execute }