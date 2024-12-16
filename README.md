# GodelTech.Microservices.Business
GodelTech.Microservices.Business is a .NET library designed to initialize microservices for applications using [GodelTech.Business](https://github.com/GodelTech/GodelTech.Business). It provides a straightforward way to set up and configure services within your microservices architecture.

```c#
yield return new BusinessInitializer<Startup>()
    .WithService<IBankService, BankService, BankDto, IBankAddDto, IBankEditDto, Guid>();
```

# License
This project is licensed under the MIT License. See the LICENSE file for more details.