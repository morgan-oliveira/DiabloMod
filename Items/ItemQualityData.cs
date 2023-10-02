using System.Collections.Generic;
using Humanizer;

namespace DiabloMod.Items {
    public class ItemQualityData{
        // dictionary that stores quality data 
        public Dictionary<int, float> ItemQualityMap {get ; private set;} = new Dictionary<int, float>();
        // using singleton pattern to ensure we can access the quality values in the dictionary
        public static ItemQualityData Instance { get; } = new ItemQualityData();

        // checks if item type exists in quality map
        public bool TryGetQuality(int itemType, out float quality) {
            if (ItemQualityMap.TryGetValue(itemType, out quality)){
                return true;
            }
            quality = 0f;
            return false;
        }

        // getter
        public float GetQuality(int itemType) {
            if (ItemQualityMap.ContainsKey(itemType)) {
                return ItemQualityMap[itemType];
            }
            return 0f;
        }

        // setter
        public void SetQuality(int itemType, float quality) {
            if (ItemQualityMap.ContainsKey(itemType)) {
                ItemQualityMap[itemType] = quality;
            }
            else {
                ItemQualityMap.Add(itemType, quality);
            }
        }        
    }
}