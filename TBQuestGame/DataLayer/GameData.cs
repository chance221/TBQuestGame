using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.Models;
using System.Collections.ObjectModel;

namespace TBQuestGame.DataLayer
{
    public  static class GameData
    {
        //public static Player PlayerData()
        //{
        //    return new Player();
        //    //{
        //    //    Id = 1,
        //    //    Name = "Joe",
        //    //    Age = 22,
        //    //    IsHuman = true,
        //    //    Health = 100,
        //    //    Sex = Player.Gender.Male,
        //    //    Lives = 3,
        //    //    ExperiencePoints = 0,
        //    //    LocationID = 0,
        //    //    PlayerSpeciality = Player.Speciality.Cyberkinetics

        //    //};
        //}

        public static List<string> InitialMessages()
        {
            return new List<string>()
            {
                "Over the past 20 years Cylon Inc. has developed into the leading company in robotics, cyberkinetics and artificial intelligence"+
                "We are looking for the best and brightest to develop into the tech leaders of tomorrow. " //change this later
            };
        }

        public static GameMapCoordinates InitialGameMapLocation()
        {
            return new GameMapCoordinates() { Row = 0, Column = 0 };
        }


        //public static Locations InitialGameMapLocation()
        //{
        //    return new Locations()
        //    {
        //        ID = 000,
        //        Name = "Detroit Public Schools Class Room",
        //        Description = "This is where it all begins, the class room where you chose your speciality and began Your journey down the path to techonoligical enightenment." +
        //        "It feels like home except for the ominous feeling that you are constantly being watched",
        //        Accessible = true,
        //        RequiredXP = 0,
        //        ModifyXP = 50,
        //        ModifyHealath = 0,
        //        ModifyLives = 0,
        //        ItemRequired = false,
        //        ToxicLevel = Locations.Toxicity.Clean


        //    };
        //}

        
        public static Map GameMap()
        {
            int rows = 3;
            int columns = 5;

            Map gameMap = new Map(rows, columns);

            

            gameMap.MapLocations[0, 0] = new Locations()
            {
                ID = 000,
                Name = "Detroit Public Schools Class Room",
                Description = "This is where it all begins, the class room where you chose your speciality and began Your journey down the path to techonoligical enightenment." +
                "It feels like home except for the ominous feeling that you are constantly being watched",
                Accessible = true,
                RequiredXP = 0,
                ModifyXP = 50,
                ModifyHealath = 0,
                ModifyLives = 0,
                Message = "\tTest Message",
                ItemRequired = false,
                ToxicLevel = Locations.Toxicity.Clean

            };

            gameMap.MapLocations[0, 1] = new Locations()
            {
                ID = 001,
                Name = "Cylon Inc. HeadQuaters - Lab",
                Description = "Your sanctuary, the lab is where you do the research that is to help countless lives by focusing on your speciality.",
                Accessible = true,
                RequiredXP = 0,
                ModifyXP = 50,
                ModifyHealath = 0,
                ModifyLives = 0,
                Message = "\tTest Message",
                ItemRequired = false,
                ToxicLevel = Locations.Toxicity.Clean

            };


            gameMap.MapLocations[0, 2] = new Locations()
            {
                ID = 002,
                Name = "Hideout",
                Description = "No longer considered a law abiding citizen you come here to work out your plan to prove your innocence. All the tools of your lab with a touch of cloak and dagger",
                Accessible = true,
                RequiredXP = 0,
                ModifyXP = 50,
                ModifyHealath = 0,
                ModifyLives = 0,
                Message = "\tTest Message",
                ItemRequired = false,
                ToxicLevel = Locations.Toxicity.Clean

            };

            gameMap.MapLocations[0, 3] = new Locations()
            {
                ID = 003,
                Name = "Smallville",
                Description = "Smallville was the pilot city to discover the limits of the Super Powerful AI Krista in suveillance, law enforcement and municipal management. You must discover the secrets behinds the AI's power here.",
                Accessible = true,
                RequiredXP = 0,
                ModifyXP = 50,
                ModifyHealath = 0,
                ModifyLives = 0,
                Message = "\tTest Message",
                ItemRequired = false,
                ToxicLevel = Locations.Toxicity.Clean

            };

            gameMap.MapLocations[0, 4] = new Locations()
            {
                ID = 004,
                Name = "New Detroit",
                Description = "The progress made by employing the A.I. Krista is undeniable as New Detroit has become the most modern and responsive municipality in the United States, but at what cost?",
                Accessible = true,
                RequiredXP = 0,
                ModifyXP = 50,
                ModifyHealath = 0,
                ModifyLives = 0,
                Message = "\tTest Message",
                ItemRequired = false,
                ToxicLevel = Locations.Toxicity.Clean

            };


            gameMap.MapLocations[1, 4] = new Locations()
            {
                ID = 005,
                Name = "Old Detroit",
                Description = "The ruins of this old city hold the remeants of the people and culture that was Detroit before Cylon Inc. It also holds answers.",
                Accessible = true,
                RequiredXP = 0,
                ModifyXP = 50,
                ModifyHealath = 0,
                ModifyLives = 0,
                Message = "\tTest Message",
                ItemRequired = false,
                ToxicLevel = Locations.Toxicity.Toxic

            };

            gameMap.MapLocations[1, 1] = new Locations()
            {
                ID = 006,
                Name = "Cylon Inc. - Level 2",
                Description = "Known as the innovators of tomorrow Cylon Inc is one of the most secure buildings on the planet. You break in to clear your name.",
                Accessible = true,
                RequiredXP = 0,
                ModifyXP = 200,
                ModifyHealath = 0,
                ModifyLives = 0,
                Message = "\tTest Message",
                ItemRequired = false,
                ToxicLevel = Locations.Toxicity.Unclean
            };


            gameMap.MapLocations[2, 1] = new Locations()
            {
                ID = 007,
                Name = "Cylon Inc. - Level 3",
                Description = "The top floor of Cylon Inc holds the mysterious CEO's office and represents the end of your Journey",
                Accessible = true,
                RequiredXP = 0,
                ModifyXP = 100,
                ModifyHealath = 0,
                ModifyLives = 0,
                Message = "\tTest Message",
                ItemRequired = false,
                ToxicLevel = Locations.Toxicity.Toxic
            };

            return gameMap;

        }

       
        //ObservableCollection<Locations> locations = new ObservableCollection<Locations>()
        //{


        //    new Locations(){
        //    ID = 000,
        //    Name = "Detroit Public Schools Class Room",
        //    Description = "This is where it all begins, the class room where you chose your speciality and began Your journey down the path to techonoligical enightenment." +
        //    "It feels like home except for the ominous feeling that you are constantly being watched",
        //    Accessible = true,
        //    RequiredXP = 0,
        //    ModifyXP = 50,
        //    ModifyHealath = 0,
        //    ModifyLives = 0,
        //    ItemRequired = false,
        //    ToxicLevel = Locations.Toxicity.Clean
        //    },

        //    new Locations()
        //    {
        //    ID = 001,
        //    Name = "Cylon Inc. HeadQuaters - Lab",
        //    Description = "Your sanctuary, the lab is where you do the research that is to help countless lives by focusing on your speciality.",
        //    Accessible = true,
        //    RequiredXP = 0,
        //    ModifyXP = 50,
        //    ModifyHealath = 0,
        //    ModifyLives = 0,
        //    ItemRequired = false,
        //    ToxicLevel = Locations.Toxicity.Clean
        //    },

        //    new Locations()
        //    {
        //    ID = 002,
        //    Name = "Hideout",
        //    Description = "No longer considered a law abiding citizen you come here to work out your plan to prove your innocence. All the tools of your lab with a touch of cloak and dagger",
        //    Accessible = false,
        //    RequiredXP = 0,
        //    ModifyXP = 50,
        //    ModifyHealath = 0,
        //    ModifyLives = 0,
        //    ItemRequired = false,
        //    ToxicLevel = Locations.Toxicity.Clean

        //    },

        //    new Locations()
        //    {
        //    ID = 003,
        //    Name = "Smallville",
        //    Description = "Smallville was the pilot city to discover the limits of the Super Powerful AI Krista in suveillance, law enforcement and municipal management. You must discover the secrets behinds the AI's power here.",
        //    Accessible = false,
        //    RequiredXP = 0,
        //    ModifyXP = 50,
        //    ModifyHealath = 0,
        //    ModifyLives = 0,
        //    ItemRequired = false,
        //    ToxicLevel = Locations.Toxicity.Clean

        //    },

        //    new Locations()
        //    {
        //    ID = 004,
        //    Name = "New Detroit",
        //    Description = "The progress made by employing the A.I. Krista is undeniable as New Detroit has become the most modern and responsive municipality in the United States, but at what cost?",
        //    Accessible = false,
        //    RequiredXP = 0,
        //    ModifyXP = 50,
        //    ModifyHealath = 0,
        //    ModifyLives = 0,
        //    ItemRequired = false,
        //    ToxicLevel = Locations.Toxicity.Clean
        //    },

        //    new Locations()
        //    {
        //    ID = 005,
        //    Name = "Old Detroit",
        //    Description = "The ruins of this old city hold the remeants of the people and culture that was Detroit before Cylon Inc. It also holds answers.",
        //    Accessible = false,
        //    RequiredXP = 0,
        //    ModifyXP = 50,
        //    ModifyHealath = 0,
        //    ModifyLives = 0,
        //    ItemRequired = false,
        //    ToxicLevel = Locations.Toxicity.Toxic
        //    },

        //    new Locations()
        //    {
        //    ID = 006,
        //    Name = "Cylon Inc. - Level 2",
        //    Description = "Known as the innovators of tomorrow Cylon Inc is one of the most secure buildings on the planet. You break in to clear your name.",
        //    Accessible = false,
        //    RequiredXP = 0,
        //    ModifyXP = 50,
        //    ModifyHealath = 0,
        //    ModifyLives = 0,
        //    ItemRequired = false,
        //    ToxicLevel = Locations.Toxicity.Unclean
        //    },

        //    new Locations()
        //    {
        //    ID = 007,
        //    Name = "Cylon Inc. - Level 3",
        //    Description = "The top floor of Cylon Inc holds the mysterious CEO's office and represents the end of your Journey",
        //    Accessible = false,
        //    RequiredXP = 0,
        //    ModifyXP = 100,
        //    ModifyHealath = 0,
        //    ModifyLives = 0,
        //    ItemRequired = false,
        //    ToxicLevel = Locations.Toxicity.Toxic
        //    },

        //};


    }
}
