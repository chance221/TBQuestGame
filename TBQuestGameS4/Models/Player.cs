using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using TBQuestGame.DataLayer;

namespace TBQuestGame.Models
{
    public class Player : Character 
    {
        #region ENUMS

        public enum Speciality { Cyberkinetics, Exosuits}
        public enum Gender { Male, Female}
        public enum Armor { High, Medium, Low}

        #endregion

        private const int DEFENDER_DAMAGE_ADJUSTMENT = 10;
        private const int MAXIMUM_RETREAT_DAMAGE = 10;

        #region FIELDS

        private int _lives;
        private double _health;
        private double _experiencePoints;
        private Speciality _speciality;
        private Gender _gender;
        private List<Location> _locationsVisited;
        private string _specialName;
        private int _skillLevel;
        private BattleModeName _battleMode;
        private Armor _armor;
        private double _wealth;
        private Weapon _currentWeapon;
        private ObservableCollection<Location> _fastTravelLocations;
        private ObservableCollection<GameItemQuantity> _inventory;
        private ObservableCollection<GameItemQuantity> _potions;
        private ObservableCollection<GameItemQuantity> _relics;
        private ObservableCollection<GameItemQuantity> _weapons;
        private ObservableCollection<GameItemQuantity> _treasure;
        

        


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
            set
            { _health = value;
                if (_health > 100)
                {
                    _health = 100;
                }
                else if (_health <= 0)
                {
                    _health = 100;
                    _lives--;
                }

                OnPropertyChanged(nameof(Health));
            }
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

        public List<Location> LocationsVisited
        {
            get { return _locationsVisited;  }
            set { _locationsVisited = value; }
        }

        public string SpecialName
        {
            get { return _specialName; }
            set { _specialName = value; }
        }

        public Armor SpecialArmor
        {
            get { return _armor; }
            set
            {
                _armor = value;
                OnPropertyChanged(nameof(Armor));
            }
        }

        public double Wealth
        {
            get { return _wealth; }
            set
            {
                _wealth = value;
                OnPropertyChanged(nameof(Wealth));
            }
        }
        public BattleModeName BattleMode
        {
            get { return _battleMode; }
            set { _battleMode = value; }
        }

        public int SkillLevel
        {
            get { return _skillLevel; }
            set { _skillLevel = value; }
        }
        public Weapon CurrentWeapon
        {
            get { return _currentWeapon; }
            set { _currentWeapon = value; }
        }

        public ObservableCollection<Location> FastTravelLocations
        {
            get {
                foreach (Location locations in LocationsVisited)
                {
                    _fastTravelLocations.Add(locations);

                }
                 //_fastTravelLocations.Add() Need to get add initial game map location and set 
                return _fastTravelLocations;
            }

            set { _fastTravelLocations = value; }
        }


        public ObservableCollection<GameItemQuantity> Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }

        public ObservableCollection<GameItemQuantity> Potions
        {
            get { return _potions; }
            set { _potions = value; }
        }

        public ObservableCollection<GameItemQuantity> Relics
        {
            get { return _relics; }
            set { _relics = value; }
        }

        public ObservableCollection<GameItemQuantity> Weapons
        {
            get { return _weapons; }
            set { _weapons = value; }
        }

        public ObservableCollection<GameItemQuantity> Treasure
        {
            get { return _treasure; }
            set { _treasure = value; }
        }
        #endregion

        #region CONSTRUCTORS
        public Player()
        {
            _locationsVisited = new List<Location>();
            _fastTravelLocations = new ObservableCollection<Location>();
            _potions = new ObservableCollection<GameItemQuantity>();
            _relics = new ObservableCollection<GameItemQuantity>();
            _weapons = new ObservableCollection<GameItemQuantity>();
            _treasure = new ObservableCollection<GameItemQuantity>();

        }
        #endregion

        #region METHODS

        public void CalculateWealth()
        {
            Wealth = _inventory.Sum(i => i.GameItem.Value * i.Quantity);
        }

        public bool HasVisited(Location location)
        {
            return _locationsVisited.Contains(location);
        }

        public void UpdateInventoryCategories()
        {
            Potions.Clear();
            Weapons.Clear();
            Treasure.Clear();
            Relics.Clear();

            foreach (var gameItemQuantity in _inventory)
            {
                if (gameItemQuantity.GameItem is Potions) Potions.Add(gameItemQuantity);
                if (gameItemQuantity.GameItem is Weapon) Weapons.Add(gameItemQuantity);
                if (gameItemQuantity.GameItem is Treasure) Treasure.Add(gameItemQuantity);
                if (gameItemQuantity.GameItem is Relic) Relics.Add(gameItemQuantity);
            }

        }
        
        /// <summary>
        /// adds selected item to inventory by adding a new spot or adding the correct quantity to an existing one
        /// </summary> //////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///
        ///
     
        /// <param name="selectedGameItemQuantity"></param>
        public void AddGameItemQuantityToInventory(GameItemQuantity selectedGameItemQuantity)
        {
            //find the item if it is in the inventory
            //////////////////////////////////////////

            GameItemQuantity gameItemQuantity = _inventory.FirstOrDefault(i => i.GameItem.Id == selectedGameItemQuantity.GameItem.Id);

            //if the game item is not in the inventory add a new GameItemQuantity object into the inventory
            ///////////////////////////////////////////////////////////////////////////////////////////////////
            if (gameItemQuantity == null)
            {
                GameItemQuantity newGameItemQuantity = new GameItemQuantity();
                newGameItemQuantity.GameItem = selectedGameItemQuantity.GameItem;
                newGameItemQuantity.Quantity = 1;

                _inventory.Add(newGameItemQuantity);
            }

            //if the selectedGameItemQuantity is in the inventory then add the appropriate quantity
            ///////////////////////////////////////////////////////////////////////////////////////////
            else
            {
                gameItemQuantity.Quantity++;
            }

            UpdateInventoryCategories();


        }

        /// <summary>
        /// remove selected item from inventory
        /// </summary>
        /// <param name="selectedGameItemQuantity"></param>
        public void RemoveGameItemQuantityFromInventory(GameItemQuantity selectedGameItemQuantity)
        {
            //find the item if it is in the inventory
            //////////////////////////////////////////

            GameItemQuantity gameItemQuantity = _inventory.FirstOrDefault(i => i.GameItem.Id == selectedGameItemQuantity.GameItem.Id);

            //if the game item is in the inventory if there is only one remove it completely. If there is more than one subtract one from the inventory
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (gameItemQuantity != null)
            {
                if (selectedGameItemQuantity.Quantity == 1)
                {
                    _inventory.Remove(gameItemQuantity);
                }
                else
                {
                    gameItemQuantity.Quantity--;
                }
            }

            UpdateInventoryCategories();


        }


        public override string DefaultGreeting()
        {
            return $"Hello, my name is {_name} and I specialize in {_speciality}";
        }

        
        /// <summary>
        /// return hit points [0 - 100] based on the player's weapon and skill level
        /// </summary>
        /// <returns>hit points 0-100</returns>
        public int Attack()
        {
            int hitPoints = random.Next(CurrentWeapon.MinimumDamage, CurrentWeapon.MaximumDamage) * _skillLevel;

            if (hitPoints <= 100)
            {
                return hitPoints;
            }
            else
            {
                return 100;
            }
        }

        
        /// <summary>
        /// return hit points [0 - 100] based on the player's weapon and skill level
        /// adjusted to deliver more damage when first attacked
        /// </summary>
        /// <returns>hit points 0-100</returns>
        public int Defend()
        {
            int hitPoints = (random.Next(CurrentWeapon.MinimumDamage, CurrentWeapon.MaximumDamage) * _skillLevel) - DEFENDER_DAMAGE_ADJUSTMENT;

            if (hitPoints >= 0 && hitPoints <= 100)
            {
                return hitPoints;
            }
            else if (hitPoints > 100)
            {
                return 100;
            }
            else
            {
                return 0;
            }
        }

        
        /// <summary>
        /// return hit points [0 - 100] based on the player's skill level
        /// </summary>
        /// <returns>hit points 0-100</returns>
        public int Retreat()
        {
            int hitpoints = _skillLevel * MAXIMUM_RETREAT_DAMAGE;

            if (hitpoints <= 100)
            {
                return hitpoints;
            }
            else
            {
                return 100;
            }
        }

        #endregion

        #region EVENTS

        #endregion
    }
}
