using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UJMR.Items
{
	public class Bait_Wand : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bait Wand");
			Tooltip.SetDefault("Summons a Mini Arapaima to fight for you");
		}
		
		public override void SetDefaults()
		{
			item.damage = 24;
			
			item.summon = true;
			item.mana = 10;
			
			item.width = 32;
			item.height = 30;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = 1;
			item.noMelee = true;
			item.knockBack = 1f;
			item.value = Item.sellPrice(0, 15, 0, 0);
			item.rare = 7;
			item.UseSound = SoundID.Item44;
			
			item.shootSpeed = 2f;
			item.shoot = mod.ProjectileType("Mini_Arapaima");
		}

        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 SPos = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);   //this make so the projectile will spawn at the mouse cursor position
            position = SPos;
			
			player.AddBuff(mod.BuffType("Mini_ArapaimaB"), 3600);

            return true;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool UseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                player.MinionNPCTargetAim();
            }
            return base.UseItem(player);
        }
	}
}
