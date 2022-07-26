using System;
using GodelTech.Business;
using GodelTech.Microservices.Business.Demo.Business.Models;

namespace GodelTech.Microservices.Business.Demo.Business.Contracts
{
    public interface IBankService : IBusinessService<BankDto, IBankAddDto, IBankEditDto, Guid>
    {

    }
}
