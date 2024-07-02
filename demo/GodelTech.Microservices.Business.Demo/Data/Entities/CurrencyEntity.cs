using GodelTech.Data;

namespace GodelTech.Microservices.Business.Demo.Data.Entities
{
    public class CurrencyEntity : Entity<int>
    {
        public string AlphabeticCode { get; set; }
    }
}
