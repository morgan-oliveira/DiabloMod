using System.Collections.Generic;
using Humanizer;

namespace DiabloMod.Items {
    public class ItemQualityData{
        // dictionary that stores quality data 
        public Dictionary<int, int> ItemQualityMap {get ; private set;} = new Dictionary<int, int>();
        // using singleton pattern to ensure we can access the quality values in the dictionary
        public static ItemQualityData Instance { get; } = new ItemQualityData();

        // checks if item type exists in quality map
        public bool TryGetQuality(int itemType, out int quality) {
            if (ItemQualityMap.TryGetValue(itemType, out quality)){
                return true;
            }
            quality = 0;
            return false;
        }

        // getter
        public int GetQuality(int itemType) {
            if (ItemQualityMap.ContainsKey(itemType)) {
                return ItemQualityMap[itemType];
            }
            return 0;
        }

        // setter
        public void SetQuality(int itemType, int quality) {
            if (ItemQualityMap.ContainsKey(itemType)) {
                ItemQualityMap[itemType] = quality;
            }
            else {
                ItemQualityMap.Add(itemType, quality);
            }
        }     
        // another setter

    }
}