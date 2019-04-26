using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame.Models
{
    public class Citizen :Npc, ISpeak
    {
        public List <string> Messages { get; set; }

        protected override string InformationText()
        {
            return $"{Name} - {Description}";
        }

        public Citizen()
        {

        }

        public Citizen(int id, string name, bool isHuman, string description, List<string> messages)
            : base(id, name, isHuman, description)
        {
            Messages = messages;
        }

        ///<summary>
        ///Generate message or use default message
        /// </summary>
        public string Speak()
        {
            if (this.Messages != null)
            {
                return GetMessage();
            }
            else
            {
                return "";
            }
        }


        /// <summary>
        /// randomly select a message from a lisst of messages
        /// </summary>
        /// <returns> message text </returns>
        private string GetMessage()
        {
            Random r = new Random();
            int messageIndex = r.Next(0, Messages.Count());
            return Messages[messageIndex];
        }
    }
}
