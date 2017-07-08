# Zaif.NET
Zaif API Wrapper Library for C# .NET  
Zaif API の C# ラッパーライブラリです。  

## API
* Public API （公開 API）
* Trade API （取引 API）
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
This class ** requires your API Key and Secret **.    

 ``` TradeApi ``` クラスを用います。   
 取引APIを利用する場合はAPIキーが必要です。  

```csharp
string key = "YOUR API KEY";
string secret = "YOUR API SECRET";
var api = new TradeApi(key, secret);
var res = api.Getinfo().Result;
Console.WriteLine(res.Return.Funds[CurrenciesEnum.jpy]);  // Show your balance (JPY)
```


