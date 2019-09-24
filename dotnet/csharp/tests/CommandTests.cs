using EventSourcing;
using System;
using Xunit;

public class CommandTests
{
    private static readonly Guid InventoryId = Guid.NewGuid();
    private const string Name = "Item 1";
    
    [Fact]
    public void Given_initial_inventory_item_When_create_command_Then_created_event()
    {
        // Given
        InventoryItem initialState = InventoryItemEventSourcing.Init;

        // When
        InventoryEvent @event = InventoryItemEventSourcing.Execute(new InventoryCommand.Create(InventoryId, Name), initialState);

        // Then
        Assert.Equal(new InventoryEvent.Created(InventoryId, Name), @event);
    }

    [Fact]
    public void Given_existing_inventory_item_When_stock_command_Then_stocked_event()
    {
        // Given
        var initialState = new InventoryItem(InventoryId, Name, count: 100, active: true);

        // When
        InventoryEvent @event = null; // TODO: execute stock command to create stocked event with 25 unit increment

        // Then
        var expectedEvent = new InventoryEvent.Stocked(25);
        Assert.Equal(expectedEvent, @event);
    }

    [Fact]
    public void Given_existing_inventory_item_When_sell_command_Then_sold_event()
    {
        // Given
        var initialState = new InventoryItem(InventoryId, Name, count: 100, active: true);

        // When
        InventoryEvent @event = null; // TODO: execute sell command to create sold event for 10 sold units

        // Then
        var expectedEvent = new InventoryEvent.Sold(10);
        Assert.Equal(expectedEvent, @event);
    }

    [Fact]
    public void Given_active_inventory_item_When_deactivate_command_Then_deactivated_event()
    {
        // Given
        var initialState = new InventoryItem(InventoryId, Name, count: 100, active: true);

        // When
        InventoryEvent @event = null; // TODO: execute deactivate command to deactivate the item

        // Then
        Assert.True(@event is InventoryEvent.Deactivated); // Assert Type for events with no properties
    }

    [Fact]
    public void Given_inactive_inventory_item_When_activate_command_Then_activated_event()
    {
        // Given
        var initialState = new InventoryItem(InventoryId, Name, count: 100, active: false);

        // When
        InventoryEvent @event = null; // TODO: execute activate command to activate the item

        // Then
        Assert.True(@event is InventoryEvent.Activated); // Assert Type for events with no properties
    }

//    [Fact]
//    public void Given_sold_out_inventory_item_When_sell_command_Then_errored_event()
//    {
//        // Given
//        var initialState = new InventoryItem(InventoryId, Name, count: 0, active: true);
//
//        // When
//        InventoryEvent @event = null; // TODO: execute sell command to cause the error event
//
//        // Then
//        Assert.Equal(1, 2);
//    }
}
