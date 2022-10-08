using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpg.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string SkillName { get; set; } = string.Empty;
        public int Damage { get; set; }
        public List<Character> Characters { get; set; }
    }
}