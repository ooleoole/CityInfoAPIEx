using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [Route("api/cities")]
    public class PointsOfInterestController : Controller
    {
        [HttpGet("{cityId}/pointsOfInterest")]
        public IActionResult GetPointsOfInterest(int cityId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            return city == null ? (IActionResult)NotFound() : Ok(city.PointsOfInterest);
        }
        [HttpGet("{cityId}/pointsOfInterest/{id}")]
        public IActionResult GetPointOfInterest(int cityId, int id)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city is null) return NotFound();
            var pointOfInterest = CitiesDataStore.Current.Cities.Where(c => c.Id == cityId).SelectMany(c => c.PointsOfInterest)
                .FirstOrDefault(p => p.Id == id);
            return pointOfInterest == null ? (IActionResult)NotFound() : Ok(pointOfInterest);
        }
    }
}
