using GodelTech.Microservices.Business.Demo.Business.Contracts;

namespace GodelTech.Microservices.Business.Demo.Models.Bank
{
    public class BankPostModel : IBankAddDto
    {
        public string Name { get; set; }
    }
}
