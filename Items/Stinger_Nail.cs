using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UJMR.Items
{
	public class Stinger_Nail : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stinger Nail");
		}
		
		public override void SetDefaults()
		{
			item.damage = 12;
			item.ranged = true;
			item.width = 24;
			item.height = 24;
			item.maxStack = 999;
			item.consumable = true;
			item.knockBack = 0f;
			item.value = Item.buyPrice(0, 0, 0, 10);
			item.rare = 7;
			item.shoot = mod.ProjectileType("Stinger_Nail");
			item.shootSpeed = 10f;
			item.ammo = mod.ItemType("Stinger_Nail");
		}
	}
}