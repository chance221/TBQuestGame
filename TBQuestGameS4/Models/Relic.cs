using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame.Models
{
    public class Relic : GameItem
    {
        public enum UseActionType
        {
            OpenLocation,
            UpgradePlayer
        }

        public UseActionType UseAction { get; set; }

        public Relic(int id, string name, double value, string description, double xp, string useMessage, UseActionType useAction)
            : base(id, name, value, description, xp, useMessage)
        {
            UseAction = useAction;
        }

        public Relic Clone(int id, string name, double value, string description, double xp, string useMessage, UseActionType useAction)
        {
            return new Relic(Id, Name, Value, Description, XP, UseMessage, UseAction);
        }


    }
}
