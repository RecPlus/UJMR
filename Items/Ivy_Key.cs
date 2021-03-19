using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UJMR.Items {
public class Ivy_Key : ModItem
{
	public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ivy Key");
			Tooltip.SetDefault("'Charged with the essence of many souls and organic matter'\nSummons a Jungle Mimic");
		}
    public override void SetDefaults()
    {
        item.width = 28;
        item.height = 28;
        item.maxStack = 20;
        item.value = 500;
        item.rare = 7;
        item.useAnimation = 30;
        item.useTime = 30;
        item.useStyle = 4;
        item.consumable = true;
    }
	
	    public override bool CanUseItem(Player player)
    {
        return NPC.CountNPCS(476) < 1;
    }

    public override bool UseItem(Player player)
    {
		int ran = Main.rand.Next(1, 3);
		if (ran == 1)NPC.NewNPC((int)player.Center.X - 75, (int)player.position.Y - 75, mod.NPCType("JMimic_Spawn"));
		if (ran == 2)NPC.NewNPC((int)player.Center.X + 75 , (int)player.position.Y - 75, mod.NPCType("JMimic_Spawn"));
        Main.PlaySound(22, (int)player.position.X, (int)player.position.Y, 0);
		

        return true;
    }

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        recipe.AddIngredient (3091);
		recipe.AddIngredient (3092);
		recipe.AddIngredient(547);
		recipe.AddIngredient(548);
		recipe.AddIngredient(549);
        recipe.AddIngredient (210);
        recipe.AddIngredient (331, 3);		
        recipe.SetResult(this, 2);
        recipe.AddTile(134);
        recipe.AddRecipe();
    }

}}
