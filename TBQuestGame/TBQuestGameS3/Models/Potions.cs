using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame.Models
{
    public class Potions : GameItem
    {
        public int HealthChange { get; set; }
        public int LivesChange { get; set; }

        public Potions(int id, string name, double value, int healthChange, int livesChange, string description, double xp)
            :base(id, name, value, description, xp)
        {
            HealthChange = healthChange;
            LivesChange = livesChange;
        }

        public Potions Clone(int id, string name, double value, int healthChange, int livesChange, string description, double xp)
        {
            return new Potions(Id, Name, Value, HealthChange, LivesChange, Description, XP);
        }

    }
}
