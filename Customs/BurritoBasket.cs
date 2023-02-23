﻿using IngredientLib.Util;
using KitchenBurritoMod;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace BurritoMod.Customs
{
    internal class BurritoBasket : CustomItem
    {
        public override string UniqueNameID => "Burrito Basket";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("BurritoBasket");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Medium;
        public override Appliance DedicatedProvider => Mod.BurritoBasketProvider;


        public override void OnRegister(GameDataObject gameDataObject)
        {
            Material[] mats = new Material[] { MaterialUtils.GetExistingMaterial("Tomato") };
            Prefab.GetChild("BurritoBasket").ApplyMaterial(mats);
            mats = new Material[] { MaterialUtils.GetExistingMaterial("Rice") };
            Prefab.GetChildFromPath("BurritoBasket/Paper").ApplyMaterial(mats);
        }

    }

}