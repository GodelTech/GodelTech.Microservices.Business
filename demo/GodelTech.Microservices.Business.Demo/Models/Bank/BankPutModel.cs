using System;
using GodelTech.Microservices.Business.Demo.Business.Contracts;

namespace GodelTech.Microservices.Business.Demo.Models.Bank
{
    public class BankPutModel : IBankEditDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
