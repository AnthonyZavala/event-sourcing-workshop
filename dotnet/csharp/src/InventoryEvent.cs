using System;

namespace EventSourcing
{
    public abstract class InventoryEvent
    {
        public class Created : InventoryEvent
        {
            public Created(Guid inventoryId, string name)
            {
                InventoryId = inventoryId;
                Name = name;
            }

            public Guid InventoryId { get; }

            public string Name { get; }

            public override bool Equals(object obj) => obj is Created created && InventoryId.Equals(created.InventoryId) && Name == created.Name;
            public override int GetHashCode() => HashCode.Combine(InventoryId, Name);
        }

        public class Stocked : InventoryEvent
        {
            public Stocked(int count) => Count = count;

            public int Count { get; }

            public override bool Equals(object obj) => obj is Stocked stocked && Count == stocked.Count;
            public override int GetHashCode() => HashCode.Combine(Count);
        }

        public class Sold : InventoryEvent
        {
            public Sold(int count) => Count = count;

            public int Count { get; }

            public override bool Equals(object obj) => obj is Sold sold && Count == sold.Count;
            public override int GetHashCode() => HashCode.Combine(Count);
        }

        public class Activated : InventoryEvent
        {
            public Activated() { }
        }

        public class Deactivated : InventoryEvent
        {
            public Deactivated() { }
        }

        //public class Errored : InventoryEvent
        //{
        //    public Errored(InventoryCommand command, InventoryItem state)
        //    {
        //        Command = command;
        //        State = state;
        //    }

        //    public InventoryCommand Command { get; }
        //    public InventoryItem State { get; }
        //}
    }
}
