open System.Net.Http

let webClient = new HttpClient()

let address = "https://example.com"

printfn "Retrieving contents of %s\n" address

let contents = 
    webClient.GetStringAsync address
    |> Async.AwaitTask
    |> Async.RunSynchronously

printfn "%s" contents
