open System

[<EntryPoint>]
let main argv =
    (Domain.Aggregate.Initialize, EventStore.GetEvents (Guid.Parse("439263a8-95be-499f-b0d5-926d972bce79")))
    ||> List.fold Domain.Aggregate.Apply
    |> printfn "%A"

    0 // return an integer exit code
