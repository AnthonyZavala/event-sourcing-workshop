const { InventoryItemEventSourcing } = require('./inventoryItemEventSourcing');
const { GetEvents } = require('./inventoryItemEventStore');

console.log(
    GetEvents("439263a8-95be-499f-b0d5-926d972bce79")
        .reduce((state, event) => {
            console.log(state);
            return InventoryItemEventSourcing.Apply(event, state);
        }, InventoryItemEventSourcing.Init()));

console.log();

console.log(
    GetEvents("26945c8a-49d2-4b0b-86e2-f480ab2bf4ec")
        .reduce((state, event) => {
            console.log(state);
            return InventoryItemEventSourcing.Apply(event, state);
        }, InventoryItemEventSourcing.Init()));