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
    public class PokemonController : ControllerBase
    {
        private ILogger<PokemonController> Logger { get; }
        private IPokemonCreateService PokemonCreateService { get; }
        private IPokemonGetService PokemonGetService { get; }
        private IPokemonUpdateService PokemonUpdateService { get; }
        private IPokemonRemoveService PokemonRemoveService { get; }
        private IMapper Mapper { get; }

        public PokemonController(ILogger<PokemonController> logger, IPokemonCreateService pokemonCreateService, IPokemonGetService pokemonGetService, IPokemonUpdateService pokemonUpdateService, IPokemonRemoveService pokemonRemoveService, IMapper mapper)
        {
            Logger = logger;
            PokemonCreateService = pokemonCreateService;
            PokemonGetService = pokemonGetService;
            PokemonUpdateService = pokemonUpdateService;
            PokemonRemoveService = pokemonRemoveService;
            Mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<PokemonDTO>> GetAsync()
        {
            Logger.LogTrace($"{nameof(GetAsync)} called");

            return Mapper.Map<IEnumerable<PokemonDTO>>(await PokemonGetService.GetAsync());
        }

        [HttpGet]
        [Route("{pokemonId}")]
        public async Task<PokemonDTO> GetAsync(int pokemonId)
        {
            Logger.LogTrace($"{nameof(GetAsync)} called for {pokemonId}");

            return Mapper.Map<PokemonDTO>(await PokemonGetService.GetAsync(new PokemonIdentityModel(pokemonId)));
        }

        [HttpPut]
        [Route("")]
        public async Task<PokemonDTO> PutAsync(PokemonCreateDTO pokemon)
        {
            Logger.LogTrace($"{nameof(PutAsync)} called");

            return Mapper.Map<PokemonDTO>(
                await PokemonCreateService.InsertAsync(Mapper.Map<PokemonUpdateModel>(pokemon)));
        }
        
        [HttpPatch]
        [Route("")]
        public async Task<PokemonDTO> PatchAsync(PokemonUpdateDTO pokemon)
        {
            Logger.LogTrace($"{nameof(PatchAsync)} called");

            return Mapper.Map<PokemonDTO>(
                await PokemonUpdateService.UpdateAsync(Mapper.Map<PokemonUpdateModel>(pokemon)));
        }
        
        [HttpDelete]
        [Route("{pokemonId}")]
        public async Task<PokemonDTO> DeleteAsync(int pokemonId)
        {
            Logger.LogTrace($"{nameof(DeleteAsync)} called for {pokemonId}");

            return Mapper.Map<PokemonDTO>(await PokemonRemoveService.RemoveAsync(new PokemonIdentityModel(pokemonId)));
        }
    }
}