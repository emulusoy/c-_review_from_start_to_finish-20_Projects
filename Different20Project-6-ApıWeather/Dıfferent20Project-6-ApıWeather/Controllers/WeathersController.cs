using Dıfferent20Project_6_ApıWeather.Context;
using Dıfferent20Project_6_ApıWeather.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dıfferent20Project_6_ApıWeather.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeathersController : ControllerBase
    {

        WeatherContext context=new WeatherContext();

        [HttpGet]
        public IActionResult WeatherCityList()
        {
            var values =context.Cities.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateWeatherCity(City city)
        {
            context.Cities.Add(city);
            context.SaveChanges();
            return Ok("City Added");
        }
        [HttpDelete]
        public IActionResult DeleteWeatherCity(int id)
        {
            var value = context.Cities.Find(id);
            context.Cities.Remove(value);
            context.SaveChanges();
            return Ok("City Deleted!");
        }
        [HttpPut]
        public IActionResult PutWeatherCity(City city) 
        {
            var value = context.Cities.Find(city.CityId);
            value.CityName = city.CityName;
            value.CountryName = city.CountryName;
            value.Temp=city.Temp;
            value.Detail = city.Detail;
            context.SaveChanges();
            return Ok("City Updated!");
        }
        [HttpGet("GetByIdWeatherCity")]
        public IActionResult GetByIdWeatherCity(int id) 
        {
            var values = context.Cities.Find(id);
            return Ok(values);
        }
        [HttpGet("TotalCityCount")]
        public IActionResult TotalCityCount()
        {
            return Ok(context.Cities.Count());
        }

        [HttpGet("MaxTemp")]
            public IActionResult MaxTemp() 
        {
            return Ok(context.Cities.OrderBy(x => x.Temp).Max(y=>y.Temp +" "+ y.CityName));
        }
        [HttpGet("MinTemp")]
        public IActionResult MinTemp()
        {
            return Ok(context.Cities.OrderBy(x => x.Temp).Min(y => y.Temp + " " + y.CityName));
        }
        //
    }
}
