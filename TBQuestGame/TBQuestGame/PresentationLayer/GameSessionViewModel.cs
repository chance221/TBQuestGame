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
    
    public class GameSessionViewModel
    {
        #region ENUMS


        #endregion

        #region FIELDS
        private Player _player;
        private List<string> _messages;

        




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
