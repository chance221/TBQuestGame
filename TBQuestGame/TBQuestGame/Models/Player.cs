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
            set { _experiencePoints = value; }
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

        #endregion

        #region CONSTRUCTORS

        #endregion

        #region METHODS

        public override string DefaultGreeting()
        {
            return $"Hello, my name is {_name} and I specialize in {_speciality}";
        }

        #endregion

        #region EVENTS

        #endregion
    }
}
