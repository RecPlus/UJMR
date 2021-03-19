using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UJMR.Projectiles
{
	public class Stinger_Nail : ModProjectile
	{
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stinger Nail");
		}

		    public override void SetDefaults()
        {
			projectile.scale = 0.8f;
            projectile.width = 18;
            projectile.height = 18;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.extraUpdates = 1/2;
			
			projectile.ranged = true;
        }
		
		public override void AI(){
		
		
		}

	    public override void Kill(int timeLeft)
		{		
		Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 25);
        Player owner = Main.player[projectile.owner];
		
        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 2f, 0f, mod.ProjectileType("Small_Stingernail"), projectile.damage / 2 * (int)owner.rangedDamage, projectile.knockBack, Main.myPlayer);
		Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 2f, 2f, mod.ProjectileType("Small_Stingernail"), projectile.damage / 2 * (int)owner.rangedDamage, projectile.knockBack, Main.myPlayer);
		Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 2f, mod.ProjectileType("Small_Stingernail"), projectile.damage / 2 * (int)owner.rangedDamage, projectile.knockBack, Main.myPlayer);
		Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, -2f, mod.ProjectileType("Small_Stingernail"), projectile.damage / 2 * (int)owner.rangedDamage, projectile.knockBack, Main.myPlayer);
		Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -2f, -2f, mod.ProjectileType("Small_Stingernail"), projectile.damage / 2 * (int)owner.rangedDamage, projectile.knockBack, Main.myPlayer);
		Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -2f, 2f, mod.ProjectileType("Small_Stingernail"), projectile.damage / 2 * (int)owner.rangedDamage, projectile.knockBack, Main.myPlayer);
		Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -2f, 0f, mod.ProjectileType("Small_Stingernail"), projectile.damage / 2 * (int)owner.rangedDamage, projectile.knockBack, Main.myPlayer);
		Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 2f, -2f, mod.ProjectileType("Small_Stingernail"), projectile.damage / 2 * (int)owner.rangedDamage, projectile.knockBack, Main.myPlayer);
		
					int num7;
					for (int num294 = 0; num294 < 25; num294 = num7 + 1)
					{
						int num295 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 18, 0f, 0f, 0, default(Color), 1f);
						Main.dust[num295].noGravity = true;
						Main.dust[num295].position = (Main.dust[num295].position + projectile.position) / 2f;
						Main.dust[num295].velocity = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
						Main.dust[num295].velocity.Normalize();
						Dust dust2 = Main.dust[num295];
						dust2.velocity *= (float)Main.rand.Next(1, 30) * 0.1f;
						Main.dust[num295].alpha = projectile.alpha;
						num7 = num294;
					}
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)  //how to add a buff to a projectile
        {
            target.AddBuff(20, 360);
        }	
    }
}