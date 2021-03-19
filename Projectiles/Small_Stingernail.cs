using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UJMR.Projectiles
{
	public class Small_Stingernail : ModProjectile
	{
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stinger Nail");
		}

		    public override void SetDefaults()
        {
			projectile.scale = 0.8f;
            projectile.width = 10;
            projectile.height = 10;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.extraUpdates = 7;
			projectile.timeLeft = 25;
			projectile.tileCollide = false;  
			
			projectile.ranged = true;
			aiType = ProjectileID.Bullet;
        }
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)  //how to add a buff to a projectile
        {
			if (Main.rand.Next(4) == 1)
			{
            target.AddBuff(20, 300);
			}
        }		
    }
}