using IngredientLib.Util;
using KitchenBurritoMod;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace BurritoMod.Customs.BurritoWithSalad
{
    class BurritoWithExtrasCooked : CustomItem
    {
        public override string UniqueNameID => "BurritoWithExtrasCooked";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("TortillaCooked");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Large;

        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Duration = 1,
                Process = Mod.WrapInFoil,
                Result = Mod.BurritoWithExtrasFoilWrapped
            },
            new Item.ItemProcess
            {
                Duration = 5,
                Process = Mod.Cook,
                IsBad = true,
                Result = Mod.Burnt
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

            mats = new Material[] { MaterialUtils.GetExistingMaterial("Well-done  Burger") };
            Prefab.GetChildFromPath("Burrito/BurritoToasted").ApplyMaterial(mats);

        }
    }
}
