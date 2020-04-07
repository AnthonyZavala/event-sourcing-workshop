using System;
using System.Linq;

namespace EventSourcing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(InventoryItemEventStore
                .GetEvents(new Guid("439263a8-95be-499f-b0d5-926d972bce79"))
                .Aggregate(InventoryItemEventSourcing.Init, (state, @event) =>
            {
                Console.WriteLine(state);
                return InventoryItemEventSourcing.Apply(@event, state);
            }));

            Console.WriteLine(InventoryItemEventStore
                .GetEvents(new Guid("26945c8a-49d2-4b0b-86e2-f480ab2bf4ec"))
                .Aggregate(InventoryItemEventSourcing.Init, (state, @event) =>
            {
                Console.WriteLine(state);
                return InventoryItemEventSourcing.Apply(@event, state);
            }));
        }
    }
}
