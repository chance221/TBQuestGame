using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame.Models
{
    public class GameItem
    {
        #region FIELDS


        #endregion
        
        #region PROPERTIES

        public int Id { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public string Description { get; set; }
        public double XP { get; set; }
        public string UseMessage { get; set; }
        
        #endregion


        #region CONSTRUCTORS
        public GameItem(int id, string name, double value, string description, double xp, string useMessage = "")
        {
            Id = id;
            Name = name;
            Value = value;
            Description = description;
            XP = xp;
            UseMessage = useMessage;

        }
        
        #endregion

        #region METHODS
        


        public GameItem Clone()
        {
            return new GameItem(Id, Name, Value, Description, XP, UseMessage);
        }

        #endregion


        #region EVENTS

        #endregion
    }
}
