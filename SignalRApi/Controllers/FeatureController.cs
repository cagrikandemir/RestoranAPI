using AutoMapper;
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
        private readonly IMapper _mapper;

        public FeatureController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }
        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            return Ok(_mapper.Map<List<Feature>>(_featureService.TGetAllList()));
        }
        [HttpGet("[action]/{Id}")]
        public IActionResult GetById(int Id)
        {
            return Ok(_mapper.Map<Feature>(_featureService.TGetById(Id)));
        }
        [HttpPost("[action]")]
        public IActionResult Add(CreateFeatureDto createFeatureDto)
        {
            var feature = _mapper.Map<Feature>(createFeatureDto);
            _featureService.TAdd(feature);
            return Ok("Feature Added Succesfuly");
        }
        [HttpPut("[action]")]
        public IActionResult Update(UpdateFeatureDto updateFeatureDto)
        {
            var feature = _mapper.Map<Feature>(updateFeatureDto);

            _featureService.TUpdate(feature);
            return Ok("Feature Updated Succesfuly");
        }

        [HttpDelete("[action]/{Id}")]
        public IActionResult Delete(int Id)
        {
            var value = _featureService.TGetById(Id);
            _featureService.TDelete(value);
            return Ok("Feature Deleted Succesfuly");

        }
    }
}
