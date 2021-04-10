using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pokedex.BLL.Contracts;
using Pokedex.Client.DTO.Read;
using Pokedex.Client.Requests.Create;
using Pokedex.Client.Requests.Update;
using Pokedex.Domain.Models;

namespace Pokedex.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpeciesController : ControllerBase
    {
        private ILogger<SpeciesController> Logger { get; }
        private ISpeciesCreateService SpeciesCreateService { get; }
        private ISpeciesGetService SpeciesGetService { get; }
        private ISpeciesUpdateService SpeciesUpdateService { get; }
        private IMapper Mapper { get; }

        public SpeciesController(ILogger<SpeciesController> logger, ISpeciesCreateService speciesCreateService, ISpeciesGetService speciesGetService, ISpeciesUpdateService speciesUpdateService, IMapper mapper)
        {
            Logger = logger;
            SpeciesCreateService = speciesCreateService;
            SpeciesGetService = speciesGetService;
            SpeciesUpdateService = speciesUpdateService;
            Mapper = mapper;
        }
        
        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<SpeciesDTO>> GetAsync()
        {
            Logger.LogTrace($"{nameof(GetAsync)} called");

            return Mapper.Map<IEnumerable<SpeciesDTO>>(await SpeciesGetService.GetAsync());
        }
        
        [HttpGet]
        [Route("{speciesId}")]
        public async Task<SpeciesDTO> GetAsync(int speciesId)
        {
            Logger.LogTrace($"{nameof(GetAsync)} called for {speciesId}");

            return Mapper.Map<SpeciesDTO>(await SpeciesGetService.GetAsync(new SpeciesIdentityModel(speciesId)));
        }
        
        [HttpPut]
        [Route("")]
        public async Task<SpeciesDTO> PutAsync(SpeciesCreateDTO species)
        {
            Logger.LogTrace($"{nameof(PutAsync)} called");

            return Mapper.Map<SpeciesDTO>(
                await SpeciesCreateService.InsertAsync(Mapper.Map<SpeciesUpdateModel>(species)));
        }
        
        [HttpPatch]
        [Route("")]
        public async Task<SpeciesDTO> PatchAsync(SpeciesUpdateDTO species)
        {
            Logger.LogTrace($"{nameof(PatchAsync)} called");

            return Mapper.Map<SpeciesDTO>(
                await SpeciesUpdateService.UpdateAsync(Mapper.Map<SpeciesUpdateModel>(species)));
        }
    }
}