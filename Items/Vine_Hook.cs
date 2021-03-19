using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UJMR.Items
{
	class Vine_Hook : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vine Hook");
		}

		public override void SetDefaults()
		{

			item.CloneDefaults(ItemID.AmethystHook);
			item.rare = 7;
			Item.sellPrice(0, 10, 0, 0);
			item.shootSpeed = 25f;
			item.shoot = mod.ProjectileType("Vine_Hook_Proj");
		}	
	}
	class Vine_Hook_Proj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vine Hook");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.GemHookAmethyst);
			projectile.width = 8;
			projectile.height = 10;
		}

		public override bool? CanUseGrapple(Player player)
		{
			int hooksOut = 0;
			for (int l = 0; l < 1000; l++)
			{
				if (Main.projectile[l].active && Main.projectile[l].owner == Main.myPlayer && Main.projectile[l].type == projectile.type)
				{
					hooksOut++;
				}
			}
			if (hooksOut > 1)
			{
				return false;
			}
			return true;
		}

		public override float GrappleRange()
		{
			return 525f;
		}

		public override void NumGrappleHooks(Player player, ref int numHooks)
		{
			numHooks = 1;
		}

		public override void GrappleRetreatSpeed(Player player, ref float speed)
		{
			speed = 20f;
		}

		public override void GrapplePullSpeed(Player player, ref float speed)
		{
			speed = 16f;
		}

		 public override bool PreDraw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture = ModContent.GetTexture("UJMR/Items/Vine_Hook_Chain");
 
            Vector2 position = projectile.Center;
            Vector2 mountedCenter = Main.player[projectile.owner].MountedCenter;
            Microsoft.Xna.Framework.Rectangle? sourceRectangle = new Microsoft.Xna.Framework.Rectangle?();
            Vector2 origin = new Vector2((float)texture.Width * 0.5f, (float)texture.Height * 0.5f);
            float num1 = (float)texture.Height;
            Vector2 vector2_4 = mountedCenter - position;
            float rotation = (float)Math.Atan2((double)vector2_4.Y, (double)vector2_4.X) - 1.57f;
            bool flag = true;
            if (float.IsNaN(position.X) && float.IsNaN(position.Y))
                flag = false;
            if (float.IsNaN(vector2_4.X) && float.IsNaN(vector2_4.Y))
                flag = false;
            while (flag)
            {
                if ((double)vector2_4.Length() < (double)num1 + 1.0)
                {
                    flag = false;
                }
                else
                {
                    Vector2 vector2_1 = vector2_4;
                    vector2_1.Normalize();
                    position += vector2_1 * num1;
                    vector2_4 = mountedCenter - position;
                    Microsoft.Xna.Framework.Color color2 = Lighting.GetColor((int)position.X / 16, (int)((double)position.Y / 16.0));
                    color2 = projectile.GetAlpha(color2);
                    Main.spriteBatch.Draw(texture, position - Main.screenPosition, sourceRectangle, color2, rotation, origin, 1f, SpriteEffects.None, 0.0f);
                }
            }
 
            return true;
        }
	}


}
