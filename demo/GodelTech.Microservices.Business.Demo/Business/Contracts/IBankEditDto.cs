using System;
using GodelTech.Business;

namespace GodelTech.Microservices.Business.Demo.Business.Contracts
{
    public interface IBankEditDto : IDto<Guid>
    {
        string Name { get; }
    }
}
