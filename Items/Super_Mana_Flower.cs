using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace UJMR.Items
{
	public class Super_Mana_Flower	: ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Super Mana Flower");
			Tooltip.SetDefault("10% reduced mana usage\nEnemies are less likely to target you\nAutomatically use mana potions when needed\n+50 Mana");
		}

		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 52;
			item.accessory = true;
			item.value = Item.sellPrice(0, 10, 0, 0);
			item.rare = 8;
		}
		
public override void UpdateAccessory(Player player, bool hideVisual)
{
	player.manaFlower = true;
	player.aggro -= 500;
	player.manaCost -= 0.1f;
	player.statManaMax2 += 50;
    }
	
		    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
		recipe.AddIngredient (555);
		recipe.AddIngredient (null, "Ancient_Flower");
		recipe.AddIngredient (2209);
        recipe.SetResult(this);
        recipe.AddTile(114);
        recipe.AddRecipe();
    }	
   
}}