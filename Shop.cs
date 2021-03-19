using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader.Audio;
using System.Text.RegularExpressions;

namespace UJMR
{
	public class Shop : GlobalNPC
	{
		
		public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {	
		    moddedP modPlayer = Main.player[Main.myPlayer].GetModPlayer<moddedP>();
		    Player player = Main.player[Main.myPlayer];
		
			if (type == NPCID.ArmsDealer)
            {
				if(modPlayer.HornetNailgun)
				{
					
                shop.item[nextSlot].SetDefaults(mod.ItemType("Stinger_Nail"));
                nextSlot++;
				}				
            }	
		}		
	}
}	