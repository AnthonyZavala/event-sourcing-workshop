using EventSourcing;
using System;
using Xunit;

public class EventTests
{
    private static readonly Guid InventoryId = Guid.NewGuid();
    private const string Name = "Item 1";
    
    [Fact]
    public void Given_initial_inventory_item_When_created_event_Then_created_inventory_item()
    {
        // Given
        InventoryItem initialState = InventoryItemEventSourcing.Init;

        // When
        var newState = InventoryItemEventSourcing.Apply(new InventoryEvent.Created(InventoryId, Name), initialState);

        // Then
        Assert.Equal(new InventoryItem(InventoryId, Name, initialState.Count, initialState.Active), newState);
    }

    [Fact]
    public void Given_inventory_item_When_stocked_event_Then_inventory_count_increased()
    {
        // Given
        var initialState = new InventoryItem(InventoryId, Name, count: 0, active: true);

        // When
        InventoryItem newState = null; // TODO, apply stocked event to fix assertion

        // Then
        Assert.Equal(12, newState.Count);
    }

    [Fact]
    public void Given_inventory_item_When_sold_event_Then_inventory_count_decreased()
    {
        // Given
        var initialState = new InventoryItem(InventoryId, Name, count: 100, active: true);

        // When
        InventoryItem newState = null; // TODO, apply sold event to fix assertion

        // Then
        Assert.Equal(90, newState.Count);
    }

    [Fact]
    public void Given_inventory_item_When_deactivated_event_Then_inventory_item_inactive()
    {
        // Given
        var initialState = new InventoryItem(InventoryId, Name, count: 100, active: true);

        // When
        InventoryItem newState = null; // TODO, apply deactivated event to fix assertion

        // Then
        Assert.False(newState.Active);
    }

    [Fact]
    public void Given_inventory_item_When_activated_event_Then_inventory_item_active()
    {
        // Given
        var initialState = new InventoryItem(InventoryId, Name, count: 100, active: false);

        // When
        InventoryItem newState = null; // TODO, apply activated event to fix assertion

        // Then
        Assert.True(newState.Active);
    }
}
