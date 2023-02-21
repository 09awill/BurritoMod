using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KitchenData.ItemGroup;
using UnityEngine;
using KitchenBurritoMod;
using Kitchen;
using IngredientLib.Util;
using KitchenAmericanBreakfast.Utils;

namespace BurritoMod.Customs
{
    class BurritoWithExtrasFoilWrapped : CustomItem
    {
        public override string UniqueNameID => "Burrito With Extras Foil Wrapped";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("TortillaWrappedIcon");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Medium;


        //Well-done  Burger for spots on burrito
        //Bread - Inside Cooked for Main Burrito
        public override void OnRegister(GameDataObject gameDataObject)
        {
            Debug.Log("Base Burrito");

            Material[] mats = new Material[] { MaterialUtils.GetExistingMaterial("Bread - Inside") };
            Prefab.GetChild("Burrito").ApplyMaterial(mats);

            Debug.Log("Burrito Toasted");

            mats = new Material[] { MaterialUtils.GetExistingMaterial("Well-done Burger") };
            Prefab.GetChild("Burrito").ApplyMaterial(mats);

            Debug.Log("Foil Wrapped Burrito");

            //TO DO: Change to chicken
            GameObject FoilWrappedBurrito = Prefab.GetChild("FoilWrappedBurrito");
            mats = new Material[] { MaterialUtils.GetExistingMaterial("Metal- Shiny") };
            FoilWrappedBurrito.ApplyMaterial(mats);
            FoilWrappedBurrito.GetChild("Burrito.002").ApplyMaterial(mats);
            FoilWrappedBurrito.GetChild("Burrito.003").ApplyMaterial(mats);
            FoilWrappedBurrito.GetChild("Burrito.004").ApplyMaterial(mats);
            FoilWrappedBurrito.GetChild("Burrito.005").ApplyMaterial(mats);

        }
    }
}
