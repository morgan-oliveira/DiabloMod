using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace DiabloMod.Items {
    public class QualitySystem : GlobalItem {
        private const int PreHardmodeQualityMax = 90;

        public override bool InstancePerEntity => true;

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (item.damage > 0 || item.defense > 0) {
                AssignQualityIfNeeded(item);
                int quality = GetQuality(item);
                ModifyItemStats(item, quality);
                AddQualityTooltip(item, quality, tooltips);
            }
        }

        
        private int GetQuality(Item item) {
            if (ItemQualityData.Instance.TryGetQuality(item.type, out int quality)) {
                return quality;
            }
            return 0;
        }
        private void AssignQualityIfNeeded(Item item) {
            if (!ItemQualityData.Instance.ItemQualityMap.ContainsKey(item.type)) {
                int qualityValue = QualityCalculation(item);
                ItemQualityData.Instance.ItemQualityMap[item.type] = qualityValue;
            }
        }
        private void ModifyItemStats(Item item, int quality) {
            item.damage = (item.damage * (quality * 2));
            if (item.defense > 0) {
                item.defense = (int)(item.defense * (quality * 0.5));
            }
        }
        private void AddQualityTooltip(Item item, int quality, List<TooltipLine> tooltips) {

            TooltipLine qualityTooltip = new TooltipLine(Mod, "Quality", $"Quality: {quality}%");
            qualityTooltip.OverrideColor = new Color(255, 255, 0);
            tooltips.Add(qualityTooltip);
        }
        private int QualityCalculation(Item item) {
            int minQuality = 0;
            int randomQuality = Main.rand.Next(minQuality, PreHardmodeQualityMax + 1);
            return randomQuality;
        }

    }
}