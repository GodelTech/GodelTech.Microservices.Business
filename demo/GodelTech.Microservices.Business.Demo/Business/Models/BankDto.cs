using System;
using GodelTech.Business;

namespace GodelTech.Microservices.Business.Demo.Business.Models
{
    public class BankDto : Dto<Guid>
    {
        public string Name { get; set; }
    }
}
