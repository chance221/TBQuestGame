using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame.Models
{
    public class Weapon : GameItem
    {
        public double MinimumDamage { get; set; }
        public double MaximumDamage { get; set; }

        public Weapon (int id, string name, double value, double minDamage, double maxDamage, string description, double xp)
            :base (id, name, value, description, xp)
        {
            MinimumDamage = minDamage;
            MaximumDamage = maxDamage;
        }

        public Weapon Clone(int id, string name, double value, double minDamage, double maxDamage, string description, double xp)
        {
            return new Weapon(Id, Name, Value, MinimumDamage, MaximumDamage, Description, XP);
        }
    }
}
