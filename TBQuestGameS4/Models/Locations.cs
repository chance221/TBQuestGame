using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace TBQuestGame.Models
{
    public class Location
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
        private int _requiredRelicId;
        private ObservableCollection<GameItemQuantity> _gameItems;
        private ObservableCollection<Npc> _npcs;

        public ObservableCollection<Npc> Npcs
        {
            get { return _npcs; }
            set { _npcs = value; }
        }





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

        public int RequiredRelicId
        {
            get { return _requiredRelicId; }
            set { _requiredRelicId = value; }
        }
        #endregion

        public ObservableCollection<GameItemQuantity> GameItems
        {
            get { return _gameItems; }
            set { _gameItems = value; }
        }

        #region Constructors

         public Location()
        {
            _gameItems = new ObservableCollection<GameItemQuantity>();
        }

        
        //need to see if I need to add a list or an observable collection of game items
        


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
        


        public void UpdateLocationGameItems()
        {
            ObservableCollection<GameItemQuantity> updatedLocationGameItems = new ObservableCollection<GameItemQuantity>();

            foreach (GameItemQuantity gameItemQuantity in _gameItems)
            {
                updatedLocationGameItems.Add(gameItemQuantity);
            }

            GameItems.Clear();

            foreach (GameItemQuantity gameItemQuantity in updatedLocationGameItems)
            {
                GameItems.Add(gameItemQuantity);
            }
        }

        ///<summary>
        ///add selected item to location or update quantity if already in location
        /// </summary>
        /// <param name="selectedGameItemQuantity">selected item</param>
        public void AddGameItemQuantityToLocation(GameItemQuantity selectedGameItemQuantity)
        {
            //locate selected item in location
            /////////////////////////////////////

            GameItemQuantity gameItemQuantity = _gameItems.FirstOrDefault(i => i.GameItem.Id == selectedGameItemQuantity.GameItem.Id);
            if (gameItemQuantity == null)
            {
                GameItemQuantity newGameItemQuantity = new GameItemQuantity();
                newGameItemQuantity.GameItem = selectedGameItemQuantity.GameItem;
                newGameItemQuantity.Quantity = 1;

                _gameItems.Add(newGameItemQuantity);
            }
            else
            {
                gameItemQuantity.Quantity++;
            }

            UpdateLocationGameItems();
        }

        ///<summary>
        ///remoce selected item from location or update quantity
        /// </summary>
        /// <param name="selectedGameItemQuantity">selected item</param>
        public void RemoveGameItemQuantityFromLocation(GameItemQuantity selectedGameItemQuantity)
        {
            //locate sleected item in location
            /////////////////////////////////////
            ///
            GameItemQuantity gameItemQuantity = _gameItems.FirstOrDefault(i => i.GameItem.Id == selectedGameItemQuantity.GameItem.Id);

            if (gameItemQuantity != null)
            {
                if (selectedGameItemQuantity.Quantity == 1)
                {
                    _gameItems.Remove(gameItemQuantity);
                }
                else
                {
                    gameItemQuantity.Quantity--;
                }
            }

            UpdateLocationGameItems();

        }

        
    }
}
#endregion