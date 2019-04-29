using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.Models;
using System.Collections.ObjectModel;

namespace TBQuestGame.DataLayer
{
    public static class GameData
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
                SkillLevel = 5,
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

        private static Npc NpcById(int id)
        {
            return Npcs().FirstOrDefault(i => i.Id == id);
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
                Message = "\tIn your education pod you see only whats in your VR headset showing the instructor and a book showing an intro intro to your speciality",
                ItemRequired = false,
                ToxicLevel = Location.Toxicity.Clean,
                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(2010), 5),
                    new GameItemQuantity(GameItemById(3001), 1),
                    new GameItemQuantity(GameItemById(4003), 1)
                },

                Npcs = new ObservableCollection<Npc>()
                {
                    NpcById(8001),
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
                Message = "\tAfter years of hard work you have obtained top level clearance but the more you learn about the malicious plans of the company the less you trust the AI that runs the metropolitan city. It will be one of the first to be completely run by the AI Krista and you are highly suspicious.",
                ItemRequired = false,
                ToxicLevel = Location.Toxicity.Clean,
                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(2010), 6),
                    
                    new GameItemQuantity(GameItemById(1001), 1),
                    new GameItemQuantity(GameItemById(4004), 1)
                },

                Npcs = new ObservableCollection<Npc>()
                {
                    NpcById(8002),
                    NpcById(9003),
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
                Message = "\tYou have programmed your own AI to combat the mallicious plot set in motion by your formaer employer. Only you can provide all the data necessary to formulate a plan to stop Cylon Inc.",
                ItemRequired = false,
                ToxicLevel = Location.Toxicity.Clean,
                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(2010), 30),
                    new GameItemQuantity(GameItemById(2020), 1),
                    new GameItemQuantity(GameItemById(2030), 1),
                },

                Npcs = new ObservableCollection<Npc>()
                {
                    NpcById(8003),
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
                Message = "\tYou must ask around about former workers of Cylon Inc to discover the weakness to the all powerful AI Krista",
                ItemRequired = false,
                ToxicLevel = Location.Toxicity.Clean,
                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(1002), 1),
                    new GameItemQuantity(GameItemById(3002), 1)
                },

                Npcs = new ObservableCollection<Npc>()
                {
                    NpcById(8005),
                }
            };

            gameMap.MapLocations[0, 4] = new Location()
            {
                ID = 004,
                Name = "New Detroit Labs",
                Description = "The progress made by employing the A.I. Krista is undeniable as New Detroit has become the most modern and responsive municipality in the United States, but at what cost?",
                Accessible = true,
                RequiredXP = 0,
                ModifyXP = 50,
                ModifyHealath = 0,
                ModifyLives = 0,
                Message = "\tAlot of Cool stuff lying around here you should pick it up to keep your space tidy, but you notice someonw sitting in the corner slumped over",
                ItemRequired = false,
                ToxicLevel = Location.Toxicity.Clean,
                GameItems = new ObservableCollection<GameItemQuantity>
                {
                    new GameItemQuantity(GameItemById(2010), 1),
                    new GameItemQuantity(GameItemById(1003), 1),
                    new GameItemQuantity(GameItemById(3002), 1)
                },

                Npcs = new ObservableCollection<Npc>()
                {
                    NpcById(9001),
                }

            };
            
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
                    
                    new GameItemQuantity(GameItemById(2050), 1),
                    new GameItemQuantity(GameItemById(4001), 1)
                },
                Npcs = new ObservableCollection<Npc>()
                {
                    NpcById(9002),
                    NpcById(8004)
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
                    
                    new GameItemQuantity(GameItemById(2030), 1),
                    new GameItemQuantity(GameItemById(4002), 1)
                },

                Npcs = new ObservableCollection<Npc>()
                {
                    NpcById(9004),
                    NpcById(8006)
                }
            };

            gameMap.MapLocations[2, 1] = new Location()
            {
                ID = 007,
                Name = "Cylon Inc. - Level 3",
                Description = "The top floor of Cylon Inc holds the mysterious CEO's office and represents the end of your Journey you find no one other than the AI Krista in human form. Prepare for battle",
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
                    
                },
                Npcs = new ObservableCollection<Npc>()
                {
                    NpcById(9005),
                    
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
                new Relic(4002, "DNA Replicator", 400, "Replicate anyone's DNA if you have a sample.", 50, "With this you will be able to sneak back into Cylon World Headquarters rooms that require top security clearance", Relic.UseActionType.OpenLocation),
                new Relic(4003, "Diploma of Success", 13, "This is proof that you have finished school and can now start your new life", 20, "You can now move to the next location", Relic.UseActionType.OpenLocation),
                new Relic(4004, "Hidden Directive Clue - 1", 0, "This details the world dominition plan beginning with letting the AI Krista gain access to all government resources. Your project manager died for this info",30, "With this you should hightail it to your Hideout", Relic.UseActionType.OpenLocation),
            };
        }
        public static List<Npc> Npcs()
        {
            return new List<Npc>()
            {
                new Military()
                {
                    Id = 9001,
                    Name = "Security Officer Kain",
                    IsHuman = true,
                    Description = "He looks mean and smells dangerous.",
                    Messages = new List<string>()
                    {
                        "You are not supposed to be here.",
                        "Remaining is not an option.",
                        "You were warned."
                    },
                   SkillLevel = 3,
                   CurrentWeapon = GameItemById(1001) as Weapon
                },

                 new Military()
                {
                    Id = 9003,
                    Name = "Mysterious Figure",
                    IsHuman = true,
                    Description = "You have never met this man but feel like you are somehow connected. He's wearing all black which is rediculious in the summer heat.",
                    Messages = new List<string>()
                    {
                        "Sorry to do this to you",
                        "You ask too many questions",
                        "Here's looking at you kid"
                    },
                   SkillLevel = 5,
                   CurrentWeapon = GameItemById(1001) as Weapon
                },

                new Military()
                {
                    Id = 9002,
                    Name = "Hunter John",
                    IsHuman = true,
                    Description = "Outfitted in the latest bio-tech the golden eyes see seemingly into the future.",
                    Messages = new List<string>()
                    {
                        "I am here to bring you to justice.",
                        "I'm going to enjoy this.",
                        "THIS IS IMPOSSIBLE."
                    },
                   SkillLevel = 6,
                   CurrentWeapon = GameItemById(1002) as Weapon
                },

                new Military()
                {
                    Id = 9004,
                    Name = "Big Boss",
                    IsHuman = true,
                    Description = "What is it with these guys and weird colored eyes?!? His purple iris' Appear to peer deep into your soul.",
                    Messages = new List<string>()
                    {
                        "No one puts baby in the corner!",
                        "WE ARE THE FUTURE!!!!.",
                        "I can't let you live."
                    },
                   SkillLevel = 8,
                   CurrentWeapon = GameItemById(1001) as Weapon
                },

                new Military()
                {
                    Id = 9005,
                    Name = "Krista",
                    IsHuman = false,
                    Description = "The AI has built herself a biogenetically engineered body and it cannot be trusted",
                    Messages = new List<string>()
                    {
                        "Submit!",
                        "I AM THE FUTURE!!!!.",
                        "You will love me and you will like it!"
                    },
                   SkillLevel = 5,
                   CurrentWeapon = GameItemById(1003) as Weapon
                },


                new Citizen()
                {
                    Id = 8005,
                    Name = "Reception Robot",
                    IsHuman = false,
                    Description = "A standard of the times this human looking robot even sounds more welcoming than your co-workers... weird",
                    Messages = new List<string>()
                    {
                        "How's it goin'? Were you able to catch the Lions last week. They can make even a robot like me depressed",
                        "You look like you need some help."
                    }
                },

                new Citizen()
                {
                    Id = 8004,
                    Name = "Old Fart",
                    IsHuman = true,
                    Description = "No one knows exactly how old old John is but he looks amazing for his age",
                    Messages = new List<string>()
                    {
                        "You'll never take me alive!!!",
                        "Oh I didn't know you were fighting against their takeover as well",
                        "Something in this room should help you though I know not what"
                    }
                },

                new Citizen()
                {
                    Id = 8003,
                    Name = "Buddy the AI",
                    IsHuman = false,
                    Description = "A  hologram of your own making you treat him like a member of your family",
                    Messages = new List<string>()
                    {
                        "Why the worried look? Framed for murder... that's unplesant",
                        "You need more facts please let me know when I can be of assistance."
                    }
                },

                 new Citizen()
                {
                    Id = 8002,
                    Name = "Dead Guy",
                    IsHuman = true,
                    Description = "You turn the chair around to see your project manager dead from a laser knife to the armpit. He does not look peaceful",
                    Messages = new List<string>()
                    {
                        "Tell my mother that I love her. Oh and that I'm dead.",
                        
                    }
                },
                new Citizen()
                {
                    Id = 8001,
                    Name = "Holo-Teacher",
                    IsHuman = false,
                    Description = "A trnaslucent blue hologram of a man this bot holds the key to your future",
                    Messages = new List<string>()
                    {
                        "Remember that we care about the whole you and not just the genius level talent you posses",
                        "What can I help you with.",
                        "No I don't speak about anything other than the carriculum, but if you keep questining the program people will become suspicios",
                        "It's best to have a montaj showing how hard you worked before moving on to the next scene"
                    }
                },
                new Citizen()
                {
                    Id = 8006,
                    Name = "Dr. Baxter",
                    IsHuman = true,
                    Description = "An eccentric through and through you wonder where he got the Zebra print lab coat.",
                    Messages = new List<string>()
                    {
                        "You gotta save me she's forcing me to build her a body but I don't wanna.",
                        "Please help!",
                        "You just put the lime in the coconut and voila you have a biogenetically engnieered human body of perfection"
                    }
                }
            };
        }
    }



}
