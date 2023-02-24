using IngredientLib.Util;
using Kitchen;
using KitchenBurritoMod;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;
using static KitchenData.ItemGroup;

namespace BurritoMod.Customs
{
    class BurritoWithExtrasInaBasket : CustomItemGroup<BurritoWithExtrasInaBasketItemGroupView>
    {
        public override string UniqueNameID => "Burrito With Extras In A Basket";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("BurritoWithExtrasInBasket");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Large;
        public override bool CanContainSide => true;


        public override List<ItemSet> Sets => new List<ItemSet>()
        {
            new ItemSet()
            {
                Max = 1,
                Min = 1,
                IsMandatory= true,
                Items = new List<Item>()
                {
                    Mod.BurritoWithExtrasFoilWrapped
                }
            },
            new ItemSet()
            {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    Mod.BurritoBasket
                }
            }
        };


        //Well-done  Burger for spots on burrito
        //Bread - Inside Cooked for Main Burrito
        public override void OnRegister(GameDataObject gameDataObject)
        {
            Debug.Log("Foil Wrapped Burrito");

            //TO DO: Change to chicken
            GameObject FoilWrappedBurrito = Prefab.GetChild("FoilWrappedBurrito");
            Material[] mats = new Material[] { MaterialUtils.GetExistingMaterial("Metal- Shiny") };
            FoilWrappedBurrito.ApplyMaterial(mats);
            FoilWrappedBurrito.GetChild("FoilEnds").ApplyMaterial(mats);

            mats = new Material[] { MaterialUtils.GetExistingMaterial("Lettuce") };
            FoilWrappedBurrito.GetChild("StickerLettuce").ApplyMaterial(mats);

            mats = new Material[] { MaterialUtils.GetExistingMaterial("Tomato") };
            FoilWrappedBurrito.GetChild("StickerTomato").ApplyMaterial(mats);

            mats = new Material[] { MaterialUtils.GetExistingMaterial("Tomato") };
            Prefab.GetChild("BurritoBasket").ApplyMaterial(mats);
            mats = new Material[] { MaterialUtils.GetExistingMaterial("Rice") };
            Prefab.GetChildFromPath("BurritoBasket/Paper").ApplyMaterial(mats);
        }
    }

    public class BurritoWithExtrasInaBasketItemGroupView : ItemGroupView
    {
        internal void Setup(GameObject prefab)
        {
            // This tells which sub-object of the prefab corresponds to each component of the ItemGroup
            // All of these sub-objects are hidden unless the item is present
            ComponentGroups = new()
            {
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "BurritoBasket"),
                    Item = Mod.BurritoBasket
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "FoilWrappedBurrito"),
                    Item = Mod.BurritoWithExtrasFoilWrapped
                }
            };
        }

    }
}
