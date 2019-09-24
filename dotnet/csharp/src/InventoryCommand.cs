using System;

namespace EventSourcing
{
    public abstract class InventoryCommand
    {
        public class Create : InventoryCommand
        {
            public Create(Guid inventoryId, string name)
            {
                InventoryId = inventoryId;
                Name = name;
            }

            public Guid InventoryId { get; }

            public string Name { get; }
        }

        public class Stock : InventoryCommand
        {
            public Stock(int count) => Count = count;

            public int Count { get; }

        }

        public class Sell : InventoryCommand
        {
            public Sell(int count) => Count = count;

            public int Count { get; }
        }

        public class Activate : InventoryCommand
        {
            public Activate() { }
        }

        public class Deactivate : InventoryCommand
        {
            public Deactivate() { }
        }
    }
}
