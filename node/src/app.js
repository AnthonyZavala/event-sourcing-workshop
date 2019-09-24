const { InventoryItemEventSourcing } = require('./inventoryItemEventSourcing');
const { GetEvents } = require('./inventoryItemEventStore');

const inventoryItem =
    GetEvents("439263a8-95be-499f-b0d5-926d972bce79")
        .reduce((state, event) => {
            console.log(state);
            return InventoryItemEventSourcing.Apply(event, state);
        }, InventoryItemEventSourcing.Init());

console.log(inventoryItem);