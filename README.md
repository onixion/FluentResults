<img src="https://github.com/onixion/FluentResults/blob/main/Assets/Icon.jpg" width="200" height="200">

# FluentResults
[![NuGet version (FluentResults)](https://img.shields.io/nuget/v/AlinSpace.FluentResults.svg?style=flat-square)](https://www.nuget.org/packages/AlinSpace.FluentResults/)

A simple fluent library for optional results and error results.

[NuGet package](https://www.nuget.org/packages/AlinSpace.FluentResults/)

## Why?

Returning a null (or default) value on failure is not the best way of conveying the reason for the specific failure.
Throwing an exception is a better way of doing it. Catching and handling exception needs a lot of boiler plate code and
can also easily be forgotten to be catched. Exceptions also makes the flow of the software much more complex than return values.



```csharp
string GetDataText()
{
    if (failure)
        return null;
        
    ...
    
    return data;
}
```

## Examples

### Return optional result value

```csharp
Result<string> Method()
{
    if (failure)
        return new Result<string>.None();
    return data;
}

var result = Method();
if (result.HasValue)
{
    var data = result.Value;
}
```

### Return result value with error value

```csharp
Result<string, int> Method()
{
    if (failure)
        return new Result<string, int>.None();
    return data.ToResult<string, int>();
}

var result = Method();
if (result.HasValue)
{
    var data = result.Value;
}
```
