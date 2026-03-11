# FastLog

`FastLog` is a simple .NET logging library 

It supports logging:
- to the console
- to a file

## Features

- Dependency injection via `AddFastLog(...)`
- Basic log levels (`Trace`, `Error``)
- Console output with timestamp
- File output with automatic directory creation

## Requirements

- .NET `10.0`

## Configuration

Configure it with DI:

```csharp
using FastLog;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddFastLog(options =>
{
	options.EnableConsoleLogging = true;
	options.EnableFileLogging = true;
	options.FileLoggingPath = "logs/exemple";
    options.AddDateToFileFormat = true;
});
```

Available options:

- `EnableConsoleLogging` (bool?): enables/disables console logging (default `true`)
- `EnableFileLogging` (bool?): enables/disables file logging (default `false`)
- `FileLoggingPath` (string?): log file path (for example `logs/exemple`)
- `AddDateToFileFormat` (bool?): enables/diasble date at the end of the file (for example `logs/exemple260311.log`)

## Usage

Inject the logger:

```csharp
using FastLog.Logging;

public class App
{
	private readonly IFastLog _fastLog;

	public App(IFastLog fastLog)
	{
		_fastLog = fastLog;
	}

	public void Run()
	{
		_fastLog.LogTrace("Application started");
		_fastLog.LogError("This is a sample error log");
	}
}
```

## Log Format

Each line is written using this format:

```text
[yyyy-MM-dd HH:mm:ss] [LogType] message
```

Example:

```text
[2026-03-10 14:30:12] [Trace] Application started
```

## Log To A File

To write logs to a file, you must:

1. set `EnableFileLogging = true`
2. set `FileLoggingPath`

Valid example:

```csharp
services.AddFastLog(options =>
{
	options.EnableConsoleLogging = true;
	options.EnableFileLogging = true;
	options.FileLoggingPath = "logs/exemple";
});
```

The directory is created automatically if needed.

## Run The Example

From the solution root:

```bash
dotnet run --project Exemple/Exemple.csproj
```

The file will be created here:

```text
Exemple/logs/fastlog.log
```

## Quick Structure

- `FastLog/Logging/FastLog.cs`: logger implementation
- `FastLog/Logging/IFastLog.cs`: logger contract
- `FastLog/Model/FastLogOption.cs`: configuration options
- `FastLog/DI/ServiceCollectionExtension.cs`: `AddFastLog` extension
- `Exemple/Program.cs`: usage example