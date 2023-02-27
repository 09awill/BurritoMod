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
    class BurritoWithExtrasFoilWrapped : CustomItemGroup<BurritoWithExtrasFoilWrappedItemGroupView>
    {
        public override string UniqueNameID => "Burrito With Extras Foil Wrapped";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("TortillaWrappedIconWithExtras");
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
                    Mod.BurritoWithExtrasCooked,
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


        //Well-done  Burger for spots on burrito
        //Bread - Inside Cooked for Main Burrito
        public override void OnRegister(GameDataObject gameDataObject)
        {

            Material[] mats = new Material[] { MaterialUtils.GetExistingMaterial("Bread - Inside") };
            Prefab.GetChild("Burrito").ApplyMaterial(mats);
            Prefab.GetChildFromPath("Burrito/Plane").ApplyMaterial(mats);
            Prefab.GetChildFromPath("Burrito/Plane.001").ApplyMaterial(mats);

            Debug.Log("Burrito Toasted");

            mats = new Material[] { MaterialUtils.GetExistingMaterial("Well-done  Burger") };
            Prefab.GetChildFromPath("Burrito/BurritoToasted").ApplyMaterial(mats);


            Debug.Log("Foil Wrapped Burrito");

            //TO DO: Change to chicken
            GameObject FoilWrappedBurrito = Prefab.GetChild("FoilWrappedBurrito");
            mats = new Material[] { MaterialUtils.GetExistingMaterial("Metal- Shiny") };
            FoilWrappedBurrito.ApplyMaterial(mats);
            FoilWrappedBurrito.GetChild("FoilEnds").ApplyMaterial(mats);

            mats = new Material[] { MaterialUtils.GetExistingMaterial("Lettuce") };
            FoilWrappedBurrito.GetChild("StickerLettuce").ApplyMaterial(mats);

            mats = new Material[] { MaterialUtils.GetExistingMaterial("Tomato") };
            FoilWrappedBurrito.GetChild("StickerTomato").ApplyMaterial(mats);
        }
    }

    public class BurritoWithExtrasFoilWrappedItemGroupView : ItemGroupView
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
                    Item = Mod.BurritoCooked
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "FoilWrappedBurrito"),
                    Item = Mod.Foil
                }
            };
        }

    }
}
