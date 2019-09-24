using System;

namespace EventSourcing
{
    public class InventoryItem
    {
        public InventoryItem(Guid id, string name, int count, bool active)
        {
            Id = id;
            Name = name;
            Count = count;
            Active = active;
        }

        public Guid Id { get; }
        public string Name { get; }
        public int Count { get; }
        public bool Active { get; }

        public override string ToString() => $"{{Id = {Id}; Name = {Name}; Count = {Count}; Active = {Active};}}";
        public override bool Equals(object obj) => obj is InventoryItem item && Id.Equals(item.Id) && Name == item.Name && Count == item.Count && Active == item.Active;
        public override int GetHashCode() => HashCode.Combine(Id, Name, Count, Active);
    }
}
