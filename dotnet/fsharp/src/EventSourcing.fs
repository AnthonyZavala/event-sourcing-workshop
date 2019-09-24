module EventSourcing

type Aggregate<'TState,'TEvent,'TCommand> =
    { /// An initial state value
      Initialize: 'TState
      /// Applies an event to a state, returning the new state
      Apply: 'TState -> 'TEvent -> 'TState
      /// Executes a command on a state yielding events
      Execute: 'TCommand -> 'TState -> 'TEvent List }