using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpg.Dtos.Character
{
    public class AddCharacterSkillDto
    {
        public int CharactersId { get; set; }
        public int SkillsId { get; set; }
    }
}