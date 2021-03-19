using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace UJMR.Projectiles
{
	public class Mini_Arapaima : ModProjectile
	{
		
    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Mini Arapaima");
	  ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
	  Main.projFrames[projectile.type] = 4;
    }
		
		public override void SetDefaults()
		{
			projectile.netImportant = true;
			projectile.width = 26;
			projectile.height = 50;
			projectile.friendly = true;
			projectile.minion = true;
			projectile.minionSlots = 1;
			projectile.penetrate = -1;
			projectile.timeLeft *= 5;
			projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 14;			
		}
				
        public override void AI()
        {
			Player player = Main.player[projectile.owner];
			
			if ((int)Main.time % 120 == 0)
			{
				projectile.netUpdate = true;
			}
			if (!player.active)
			{
				projectile.active = false;
			}
			else
			{

				Vector2 center2;

					Vector2 center = player.Center;
					float num4 = 700f;
					float num5 = 1000f;
					int num6 = -1;
					if (projectile.Distance(center) > 2000f)
					{
						projectile.Center = center;
						projectile.netUpdate = true;
					}
					if (true)
					{
						NPC ownerMinionAttackTargetNPC = projectile.OwnerMinionAttackTargetNPC;
						if (ownerMinionAttackTargetNPC != null && ownerMinionAttackTargetNPC.CanBeChasedBy(projectile, false))
						{
							float num7 = projectile.Distance(ownerMinionAttackTargetNPC.Center);
							if (num7 < num4 * 2f)
							{
								num6 = ownerMinionAttackTargetNPC.whoAmI;
								if (ownerMinionAttackTargetNPC.boss)
								{
									int whoAmI = ownerMinionAttackTargetNPC.whoAmI;
								}
								else
								{
									int whoAmI2 = ownerMinionAttackTargetNPC.whoAmI;
								}
							}
						}
						if (num6 < 0)
						{
							for (int i = 0; i < 200; i++)
							{
								NPC nPC = Main.npc[i];
								if (nPC.CanBeChasedBy(projectile, false) && player.Distance(nPC.Center) < num5)
								{
									float num8 = projectile.Distance(nPC.Center);
									if (num8 < num4)
									{
										num6 = i;
										bool boss = nPC.boss;
									}
								}
							}
						}
					}
					if (num6 != -1)
					{
						NPC nPC2 = Main.npc[num6];
						Vector2 vector = nPC2.Center - projectile.Center;
						(vector.X > 0f).ToDirectionInt();
						(vector.Y > 0f).ToDirectionInt();
						float scaleFactor = 0.4f;
						if (vector.Length() < 600f)
						{
							scaleFactor = 0.6f;
						}
						if (vector.Length() < 300f)
						{
							scaleFactor = 0.8f;
						}
						float num9 = vector.Length();
						center2 = nPC2.Size;
						if (num9 > center2.Length() * 0.75f)
						{
							projectile.velocity += Vector2.Normalize(vector) * scaleFactor * 1.5f;
							if (Vector2.Dot(projectile.velocity, vector) < 0.25f)
							{
								projectile.velocity *= 0.8f;
							}
						}
						float num10 = 30f;
						if (projectile.velocity.Length() > num10)
						{
							projectile.velocity = Vector2.Normalize(projectile.velocity) * num10;
						}
					}
					else
					{
						float num11 = 0.2f;
						Vector2 vector2 = center - projectile.Center;
						if (vector2.Length() < 200f)
						{
							num11 = 0.12f;
						}
						if (vector2.Length() < 140f)
						{
							num11 = 0.06f;
						}
						if (vector2.Length() > 100f)
						{
							if (Math.Abs(center.X - projectile.Center.X) > 20f)
							{
								projectile.velocity.X += num11 * (float)Math.Sign(center.X - projectile.Center.X);
							}
							if (Math.Abs(center.Y - projectile.Center.Y) > 10f)
							{
								projectile.velocity.Y += num11 * (float)Math.Sign(center.Y - projectile.Center.Y);
							}
						}
						else if (projectile.velocity.Length() > 2f)
						{
							projectile.velocity *= 0.96f;
						}
						if (Math.Abs(projectile.velocity.Y) < 1f)
						{
							projectile.velocity.Y -= 0.1f;
						}
						float num12 = 15f;
						if (projectile.velocity.Length() > num12)
						{
							projectile.velocity = Vector2.Normalize(projectile.velocity) * num12;
						}
					}
					projectile.rotation = projectile.velocity.ToRotation() + 1.57079637f;
					int direction = projectile.direction;
					projectile.direction = (projectile.spriteDirection = ((projectile.velocity.X > 0f) ? 1 : (-1)));
					if (direction != projectile.direction)
					{
						projectile.netUpdate = true;
					}
					float num13 = MathHelper.Clamp(projectile.localAI[0], 0f, 50f);
					projectile.position = projectile.Center;
					projectile.scale = 1f + num13 * 0.01f;
					projectile.Center = projectile.position;
					if (projectile.alpha > 0)
					{
						for (int j = 0; j < 2; j++)
						{
							int num14 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 135, 0f, 0f, 100, default(Color), 2f);
							Main.dust[num14].noGravity = true;
							Main.dust[num14].noLight = true;
						}
						projectile.alpha -= 42;
						if (projectile.alpha < 0)
						{
							projectile.alpha = 0;
						}
					}
				projectile.position.X = MathHelper.Clamp(projectile.position.X, 160f, (float)(Main.maxTilesX * 16 - 160));
				projectile.position.Y = MathHelper.Clamp(projectile.position.Y, 160f, (float)(Main.maxTilesY * 16 - 160));
			}
		
			moddedP modPlayer = player.GetModPlayer<moddedP>();
			if (player.dead) {
				modPlayer.Arapaima = false;
			}
			if (modPlayer.Arapaima) {
				projectile.timeLeft = 2;
			}		
		}	

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {	
			projectile.frameCounter++;
            if (projectile.frameCounter >= 5)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
                if (projectile.frame > 3)
                    projectile.frame = 0;
            }
            return true;
        }	
	}
}
