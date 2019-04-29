
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TBQuestGame.Models;

namespace TBQuestGame.PresentationLayer
{
    /// <summary>
    /// Interaction logic for GameSessionView.xaml
    /// </summary>
    public partial class GameSessionView : Window
    {
        GameSessionViewModel _gameSessionViewModel;

        public GameSessionView(GameSessionViewModel gameSessionViewModel)
        {
            _gameSessionViewModel = gameSessionViewModel;

            InitializeComponent();
        }
        public GameSessionView()
        {
            

            #region ENUMS


            #endregion

            #region FIELDS


            #endregion

            #region PROPERTIES


            #endregion

            #region CONSTRUCTORS


            #endregion

            #region METHODS


            #endregion


        }

        private void Previous_Area_Button_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.MovePrevious();
        }


        private void Next_Area_Button_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.MoveNext();
        }


        private void Move_Up_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.MoveUp();
        }

        private void Move_Down_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.MoveDown();
        }



        private void PickUpButton_Click(object sender, RoutedEventArgs e)
        {
            if (LocationItemsDataGrid.SelectedItem != null)
            {
                _gameSessionViewModel.AddItemToInventory();
            }
        }

        private void PutDownButton_Click(object sender, RoutedEventArgs e)
        {
            if (PlayerDataTabControl.SelectedItem != null)
            {
                _gameSessionViewModel.RemoveItemFromInventory();
            }
        }

        private void UseItem_Click(object sender, RoutedEventArgs e)
        {
            if (PlayerDataTabControl.SelectedItem != null)
            {
                _gameSessionViewModel.OnUseGameItem();
            }
        }

        private void SpeakToButton_Click(object sender, RoutedEventArgs e)
        {
            if (LocationNpcsDataGrid.SelectedItem != null)
            {
                _gameSessionViewModel.OnPlayerTalkTo();
            }
        }

        private void AttackButton_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.OnPlayerAttack();
        }

        private void DefendButton_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.OnPlayerDefend();
        }

        private void RetreatButton_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.OnPlayerRetreat();
        }
    }
}
