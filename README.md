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

	container.AddMediatR(typeof(MyHandler));

    // OR
	
	container.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
```

## References

- [MediatR](https://github.com/jbogard/MediatR)
- [LightInject](https://github.com/seesharper/lightinject/)
- [MediatR extensions for Microsoft.Extensions.DependencyInjection](https://github.com/jbogard/MediatR.Extensions.Microsoft.DependencyInjection)
