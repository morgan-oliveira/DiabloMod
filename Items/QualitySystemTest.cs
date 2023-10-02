using System;
using DiabloMod.Items;
using IL.Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace DiabloMod {

    public class QualitySystemTest {
    
        public static void QualityTest() {

            int testItemType = 24;

            float qualityValue = 0.7f;

            ItemQualityData.Instance.SetQuality(testItemType, qualityValue);

            float retrievedQuality;
            bool hasQuality = ItemQualityData.Instance.TryGetQuality(testItemType, out retrievedQuality);

            if (hasQuality) {
                Console.WriteLine($"Quality for {testItemType} is {retrievedQuality}");
            } else {
                Console.WriteLine($"Item {testItemType} does not have quality");
            }

        }
    
    }
}