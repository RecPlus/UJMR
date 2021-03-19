using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace UJMR.Items
{
	public class Ancient_Flower	: ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ancient Flower");
			Tooltip.SetDefault("8% reduced mana usage\nEnemies are less likely to target you\n+40 Mana");
		}

		public override void SetDefaults()
		{
			item.width = 42;
			item.height = 30;
			item.accessory = true;
			item.value = Item.sellPrice(0, 8, 0, 0);
			item.rare = 7;
		}
		
public override void UpdateAccessory(Player player, bool hideVisual)
{
	player.aggro -= 500;
	player.manaCost -= 0.08f;
	player.statManaMax2 += 40;
    }
   
}}