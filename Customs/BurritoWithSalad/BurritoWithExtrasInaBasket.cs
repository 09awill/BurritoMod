using Kitchen;
using KitchenBurritoMod;
using KitchenData;
using KitchenLib.Colorblind;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;
using static KitchenData.ItemGroup;

namespace BurritoMod.Customs.BurritoWithSalad
{
    class BurritoWithExtrasInaBasket : CustomItemGroup<BurritoWithExtrasInaBasketItemGroupView>
    {
        public override string UniqueNameID => "Burrito With Extras In A Basket";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("ChickenBurritoExtrasInBasket");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override bool CanContainSide => true;
        public override ItemValue ItemValue => ItemValue.MediumLarge;

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
        public override void OnRegister(ItemGroup gameDataObject)
        {
            Prefab.GetComponent<BurritoWithExtrasInaBasketItemGroupView>()?.Setup(Prefab);
            //TO DO: Change to chicken
            GameObject FoilWrappedBurrito = Prefab.GetChild("FoilWrappedBurrito");
            Material[] mats = new Material[] { MaterialUtils.GetExistingMaterial("Metal- Shiny") };
            FoilWrappedBurrito.ApplyMaterial(mats);
            FoilWrappedBurrito.GetChild("FoilEnds").ApplyMaterial(mats);

            mats = new Material[] { MaterialUtils.GetExistingMaterial("Lettuce") };
            FoilWrappedBurrito.GetChild("StickerLettuce").ApplyMaterial(mats);

            mats = new Material[] { MaterialUtils.GetExistingMaterial("Tomato") };
            FoilWrappedBurrito.GetChild("StickerTomato").ApplyMaterial(mats);

            FoilWrappedBurrito.ApplyMaterialToChild("StickerChicken", "Bread - Inside Cooked");



            mats = new Material[] { MaterialUtils.GetExistingMaterial("Tomato") };
            Prefab.GetChild("BurritoBasket").ApplyMaterial(mats);
            mats = new Material[] { MaterialUtils.GetExistingMaterial("Cooked Pastry") };
            Prefab.GetChild("BurritoBasket/Paper").ApplyMaterial(mats);
        }   
    }

    public class BurritoWithExtrasInaBasketItemGroupView : ItemGroupView
    {
        internal void Setup(GameObject prefab)
        {
            ComponentLabels.Add(new ColourBlindLabel() { Item = Mod.BurritoWithExtrasFoilWrapped, Text = "ChiS" });

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
