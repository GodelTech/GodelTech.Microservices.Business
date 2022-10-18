# GodelTech.Microservices.Business
Microservice initializer for [GodelTech.Business](https://github.com/GodelTech/GodelTech.Business)

```c#
yield return new BusinessInitializer<Startup>()
    .WithService<IBankService, BankService, BankDto, IBankAddDto, IBankEditDto, Guid>();
```
