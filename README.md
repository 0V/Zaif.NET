# Zaif.NET
Zaif API (v1.1.1) Wrapper Library for C# .NET 
Zaif API (v1.1.1) の C# ラッパーライブラリです。  

[Zaif API Doc](http://techbureau-api-document.readthedocs.io/ja/latest/index.html)

## API
* Public API （現物公開 API）
* Trade API （現物取引 API）
* Future Public API （先物公開 API）
* LeverageTrade API （レバレッジ取引 API）
* Streaming API （ストリーミング API）
  
  
## Usage
  
Add ``` using ``` directive.    
using ディレクティブを追加してください。  

```csharp
using ZaifNet;
```

### Public API

Use ``` PublicApi ``` Class.  
 ``` PublicApi ``` クラスを用います。
 
```csharp
var api = new PublicApi();
var res = api.Currencies("all").Result;
foreach (var item in res.Result)
{
    Console.WriteLine(item.CurrencyPairValue); // Show all "currency_pair"
}
```

### Future Public API

Use ``` FuturePublicApi ``` Class.    
 ``` FuturePublicApi ``` クラスを用います。

```csharp
var api = new FuturePublicApi();
var res = api.Groups("all").Result;
foreach (var item in res.Result)
{
    Console.WriteLine(item.Id + " : " + item.CurrencyPair); // Show all "id" and "currency_pair"
}

```
### Streaming API

Use ``` StreamingApi ``` Class.    
 ``` StreamingApi ``` クラスを用います。

```csharp
var api = new StreamingApi();
var cs = new CancellationTokenSource();
var res = api.StartStream(CurrencyPairsEnum.btc_jpy, s =>
{
    Console.WriteLine(s.LastPrice.Price); // Show last price (BTC/JPY) in real time
}, cs.Token);

Console.ReadLine(); 
cs.Cancel(); // -> Stop Stream

```

### Trade API

Use ``` TradeApi ``` Class.  
This class **requires your API Key and Secret**.    

 ``` TradeApi ``` クラスを用います。   
このAPIを利用する場合はAPIキーが必要です。  

```csharp
string key = "YOUR API KEY";
string secret = "YOUR API SECRET";
var api = new TradeApi(key, secret);
var res = api.Getinfo().Result;
Console.WriteLine(res.Return.Funds[CurrenciesEnum.jpy]);  // Show your balance (JPY)
```

### Leverage Trade API

Use ``` LeverageTradeApi ``` Class.  
This class **requires your API Key and Secret**.    

 ``` LeverageTradeApi ``` クラスを用います。   
 このAPIを利用する場合はAPIキーが必要です。  

```csharp

    string key = "YOUR API KEY";
    string secret = "YOUR API SECRET";
    var api = new LeverageTradeApi(key, secret);
    var param = new Dictionary<string, string>();
    param.Add("type", "futures");
    var res = api.PositionHistory(param).Result;
    foreach (var item in res.Return)
    {
        Console.Write(item.Value.YourAction + " : " +item.Value.Price);  // Show your action and price
    }
```


