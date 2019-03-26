using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using TBQuestGame.Models;

namespace TBQuestGame.PresentationLayer
{
    // When you create a view model it ALWAYS goes to the constructor first so if you need informatin to be passed into the view model before launching put it in the constructor
    public class GameSessionViewModel
    {
        #region ENUMS


        #endregion

        #region FIELDS
        private Player _player;
        private List<string> _messages;
        private DateTime _gameStartTime;






        #endregion

        #region PROPERTIES

        public Player Player
        {
            get { return _player; }
            set { _player = value; }
        }

        public string MessageDisplay
        {
            get { return string.Join("\n\n", _messages); }

        }

        #endregion

        #region CONSTRUCTORS

        public GameSessionViewModel()
        {

        }

        public GameSessionViewModel(Player Player, List<string> InitialMessages)
        {
            _player = Player;
            _messages = InitialMessages;
            // if you want a timer in the view model it MUST be in the constructor
            InitializeView();

        }

        private void InitializeView()
        {
            _gameStartTime = DateTime.Now;
        }


        /// <summary>
        /// generates a sting of mission messages with time stamp with most current first
        /// </summary>
        /// <returns>string of formated mission messages</returns>
        private string FormatMessagesForViewer()
        {
            List<string> lifoMessages = new List<string>(); //creates a list of messages

            for (int index = 0; index < _messages.Count; index++) // Adds the message to the list then goes through each message in the list and adds a time stamp
            {
                lifoMessages.Add($" <T:{GameTime().ToString(@"hh\:mm\:ss")}> " + _messages[index]);
            }

            lifoMessages.Reverse(); // ensures most latest message in list will be displayed at the top

            return string.Join("\n\n", lifoMessages); // formats spacing to ensure message is easily seperated from others and readable 
        }

        /// <summary>
        /// running time of game
        /// </summary>
        /// <returns></returns>
        private TimeSpan GameTime()
        {
            return DateTime.Now - _gameStartTime;
        }
        #endregion

        #region METHODS



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
