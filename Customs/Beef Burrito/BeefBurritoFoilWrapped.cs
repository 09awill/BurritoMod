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

namespace BurritoMod.Customs.BeefBurrito
{
    class BeefBurritoFoilWrapped : CustomItemGroup<BeefBurritoFoilWrappedItemGroupView>
    {
        public override string UniqueNameID => "Beef Burrito Foil Wrapped";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("BeefBurritoFoilWrapped");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Large;

        public override List<ItemSet> Sets => new List<ItemSet>()
        {
            new ItemSet()
            {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    Mod.BeefBurritoCooked,
                }
            },
            new ItemSet()
            {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    Mod.Foil,
                }
            }
        };

        public override List<ItemGroupView.ColourBlindLabel> Labels => new List<ItemGroupView.ColourBlindLabel>()
        {
            new ColourBlindLabel() { Item = Mod.BeefBurritoCooked, Text = "M" }
        };

        //Well-done  Burger for spots on burrito
        //Bread - Inside Cooked for Main Burrito
        public override void OnRegister(ItemGroup gameDataObject)
        {
            Prefab.GetComponent<BeefBurritoFoilWrappedItemGroupView>()?.Setup(Prefab);

            Material[] mats = new Material[] { MaterialUtils.GetExistingMaterial("Bread - Inside") };
            Prefab.GetChild("Burrito").ApplyMaterial(mats);
            Prefab.GetChild("Burrito/Plane").ApplyMaterial(mats);
            Prefab.GetChild("Burrito/Plane.001").ApplyMaterial(mats);


            mats = new Material[] { MaterialUtils.GetExistingMaterial("Well-done  Burger") };
            Prefab.GetChild("Burrito/BurritoToasted").ApplyMaterial(mats);


            //TO DO: Change to chicken
            GameObject FoilWrappedBurrito = Prefab.GetChild("FoilWrappedBurrito");
            mats = new Material[] { MaterialUtils.GetExistingMaterial("Metal- Shiny") };
            FoilWrappedBurrito.ApplyMaterial(mats);
            FoilWrappedBurrito.GetChild("FoilEnds").ApplyMaterial(mats);

            mats = new Material[] { MaterialUtils.GetExistingMaterial("Well-done") };
            FoilWrappedBurrito.GetChild("StickerBeef").ApplyMaterial(mats);
        }
    }

    public class BeefBurritoFoilWrappedItemGroupView : ItemGroupView
    {
        internal void Setup(GameObject prefab)
        {
            // This tells which sub-object of the prefab corresponds to each component of the ItemGroup
            // All of these sub-objects are hidden unless the item is present
            ComponentGroups = new()
            {
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Burrito"),
                    Item = Mod.BeefBurritoCooked
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "FoilWrappedBurrito"),
                    Item = Mod.Foil
                },
            };

        }

    }
}
