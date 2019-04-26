using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace TBQuestGame.Models
{
    public class Map
    {
        #region ENUMS



        #endregion


        #region FIELDS

        private Location[,] _mapLocations;
        private int _maxRows, _maxColumns;
        private GameMapCoordinates _currentLocationCoordinates;
        private Player _player;
        private List<GameItem> _standardGameItems;
        private ObservableCollection<Location> _fastTravelLocations;
        private List<Location> _allMapLocations;






        #endregion


        #region PROPERTIES
        public Location[,] MapLocations
        {
            get { return _mapLocations; }
            set { _mapLocations = value; }
        }

        public GameMapCoordinates CurrentLocationCoordinates
        {
            get { return _currentLocationCoordinates; }
            set { _currentLocationCoordinates = value; }

        }

        public Location CurrentLocation
        {
            get { return _mapLocations[_currentLocationCoordinates.Row, _currentLocationCoordinates.Column]; }
        }

        public Player Player
        {
            get { return _player; }
            set { _player = value; }
        }

        public ObservableCollection<Location> FastTravelLocations
        {
            get
            {
                ObservableCollection<Location> fastTravelLocations = new ObservableCollection<Location>();

                foreach (var locations in MapLocations)
                    if (_player.HasVisited(locations))
                    {
                        fastTravelLocations.Add(locations);
                    }

                return fastTravelLocations;
            }
            set { _fastTravelLocations = value; }
        }

        public List<GameItem> StandardGameItems
        {
            get { return _standardGameItems; }
            set { _standardGameItems = value; }
        }


        public List<Location> AllMapLocations
        {
            get
            {
                List<Location> allMapLocations = new List<Location>();
                Location mapLocation = new Location();

                for (int row = 0; row < _maxRows; row++)
                {
                    for (int column = 0; column < _maxColumns; column++)
                    {
                        mapLocation = _mapLocations[row, column];
                        if (mapLocation != null)
                        {
                            allMapLocations.Add(mapLocation);
                        }
                    }
                }
                return allMapLocations;
            }
            set { _allMapLocations = value; }
        }
        #endregion


        #region CONSTRUCTORS

        public Map(int rows, int columns)
        {
            _maxRows = rows;
            _maxColumns = columns;
            _mapLocations = new Location[rows, columns];

        }

        //public Map()
        //{

        //}

        #endregion

        #region METHODS
        //Fast Travel Movement
        //public void Move (Locations location)

        //{
        //    _currentLocation = location;
        //}


        //Grid Movement
        public void MoveUp()
        {
            if (_currentLocationCoordinates.Row >= 0)
            {
                _currentLocationCoordinates.Row += 1;
            }
        }

        public void MoveDown()
        {
            if (_currentLocationCoordinates.Row < _maxRows)
            {
                _currentLocationCoordinates.Row -= 1;
            }

        }

        public void MoveNext()
        {
            if (_currentLocationCoordinates.Column < _maxColumns)
            {
                _currentLocationCoordinates.Column += 1;
            }
        }

        public void MovePrevious()
        {
            if (_currentLocationCoordinates.Column > 0)
            {
                _currentLocationCoordinates.Column -= 1;
            }
        }

        //Name of location for next move in each direction
        public Location UpLocation()
        {
            Location upLocation = null;

            //if statement that makes sure you are not beyond map border

            if (_currentLocationCoordinates.Row < _maxRows - 1)
            {
                Location nextUpLocation = _mapLocations[_currentLocationCoordinates.Row + 1, _currentLocationCoordinates.Column];

                // if the locations exists and the player can access location
                /* need to ask john how to make a room accessible based on recovering an item|| nextUpLocation.IsAccessibleByExperiencePoints(player.ExperiencePoints)))*/
                if (nextUpLocation != null && (nextUpLocation.Accessible == true))
                {
                    upLocation = nextUpLocation;
                }
            }

            return upLocation;
        }

        public Location DownLocation()
        {
            Location downLocation = null;

            //if statement that makes sure you are not beyond map border

            if (_currentLocationCoordinates.Row > 0)
            {
                Location nextDownLocation = _mapLocations[_currentLocationCoordinates.Row - 1, _currentLocationCoordinates.Column];

                // the locations exists and the player can access location
                /* need to ask john how to make a room accessible based on recovering an item|| nextUpLocation.IsAccessibleByExperiencePoints(player.ExperiencePoints)))*/
                if (nextDownLocation != null && (nextDownLocation.Accessible == true))
                {
                    downLocation = nextDownLocation;
                }
            }

            return downLocation;
        }

        public Location NextLocation()
        {
            Location nextLocation = null;

            //if statement that makes sure you are not beyond map border

            if (_currentLocationCoordinates.Column < _maxColumns - 1)
            {
                Location nextNextLocation = _mapLocations[_currentLocationCoordinates.Row, _currentLocationCoordinates.Column + 1];

                // the locations exists and the player can access location
                /* need to ask john how to make a room accessible based on recovering an item|| nextUpLocation.IsAccessibleByExperiencePoints(player.ExperiencePoints)))*/
                if ((nextNextLocation != null) && (nextNextLocation.Accessible == true))
                {
                    nextLocation = nextNextLocation;
                }
            }

            return nextLocation;
        }

        public Location PreviousLocation()
        {
            Location previousLocation = null;

            //if statement that makes sure you are not beyond map border

            if (_currentLocationCoordinates.Column > 0)
            {
                Location nextPreviousLocation = _mapLocations[_currentLocationCoordinates.Row, _currentLocationCoordinates.Column - 1];

                // the locations exists and the player can access location
                /* need to ask john how to make a room accessible based on recovering an item|| nextUpLocation.IsAccessibleByExperiencePoints(player.ExperiencePoints)))*/
                if (nextPreviousLocation != null && (nextPreviousLocation.Accessible == true))
                {
                    previousLocation = nextPreviousLocation;
                }
            }

            return previousLocation;
        }



        ///get a standard game item from the list by id
        //////////////////////////////////////////////////
        //////////////////////////////////////////////////

        /// <param name="gameItemId">standard game item info</param>
        /// <returns></returns>
        public GameItem GameItemById(int gameItemId)
        {
            return StandardGameItems.FirstOrDefault(i => i.Id == gameItemId);
        }


        /// open the location controlled by a given relic
        /// </summary>
        /// <param name="relicId"></param>
        /// <returns>user message regarding success of attempt</returns>
        public string OpenLocationsByRelic(int relicId)
        {
            string message = "The relic did nothing.";
            Location mapLocation = new Location();

            for (int row = 0; row <= _maxRows; row++)
            {
                for (int column = 0; column <= _maxColumns; column++)
                {
                    mapLocation = _mapLocations[row, column];

                    if (mapLocation != null && mapLocation.RequiredRelicId == relicId)
                    {
                        mapLocation.Accessible = true;
                        message = $"{mapLocation.Name} is now accessible.";
                    }
                }
            }

            return message;
        }


        private List<Location> LocationListGenerator()
        {
            List<Location> allMapLocations = new List<Location>();
            Location mapLocation = new Location();

            for (int row = 0; row < _maxRows; row++)
            {
                for (int column = 0; column < _maxColumns; column++)
                {
                    mapLocation = _mapLocations[row, column];
                    allMapLocations.Add(mapLocation);
                }
            }
            return allMapLocations;
        }
        #endregion



        #region EVENTS



        #endregion

    }
}
