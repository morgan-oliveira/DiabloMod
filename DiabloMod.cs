using Terraria.ModLoader;
using DiabloMod.Items;

namespace DiabloMod
{
	public class DiabloMod : Mod
	{

       int moddedItemID;
       float qualityValue = 0.4f;
        public override void Load()
        {
            GlobalItem globalItem = new Weapon();
            GlobalItem qualityGlobal = new Quality();

            // Getting modded item ID to test quality system
            moddedItemID = ModContent.ItemType<Items.ShortSword>();

            // Setting modded item ID to quality data structure, so that we can assign it's ID to the designed quality value
            ItemQualityData.Instance.SetQuality(moddedItemID, qualityValue);

        }


    }
}