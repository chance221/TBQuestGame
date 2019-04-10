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
        
        public enum Toxicity
        {
            Clean,
            Unclean,
            Toxic
        }
        


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
        private string _message;


        private Toxicity _toxicity;

        


        




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

        public bool Accessible
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

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        public Toxicity ToxicLevel
        {
            get { return _toxicity; }
            set { _toxicity = value; }
        }
        #endregion


        #region Constructors





        #endregion

        #region Methods
        //translates object data to be easily displayed
        public override string ToString()
        {
            return _name;
        }

        public bool IsAccessibleByExperiencePoints (int playerExperiencePoints)
        {
            return playerExperiencePoints >= _requiredXP ? true : false;
        }
        #endregion

    }
}
