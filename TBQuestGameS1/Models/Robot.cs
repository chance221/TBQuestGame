using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame.Models
{
    public class Robot
    {
        #region FIELDS
        private double _power;
        private double _armor;
        private string _name;
        private bool _isHuman;
        private bool _canTranslate;

        


        #endregion


        #region PROPERTIES

        public double Power
                {
                    get { return _power; }
                    set { _power = value; }
                }


        public double Armor
                {
                    get { return _armor; }
                    set { _armor = value; }
                }


        public string Name
                {
                    get { return _name; }
                    set { _name = value; }
                }

        public bool IsHuman
                {
                    get { return _isHuman; }
                    set { _isHuman = value; }
                }

        public bool CanTranslate
                {
                    get { return _canTranslate; }
                    set { _canTranslate = value; }
                }

        #endregion


        #region CONSTRUCTORS

        public Robot()
        {

        }

        #endregion


        #region METHODS



        #endregion


    }
}
