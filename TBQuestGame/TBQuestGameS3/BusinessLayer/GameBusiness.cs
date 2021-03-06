﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.Models;
using TBQuestGame.DataLayer;
using TBQuestGame.PresentationLayer;
using System.Collections.ObjectModel;


namespace TBQuestGame.BusinessLayer
{
    public class GameBusiness
    {
        GameSessionViewModel _gameSessionViewModel;
        Player _player = new Player(); 
        bool _newPlayer = true;
        PlayerSetupView _playerSetupView;
        private List<string> _messages;
        ExoSuit _exoSuit = new ExoSuit();
        Robot _robot = new Robot();
        

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
                GameData.GameMap(),
                GameData.InitialGameMapLocation()
                

                );
            GameSessionView gameSessionView = new GameSessionView(_gameSessionViewModel);

            gameSessionView.DataContext = _gameSessionViewModel;

            gameSessionView.Show();

            //
            //dialog window is initially hidden to mitigate issue with main window closing after dialog window closes
            //

            _playerSetupView.Close();
        }
        
        private void SetupPlayer()
        {
            

            if (_newPlayer)
            {
                _playerSetupView = new PlayerSetupView(_player);//sends the fields of the player to the player setup view to set the player properties
                _playerSetupView.ShowDialog();//launches window and returns the data after the input has been provided
                _player.ExperiencePoints = 0;
                _player.Health = 100;
                _player.Lives = 4;


                _player.SpecialArmor = Player.Armor.Low; 
                _player.Inventory = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemById(1001), 1),
                    new GameItemQuantity(GameItemById(2010), 2)
                };


            }

            else
            {
                _player = GameData.PlayerData(); //if the player is not a new player look to the existing game data for player information
            }
        }

        private static GameItem GameItemById(int id)
        {
            return GameData.StandardGameItems().FirstOrDefault(i => i.Id == id);
        }   
      
    }

    
}
