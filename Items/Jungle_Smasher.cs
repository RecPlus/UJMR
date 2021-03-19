using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace UJMR.Items
{
    public class Jungle_Smasher : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Jungle Smasher");
			Tooltip.SetDefault("Increases throwing velocity and projectile knockBack the more you throw");
		}
		
        public override void SetDefaults()
        {
			item.channel = true;
			item.crit = 12;
            item.width = 38;
            item.height = 46;
            item.value = Item.sellPrice(0, 15, 0, 0);
            item.rare = 7;
            item.noMelee = true;
            item.useStyle = 1;
            item.useAnimation = 25;
            item.useTime = 25;
            item.knockBack = 7F;
            item.damage = 112;
            item.noUseGraphic = true;
            item.shoot = mod.ProjectileType("Massive_Leafball");
            item.shootSpeed = 1f;
			item.UseSound = SoundID.Item1;
            item.melee = true;
			item.autoReuse = true;
        }
	
	bool shootProj = false;
	int Hold = 0;
    float SpeedMult = 4f;	
	
		public override void HoldItem(Player player)
		{
			if(player.channel){
			Hold++;
			}else{
            SpeedMult = 4f;
			Hold = 0;
			}
			
			
        if(Hold > 2){
        SpeedMult += 0.05f;
		}
		
        if(SpeedMult >= 35f){
		SpeedMult = 35f;}
        }
		
	public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Projectile.NewProjectile(position.X, player.position.Y - 20, speedX * SpeedMult, speedY * SpeedMult, type, damage, knockBack * (SpeedMult / 17.5f), player.whoAmI);		
			
			return false;
		}		
			
		
		 public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[item.shoot] < 1; 
        }
    }
}