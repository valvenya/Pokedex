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
    public class MoveController : ControllerBase
    {
        private ILogger<MoveController> Logger { get; }
        private IMoveCreateService MoveCreateService { get; }
        private IMoveGetService MoveGetService { get; }
        private IMoveUpdateService MoveUpdateService { get; }
        private IMapper Mapper { get; }

        public MoveController(ILogger<MoveController> logger, IMoveCreateService moveCreateService, IMoveGetService moveGetService, IMoveUpdateService moveUpdateService, IMapper mapper)
        {
            Logger = logger;
            MoveCreateService = moveCreateService;
            MoveGetService = moveGetService;
            MoveUpdateService = moveUpdateService;
            Mapper = mapper;
        }
        
        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<MoveDTO>> GetAsync()
        {
            Logger.LogTrace($"{nameof(GetAsync)} called");

            return Mapper.Map<IEnumerable<MoveDTO>>(await MoveGetService.GetAsync());
        }
        
        [HttpGet]
        [Route("{moveId}")]
        public async Task<MoveDTO> GetAsync(int moveId)
        {
            Logger.LogTrace($"{nameof(GetAsync)} called for {moveId}");

            return Mapper.Map<MoveDTO>(await MoveGetService.GetAsync(new MoveIdentityModel(moveId)));
        }
        
        [HttpPut]
        [Route("")]
        public async Task<MoveDTO> PutAsync(MoveCreateDTO move)
        {
            Logger.LogTrace($"{nameof(PutAsync)} called");

            return Mapper.Map<MoveDTO>(
                await MoveCreateService.InsertAsync(Mapper.Map<MoveUpdateModel>(move)));
        }
        
        [HttpPatch]
        [Route("")]
        public async Task<MoveDTO> PatchAsync(MoveUpdateDTO move)
        {
            Logger.LogTrace($"{nameof(PatchAsync)} called");

            return Mapper.Map<MoveDTO>(
                await MoveUpdateService.UpdateAsync(Mapper.Map<MoveUpdateModel>(move)));
        }
        
    }
}