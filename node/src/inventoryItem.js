const { Created, Stocked, Sold, Activated, Deactivated } = require('./inventoryEvent');
const { Create, Stock, Sell, Activate, Deactivate } = require('./inventoryCommand');

class InventoryItem {
    constructor(id, name, count, active) {
        this.id = id;
        this.name = name;
        this.count = count;
        this.active = active;
    }
}

module.exports = { InventoryItem };
