using GodelTech.Data.EntityFrameworkCore;

namespace GodelTech.Microservices.Business.Demo.Data.Entities
{
    public class CurrencyEntity : EntityNoneDatabaseGeneratedIdentifier<int>
    {
        public string AlphabeticCode { get; set; }
    }
}
