using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame.Models
{
    public class Player : Character 
    {
        #region ENUMS

        public enum Speciality { Cyberkinetics, Exosuits}
        public enum Gender { Male, Female}

        #endregion

        #region FIELDS

        private int _lives;
        private double _health;
        private double _experiencePoints;
        private Speciality _speciality;
        private Gender _gender;
        private List<Locations> _locationsVisited;

        #endregion

        #region PROPERTIES

        public int Lives
        {
            get { return _lives; }
            set { _lives = value; }
        }

        public double Health
        {
            get { return _health; }
            set { _health = value; }
        }

        public double ExperiencePoints
        {
            get { return _experiencePoints; }
            set
            {
                _experiencePoints = value;
                OnPropertyChanged(nameof(ExperiencePoints));
            }
        }

        public Speciality PlayerSpeciality
        {
            get { return _speciality; }
            set { _speciality = value; }
        }

        public Gender Sex
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public List<Locations> LocationsVisited
        {
            get { return _locationsVisited;  }
            set { _locationsVisited = value; }
        }
        #endregion

        #region CONSTRUCTORS
        public Player()
        {
            _locationsVisited = new List<Locations>();
        }
        #endregion

        #region METHODS

        public bool HasVisited(Locations location)
        {
            return _locationsVisited.Contains(location);
        }



        public override string DefaultGreeting()
        {
            return $"Hello, my name is {_name} and I specialize in {_speciality}";
        }

        #endregion

        #region EVENTS

        #endregion
    }
}
