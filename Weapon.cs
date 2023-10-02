using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace DiabloMod {

    public class Weapon : GlobalItem {

        // Defining ways of making the same item have different damage numbers so that we can
        // add the new Quality/Tier system. Items with higher quality/tier will do more damage and
        // have overall better stats.

        public override bool InstancePerEntity => true;
        public override void SetDefaults(Item item)
        {
            if ((item.damage < 15) & (item.damage > 0)) {
                item.damage = Main.rand.Next(1, 15);
                
            } else if ((item.damage < 35) & (item.damage > 15)) {
                item.damage = Main.rand.Next(15, 35);
            }
        }

        // Setting quality system tooltip to every item that has damage in the game.
        

        // TODO: remove old prefix system and add new one

        // Removes the old prefix system globally
        public override bool? PrefixChance(Item item, int pre, UnifiedRandom rand)
        {
            if (pre == -3) {
                return false;
            }
            if (pre == -1) {
                return false;
            }
            return false;
        }



    }

}



