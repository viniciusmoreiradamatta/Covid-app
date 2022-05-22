using CovidService.Domain.Validations;
using FluentValidation.Results;

namespace CovidService.Domain.Models
{
    public class Covid
    {
        protected Covid()
        {
        }

        public Covid(string country, int cases, int confirmed, int deaths, int recovered)
        {
            this.Country = country;
            this.Cases = cases;
            this.Confirmed = confirmed;
            this.Deaths = deaths;
            this.Recovered = recovered;
            this.Id = Guid.NewGuid();
            this.Updated_at = DateTime.Now;

            this.Validar();
        }

        public Guid Id { get; private set; }
        public string Country { get; private set; }
        public int Cases { get; private set; }
        public int Confirmed { get; private set; }
        public int Deaths { get; private set; }
        public int Recovered { get; private set; }
        public DateTime Updated_at { get; private set; }
        
        public bool Valid { get; private set; }
        public ValidationResult ValidationResult { get; private set; }

        protected void Validar()
        {
            CovidValidations validator = new();

            ValidationResult ??= new ValidationResult();
            ValidationResult = validator.Validate(this);

            Valid = ValidationResult.IsValid;
        }
    }
}
