using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame.Models
{
    public class Character : ObservableObject
    {
        #region ENUMS

        
     
        #endregion

        #region FIELDS

        //protected allows the fields to be used in derived classes so not a bad idea if you want the children of the parent class to access the fields
        protected int _id;
        protected string _name;
        protected int _locationId;
        protected int _age;
        protected bool _isHuman;
        protected double _exp;
        protected Random randm = new Random();
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

        public double Exp
        {
            get { return _exp; }
            set { _exp = value; }
        }
        #endregion

        #region CONSTRUCTORS
        public Character()
        {

        }

        public Character(string Name, bool IsHuman, int LocationID, int Age, double Exp)
        {
            _name = Name;
            _isHuman = IsHuman;
            _locationId = LocationID;
            _age = Age;
            _exp = Exp;
        }

        public Character(int Id, string Name, int LocationId, int Age, bool isHuman, double Exp)
        {
            _id = Id;
            _name = Name;
            _locationId = LocationId;
            _age = Age;
            _isHuman = IsHuman;
            _exp = Exp;
            
        }
        #endregion

        #region METHODS
        // remember virtual means optional and abstract means it is absolutely required
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
