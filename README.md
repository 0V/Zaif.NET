# Zaif.NET
Zaif API Wrapper for C# .NET

## Usage

Add ``` using ``` directive.

```csharp
using ZaifNet;
```

### Public API

Use ``` PublicApi ``` Class.


```csharp
var papi = new PublicApi();
var res = papi.Currencies("all"),Result;
Console.WriteLine(res.ToList()[0].Name);
```

### Trade API

Use ``` TradeApi ``` Class.  
This class ** requires your API Key and Secret **.

```csharp
string key = "YOUR API KEY";
string secret = "YOUR API SECRET";
var api = new TradeApi(key, secret);
var res = api.Getinfo().Result;
Console.WriteLine(res.Return.Funds.Jpy);
```

