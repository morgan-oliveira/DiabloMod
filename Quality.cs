using System;
using System.Collections.Generic;
using Humanizer;
using Terraria;
using Terraria.ModLoader;
using DiabloMod.Items;

namespace DiabloMod {

    public class Quality : GlobalItem {

        private const float PreHardmodeMaxQuality = 0.9f;

        public override bool InstancePerEntity => true;

        // update tooltip with item quality
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if(ItemQualityData.Instance.ItemQualityMap.ContainsKey(item.type)) {
                float quality = ItemQualityData.Instance.ItemQualityMap[item.type];
                tooltips.Add(new TooltipLine(Mod, "Quality", $"Quality: {quality * 100}%"));
            }
        }

        public void QualityRandomizer(Item item) {
            // low quality parameter
            float lowQuality = 0.5f;

            // quality, obviously
            float quality;
            // checks if item has damage and if there is quality associated
            if (item.damage > 0 && ItemQualityData.Instance.TryGetQuality(item.type, out quality)) {
                float randomValue = Main.rand.NextFloat();
                float randomQuality;
                if (randomValue < lowQuality) {
                    randomQuality = Main.rand.NextFloat(0f, 0.6f);
                }
                else {
                    randomQuality = Main.rand.NextFloat(0.6f, 1.0f);
                }
                ItemQualityData.Instance.SetQuality(item.type, randomQuality);
            }
        }

    }
}