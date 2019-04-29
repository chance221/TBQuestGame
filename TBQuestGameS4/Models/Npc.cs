using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame.Models
{
    public abstract class Npc : Character
    {
        public string Description { get; set; }
        public string Information
        {
            get
            {
                return InformationText();
            }
            set
            {

            }

        }
        #region CONSTRUCTORS
        public Npc()
        {

        }

        public Npc(int id, string name, int locationId, int age, bool isHuman, double exp, string description)
            : base(id, name, locationId, age, isHuman, exp)
        {
            Id = id;
            Name = name;
            LocationID = locationId;
            Age = age;
            IsHuman = isHuman;
            Description = description;
        }

        protected Npc(int id, string name, bool isHuman, string description)
        {
            Id = id;
            Name = name;
            IsHuman = isHuman;
            Description = description;
        }
        #endregion
        protected abstract string InformationText();
    }
}
