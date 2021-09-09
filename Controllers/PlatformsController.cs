using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlateformService.DataAccess;
using PlateformService.Dtos;
using PlateformService.Models;

namespace PlateformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepo _repositary;
        private readonly IMapper _mapper;

        public PlatformsController(IPlatformRepo repositary, IMapper mapper)
        {
            _repositary = repositary;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
        {
            System.Console.WriteLine("Getting Platforms..............");
            var platformItem =  _repositary.GetAllPlatforms();
            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItem));
        }
        [HttpGet("{id}" , Name= "GetPlatformById")]
        public ActionResult<PlatformReadDto> GetPlatformById(int id )
        {
            System.Console.WriteLine("Getting Platforms by condidering id..............");
            var platformItem =  _repositary.GetPlatformById(id);
            if (platformItem != null)
            {
                return Ok(_mapper.Map<PlatformReadDto>(platformItem));
            }
            return NotFound();
        }
        [HttpPost]
        public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreateDto platformCreateDto)
        {
            System.Console.WriteLine("Getting Platforms..............");
            var platformItem =  _mapper.Map<Platform>(platformCreateDto);
            _repositary.CreatePlatform(platformItem);
            _repositary.SaveChanges();

             var platformReadDto =  _mapper.Map<PlatformReadDto>(platformItem);
            return CreatedAtRoute(nameof(GetPlatformById), new {Id =platformReadDto.Id},platformReadDto);
        }
    }
}