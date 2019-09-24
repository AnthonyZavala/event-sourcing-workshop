const { Created, Stocked, Sold, Activated, Deactivated } = require('./inventoryEvent');

const inventoryItems =
{
    "439263a8-95be-499f-b0d5-926d972bce79": [
        new Created("439263a8-95be-499f-b0d5-926d972bce79", "Item 1"),
        new Stocked(10),
        new Activated(),
        new Sold(5),
    ],
    "26945c8a-49d2-4b0b-86e2-f480ab2bf4ec": [
        new Created("26945c8a-49d2-4b0b-86e2-f480ab2bf4ec", "Item 2"),
        new Stocked(10),
        new Activated(),
        new Sold(20),
        new Deactivated()
    ],
}

exports.GetEvents = (id) => inventoryItems[id] ? inventoryItems[id] : [];