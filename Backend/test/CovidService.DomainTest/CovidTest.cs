using CovidService.Domain.Models;

namespace CovidService.DomainTest;

public class CovidTest
{
    [Theory]
    [InlineData("Brasil", 1000, 990, 500, 490)]
    [InlineData("Chile", 10000, 9000, 4500, 4000)]
    [InlineData("Uruguai", 5550, 5550, 2215, 3300)]
    public void Criar_Entidade_Sucesso(string Country, int Cases, int Confirmed, int Deaths, int Recovered)
    {
        Covid covid = new(country: Country,
                             cases: Cases,
                             confirmed: Confirmed,
                             deaths: Deaths,
                             recovered: Recovered);

        Assert.True(covid.Valid);
    }

    [Theory]
    [InlineData("", 1000, 990, 500, 490)]
    [InlineData("Chile", 0, 9000, 4500, 4000)]
    [InlineData("Uruguai", 5550, 0, 2215, 3300)]
    public void Criar_Entidade_Falha(string Country, int Cases, int Confirmed, int Deaths, int Recovered)
    {
        Covid covid = new(country: Country,
                             cases: Cases,
                             confirmed: Confirmed,
                             deaths: Deaths,
                             recovered: Recovered);

        Assert.False(covid.Valid);
    }

    [Fact]
    public void Criar_Entidade_Country_Nao_Informado_Falha()
    {
        Covid covid = new(country: string.Empty,
                             cases: 1000,
                             confirmed: 990,
                             deaths: 500,
                             recovered: 490);

        Assert.False(covid.Valid);
        Assert.True(covid.ValidationResult.Errors.Any(c => c.ErrorMessage.Equals("Country deve ser informado")));
    }

    [Fact]
    public void Criar_Entidade_Country_Numero_Casos_Menor_Confirmados_Falha()
    {
        Covid covid = new(country: "Chile",
                             cases: 100,
                             confirmed: 990,
                             deaths: 50,
                             recovered: 49);

        Assert.False(covid.Valid);
        Assert.True(covid.ValidationResult.Errors.Any(c => c.ErrorMessage.Equals("Numero de casos confirmados nao deve ser maior que o numero de casos")));
    }

    [Fact]
    public void Criar_Entidade_Country_Numero_Casos_Menor_Mortes_Falha()
    {
        Covid covid = new(country: "Chile",
                             cases: 100,
                             confirmed: 90,
                             deaths: 500,
                             recovered: 49);

        Assert.False(covid.Valid);
        Assert.True(covid.ValidationResult.Errors.Any(c => c.ErrorMessage.Equals("Numero de mortes nao deve ser maior que o numero de casos")));
    }
    
    [Fact]
    public void Criar_Entidade_Country_Numero_Casos_Menor_Recuperados_Falha()
    {
        Covid covid = new(country: "Chile",
                             cases: 100,
                             confirmed: 90,
                             deaths: 50,
                             recovered: 490);

        Assert.False(covid.Valid);
        Assert.True(covid.ValidationResult.Errors.Any(c => c.ErrorMessage.Equals("Numero de casos recuperados nao deve ser maior que o numero de casos")));
    }


}