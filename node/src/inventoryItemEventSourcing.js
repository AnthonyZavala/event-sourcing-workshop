const { Created, Stocked, Sold, Activated, Deactivated } = require('./inventoryEvent');
const { Create, Stock, Sell, Activate, Deactivate } = require('./inventoryCommand');
const { InventoryItem } = require('./inventoryItem');

class InventoryItemEventSourcing {
    static Init() {
        return new InventoryItem(null, null, 0, false);
    }

    static Apply(event, state) {
        if (!event) return state;
        switch (event.constructor) {
            case Created:
                return new InventoryItem(event.inventoryId, event.name, state.count, state.active);
            case Stocked:
                return new InventoryItem(state.id, state.name, state.count + event.count, state.active);
            case Sold:
                return new InventoryItem(state.id, state.name, state.count - event.count, state.active);
            case Deactivated:
                return new InventoryItem(state.id, state.name, state.count, false);
            case Activated:
                return new InventoryItem(state.id, state.name, state.count, true);
            default:
                return state;
        }
    }

    static Execute(command, state) {
        switch (command.constructor) {
            case Create:
                if (state.id === null && state.name === null) {
                    return new Created(command.inventoryId, command.name);
                }
                break;
            case Stock:
                if (state.id !== null && command.count > 0) {
                    return new Stocked(command.count);
                }
                break;
            case Sell:
                if (state.id !== null /*&& state.count - command.count >= 0 && state.active && command.count > 0*/) {
                    return new Sold(command.count);
                }
                break;
            case Deactivate:
                if (state.id !== null && state.active) {
                    return new Deactivated();
                }
                break;
            case Activate:
                if (state.id !== null && !state.active) {
                    return new Activated();
                }
                break;
        }
        return null; // return new Errored(command, state);
    }
}

module.exports = { InventoryItemEventSourcing };