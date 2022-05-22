using CovidService.Domain.Models;

namespace CovidService.Application.Dtos
{
    public class CovidDto
    {
        public Guid Id { get; set; }
        public string Country { get; set; }
        public int Cases { get; set; }
        public int Confirmed { get; set; }
        public int Deaths { get; set; }
        public int Recovered { get; set; }
        public DateTime Updated_at { get; set; }
    }

    public static class CovidConvertExtenssions
    {
        public static Covid ToModel(this CovidDto dto)
        {
            return new Covid(country: dto.Country,
                             cases: dto.Cases,
                             confirmed: dto.Confirmed,
                             deaths: dto.Deaths,
                             recovered: dto.Recovered);
        }

        public static CovidDto ToDto(this Covid item)
        {
            return new CovidDto
            {
                Id = item.Id,
                Country = item.Country,
                Cases = item.Cases,
                Confirmed = item.Confirmed,
                Deaths = item.Deaths,
                Recovered = item.Recovered,
                Updated_at = item.Updated_at
            };
        }
    }
}
