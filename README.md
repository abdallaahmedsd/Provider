# Provider Service (Sum API)

Simple ASP.NET Core Web API that accepts two numbers and returns their sum.

## Endpoint
**POST** `/math/sum`

### Request
```json
{
  "number1": 5,
  "number2": 7
}
```

### Response
```json
{
  "result": 12
}
```
