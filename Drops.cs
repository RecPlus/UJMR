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
	public class Drops : GlobalNPC
	{
	
    public override void SetDefaults(NPC npc)
	{
		
	if(npc.type == 476){
	npc.lifeMax = 7000;
    npc.damage = 105;
    npc.defense = 36;
	npc.value = Item.buyPrice(0, 5, 0, 0);
	}
	
	}
	
	public override void NPCLoot(NPC npc)
	{
		if(npc.type == 476)
		{
			int ran = Main.rand.Next(1, 6);
			 if (ran == 1) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Bait_Wand"), 1);
			 if (ran == 2){ Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Hornet_Nailgun"), 1);
			 Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Stinger_Nail"), Main.rand.Next(100, 200));}
			 if (ran == 3) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Jungle_Smasher"), 1);
			 if (ran == 4) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Ancient_Flower"), 1);
			 if (ran == 5) Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Vine_Hook"), 1);

				 
				 Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 210, Main.rand.Next(5, 7));
				 Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 209, Main.rand.Next(7, 15));
				 Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 331, Main.rand.Next(10, 20));
				 
				 if (Main.player[Main.myPlayer].ZoneRockLayerHeight)
			if (Main.player[Main.myPlayer].ZoneJungle)
				 if(Main.rand.Next(10) < 1)
				{
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1291);
                }
		}		
	}
	
	}
}