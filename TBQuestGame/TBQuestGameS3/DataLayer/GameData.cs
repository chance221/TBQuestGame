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
                PlayerSpeciality = Player.Speciality.Cyberkinetics,
                SpecialArmor = Player.Armor.Low,

            Inventory = new ObservableCollection<GameItemQuantity>()
            {
                new GameItemQuantity(GameItemById(1001), 1),
                new GameItemQuantity(GameItemById(2010), 2)
            }

            };
        }

        private static GameItem GameItemById(int id)
        {
            return StandardGameItems().FirstOrDefault(i => i.Id == id);
        }
        
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



            gameMap.MapLocations[0, 0] = new Location()
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
                ToxicLevel = Location.Toxicity.Clean,
                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(2010), 5),
                    new GameItemQuantity(GameItemById(3001), 1)
                }

            };

            gameMap.MapLocations[0, 1] = new Location()
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
                ToxicLevel = Location.Toxicity.Clean,
                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(2010), 10),
                    new GameItemQuantity(GameItemById(1001), 1),
                    new GameItemQuantity(GameItemById(3001), 1),
                    new GameItemQuantity(GameItemById(3002), 1)
                }

            };
            
            gameMap.MapLocations[0, 2] = new Location()
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
                ToxicLevel = Location.Toxicity.Clean,
                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(2010), 30),
                    new GameItemQuantity(GameItemById(2020), 1),
                    new GameItemQuantity(GameItemById(2030), 1)
                }

            };

            gameMap.MapLocations[0, 3] = new Location()
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
                ToxicLevel = Location.Toxicity.Clean,
                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(1002), 1),
                    new GameItemQuantity(GameItemById(3002), 1)
                }

            };

            gameMap.MapLocations[0, 4] = new Location()
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
                ToxicLevel = Location.Toxicity.Clean,
                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(2010), 15),
                    new GameItemQuantity(GameItemById(1002), 1),
                    new GameItemQuantity(GameItemById(3002), 1)
                }

            };
            //need to add items to the rest of these locations
            gameMap.MapLocations[1, 4] = new Location()
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
                ToxicLevel = Location.Toxicity.Toxic,
                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(2010), 15),
                    new GameItemQuantity(GameItemById(2050), 1),
                    new GameItemQuantity(GameItemById(4001), 1)
                }

            };

            gameMap.MapLocations[1, 1] = new Location()
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
                ToxicLevel = Location.Toxicity.Unclean,
                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(1003), 1),
                    new GameItemQuantity(GameItemById(2030), 1),
                    new GameItemQuantity(GameItemById(4002), 1)
                }
            };

            gameMap.MapLocations[2, 1] = new Location()
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
                ToxicLevel = Location.Toxicity.Toxic,
                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(2010), 300),
                    new GameItemQuantity(GameItemById(2030), 1),
                    new GameItemQuantity(GameItemById(4002), 1)
                }
            };

            return gameMap;

        }


        public static List<GameItem> StandardGameItems()
        {
            return new List<GameItem>()
            {
                new Weapon(1001, "Laser Knife", 75, 1, 4, "The Star Wars fanboy had too much time and money. This cuts through most material but not very deeply", 0),
                new Weapon(1002, "Sonic Disabeler", 100, 2, 6, "Sends a disorienting frequency that auto adjust to robots and humans.", 0),
                new Weapon(1003, "Light Sabre", 125, 5, 12, "The Star Wars fanboys got more money. This is a fully functional lightsabre that cuts through all, and deeply", 0),
                new Treasure(2010, "Gold Coin", 10, Treasure.TreasureType.Coin, "With International markets constatntly in flux this is the currency of the future.", 0),
                new Treasure(2020, "Basic Armor Upgrade", 10, Treasure.TreasureType.UpgradeSpecs, "Provides Medium Armor Upgrade.", 0),
                new Treasure(2030, "GlassSteel", 50, Treasure.TreasureType.PreciousMetal, "Technology has made this light but strong material chick and fashionable.", 0),
                new Treasure(2040, "Platnum", 100, Treasure.TreasureType.PreciousMetal, "The platnum standard in metalurgy", 0),
                new Treasure(2050, "High Armor Upgrade", 10, Treasure.TreasureType.UpgradeSpecs, "Grants High Level Armor", 0),
                new Potions(3001, "Minor Repair Kit", 5, 30, 0, "Auto Repair your Tech. Add 30 points of health.",0),
                new Potions(3002, "Major Repair Kit", 5, 60, 0, "Fixes all types of tech like new (almost). Add 60 points of health.",0),
                new Relic(4001, "Biometric Key", 300, "Can open any biometeric lock at you old job.", 20, "You Can now enter the second level of your old DPS classroom.", Relic.UseActionType.OpenLocation),
                new Relic(4002, "DNA Replicator", 400, "Replicate anyone's DNA if you have a sample.", 50, "With this you will be able to sneak back into Cylon World Headquarters rooms that require top security clearance", Relic.UseActionType.OpenLocation)
            };
        }
        


    }
}
