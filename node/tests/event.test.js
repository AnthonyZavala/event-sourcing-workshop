const { Created, Stocked, Sold, Activated, Deactivated } = require('../src/inventoryEvent');
const { InventoryItemEventSourcing } = require('../src/inventoryItemEventSourcing');
const { InventoryItem } = require('../src/inventoryItem');

describe('Inventory Event Tests', () => {
    const InventoryId = 'inventoryId';
    const Name = "Item 1";

    it('Given initial inventory item, when created event, then created inventory item', () => {
        // Given
        const initialState = InventoryItemEventSourcing.Init();

        // When
        const newState = InventoryItemEventSourcing.Apply(new Created(InventoryId, Name), initialState);

        // Then
        expect(newState).toEqual(new InventoryItem(InventoryId, Name, initialState.count, initialState.active));
    });

    it('Given inventory item, when stocked event, then inventory count increased', () => {
        // Given
        const initialState = new InventoryItem(InventoryId, Name, 0, true);

        // When
        const newState = null; // TODO, apply stocked event to fix assertion

        // Then
        expect(newState.count).toEqual(12);
    });

    it('Given inventory item, when sold event, then inventory count decreased', () => {
        // Given
        var initialState = new InventoryItem(InventoryId, Name, 100, true);

        // When
        var newState = null; // TODO, apply sold event to fix assertion

        // Then
        expect(newState.count).toEqual(90);
    });

    it('Given inventory item, when deactivated event, then inventory item inactive', () => {
        // Given
        var initialState = new InventoryItem(InventoryId, Name, 100, true);

        // When
        var newState = null; // TODO, apply deactivated event to fix assertion

        // Then
        expect(newState.active).toEqual(false);
    });

    it('Given inventory item, when activated event, then inventory item active', () => {
        // Given
        var initialState = new InventoryItem(InventoryId, Name, 100, false);

        // When
        var newState = null; // TODO, apply activated event to fix assertion

        // Then
        expect(newState.active).toEqual(true);
    });
});
