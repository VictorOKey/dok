using System;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;

namespace serviceone.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    private HttpClient _client;

    public HomeController()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri(Environment.GetEnvironmentVariable("URI_ENV") ?? string.Empty);
        _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
    }

    [HttpGet("test")]
    public IActionResult Test()
    {
        return Ok("Single works!");
    }
    
    
    [HttpGet("network")]
    public IActionResult NetworkRequest()
    {
        var response = _client.GetAsync("WeatherForecast").Result;
        return Ok(response.Content.ReadAsStringAsync().Result);
    }
}

