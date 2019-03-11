using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.Models;

namespace TBQuestGame.DataLayer
{
    public class GameData
    {
        public static Player PlayerData()
        {
            return new Player()
            {
                Id = 1,
                Name = "Joe",
                Age = 22,
                IsHuman = true,
                Health = 100,
                Sex = Player.Gender.Male,
                Lives = 3,
                ExperiencePoints = 0,
                LocationID = 0,
                PlayerSpeciality = Player.Speciality.Cyberkinetics

            };
        }

        public static List<string> InitialMessages()
        {
            return new List<string>()
            {
                "Welcome to the game!" //change this later
            };
        }
    }
}
