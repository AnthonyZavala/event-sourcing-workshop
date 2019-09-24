class Created {
    constructor(inventoryId, name) {
        this.inventoryId = inventoryId;
        this.name = name;
    }
}

class Stocked {
    constructor(count) {
        this.count = count;
    }
}

class Sold {
    constructor(count) {
        this.count = count;
    }
}

class Deactivated { }

class Activated { }

// class Errored {
//     constructor(command, state) {
//         this.command = command;
//         this.state = state;
//     }
// }

module.exports = { Created, Stocked, Sold, Deactivated, Activated };