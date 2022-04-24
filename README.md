# PeriodProjection

Given a reference date, provides the projection in the past and/or future of such date based on input strings.


### Sample usage

Currently, there is no NuGet package available; you can download the sources and include them into your solution.

Using:

```using PeriodProjectionSrc;```

Then:

```
DateTime initialDate = new DateTime(2022, 04, 24);
string pastPeriodConstraints = "2M-2Y-1W+2D";
string futurePeriodConstraints = "2M+2Y-1W+2D";

PeriodProjection periodProjection = new PeriodProjection();
var finalDates = periodProjection.GetValidPeriod(initialDate, pastPeriodConstraints, futurePeriodConstraints);
```

The result will be two DateTime objects containing the projected date in the past and in the future.

Supports DateOnly for .Net 6.0.


### Input strings format

```[sign][number][type][sign][number][type][sign][number][type][sign][number][type]```

Where:

```[sign]``` is '+' by default; accepted values: '+', '-'

```[number]``` is any integer number

```[type]``` represents the type of projection that is requested; accepted values: 'Y' for years, 'M' for months, 'W' for weeks, 'D' for days


### Supported .NET versions

.Net Framework 4.8 and upwards


### License

[MIT](https://opensource.org/licenses/MIT)
