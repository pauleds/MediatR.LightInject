[![NuGet](https://img.shields.io/nuget/v/Ardalis.GuardClauses.svg)](https://www.nuget.org/packages/Ardalis.GuardClauses)[![NuGet](https://img.shields.io/nuget/dt/Ardalis.GuardClauses.svg)](https://www.nuget.org/packages/Ardalis.GuardClauses)
![publish Ardalis.GuardClauses to nuget](https://github.com/ardalis/GuardClauses/workflows/publish%20Ardalis.GuardClauses%20to%20nuget/badge.svg)

# MediatR.LightInject
Provides MediatR extensions for the LightInject IoC Container. Compatible with Umbraco 8 CMS.

It's basically a simple LightInject port of [MediatR extensions for Microsoft.Extensions.DependencyInjection](https://github.com/jbogard/MediatR.Extensions.Microsoft.DependencyInjection).

:star: Please give this project a star if you like or are using it. Thanks!

## Usage

```c#
	// LightInject
	var container = new LightInject.ServiceContainer();

	// Umbraco 8
	var container = composition.Concrete as LightInject.ServiceContainer;

	...

	container.AddMediatR();

    // OR
	
	container.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
```

## References

- [MediatR](https://github.com/jbogard/MediatR)
- [LightInject](https://github.com/seesharper/lightinject/)
- [MediatR extensions for Microsoft.Extensions.DependencyInjection](https://github.com/jbogard/MediatR.Extensions.Microsoft.DependencyInjection)

## Build Notes

- Remember to update the PackageVersion in the csproj file and then a build on master should automatically publish the new package to nuget.org.
- Add a release with form `1.3.2` to GitHub Releases in order for the package to actually be published to Nuget. Otherwise it will claim to have been successful but won't have been.

