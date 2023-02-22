using IngredientLib.Util;
using KitchenBurritoMod;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace BurritoMod.Customs
{
    internal class Tortilla : CustomItem
    {
        public override string UniqueNameID => "Large Tortilla";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Large Tortilla");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Medium;
        public override Appliance DedicatedProvider => Mod.TortillaProvider;


        public override void OnRegister(GameDataObject gameDataObject)
        {
            GameObject Tortilla = Prefab.GetChildFromPath("Tortilla.002");
            Material[] mats = new Material[] { MaterialUtils.GetExistingMaterial("Bread - Inside") };
            Tortilla.GetChild("Wrap").ApplyMaterial(mats);

            Debug.Log("Wrap");


            mats = new Material[] { MaterialUtils.GetExistingMaterial("Well-done  Burger") };
            Tortilla.GetChild("Wrap").GetChild("Tortilla_Charred").ApplyMaterial(mats);
        }

    }

}