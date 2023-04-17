using KitchenBurritoMod;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace BurritoMod.Customs.BeefBurritoWithSalad
{
    class BeefBurritoWithExtrasWrapped : CustomItem
    {
        public override string UniqueNameID => "BeefBurritoWithExtrasWrapped";
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
                Result = Mod.BeefBurritoWithExtrasCooked
            }
        };

        //Well-done  Burger for spots on BeefBurrito
        //Bread - Inside Cooked for Main BeefBurrito
        public override void OnRegister(Item gameDataObject)
        {

            Material[] mats = new Material[] { MaterialUtils.GetExistingMaterial("Bread - Inside") };
            Prefab.GetChild("Burrito").ApplyMaterial(mats);
            Prefab.GetChild("Burrito/Plane").ApplyMaterial(mats);
            Prefab.GetChild("Burrito/Plane.001").ApplyMaterial(mats);

        }
    }
}
