using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_rpg.Dtos.Character;

namespace dotnet_rpg.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;
        public CharacterService(IMapper mapper)
        {
            this._mapper = mapper;
        }
        private static List<Character> characters = new List<Character>{
            new Character(),
            new Character{ Id = 1,Name = "John",Class = RpgClass.Healer}
        };
        

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto character)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            Character chara = _mapper.Map<Character>(character);
            chara.Id = characters.Max(c=>c.Id)+1;
            characters.Add(chara);
            serviceResponse.Data = characters.Select(c=> _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> Get(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            var character = characters.FirstOrDefault(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAll()
        {
           return new ServiceResponse<List<GetCharacterDto>>(){Data = characters.Select(c=> _mapper.Map<GetCharacterDto>(c)).ToList()};
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto character)
        {
           
            ServiceResponse<GetCharacterDto> response = new ServiceResponse<GetCharacterDto>();
            try{
            Character chara = characters.FirstOrDefault(c=> c.Id == character.Id); 
            _mapper.Map(character, chara);
            
            // chara.Name = character.Name;
            // chara.HitPoints = character.HitPoints;
            // chara.Stringth = character.Stringth;
            // chara.Defence = character.Defence;
            // chara.Intelligence = character.Intelligence;
            // chara.Class = character.Class;

            response.Data  = _mapper.Map<GetCharacterDto>(chara);
            }
            catch(Exception ex){
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            ServiceResponse<List<GetCharacterDto>> response = new ServiceResponse<List<GetCharacterDto>>();
            try{
            Character chara = characters.First(c=> c.Id == id); 
            characters.Remove(chara);   
            response.Data = characters.Select(c=> _mapper.Map<GetCharacterDto>(c)).ToList();
            }
            catch(Exception ex){
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
            
        }
    }
}