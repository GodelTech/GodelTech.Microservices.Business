using System;

namespace GodelTech.Microservices.Business.Demo.Business.Contracts
{
    public interface IBankEditDto
    {
        Guid Id { get; }

        string Name { get; }
    }
}
