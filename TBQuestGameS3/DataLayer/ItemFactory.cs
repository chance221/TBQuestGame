using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.Models;

namespace TBQuestGame.DataLayer
{
    public static class ItemFactory
    {
        private static List<GameItem> _standardGameItems;

        static ItemFactory()
        {
            _standardGameItems = GameData.StandardGameItems();
        }

        public static GameItem CreateGameItem(int id)
        {
            GameItem standardItem = _standardGameItems.FirstOrDefault(item => item.Id == id);

            if (standardItem != null)
            {
                return standardItem.Clone();
            }

            return null;
        }
    }
}
