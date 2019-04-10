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
        private Locations _currentLocation;

        //private List<string> _accessibleLocations;
        //private string _currentLocationName;
        //private ObservableCollection<Locations> _accessibleLocations1;
        //private Locations[,] locations;
        
        private Locations _upLocation, _downLocation, _previousLocation, _nextLocation;




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
            get { return string.Join("\n\n", _currentLocation.Message); }

        }
        

        public Map GameMap
        {
            get { return _gameMap; }
            set { _gameMap = value; }
        }



        //public Locations Location
        //{
        //    get { return _locations; }
        //    set { _locations = value; }
        //}


        public Locations CurrentLocation
        {
            get { return _currentLocation; }
            set
            {
                _currentLocation = value;
                OnPropertyChanged(nameof(CurrentLocation));

            }
        }

        public Locations UpLocation
        {
            get { return _upLocation; }
            set
            {
                _upLocation = value;
                OnPropertyChanged(nameof(UpLocation));
                OnPropertyChanged(nameof(HasUpLocation));
            }
        }

        public Locations DownLocation
        {
            get { return _downLocation; }
            set
            {
                _downLocation = value;
                OnPropertyChanged(nameof(DownLocation));
                OnPropertyChanged(nameof(HasDownLocation));
            }
        }

        public Locations PreviousLocation
        {
            get { return _previousLocation;  }
            set
            {
                _previousLocation = value;
                OnPropertyChanged(nameof(PreviousLocation));
                OnPropertyChanged(nameof(HasPreviousLocation));
            }
        }

        public Locations NextLocation
        {
            get { return _nextLocation;  }
            set
            {
                _nextLocation = value;
                OnPropertyChanged(nameof(NextLocation));
                OnPropertyChanged(nameof(HasNextLocation));
            }
        }
        //public List<string> AccessibleLocations
        //{
        //    get { return _accessibleLocations; }
        //    set { _accessibleLocations = value; }
        //}


        //public string CurrentLocationName
        //{
        //    get { return _currentLocationName; }
        //    set
        //    {
        //        _currentLocationName = value;
        //        OnPlayerMove();
        //        OnPropertyChanged(nameof(CurrentLocation));
        //    }
        //}


        //public ObservableCollection<Locations> AccessibleLocations1
        //{
        //    get { return _accessibleLocations1; }
        //    set { _accessibleLocations1 = value; }
        //}

        #endregion

        #region CONSTRUCTORS

        //public GameSessionViewModel()
        //{

        //}
        //constructor for list (fast travel)
        //public GameSessionViewModel(
        //    Player player, 
        //    List<string> initialMessages, 
        //    Map gameMap, 
        //    Locations currentLocation,
        //    string currentLocationName
        //    )
        //    //List<string> AccessibleLocations)
        //{
        //    _player = player;
        //    //_messages = initialMessages;
        //    _gameMap = gameMap;
        //    _currentLocation = currentLocation;
        //    //_accessibleLocations1 = _gameMap.AccessibleLocations;
        //    _currentLocationName = currentLocationName;
            
        //   // _accessibleLocations = AccessibleLocations;


        //    // if you want a timer in the view model it MUST be in the constructor
        //    InitializeView();
            
        //}

        public GameSessionViewModel(
            Player player, 
            Map gameMap, 
            GameMapCoordinates currentLocationCoordinates)
        {
            _player = player;
            _gameMap = gameMap;
            _gameMap.CurrentLocationCoordinates = currentLocationCoordinates;
            _currentLocation = _gameMap.CurrentLocation;
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
        }


        public void MoveUp()
        {
            if (HasUpLocation)
            {
                _gameMap.MoveUp();
                CurrentLocation = _gameMap.CurrentLocation;
                UpdateAvailableTravelPoints();
                OnPlayerMove();
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
            }
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

            if(_gameMap.UpLocation() != null)
            {
                Locations goUpLocation = _gameMap.UpLocation();

                if (goUpLocation.Accessible == true)  // you can add player accessibility modifiers here to ensure an area is accessable and visible on the screen)
                {
                    UpLocation = goUpLocation;
                }
            }

            if (_gameMap.DownLocation() != null)
            {
                Locations goDownLocation = _gameMap.DownLocation();

                if (goDownLocation.Accessible == true)  // you can add player accessibility modifiers here to ensure an area is accessable and visible on the screen)
                {
                    DownLocation = goDownLocation;
                }
            }

            if (_gameMap.PreviousLocation() != null)
            {
                Locations goPreviousLocation = _gameMap.PreviousLocation();

                if (goPreviousLocation.Accessible == true)  // you can add player accessibility modifiers here to ensure an area is accessable and visible on the screen)
                {
                    PreviousLocation = goPreviousLocation;
                }
            }

            if (_gameMap.NextLocation() != null)
            {
                Locations goNextLocation = _gameMap.NextLocation();

                if (goNextLocation.Accessible == true)  // you can add player accessibility modifiers here to ensure an area is accessable and visible on the screen)
                {
                    PreviousLocation = goNextLocation;
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
        //        lifoMessages.Add($" <T:{GameTime().ToString(@"hh\:mm\:ss")}> " + _messages[index]);
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
