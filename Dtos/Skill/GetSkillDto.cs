using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpg.Dtos.Skill
{
    public class GetSkillDto
    {
        public string SkillName { get; set; } = string.Empty;
        public int Damage { get; set; }

    }
}