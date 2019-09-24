const { Create, Stock, Sell, Activate, Deactivate } = require('../src/inventoryCommand');
const { Created, Stocked, Sold, Activated, Deactivated } = require('../src/inventoryEvent');
const { InventoryItemEventSourcing } = require('../src/inventoryItemEventSourcing');
const { InventoryItem } = require('../src/inventoryItem');

describe('Inventory Command Tests', () => {
    const InventoryId = '0ae1820f-69eb-4517-91da-b09c2d1d50af';
    const Name = "Item 1";

    it('Given initial inventory item, when create command, then created event', () => {
        // Given
        const initialState = InventoryItemEventSourcing.Init();

        // When
        const event = InventoryItemEventSourcing.Execute(new Create(InventoryId, Name), initialState);

        // Then
        expect(event).toEqual(new Created(InventoryId, Name));
    });

    it('Given existing inventory item, when stock command, then stocked event', () => {
        // Given
        var initialState = new InventoryItem(InventoryId, Name, 100, true);

        // When
        var event = null; // TODO: execute stock command to create stocked event with 25 unit increment

        // Then
        var expectedEvent = new Stocked(25);
        expect(event).toEqual(expectedEvent);
    });

    it('Given existing inventory item, when sell command, then sold event', () => {
        // Given
        var initialState = new InventoryItem(InventoryId, Name, 100, true);

        // When
        var event = null; // TODO: execute sell command to create sold event for 10 sold units

        // Then
        var expectedEvent = new Sold(10);
        expect(event).toEqual(expectedEvent);
    });

    it('Given active inventory item, when deactivate command, then deactivated event', () => {
        // Given
        var initialState = new InventoryItem(InventoryId, Name, 100, true);

        // When
        var event = null; // TODO: execute deactivate command to deactivate the item

        // Then
        expect(event).toEqual(new Deactivated());
    });

    it('Given inactive inventory item, when activate command, then activated event', () => {
        // Given
        var initialState = new InventoryItem(InventoryId, Name, 100, false);

        // When
        var event = null; // TODO: execute activate command to activate the item

        // Then
        expect(event).toEqual(new Activated());
    });

    // it('Given sold out inventory item, when sell command, then errored event', () => {
    //     // Given
    //
    //     // When
    //
    //     // Then
    //     expect(true).toEqual(false);
    // });
});
