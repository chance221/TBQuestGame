using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel; //need to add to use observable objects. These types of objects listen for changes

namespace TBQuestGame.Models
{
    public class Map
    {
        #region ENUMS



        #endregion


 #region FIELDS
        
       // private ObservableCollection<Locations> _locations;
       // private Locations _currentLocation;
        private Locations[,] _mapLocations;
        private int _maxRows, _maxColumns;
        private GameMapCoordinates _currentLocationCoordinates;




        #endregion


        #region PROPERTIES
        public Locations[,] MapLocations
        {
            get { return _mapLocations; }
            set { _mapLocations = value; }
        }

        public GameMapCoordinates CurrentLocationCoordinates
        {
            get { return _currentLocationCoordinates;  }
            set { _currentLocationCoordinates = value; }

        }

        public Locations CurrentLocation
        {
            get { return _mapLocations[_currentLocationCoordinates.Row, _currentLocationCoordinates.Column];  }
        }

        
        //public ObservableCollection<Locations> Locations
        //{
        //    get { return _locations; }
        //    set { _locations = value; }
        //}

        //public Locations CurrentLocation
        //{
        //    get { return _currentLocation; }
        //    set { _currentLocation = value; }
        //}

        //public Locations CurrentLocation
        //{
        //    get { return _mapLocation[_currentLocationCoordinates.Row, _currentLocationCoordinates.Column]; }
        //    set { _currentLocation = value; }

        //}

        //public ObservableCollection<Locations> AccessibleLocations
        //{
        //    get
        //    {
        //        ObservableCollection<Locations> accessibleLocations = new ObservableCollection<Locations>();

        //        foreach (var location in _locations)
        //        {
        //            if (location.Accessible == true)
        //            {
        //                accessibleLocations.Add(location);
        //            }
        //        }

        //        return accessibleLocations;
        //    }

        //}

        #endregion


        #region CONSTRUCTORS

        public Map(int rows, int columns)
        {
            _maxRows = rows;
            _maxColumns = columns;
            _mapLocations = new Locations[rows, columns];

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
            if (_currentLocationCoordinates.Row > 0)
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
        public Locations UpLocation()
        {
            Locations upLocation = null;

            //if statement that makes sure you are not beyond map border

            if (_currentLocationCoordinates.Row < _maxRows -1)
            {
                Locations nextUpLocation = _mapLocations[_currentLocationCoordinates.Row + 1, _currentLocationCoordinates.Column];

                // if the locations exists and the player can access location
                /* need to ask john how to make a room accessible based on recovering an item|| nextUpLocation.IsAccessibleByExperiencePoints(player.ExperiencePoints)))*/
                if (nextUpLocation != null && (nextUpLocation.Accessible == true))
                {
                    upLocation = nextUpLocation;
                } 
            }

            return upLocation;
        }

        public Locations DownLocation()
        {
            Locations downLocation = null;

            //if statement that makes sure you are not beyond map border

            if (_currentLocationCoordinates.Row > 0)
            {
                Locations nextDownLocation = _mapLocations[_currentLocationCoordinates.Row + 1, _currentLocationCoordinates.Column];

                // the locations exists and the player can access location
                /* need to ask john how to make a room accessible based on recovering an item|| nextUpLocation.IsAccessibleByExperiencePoints(player.ExperiencePoints)))*/
                if (nextDownLocation != null && (nextDownLocation.Accessible == true))
                {
                    downLocation = nextDownLocation;
                }
            }

            return downLocation;
        }

        public Locations NextLocation()
        {
            Locations nextLocation = null;

            //if statement that makes sure you are not beyond map border

            if (_currentLocationCoordinates.Column < _maxColumns - 1)
            {
                Locations nextNextLocation = _mapLocations[_currentLocationCoordinates.Row, _currentLocationCoordinates.Column + 1];

                // the locations exists and the player can access location
                /* need to ask john how to make a room accessible based on recovering an item|| nextUpLocation.IsAccessibleByExperiencePoints(player.ExperiencePoints)))*/
                if ((nextNextLocation != null) && (nextNextLocation.Accessible == true))
                {
                    nextLocation = nextNextLocation;
                }
            }

            return nextLocation;
        }

        public Locations PreviousLocation()
        {
            Locations previousLocation = null;

            //if statement that makes sure you are not beyond map border

            if (_currentLocationCoordinates.Column > 0)
            {
                Locations nextPreviousLocation = _mapLocations[_currentLocationCoordinates.Row, _currentLocationCoordinates.Column - 1];

                // the locations exists and the player can access location
                /* need to ask john how to make a room accessible based on recovering an item|| nextUpLocation.IsAccessibleByExperiencePoints(player.ExperiencePoints)))*/
                if (nextPreviousLocation != null && (nextPreviousLocation.Accessible == true))
                {
                    previousLocation = nextPreviousLocation;
                }
            }

            return previousLocation;
        }
        #endregion


        #region EVENTS



        #endregion

    }
}
