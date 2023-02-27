using IngredientLib.Util;
using KitchenBurritoMod;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace BurritoMod.Customs
{
    class BurritoWithExtrasWrapped : CustomItem
    {
        public override string UniqueNameID => "BurritoWithExtrasWrapped";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("TortillaWrapped");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Medium;

        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Duration = 1,
                Process = Mod.Cook,
                Result = Mod.BurritoWithExtrasCooked
            }
        };

        //Well-done  Burger for spots on burrito
        //Bread - Inside Cooked for Main Burrito
        public override void OnRegister(GameDataObject gameDataObject)
        {

            Material[] mats = new Material[] { MaterialUtils.GetExistingMaterial("Bread - Inside") };
            Prefab.GetChild("Burrito").ApplyMaterial(mats);
            Prefab.GetChildFromPath("Burrito/Plane").ApplyMaterial(mats);
            Prefab.GetChildFromPath("Burrito/Plane.001").ApplyMaterial(mats);

        }
    }
}
