using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame.Models
{
    public class Locations
    {
        #region Enums
        

        





        #endregion




        #region Fields
        private int _id;
        private string _name;
        private string _description;
        private bool _accesible;
        private int _requiredXP;
        private int _modifyXP;
        private int _modifyHealth;
        private int _modifyLives;
        
        private bool _itemRequired;

        


        #endregion




        #region Properties

        public int ID
                {
                    get { return _id; }
                    set { _id = value; }
                }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public bool Accessable
        {
            get { return _accesible; }
            set { _accesible = value; }
        }

        public int RequiredXP
                {
                    get { return _requiredXP; }
                    set { _requiredXP = value; }
                }

        public int ModifyXP
        {
            get { return _modifyXP; }
            set { _modifyXP = value; }
        }

        public int ModifyHealath
                {
                    get { return _modifyHealth; }
                    set { _modifyHealth = value; }
                }

        public int ModifyLives
        {
            get { return _modifyLives; }
            set { _modifyLives = value; }
        }


        public bool ItemRequired
        {
            get { return _itemRequired; }
            set { _itemRequired = value; }
        }

        #endregion




        #region Constructors





        #endregion

    }
}
