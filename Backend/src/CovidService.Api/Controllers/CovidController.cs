using CovidService.Application.Dtos;
using CovidService.Application.Interfaces;
using CovidService.Domain.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CovidService.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CovidController : ControllerBase
{
    private readonly ICovidAppService _covidAppService;
    private readonly ILogger<CovidController> _logger;

    public CovidController(ICovidAppService covidAppService, ILogger<CovidController> logger)
    {
        _covidAppService = covidAppService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _covidAppService.Get());

    [HttpPost]
    public async Task<IActionResult> Post(CovidDto dto)
    {
        var result = await _covidAppService.Add(dto);

        return Ok(result);
    }
}
