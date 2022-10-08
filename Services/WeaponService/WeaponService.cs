using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_rpg.Data;
using dotnet_rpg.Dtos.Character;
using dotnet_rpg.Dtos.Weapon;
using Microsoft.EntityFrameworkCore;

namespace dotnet_rpg.Services.WeaponService
{
    public class WeaponService : IWeaponService
    {
        private readonly DataContext _db;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;

        public WeaponService(DataContext db, IHttpContextAccessor contextAccessor, IMapper mapper)
        {
            _db = db;
            _contextAccessor = contextAccessor;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto newWeapon)
        {
            ServiceResponse<GetCharacterDto> response = new ServiceResponse<GetCharacterDto>();
            try
            {
                Character character = await _db.Characters
                    .FirstOrDefaultAsync(c => c.Id == newWeapon.CharacterId &&
                    c.User.Id == int.Parse(_contextAccessor.HttpContext.User
                    .FindFirstValue(ClaimTypes.NameIdentifier)));

                if (character == null)
                {
                    response.Success = false;
                    response.Message = "Character not found";
                }
                Weapon weapon = new Weapon
                {
                    WeaponName = newWeapon.WeaponName,
                    Damage = newWeapon.Damage,
                    CharacterId = newWeapon.CharacterId
                };
                _db.Weapons.Add(weapon);
                await _db.SaveChangesAsync();
                response.Data = _mapper.Map<GetCharacterDto>(character);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}