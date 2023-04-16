using IngredientLib.Util;
using Kitchen;
using KitchenBurritoMod;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace BurritoMod.Customs.Providers
{
    internal class FlourTortillaProvider : CustomAppliance
    {
        public override string UniqueNameID => "FlourTortillaProvider";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("FlourTortillaProvider");
        public override PriceTier PriceTier => PriceTier.Medium;
        public override bool SellOnlyAsDuplicate => true;
        public override bool IsPurchasable => true;
        public override ShoppingTags ShoppingTags => ShoppingTags.Cooking | ShoppingTags.Misc;
        public override List<(Locale, ApplianceInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateApplianceInfo("Flour Tortilla", "Provides Flour Tortillas", new(), new()) )
        };

        public override List<IApplianceProperty> Properties => new List<IApplianceProperty>()
        {
            KitchenPropertiesUtils.GetUnlimitedCItemProvider(Mod.FlourTortilla.ID)
        };
        public override void OnRegister(Appliance gameDataObject)
        {

            Material[] mats = new Material[] { MaterialUtils.GetExistingMaterial("Bread - Inside") };
            Prefab.GetChildFromPath("TortillaStack/Wrap").ApplyMaterial(mats);
            Prefab.GetChildFromPath("TortillaStack/Wrap.001").ApplyMaterial(mats);
            Prefab.GetChildFromPath("TortillaStack/Wrap.002").ApplyMaterial(mats);
            Prefab.GetChildFromPath("TortillaStack/Wrap.003").ApplyMaterial(mats);
            Prefab.GetChildFromPath("TortillaStack/Wrap.004").ApplyMaterial(mats);

            mats = new Material[] { MaterialUtils.GetExistingMaterial("Well-done  Burger") };
            Prefab.GetChildFromPath("TortillaStack/Wrap/Tortilla_Charred").ApplyMaterial(mats);
            Prefab.GetChildFromPath("TortillaStack/Wrap.001/Tortilla_Charred.001").ApplyMaterial(mats);
            Prefab.GetChildFromPath("TortillaStack/Wrap.002/Tortilla_Charred.002").ApplyMaterial(mats);
            Prefab.GetChildFromPath("TortillaStack/Wrap.003/Tortilla_Charred.003").ApplyMaterial(mats);
            Prefab.GetChildFromPath("TortillaStack/Wrap.004/Tortilla_Charred.004").ApplyMaterial(mats);


            mats = new Material[] { MaterialUtils.GetExistingMaterial("Wood 4 - Painted") };

            Prefab.GetChildFromPath("Tray Counter/Counter2/Counter").ApplyMaterial(mats);
            Prefab.GetChildFromPath("Tray Counter/Counter2/Counter Doors").ApplyMaterial(mats);


            mats = new Material[] { MaterialUtils.GetExistingMaterial("Wood - Default") };
            Prefab.GetChildFromPath("Tray Counter/Counter2/Counter Surface").ApplyMaterial(mats);
            Prefab.GetChildFromPath("Tray Counter/Counter2/Counter Top").ApplyMaterial(mats);


            mats = new Material[] { MaterialUtils.GetExistingMaterial("Knob") };
            Prefab.GetChildFromPath("Tray Counter/Counter2/Handles").ApplyMaterial(mats);
        }
    }
}
