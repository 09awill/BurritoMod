using IngredientLib.Util;
using KitchenAmericanBreakfast.Utils;
using KitchenBurritoMod;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


        public override void OnRegister(GameDataObject gameDataObject)
        {
            Material[] mats = new Material[] { MaterialUtils.GetExistingMaterial("Rice") };
            Prefab.GetChild("TortillaBase").GetChild("Tortilla").ApplyMaterial(mats);
        }

    }

}