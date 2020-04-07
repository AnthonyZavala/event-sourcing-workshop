open System

[<EntryPoint>]
let main argv =
    (Domain.Aggregate.Initialize, EventStore.GetEvents (Guid.Parse("439263a8-95be-499f-b0d5-926d972bce79")))
    ||> List.fold (fun state ->
        printfn "%A" state
        state |> Domain.Aggregate.Apply)
    |> printfn "%A"

    Console.WriteLine()
    
    (Domain.Aggregate.Initialize, EventStore.GetEvents (Guid.Parse("26945c8a-49d2-4b0b-86e2-f480ab2bf4ec")))
    ||> List.fold (fun state ->
        printfn "%A" state
        state |> Domain.Aggregate.Apply)
    |> printfn "%A"

    0 // return an integer exit code
