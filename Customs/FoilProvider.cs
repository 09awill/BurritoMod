using IngredientLib.Util;
using Kitchen;
using KitchenAmericanBreakfast.Utils;
using KitchenBurritoMod;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Unity.Entities;
using UnityEngine;

namespace BurritoMod.Customs
{
    class FoilProvider : CustomAppliance
    {
        public override string UniqueNameID => "FoilProvider";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("FoilProvider");
        public override PriceTier PriceTier => PriceTier.Medium;
        public override bool SellOnlyAsDuplicate => true;
        public override bool IsPurchasable => true;
        public override ShoppingTags ShoppingTags => ShoppingTags.Cooking | ShoppingTags.Misc;

        public override List<(Locale, ApplianceInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateApplianceInfo("Foil Provider", "Allows a burrito to be wrapped in foil", new(), new()) )
        };

        public override List<IApplianceProperty> Properties => new()
        {
            new CItemHolder()
        };


        public override List<Appliance.ApplianceProcesses> Processes => new List<Appliance.ApplianceProcesses>()
        {
            // ...
            new Appliance.ApplianceProcesses()
            {
                Process = Mod.WrapInFoil,                               // reference to the base process
                Speed = 1f,                                              // the speed multiplier when using this appliance (for reference, starter = 0.75, base = 1, danger hob/oven = 2)
                IsAutomatic = true                                       // (optional) whether the process is automatic on this appliance
            }
            // ...
        };


        public override void OnRegister(GameDataObject gameDataObject)
        {
            Debug.Log("Counter");

            Material[] mats = new Material[] { MaterialUtils.GetExistingMaterial("Wood - Default") };
            Prefab.GetChild("BaseCounter").ApplyMaterial(mats);
            Prefab.GetChildFromPath("BaseCounter/BaseCountertop").ApplyMaterial(mats);
            Prefab.GetChildFromPath("BaseCounter/BaseCounterHandles").ApplyMaterial(mats);

            Debug.Log("Foil Dispenser");
            Prefab.GetChild("FoilDispenser").ApplyMaterial(mats);
            Prefab.GetChildFromPath("FoilDispenser/Plane").ApplyMaterial(mats);
            Prefab.GetChildFromPath("FoilDispenser/WoodenEnds").ApplyMaterial(mats);
            Prefab.GetChildFromPath("FoilDispenser/WoodenEnds/WoodenEnds.001").ApplyMaterial(mats);

            mats = new Material[] { MaterialUtils.GetExistingMaterial("Metal- Shiny") };
            Prefab.GetChildFromPath("FoilDispenser/Foil").ApplyMaterial(mats);

            var holdTransform = Prefab.GetChildFromPath("BaseCounter/HoldPoint").transform;
            var holdPoint = Prefab.AddComponent<HoldPointContainer>();
            holdPoint.HoldPoint = holdTransform;
        }
    }
}
