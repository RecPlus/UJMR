using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using static Terraria.ModLoader.ModContent;

namespace UJMR
{
    public class moddedP : ModPlayer
    {
	public bool Arapaima;
	public bool HornetNailgun = false;

		public override void ResetEffects()
		{
		Arapaima = false;	
		HornetNailgun = false;
		}			
	}	
}