using System;
using System.Collections.Generic;
using System.Text;

namespace EventSourcing
{
    public class InventoryItemEventSourcing
    {
        public static InventoryItem Init => new InventoryItem(Guid.Empty, null, 0, false);

        public static InventoryItem Apply(InventoryEvent @event, InventoryItem state)
        {
            switch (@event)
            {
                case InventoryEvent.Created created:
                    return new InventoryItem(created.InventoryId, created.Name, state.Count, state.Active);
                case InventoryEvent.Stocked stocked:
                    return new InventoryItem(state.Id, state.Name, state.Count + stocked.Count, state.Active);
                case InventoryEvent.Sold sold:
                    return new InventoryItem(state.Id, state.Name, state.Count - sold.Count, state.Active);
                case InventoryEvent.Deactivated _:
                    return new InventoryItem(state.Id, state.Name, state.Count, false);
                case InventoryEvent.Activated _:
                    return new InventoryItem(state.Id, state.Name, state.Count, true);
                default:
                    return state;
            }
        }

        public static InventoryEvent Execute(InventoryCommand command, InventoryItem state)
        {
            switch (command)
            {
                case InventoryCommand.Create create when state.Id == Guid.Empty && state.Name == null:
                    return new InventoryEvent.Created(create.InventoryId, create.Name);
                case InventoryCommand.Stock stock when state.Id != Guid.Empty && stock.Count > 0:
                    return new InventoryEvent.Stocked(stock.Count);
                case InventoryCommand.Sell sell when state.Id != Guid.Empty /*&& state.Count - sell.Count >= 0 && state.Active && sell.Count > 0*/:
                    return new InventoryEvent.Sold(sell.Count);
                case InventoryCommand.Deactivate _ when state.Id != Guid.Empty && state.Active:
                    return new InventoryEvent.Deactivated();
                case InventoryCommand.Activate _ when state.Id != Guid.Empty && !state.Active:
                    return new InventoryEvent.Activated();
                default:
                    return null; // return new InventoryEvent.Errored(command, state);
            }
        }
    }
}
