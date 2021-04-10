using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Pokedex.Client.DTO.Read;
using Pokedex.Client.Requests.Create;
using Pokedex.Client.Requests.Update;
using Pokedex.DataAccess.Entities;
using Pokedex.Domain.Models;

namespace Pokedex.WebAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Move, Domain.Move>();
            CreateMap<Pokemon, Domain.Pokemon>();
            CreateMap<Species, Domain.Species>();

            CreateMap<MoveUpdateModel, Move>();
            CreateMap<SpeciesUpdateModel, Species>();
               // .ForMember(dest => dest.MovePool, opt =>
               //     opt.MapFrom(s => s.MoveIds.Select(id => new Move() { Id = id})));
               CreateMap<PokemonUpdateModel, Pokemon>();
              //  .ForMember(dest => dest.Moves, opt =>
              //      opt.MapFrom(s => s.MoveIds.Select(id => new Move() { Id = id})));

            CreateMap<PokemonCreateDTO, PokemonUpdateModel>();
            CreateMap<PokemonUpdateDTO, PokemonUpdateModel>();
            CreateMap<SpeciesCreateDTO, SpeciesUpdateModel>();
            CreateMap<SpeciesUpdateDTO, SpeciesUpdateModel>();
            CreateMap<MoveCreateDTO, MoveUpdateModel>();
            CreateMap<MoveUpdateDTO, MoveUpdateModel>();

            CreateMap<Domain.Pokemon, PokemonDTO>();
            CreateMap<Domain.Species, SpeciesDTO>();
            CreateMap<Domain.Move, MoveDTO>();
        }
    }
}