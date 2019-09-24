using System;
using System.Collections.Generic;

namespace EventSourcing
{
    public static class InventoryItemEventStore
    {
        private static readonly Dictionary<Guid, List<InventoryEvent>> inventoryItems = new Dictionary<Guid, List<InventoryEvent>>
            {
                { new Guid("439263a8-95be-499f-b0d5-926d972bce79"), new List<InventoryEvent>
                    {
                        new InventoryEvent.Created(new Guid("439263a8-95be-499f-b0d5-926d972bce79"), "Item 1"),
                        new InventoryEvent.Stocked(10),
                        new InventoryEvent.Activated(),
                        new InventoryEvent.Sold(5),
                    }
                },
                { new Guid("26945c8a-49d2-4b0b-86e2-f480ab2bf4ec"), new List<InventoryEvent>
                    {
                        new InventoryEvent.Created(new Guid("26945c8a-49d2-4b0b-86e2-f480ab2bf4ec"), "4x4"),
                        new InventoryEvent.Stocked(10),
                        new InventoryEvent.Activated(),
                        new InventoryEvent.Sold(20),
                    }
                }
            };

        public static IList<InventoryEvent> GetEvents(Guid id) => inventoryItems.ContainsKey(id) ? inventoryItems[id] : new List<InventoryEvent>();
    }
}
