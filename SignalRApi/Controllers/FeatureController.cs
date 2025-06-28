using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.FeatureDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;

        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
        }
        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            var values = _featureService.TGetAllList();
            return Ok(values);
        }
        [HttpGet("[action]")]
        public IActionResult GetById(int Id)
        {
            var value = _featureService.TGetById(Id);
            return Ok(value);
        }
        [HttpPost("[action]")]
        public IActionResult Add(CreateFeatureDto createFeatureDto)
        {
            Feature feature = new Feature
            {
                Title1 = createFeatureDto.Title1,
                Despcription1 = createFeatureDto.Despcription1,
                Title2 = createFeatureDto.Title2,
                Despcription2 = createFeatureDto.Despcription2,
                Title3 = createFeatureDto.Title3,
                Despcription3 = createFeatureDto.Despcription3
            };
            _featureService.TAdd(feature);
            return Ok("Feature Added Succesfuly");
        }
        [HttpPut("[action]")]
        public IActionResult Update(UpdateFeatureDto updateFeatureDto)
        {
            Feature feature = new Feature
            {
                FeatureId = updateFeatureDto.FeatureId,
                Title1 = updateFeatureDto.Title1,
                Despcription1 = updateFeatureDto.Despcription1,
                Title2 = updateFeatureDto.Title2,
                Despcription2 = updateFeatureDto.Despcription2,
                Title3 = updateFeatureDto.Title3,
                Despcription3 = updateFeatureDto.Despcription3
            };
            _featureService.TUpdate(feature);
            return Ok("Feature Updated Succesfuly");
        }

        [HttpDelete("[action]")]
        public IActionResult Delete(int Id)
        {
            var value = _featureService.TGetById(Id);
            _featureService.TDelete(value);
            return Ok("Feature Deleted Succesfuly");

        }
    }
}
