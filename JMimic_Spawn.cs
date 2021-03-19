using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace UJMR

{
    public class JMimic_Spawn : ModNPC // ModNPC is used for Custom NPCs
    {		
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("");
        }

        public override void SetDefaults()
        {
            npc.width = 2;
            npc.height = 2;
            npc.damage = 0;
            npc.defense = 5;
            npc.lifeMax = 1;
            npc.value = 0f;
            npc.knockBackResist = 0f;
            npc.aiStyle = -1;
            aiType = -1;
		    npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
        }
		
		 public override void AI()
		 {
        npc.Transform(476);
		 }
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
		if(Main.player[Main.myPlayer].ZoneJungle && Main.expertMode && NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
        {
            return SpawnCondition.Cavern.Chance * 0.005f;
        }
		else
		{
           return SpawnCondition.Cavern.Chance * 0f;
        }
		}
    }
}