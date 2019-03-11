using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame.Models
{
    public class Character
    {
        #region ENUMS

        
     
        #endregion

        #region FIELDS
        protected int _id;
        protected string _name;
        protected int _locationId;
        protected int _age;
        protected bool _isHuman;
        


        #endregion

        #region PROPERTIES
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int LocationID
        {
            get { return _locationId; }
            set { _locationId = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public bool IsHuman
        {
            get { return _isHuman; }
            set { _isHuman = value; }
        }

        #endregion

        #region CONSTRUCTORS
        public Character()
        {

        }

        public Character(string Name, bool IsHuman, int LocationID)
        {
            _name = Name;
            _isHuman = IsHuman;
            _locationId = LocationID;
        }
        #endregion

        #region METHODS

        public virtual string DefaultGreeting()
        {
            string humanAnswer = ((_isHuman == true) ? "I am human." : "I am a robot.");
            return $"Hello, my name is {_name} and {humanAnswer}";
        }

        

        #endregion

        #region EVENTS

        #endregion
    }
}
