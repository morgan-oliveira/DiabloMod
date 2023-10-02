using Terraria.ModLoader;
using DiabloMod.Items;

namespace DiabloMod
{
	public class DiabloMod : Mod
	{

        public override void Load()
        {
            GlobalItem globalItem = new Weapon();
            GlobalItem qualityGlobal = new Quality();
        }

    }
}