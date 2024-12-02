using System.Collections.Generic;
using ScriptableObjects;
using ScriptableObjects.Data;

namespace Helpers
{
    public static class ItemDataExtensions
    {
        public static T[] FilterByRarity<T>(this T[] list, RarityData rarity) where T : ItemData
        {
            var filteredList = new List<T>();
            for (var i = 0; i < list.Length; i++)
                if (list[i].Rarity == rarity)
                    filteredList.Add(list[i]);
            return filteredList.ToArray();
        }   
    }
}