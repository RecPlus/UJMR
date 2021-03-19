using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
 
namespace UJMR.Projectiles
{
    public class Massive_Leafball : ModProjectile
    {
	bool Return = false;	
		
 		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Massive Leafball");
		}
        public override void SetDefaults()
        {
            projectile.width = 58;
            projectile.height = 60;
            projectile.friendly = true;
            projectile.penetrate = -1;
			projectile.aiStyle = 2;
            projectile.melee = true;
        }
		
		public override void AI(){
				
		Player player = Main.player[projectile.owner];
		
		if(player.dead || !player.active)
		{
        projectile.timeLeft = 2;
		}	
		
		if((projectile.Center - player.Center).Length() > 1000f){
			
		Return = true;
	    }

		for(int i = 0; i < 200; i++)
      {
		Player target = Main.player[i]; 
           float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
           float shootToY = target.position.Y - projectile.Center.Y;
           float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));		   
		  
		if(Return){
		projectile.tileCollide = false;	

		   projectile.aiStyle = 1;
		   aiType = ProjectileID.Bullet;
		   
		   if(distance < 10f){
		   projectile.active = false;
		   }
		   
           if(!target.dead && target.active)
           {
               distance = 4f / distance;
   
               shootToX *= distance * 5;
               shootToY *= distance * 5;

               projectile.velocity.X = shootToX;
               projectile.velocity.Y = shootToY;
           }

		}else{		   
		   
	projectile.tileCollide = true;	
	}


	}
			
		}
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
        Return = true; 

      for(int i = 0; i < 25; i++)
      {
			int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 18);
            Main.dust[num1].scale = 1.3f;
            Main.dust[num1].velocity *= 1.2f;
            Main.dust[num1].noGravity = false;
	  }

        Main.PlaySound(6, (int)projectile.position.X, (int)projectile.position.Y, 10);			
		}
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
		Return = true;

      for(int i = 0; i < 40; i++)
      {
			int num1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 18);
            Main.dust[num1].scale = 1.3f;
            Main.dust[num1].velocity *= 1.5f;
            Main.dust[num1].noGravity = false;
	  }

        Main.PlaySound(6, (int)projectile.position.X, (int)projectile.position.Y, 10);
                Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 10);		

      return false;
		}
		
        public override bool PreDraw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture = ModContent.GetTexture("UJMR/Projectiles/Rope");
 
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