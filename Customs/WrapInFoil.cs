﻿using KitchenBurritoMod;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurritoMod.Customs
{
    class WrapInFoil : CustomProcess
    {
        // The unique internal name of this process
        public override string UniqueNameID => "WrapInFoil";

        // The "default" appliance of this process (e.g., counter for "chop", hob for "cook")
        // When a dish requires this process, this is the appliance that will spawn at the beginning of a run
        public override GameDataObject BasicEnablingAppliance => Mod.FoilProvider;

        // Whether or not the process can be obfuscated, such as through the "Blindfolded Chefs" card. This is normally set to `true`
        public override bool CanObfuscateProgress => true;


    }
}