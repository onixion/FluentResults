<img src="https://github.com/onixion/FluentResults/blob/main/Assets/Icon.jpg" width="200" height="200">

# FluentResults
[![NuGet version (FluentResults)](https://img.shields.io/nuget/v/AlinSpace.FluentResults.svg?style=flat-square)](https://www.nuget.org/packages/AlinSpace.FluentResults/)

A simple fluent library for optional results and error results.

[NuGet package](https://www.nuget.org/packages/AlinSpace.FluentResults/)

## Why?

Returning a null (or default) value on failure is not the best way of conveying the reason for the specific failure.
Throwing an exception is a better way of doing it. Catching and handling exception needs a lot of boiler plate code and
can also easily be forgotten to be catched. Exceptions also makes the flow of the software much more complex than return values.

## Examples

### Return optional value

The following method returns an optional result of type *string*:

```csharp
Result<string> Method()
{
    ...

    if (failure)
    {
        return Result<string>.None();
    }
    
    ...
    
    return data.ToResult();
}
```

```csharp
// Create results with no value. 
var result1 = new Result<string>();
var result2 = Result<string>.None();

// This will throw an exception, because there is no value.
result1.Value;
result2.Value;

// This will return false.
result1.HasValue;
result2.HasValue;

// Create result with a value.
var result3 = new Result<string>("Data");

// This will return "Data".
result3.Value;

// This will return true.
result3.HasValue;
```

### Return result value with error value

The result can also contain an error value instead of simply beeing empty.
The following method returns a result with :

```csharp
Result<string, int> Method()
{
    if (failure < 0)
    {
        return Result<string, int>.Error(failure);
    }
    
    ...
    
    return Result<string, int>.Return(data);
}
```

```csharp
// Create result with string value and int error value. 
var result1 = Result<string, int>.Error(5);

// This will throw an exception, because there is no value.
result1.Value;

// This will return false.
result1.HasValue;
result2.HasValue;

// Create result with a value.
var result3 = new Result<string>("Data");

// This will return "Data".
result3.Value;

// This will return true.
result3.HasValue;
```
