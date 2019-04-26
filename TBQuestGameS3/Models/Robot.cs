using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame.Models
{
    public class Robot : Character
    {
        #region FIELDS
        private double _power;
        private double _armor;
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
