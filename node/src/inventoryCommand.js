class Create {
    constructor(inventoryId, name) {
        this.inventoryId = inventoryId;
        this.name = name;
    }
}

class Stock {
    constructor(count) {
        this.count = count;
    }
}

class Sell {
    constructor(count) {
        this.count = count;
    }
}

class Deactivate { }

class Activate { }

module.exports = { Create, Stock, Sell, Deactivate, Activate };