using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame.Models
{
    public class Treasure : GameItem
    {
        #region ENUMS

        public enum TreasureType
        {
            Coin,
            PreciousMetal, 
            UpgradeSpecs,
        }

        #endregion

        #region PROPERTIES

        public TreasureType Type { get; set; }

        #endregion

        #region CONSTRUCTORS

        public Treasure(int id, string name, double value, TreasureType type, string description, double xp)
            :base(id, name, value, description, xp)
        {
            Type = type;
        }

        #endregion

        #region METHODS

        public Treasure Clone(int id, string name, double value, TreasureType type, string description, double xp)
        {
            return new Treasure(Id, Name, Value, Type, Description, XP);
        }

        

        #endregion

    }
}
