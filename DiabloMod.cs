using Terraria.ModLoader;
using DiabloMod.Items;
using IL.Terraria;

namespace DiabloMod
{
	public class DiabloMod : Mod
	{

       int moddedItemID;
       float qualityValue = 0.4f;
        public override void Load()
        {
            GlobalItem globalItem = new Weapon();
            GlobalItem qualityGlobal = new QualitySystem();

        }
    }
}