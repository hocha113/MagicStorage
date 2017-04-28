using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MagicStorage.Items
{
	public class ShadowDiamond : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Shadow Diamond";
			item.toolTip = "Traces of light still linger inside";
			item.width = 16;
			item.height = 16;
			item.maxStack = 99;
			item.rare = 1;
			item.value = Item.sellPrice(0, 1, 0, 0);
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}
	}
}