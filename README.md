# event-sourcing-workshop
A workshop for hands-on introduction to Event Sourcing.

## What is Event Sourcing?
The fundamental idea of Event Sourcing is that changes to state (events) are persisted in sequence. As opposed to storing the current state. A common use case for Event Sourcing is to persist events from an aggregate.

## Component Types
| **Input/Output** | **Events**                 | **Commands**                  | **External**              |
|------------------|----------------------------|-------------------------------|---------------------------|
| **Events**       | Translator (ACL)           | Process Manager               | Projector (Projection)    |
| **Commands**     | **Aggregator** (Aggregate) | Controller (Translator/ACL)   | Actuator                  |
| **External**     | Sensor                     | Actor                         | System                    |

## Prerequisites
- .NET
    - [Visual Studio Code](https://code.visualstudio.com/download) (or anything that can be used for dotnet development)
    - [.NET Core SDK 3.1](https://dotnet.microsoft.com/download/dotnet-core)
    - [C# for Visual Studio Code version 1.17.1 or later](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp) (If you are using VSCode and prefer C#)
    - [F#: Ionide-fsharp](https://marketplace.visualstudio.com/items?itemName=Ionide.Ionide-fsharp) (If you are using VSCode and prefer F#)
- Node.js
    - [Visual Studio Code](https://code.visualstudio.com/download) (or anything that can be used for Node development)
    - [Node.js](https://nodejs.org/) with [npm](https://www.npmjs.com/)

## Concepts
In this workshop we will be working with the inventory item example. Assume this example is for a store and a user can be create, stock, sell, activate, and deactivate inventory items.

### State
InventoryItem is a container that holds state.
```yaml
inventoryItem:
    id: e85c1ec3-f077-4625-adf2-5a593a293988
    name: "Item 1"
    count: 212
    active: true
```

### Events
InventoryEvent defines the events that can happen to an InventoryItem state.
```yaml
- Created:
    InventoryId: e85c1ec3-f077-4625-adf2-5a593a293988
    Name: "Item 1"

- Stocked:
    Count: 123

- Sold:
    Count: 43

- Activated

- Deactivated
```

### Commands
InventoryCommand defines the commands that a user can ask to execute on an InventoryItem state.
```yaml
- Create:
    InventoryId: e85c1ec3-f077-4625-adf2-5a593a293988
    Name: "Item 1"

- Stock:
    Count: 123

- Sell:
    Count: 43

- Activate

- Deactivate
```

### Event Sourcing Functions
The basic function to describe event sourcing is: `(state, event) -> state'`  
This function is described as: given some state, when an event is applied, then a new state is given.  
This function is often referred to as the `Apply` function.

When utilizing commands the execute function is: `(state, command) -> event`  
This function is describe as: given some state, when a command is executed, then an event is given.  
This function is where your business logic belongs and is often referred to as the `Execute` function.

Another function that is useful for event sourcing is an initialization function. `() -> state`  
This function allows for a known initialization state before applying events.

## Workshop
This workshop is implemented as using Quality Assurance and test writing to verify an Event Sourcing implementation.

### Steps
- Clone this repo and navigate to the directory of your chosen framework/language.
- Build if using dotnet `dotnet build`; Install packages if using node `npm i`
- Run the tests `dotnet test` or `npm test`
    - A number of the tests will fail.
- Open the `Domain.EventTests.fs`, `EventTests.cs`, or `event.test.js` file under the tests directory.
- Fix the broken event tests by following the `Given,When,Then` pattern of the test names. You will need to use the Apply function.
- Open the `Domain.CommandTests.fs`, `CommandTests.cs` or `command.test.js` file under the tests directory.
- Fix the broken command tests by following the `Given,When,Then` pattern of the test names. You will need to use the Execute function.

### Bonus Concepts
- Compensating Events
- Error Events
