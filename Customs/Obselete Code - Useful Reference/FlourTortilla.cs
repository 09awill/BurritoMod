using IngredientLib.Util;
using KitchenBurritoMod;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace BurritoMod.Customs.BurritoSharedItems
{
    internal class FlourTortilla : CustomItem
    {
        public override string UniqueNameID => "FlourTortilla";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("FlourTortilla");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Medium;
        //public override Appliance DedicatedProvider => Mod.FlourTortillaProvider; <- Swapped for ingredient lib so don't need this reference


        public override void OnRegister(GameDataObject gameDataObject)
        {
            GameObject Tortilla = Prefab.GetChildFromPath("Tortilla.002");
            Material[] mats = new Material[] { MaterialUtils.GetExistingMaterial("Bread - Inside") };
            Tortilla.GetChild("Wrap").ApplyMaterial(mats);



            mats = new Material[] { MaterialUtils.GetExistingMaterial("Well-done  Burger") };
            Tortilla.GetChild("Wrap").GetChild("Tortilla_Charred").ApplyMaterial(mats);
        }

    }

}