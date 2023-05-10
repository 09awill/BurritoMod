using Kitchen;
using KitchenBurritoMod;
using KitchenData;
using KitchenLib.Colorblind;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;
using static Kitchen.ItemGroupView;
using static KitchenData.ItemGroup;

namespace BurritoMod.Customs.BaseBurrito
{
    class BurritoInaBasket : CustomItemGroup<BurritoInaBasketItemGroupView>
    {
        public override string UniqueNameID => "BurritoInaBasket";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("ChickenBurritoInBasket");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemValue ItemValue => ItemValue.Medium;

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
                    Mod.BurritoFoilWrapped
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

        public override List<ItemGroupView.ColourBlindLabel> Labels => new List<ItemGroupView.ColourBlindLabel>()
        {
            new ColourBlindLabel() { Item = Mod.BurritoFoilWrapped, Text = "Chi" }
        };
        //Well-done  Burger for spots on burrito
        //Bread - Inside Cooked for Main Burrito
        public override void OnRegister(ItemGroup gameDataObject)
        {
            Prefab.GetComponent<BurritoInaBasketItemGroupView>()?.Setup(Prefab);

            //TO DO: Change to chicken
            GameObject FoilWrappedBurrito = Prefab.GetChild("FoilWrappedBurrito");
            Material[] mats = new Material[] { MaterialUtils.GetExistingMaterial("Metal- Shiny") };
            FoilWrappedBurrito.ApplyMaterial(mats);
            FoilWrappedBurrito.GetChild("FoilEnds").ApplyMaterial(mats);
            FoilWrappedBurrito.ApplyMaterialToChild("StickerChicken", "Bread - Inside Cooked");




            mats = new Material[] { MaterialUtils.GetExistingMaterial("Tomato") };
            Prefab.GetChild("BurritoBasket").ApplyMaterial(mats);
            mats = new Material[] { MaterialUtils.GetExistingMaterial("Cooked Pastry") };
            Prefab.GetChild("BurritoBasket/Paper").ApplyMaterial(mats);
        }
    }

    public class BurritoInaBasketItemGroupView : ItemGroupView
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
                    Item = Mod.BurritoFoilWrapped
                }
            };
        }

    }
}
