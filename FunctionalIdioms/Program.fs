// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

// Define a function to construct a message to print
let Idiom2 ()=
    let print count =
        let text = seq{for i in 1  .. count do yield "Hello"}
        for t in text do
            printfn "%s" t
    print 10

// https://programming-idioms.org/about#about-block-all-idioms
[<EntryPoint>]
let main argv =
    Idiom2 ()
    0 // return an integer exit code