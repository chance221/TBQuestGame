using System;
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
// <summary>
// Interaction logic for PlayerSetupView.xaml
// </summary>
    public partial class PlayerSetupView : Window
    {
        private Player _player;

        public PlayerSetupView(Player player)
        {
            _player = player;

            InitializeComponent();

            SetupWindow();


        }

        private void SetupWindow()
            {
            
                List<string> speciality = Enum.GetNames(typeof(Player.Speciality)).ToList();
                ComboBox1.ItemsSource = speciality;
            
            ErrorMessageTextBlock.Visibility = Visibility.Hidden;

            }

        

        //
        //event handler for OK Button
        //
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage;

            if (IsValidInput(out errorMessage))
            {
                //
                // get values from combo box
                //

                Enum.TryParse(ComboBox1.SelectionBoxItem.ToString(), out Player.Speciality speciality);

                //
                //set player properties
                //

                _player.PlayerSpeciality = speciality;

                Visibility = Visibility.Hidden;
            }
            else
            {
                //
                //display error message
                //

                ErrorMessageTextBlock.Visibility = Visibility.Visible;
                ErrorMessageTextBlock.Text = errorMessage;
            }
        }
        //validate user Input for name and generate appropriate error message if not
        //
        //This returns if the user input is valid and if not the appropriate error message

        private bool IsValidInput(out string errorMessage)
        {
            errorMessage = "";
            if (NameTextBox.Text == "")
            {
                errorMessage += "Player Name is Required";
            }
            else
            {
                _player.Name = NameTextBox.Text;
            }
            if (!int.TryParse(AgeTextBox.Text, out int age))
            {
                errorMessage += "Player Age is required and must be an integer. \n";

            }
            else
            {
                _player.Age = age;
            }

            return errorMessage == "" ? true : false;
        }


        //sets placeholder text need to understand syntax
        

        public void RemoveText(object sender, EventArgs e)
        {
            AgeTextBox.Text = "";
        }

        public void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AgeTextBox.Text))
                AgeTextBox.Text = "Enter text here...";
        }
        
        
    }

    
}
