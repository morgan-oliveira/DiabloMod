using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace DiabloMod.Items {
    public class QualitySystem : GlobalItem {
        private const float PreHardmodeQualityMax = 0.9f;

        public override bool InstancePerEntity => true;

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (item.damage > 0 || item.defense > 0) {
                AssignQualityIfNeeded(item);
                float quality = GetQuality(item);
                ModifyItemStats(item, quality);
                AddQualityTooltip(item, quality, tooltips);
            }
        }
        private float GetQuality(Item item) {
            if (ItemQualityData.Instance.TryGetQuality(item.type, out float quality)) {
                return quality;
            }
            return 0f;
        }
        private void AssignQualityIfNeeded(Item item) {
            if (!ItemQualityData.Instance.ItemQualityMap.ContainsKey(item.type)) {
                float qualityValue = QualityCalculation(item);
                ItemQualityData.Instance.ItemQualityMap[item.type] = qualityValue;
            }
        }
        private void ModifyItemStats(Item item, float quality) {
            item.damage = (int)(item.damage * (quality * 2));
            if (item.defense > 0) {
                item.defense = (int)(item.defense * (quality * 0.5));
            }
        }
        private void AddQualityTooltip(Item item, float quality, List<TooltipLine> tooltips) {

            // rounding numbers
            int decimalPlaces = 1;
            float roundedQuality = (float)Math.Round(quality, decimalPlaces);

            TooltipLine qualityTooltip = new TooltipLine(Mod, "Quality", $"Quality: {roundedQuality * 100:F}%");
            qualityTooltip.OverrideColor = new Color(255, 255, 0);
            tooltips.Add(qualityTooltip);
        }
        private float QualityCalculation(Item item) {
            return Main.rand.NextFloat(0.0f, PreHardmodeQualityMax);
        }

    }
}