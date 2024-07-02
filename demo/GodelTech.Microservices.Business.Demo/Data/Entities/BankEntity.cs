using System;
using GodelTech.Data;

namespace GodelTech.Microservices.Business.Demo.Data.Entities
{
    public class BankEntity : Entity<Guid>
    {
        public string Name { get; set; }
    }
}
