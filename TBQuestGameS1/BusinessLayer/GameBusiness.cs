using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.Models;
using TBQuestGame.DataLayer;
using TBQuestGame.PresentationLayer;


namespace TBQuestGame.BusinessLayer
{
    public class GameBusiness
    {
        GameSessionViewModel _gameSessionViewModel;
        Player _player = new Player(); // instantiates or rather creates a player object in the heap
        List<String> _messages;
        bool _newPlayer = true;
        PlayerSetupView _playerSetupView;

        public GameBusiness()//constructor
        {
            SetupPlayer();
            InitializeDataSet();
            InstantiateAndShowView();
        }

        //<summary>
        //initialize DataSet
        //<summary>

        private void InitializeDataSet()
        {
            _messages = GameData.InitialMessages();
        }

        //<summary>
        //initialize create View Model with data set
        //<summary>

        private void InstantiateAndShowView()
        {
            //
            // instantiate the view model and initialize the data set
            //

            _gameSessionViewModel = new GameSessionViewModel(
                _player,
                GameData.InitialMessages()
                //GameData.GameMap(),  *****************UNCOMMENT AFTER GAME MAP ID CREATED********************
                //GameData.InitialGameMapLocation()  *****************UNCOMMENT AFTER GAME MAP ID CREATED********************
                );
            GameSessionView gameSessionView = new GameSessionView(_gameSessionViewModel);

            gameSessionView.DataContext = _gameSessionViewModel;

            gameSessionView.Show();

            //
            //dialog window is initially hidden to mitigate issue with main window closing after dialog window closes
            //

            _playerSetupView.Close();
        }
        //This is the method that allows a new player setup to begin by creating a field to hold weather or not this is a new player and if so to launch the player setup window
        private void SetupPlayer()
        {
            if (_newPlayer)
            {
                _playerSetupView = new PlayerSetupView(_player);//sends the fields of the player to the player setup view to set the player properties
                _playerSetupView.ShowDialog();//launches window and returns the data after the input has been provided


                _player.ExperiencePoints = 0;
                _player.Health = 100;
                _player.Lives = 4;

            }

            else
            {
                _player = GameData.PlayerData(); //if the player is not a new player loof to the existing game data for player information
            }
        }

    }


}
    
   

