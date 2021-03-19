using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;

namespace UJMR.Items {
public class Hornet_Nailgun : ModItem
{
public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hornet Nailgun");
			Tooltip.SetDefault("");
		}
    public override void SetDefaults()
    {
        item.damage = 65;
        item.ranged = true;
        item.width = 60; 
        item.height = 34; 
        item.useTime = 25;
        item.useAnimation = 25;
        item.useStyle = 5; 
        item.noMelee = true;
        item.knockBack = 3f;
        item.rare = 7;
        item.value = Item.sellPrice(0, 15, 0, 0);
        item.UseSound = SoundID.Item108; 
        item.autoReuse = true;
        item.shoot = mod.ProjectileType("Stinger_Nail");
        item.shootSpeed = 10f;
        item.useAmmo = mod.ItemType("Stinger_Nail");
    }
	
	public override Vector2? HoldoutOffset()
		{
			return new Vector2(-4, 0);
		}	
		
	public override void UpdateInventory(Player player)
        {
			moddedP modPlayer = Main.player[Main.myPlayer].GetModPlayer<moddedP>();
			
			modPlayer.HornetNailgun = true;
		}			
}   }