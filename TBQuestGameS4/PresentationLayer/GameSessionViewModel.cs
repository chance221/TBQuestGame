using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using TBQuestGame.Models;
using System.Windows.Threading;
using System.Collections.ObjectModel;
using System.Windows;
namespace TBQuestGame.PresentationLayer
{
    // When you create a view model it ALWAYS goes to the constructor first so if you need informatin to be passed into the view model before launching put it in the constructor
    public class GameSessionViewModel : ObservableObject
    {
        #region ENUMS


        #endregion

        #region FIELDS
        private Player _player;

        //private List<string> _messages;
        private DateTime _gameStartTime;
        private Map _gameMap;
        //private Locations _locations;
        private Location _currentLocation;
        private string _currentLocationName;
        private Location _upLocation, _downLocation, _previousLocation, _nextLocation;
        private ObservableCollection<Location> _fastTravelLocations;
        private GameItemQuantity _currentGameItem;
        private Weapon _currentWeapon;
        private string _currentLocationInformation;
        private List<Location> _allMapLocations;
        private Random random = new Random();
        private Npc _currentNpc;

        #endregion

        #region PROPERTIES


        // must have a property to bind to control. NOT A FIELD BUT A PROPERTY
        public Player Player
        {
            get { return _player; }
            set { _player = value; }
        }


        public string MessageDisplay
        {
            get { return _currentLocation.Message; }

        }


        public Map GameMap
        {
            get { return _gameMap; }
            set { _gameMap = value; }
        }

        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set
            {
                _currentLocation = value;
                _currentLocationInformation = _currentLocation.Description;
                OnPropertyChanged(nameof(CurrentLocation));
                OnPropertyChanged(nameof(CurrentLocationInformation));

            }
        }

        public Location UpLocation
        {
            get { return _upLocation; }
            set
            {
                _upLocation = value;
                OnPropertyChanged(nameof(UpLocation));
                OnPropertyChanged(nameof(HasUpLocation));
            }
        }

        public Player.Armor Armor
        {
            get { return _player.SpecialArmor; }
            set
            {
                OnPropertyChanged(nameof(Player.Armor));
            }
        }

        public Location DownLocation
        {
            get { return _downLocation; }
            set
            {
                _downLocation = value;
                OnPropertyChanged(nameof(DownLocation));
                OnPropertyChanged(nameof(HasDownLocation));
            }
        }

        public Location PreviousLocation
        {
            get { return _previousLocation; }
            set
            {
                _previousLocation = value;
                OnPropertyChanged(nameof(PreviousLocation));
                OnPropertyChanged(nameof(HasPreviousLocation));
            }
        }

        public Location NextLocation
        {
            get { return _nextLocation; }
            set
            {
                _nextLocation = value;
                OnPropertyChanged(nameof(NextLocation));
                OnPropertyChanged(nameof(HasNextLocation));
            }
        }

        public ObservableCollection<Location> FastTravelLocations
        {
            get { return _fastTravelLocations; }
            set
            {
                _fastTravelLocations = value;
                OnPlayerMove();
                OnPropertyChanged(nameof(CurrentLocation));

            }
        }

        public string CurrentLocationName
        {
            get { return _currentLocationName; }
            set
            {
                if (value != null)
                {
                    _currentLocationName = value;

                    foreach (Location newLocation in _gameMap.AllMapLocations)
                    {
                        if (newLocation.Name == _currentLocationName)
                        {
                            CurrentLocation = newLocation;
                        }
                    }

                    OnPlayerMove();
                    OnPropertyChanged(nameof(CurrentLocation));
                }

            }
        }

        public string CurrentLocationInformation
        {
            get { return _currentLocationInformation; }
            set
            {
                _currentLocationInformation = value;
                OnPropertyChanged(nameof(CurrentLocationInformation));
            }
        }

        public Npc CurrentNpc
        {
            get { return _currentNpc; }
            set
            {
                _currentNpc = value;
                OnPropertyChanged(nameof(_currentNpc));
            }
        }

        public GameItemQuantity CurrentGameItem
        {
            get { return _currentGameItem; }
            set
            {
                _currentGameItem = value;
                OnPropertyChanged(nameof(CurrentGameItem));
                if(_currentGameItem != null && _currentGameItem.GameItem is Weapon)
                {
                    _player.CurrentWeapon = _currentGameItem.GameItem as Weapon;
                }
            }
        }

        #endregion

        #region CONSTRUCTORS



        public GameSessionViewModel(
            Player player,
            Map gameMap,
            GameMapCoordinates currentLocationCoordinates)
        {
            _player = player;
            _gameMap = gameMap;
            _gameMap.CurrentLocationCoordinates = currentLocationCoordinates;
            _currentLocation = _gameMap.CurrentLocation;
            _fastTravelLocations = _player.FastTravelLocations;
            _player.CalculateWealth();
            InitializeView();

            //GameTimer();
        }

        //public void GameTimer()
        //{
        //    DispatcherTimer timer = new DispatcherTimer();
        //    timer.Interval = TimeSpan.FromMilliseconds(1000);
        //    timer.Tick += OnGameTimerTick;
        //    timer.Start();
        //}




        //void OnGameTimerTick(object sender, EventArgs e)
        //{
        //    _gameTime = DateTime.Now - _gameStartTime;
        //    MissionTimeDisplay = "Mission Time " + _gameTime.ToString(@"hh\:mm\:ss");
        //}
        #endregion

        #region METHODS

        private void InitializeView()
        {
            _gameStartTime = DateTime.Now;
            UpdateAvailableTravelPoints();
            _player.UpdateInventoryCategories();
            UpdateFastTravelLocations();
        }

        public void MoveUp()
        {
            if (HasUpLocation)
            {
                _gameMap.MoveUp();
                CurrentLocation = _gameMap.CurrentLocation;
                UpdateAvailableTravelPoints();
                OnPlayerMove();
                UpdateFastTravelLocations();
            }
        }

        public void MoveDown()
        {
            if (HasDownLocation)
            {
                _gameMap.MoveDown();
                CurrentLocation = _gameMap.CurrentLocation;
                UpdateAvailableTravelPoints();
                OnPlayerMove();
                UpdateFastTravelLocations();
            }
        }

        public void MovePrevious()
        {
            if (HasPreviousLocation)
            {
                _gameMap.MovePrevious();
                CurrentLocation = _gameMap.CurrentLocation;
                UpdateAvailableTravelPoints();
                OnPlayerMove();
                UpdateFastTravelLocations();
            }
        }

        public void MoveNext()
        {
            if (HasNextLocation)
            {
                _gameMap.MoveNext();
                CurrentLocation = _gameMap.CurrentLocation;
                UpdateAvailableTravelPoints();
                OnPlayerMove();
                UpdateFastTravelLocations();
            }
        }
        
        //if player has previously visited location then add it to the list of FastTravel Locations
        private void UpdateFastTravelLocations()
        {
            _fastTravelLocations.Clear();
            foreach (Location locations in _player.LocationsVisited)
            {
                _fastTravelLocations.Add(locations);
            }
        }

        

        /// <summary>
        /// add a new item to the players inventory
        /// </summary>
        /// <param name="selectedItem"></param>
        public void AddItemToInventory()
        {
            //
            // confirm a game item selected and is in current location
            // subtract from location and add to inventory
            //
            if (_currentGameItem != null && _currentLocation.GameItems.Contains(_currentGameItem))
            {
                //
                // cast selected game item 
                //
                GameItemQuantity selectedGameItemQuantity = _currentGameItem as GameItemQuantity;

                _currentLocation.RemoveGameItemQuantityFromLocation(selectedGameItemQuantity);
                _player.AddGameItemQuantityToInventory(selectedGameItemQuantity);

                OnPlayerPickUp(selectedGameItemQuantity);
            }
        }

        /// <summary>
        /// remove item from the players inventory
        /// </summary>
        /// <param name="selectedItem"></param>
        public void RemoveItemFromInventory()
        {
            //
            // confirm a game item selected and is in inventory
            // subtract from inventory and add to location
            //
            if (_currentGameItem != null)
            {
                //
                // cast selected game item 
                //
                GameItemQuantity selectedGameItemQuantity = _currentGameItem as GameItemQuantity;

                _currentLocation.AddGameItemQuantityToLocation(selectedGameItemQuantity);
                _player.RemoveGameItemQuantityFromInventory(selectedGameItemQuantity);

                OnPlayerPutDown(selectedGameItemQuantity);
            }
        }

        /// <summary>
        /// process events when a player picks up a new game item
        /// </summary>
        /// <param name="gameItemQuantity">new game item</param>
        private void OnPlayerPickUp(GameItemQuantity gameItemQuantity)
        {
            _player.ExperiencePoints += gameItemQuantity.GameItem.XP;
            _player.Wealth += gameItemQuantity.GameItem.Value;
        }

        /// <summary>
        /// process events when a player puts down a new game item
        /// </summary>
        /// <param name="gameItemQuantity">new game item</param>
        private void OnPlayerPutDown(GameItemQuantity gameItemQuantity)
        {
            _player.Wealth -= gameItemQuantity.GameItem.Value;
        }

        /// <summary>
        /// process using an item in the player's inventory
        /// </summary>
        public void OnUseGameItem()
        {
            switch (_currentGameItem.GameItem)
            {
                case Potions potion:
                    ProcessPotionUse(potion);
                    break;
                case Relic relic:
                    ProcessRelicUse(relic);
                    break;
                case Treasure treasure:
                    ProcessArmorUpgrade(treasure);
                    break;
                default:
                    break;
            }
        }

        private void ProcessArmorUpgrade(Treasure treasure)
        {
            if (Player.SpecialArmor == Player.Armor.Low)
            {
                _player.SpecialArmor = Player.Armor.Medium;
            }

            if (Player.SpecialArmor == Player.Armor.Medium)
            {
                _player.SpecialArmor = Player.Armor.High;
            }
            
        }

        /// <summary>
        /// process the effects of using the potion
        /// </summary>
        /// <param name="potion">potion</param>
        private void ProcessPotionUse(Potions potion)
        {
            _player.Health += potion.HealthChange;
            _player.Lives += potion.LivesChange;
            _player.RemoveGameItemQuantityFromInventory(_currentGameItem);
        }


        /// <summary>
        /// process the effects of using the relic
        /// </summary>
        /// <param name="relic">Relic</param>
        private void ProcessRelicUse(Relic relic)
        {
            string message;

            switch (relic.UseAction)
            {
                case Relic.UseActionType.OpenLocation:
                    message = _gameMap.OpenLocationsByRelic(relic.Id);
                    CurrentLocationInformation = relic.UseMessage;
                    break;
                case Relic.UseActionType.UpgradePlayer:
                    message = "You have upgraded your player armor one level";
                    if (_player.SpecialArmor == Player.Armor.Low)
                    {
                        _player.SpecialArmor = Player.Armor.Medium;
                    }
                    else
                    {
                        _player.SpecialArmor = Player.Armor.High;
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// handle the attack event in the view.
        /// </summary>
        public void OnPlayerAttack()
        {
            _player.BattleMode = BattleModeName.ATTACK;
            Battle();
        }

        /// <summary>
        /// handle the defend event in the view.
        /// </summary>
        public void OnPlayerDefend()
        {
            _player.BattleMode = BattleModeName.DEFEND;
            Battle();
        }

        /// <summary>
        /// handle the retreat event in the view.
        /// </summary>
        public void OnPlayerRetreat()
        {
            _player.BattleMode = BattleModeName.RETREAT;
            Battle();
        }

        /// <summary>
        /// player chooses to exit game
        /// </summary>
        private void QuiteApplication()
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// player chooses to reset game
        /// </summary>
        private void ResetPlayer()
        {
            Environment.Exit(0);
        }

        //public bool HasUpLocation
        //{
        //    get
        //    {
        //        if (UpLocation != null)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //}
        //same as code above just shorthand
        public bool HasUpLocation { get { return UpLocation != null; } }
        public bool HasDownLocation { get { return DownLocation != null; } }
        public bool HasPreviousLocation { get { return PreviousLocation != null; } }
        public bool HasNextLocation { get { return NextLocation != null; } }




        private void UpdateAvailableTravelPoints()
        {
            UpLocation = null;
            DownLocation = null;
            PreviousLocation = null;
            NextLocation = null;

            if (_gameMap.UpLocation() != null)
            {
                Location goUpLocation = _gameMap.UpLocation();

                if (goUpLocation.Accessible == true)  // you can add player accessibility modifiers here to ensure an area is accessable and visible on the screen)
                {
                    UpLocation = goUpLocation;
                }
            }

            if (_gameMap.DownLocation() != null)
            {
                Location goDownLocation = _gameMap.DownLocation();

                if (goDownLocation.Accessible == true)  // you can add player accessibility modifiers here to ensure an area is accessable and visible on the screen)
                {
                    DownLocation = goDownLocation;
                }
            }

            if (_gameMap.PreviousLocation() != null)
            {
                Location goPreviousLocation = _gameMap.PreviousLocation();

                if (goPreviousLocation.Accessible == true)  // you can add player accessibility modifiers here to ensure an area is accessable and visible on the screen)
                {
                    PreviousLocation = goPreviousLocation;
                }
            }

            if (_gameMap.NextLocation() != null)
            {
                Location goNextLocation = _gameMap.NextLocation();

                if (goNextLocation.Accessible == true)  // you can add player accessibility modifiers here to ensure an area is accessable and visible on the screen)
                {
                    NextLocation = goNextLocation;
                }
            }
        }

        /// <summary>
        ///***************** The block of code below is how you make additional stipulations to weather or not a room becomes accessible.************************
        /// </summary>
        /// 
        /// <returns>accessibility</returns>
        //private bool PlayerCanAccessLocation(Location nextLocation)
        //{
        //    //
        //    // check access by experience points
        //    //
        //    if (nextLocation.IsAccessibleByExperiencePoints(_player.ExperiencePoints))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}



        private void OnPlayerMove()
        {
            if (!_player.HasVisited(_currentLocation))
            {
                _player.LocationsVisited.Add(_currentLocation);
                _player.ExperiencePoints += _currentLocation.ModifyXP;
                _player.Health += _currentLocation.ModifyHealath;

                if (_currentLocation.ModifyLives != 0)
                {
                    _player.Lives += _currentLocation.ModifyLives;
                }

                OnPropertyChanged(nameof(MessageDisplay));



                /////////////////////////////////////////////////////////FOR LIST OF LOCATIONS///////////////////////////////////
                //////////////////////////////////////////////////////////////This commented section does the same thing as the code within the OnPlayerMove method except this takes alot more typing ///////////////////////////////////

                //Locations newLocation = new Locations();

                //foreach (Locations locations in AccessibleLocations1)
                //{
                //    if (locations.Name == _currentLocationName)
                //    {
                //        newLocation = locations;
                //    }
                //}
                //Locations newLocation = AccessibleLocations1.FirstOrDefault(l => l.Name == _currentLocationName);
                //_gameMap.CurrentLocation = newLocation;
                //_currentLocation = newLocation;
                //_player.ExperiencePoints += _currentLocation.ModifyXP;
            }
        }

        /// <summary>
        /// generates a sting of mission messages with time stamp with most current first
        /// </summary>
        /// <returns>string of formated mission messages</returns>
        //private string FormatMessagesForViewer()
        //{
        //    List<string> lifoMessages = new List<string>(); //creates a list of messages

        //    for (int index = 0; index < _messages.Count; index++) // Adds the message to the list then goes through each message in the list and adds a time stamp
        //    {
        //        lifoMessages.Add( _messages[index]);
        //    }

        //    lifoMessages.Reverse(); // ensures most latest message in list will be displayed at the top

        //    return string.Join("\n\n", lifoMessages); // formats spacing to ensure message is easily seperated from others and readable 
        //}

        /// <summary>
        /// running time of game
        /// </summary>
        /// <returns></returns>
        private TimeSpan GameTime()
        {
            return DateTime.Now - _gameStartTime;
        }


        /// <summary>
        /// handle the speak to event in the view
        /// </summary>
        public void OnPlayerTalkTo()
        {
            if (CurrentNpc != null && CurrentNpc is ISpeak)
            {
                ISpeak speakingNpc = CurrentNpc as ISpeak;
                CurrentLocationInformation = speakingNpc.Speak();
            }
        }


        private BattleModeName NpcBattleResponse()
        {
            BattleModeName npcBattleResponse = BattleModeName.RETREAT;

            switch (DieRoll(3))
            {
                case 1:
                    npcBattleResponse = BattleModeName.ATTACK;
                    break;
                case 2:
                    npcBattleResponse = BattleModeName.DEFEND;
                    break;
                case 3:
                    npcBattleResponse = BattleModeName.RETREAT;
                    break;
            }
            return npcBattleResponse;
        }

        #region HELPER METHODS

        private int DieRoll(int sides)
        {
            return random.Next(1, sides + 1);
        }

        /// <summary>
        /// calculate player hit points based on battle mode
        /// </summary>
        /// <returns>player hit points</returns>
        private int CalculatePlayerHitPoints()
        {
            int playerHitPoints = 0;

            switch (_player.BattleMode)
            {
                case BattleModeName.ATTACK:
                    playerHitPoints = _player.Attack();
                    break;
                case BattleModeName.DEFEND:
                    playerHitPoints = _player.Defend();
                    break;
                case BattleModeName.RETREAT:
                    playerHitPoints = _player.Retreat();
                    break;
            }

            return playerHitPoints;
        }

        /// <summary>
        /// calculate NPC hit points based on battle mode
        /// </summary>
        /// <returns>NPC hit points</returns>
        private int CalculateNpcHitPoints(IBattle battleNpc)
        {
            int battleNpcHitPoints = 0;

            switch (NpcBattleResponse())
            {
                case BattleModeName.ATTACK:
                    battleNpcHitPoints = battleNpc.Attack();
                    break;
                case BattleModeName.DEFEND:
                    battleNpcHitPoints = battleNpc.Defend();
                    break;
                case BattleModeName.RETREAT:
                    battleNpcHitPoints = battleNpc.Retreat();
                    break;
            }
            if(_player.SpecialArmor == Player.Armor.High)
            {
                battleNpcHitPoints -= 2;
            }
            if (_player.SpecialArmor == Player.Armor.High)
            {
                battleNpcHitPoints -= 1;
            }
           
            return battleNpcHitPoints;
        }

        /// <summary>
        /// process the outcome of a battle with an NPC
        /// </summary>
        private void Battle()
        {
            //
            // check to see if an NPC can battle
            //
            if (_currentNpc is IBattle)
            {
                IBattle battleNpc = _currentNpc as IBattle;
                int playerHitPoints = 0;
                int battleNpcHitPoints = 0;
                string battleInformation = "";

                //
                // calculate hit points if the player and NPC have weapons
                //
                if (_player.CurrentWeapon != null)
                {
                    playerHitPoints = CalculatePlayerHitPoints();
                }
                else
                {
                    battleInformation = "It appears you are entering into battle without a weapon." + Environment.NewLine;
                }

                if (battleNpc.CurrentWeapon != null)
                {
                    battleNpcHitPoints = CalculateNpcHitPoints(battleNpc);
                }
                else
                {
                    battleInformation = $"It appears you are entering into battle with {_currentNpc.Name} who has no weapon." + Environment.NewLine;
                }

                //
                // build out the text for the current location information
                //
                battleInformation +=
                    $"Player: {_player.BattleMode}     Hit Points: {playerHitPoints}" + Environment.NewLine +
                    $"NPC: {battleNpc.BattleMode}     Hit Points: {battleNpcHitPoints}" + Environment.NewLine;

                //
                // determine results of battle
                //
                if (playerHitPoints >= battleNpcHitPoints)
                {
                    battleInformation += $"You have slain {_currentNpc.Name}.";
                    _currentLocation.Npcs.Remove(_currentNpc);
                }
                else
                {
                    battleInformation += $"You have been slain by {_currentNpc.Name}.";
                    _player.Health -= battleNpcHitPoints;
                }

                CurrentLocationInformation = battleInformation;
                if (_player.Lives <= 0) OnPlayerDies("You have been slain and have no lives left.");
            }
            else
            {
                CurrentLocationInformation = "The current NPC was not trying to fight. He sues you for Damages and you loose 10 Coins.";
                _player.Wealth -= 100;
            }

        }

        /// <summary>
        /// process player dies with option to reset and play again
        /// </summary>
        /// <param name="message">message regarding player death</param>
        private void OnPlayerDies(string message)
        {
            string messagetext = message +
                "\n\nWould you like to play again?";

            string titleText = "Death";
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxResult result = MessageBox.Show(messagetext, titleText, button);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    ResetPlayer();
                    break;
                case MessageBoxResult.No:
                    QuiteApplication();
                    break;
            }
        }
        #endregion




        #endregion

        #region EVENTS
        public class MultiplyConverter : IMultiValueConverter
        {
            public object Convert(object[] values, Type targetType,
                   object parameter, CultureInfo culture)
            {
                double result = 1.0;
                for (int i = 0; i < values.Length; i++)
                {
                    if (values[i] is double)
                        result *= (double)values[i];
                }

                return result;
            }

            public object[] ConvertBack(object value, Type[] targetTypes,
                   object parameter, CultureInfo culture)
            {
                throw new Exception("Not implemented");
            }
        }
        #endregion
    }





}
