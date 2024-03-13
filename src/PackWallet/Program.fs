open System.Net.Http
open FSharp.Data

type CoindDeskProvider =
    JsonProvider<"""
    {
        "time": {
            "updated": "Feb 25, 2024 12:27:26 UTC",
            "updatedISO": "2024-02-25T12:27:26+00:00",
            "updateduk": "Feb 25, 2024 at 12:27 GMT"
        },
        "disclaimer":"This data was produced from the CoinDesk Bitcoin Price Index (USD). Non-USD currency data converted using hourly conversion rate from openexchangerates.org",
        "chartName":"Bitcoin",
        "bpi": {
            "USD": {
                "code": "USD",
                "symbol": "&#36;",
                "rate": "51,636.062",
                "description": "United States Dollar",
                "rate_float": 51636.0621
            },
            "GBP": {
                "code": "GBP",
                "symbol": "&pound;",
                "rate": "40,725.672",
                "description": "British Pound Sterling",
                "rate_float": 40725.672
            },
            "EUR": {
                "code":"EUR",
                "symbol": "&euro;",
                "rate":"47,654.25",
                "description": "Euro",
                "rate_float": 47654.2504
            }
        }
    }
    """>

let webClient = new HttpClient()

let address = "https://api.coindesk.com/v1/bpi/currentprice.json"

printfn "Retrieving contents of %s ...\n" address

let contents =
    webClient.GetStringAsync address
    |> Async.AwaitTask
    |> Async.RunSynchronously


let json = CoindDeskProvider.Parse contents

printfn "BTC price is %.2f USD" json.Bpi.Usd.Rate
