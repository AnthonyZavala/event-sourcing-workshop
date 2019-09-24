module EventStore

open System
open Domain

let private inventoryItems = Map<Guid, List<InventoryEvent>> [
    (Guid.Parse("439263a8-95be-499f-b0d5-926d972bce79"), [
        Created (Guid.Parse("439263a8-95be-499f-b0d5-926d972bce79"), "Item 1");
        Stocked 10;
        Activated;
        Sold 5 ])
    (Guid.Parse("26945c8a-49d2-4b0b-86e2-f480ab2bf4ec"), [
        Created (Guid.Parse("26945c8a-49d2-4b0b-86e2-f480ab2bf4ec"), "Item 2");
        Stocked 10;
        Activated;
        Sold 20 ]) ]

let GetEvents id =
    id
    |> inventoryItems.TryFind
    |> Option.defaultValue []