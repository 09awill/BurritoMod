using IngredientLib.Util;
using Kitchen;
using KitchenAmericanBreakfast.Mains;
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
using static KitchenData.ItemGroup;

namespace BurritoMod.Customs
{
    class Burrito : CustomItemGroup<BurritoItemGroupView>
    {
        public override string UniqueNameID => "Burrito";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Burrito");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Medium;
        public override bool CanContainSide => true;
        public override List<ItemSet> Sets => new List<ItemSet>()
        {
            new ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    Mod.ChoppedLettuce,
                }
            },
            new ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    Mod.ChoppedTomato,
                }
            },
            new ItemSet()
            {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    Mod.Tortilla,
                }
            },
            new ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    Mod.CookedRice,
                }
            },
            new ItemSet()
            {
                Max = 1,
                Min = 0,
                RequiresUnlock = true,
                Items = new List<Item>()
                {
                    Mod.ChoppedMeatCooked
                }
            }
        };


        public override void OnRegister(GameDataObject gameDataObject)
        {
            Prefab.GetComponent<BurritoItemGroupView>()?.Setup(Prefab);

            GameObject lettuce = Prefab.GetChild("Salad");
            Material[] mats = new Material[] { MaterialUtils.GetExistingMaterial("Lettuce") };
            lettuce.GetChild("ChoppedLettuce").ApplyMaterial(mats);

            GameObject tomato = Prefab.GetChildFromPath("Tomato - Chopped/Tomato Sliced");
            mats = new Material[] { MaterialUtils.GetExistingMaterial("Tomato Flesh") };
            tomato.GetChild("ChoppedTomatoLiquid").ApplyMaterial(mats);

            mats = new Material[] { MaterialUtils.GetExistingMaterial("Tomato Flesh 2") };
            tomato.GetChild("ChoppedTomatoLiquid1").ApplyMaterial(mats);

            mats = new Material[] { MaterialUtils.GetExistingMaterial("Tomato") };
            tomato.GetChild("ChoppedTomatoSkin").ApplyMaterial(mats);

            GameObject Meat = Prefab.GetChild("Meat - Chopped");
            mats = new Material[] { MaterialUtils.GetExistingMaterial("Raw") };
            Meat.GetChild("ChoppedMeatCooked").ApplyMaterial(mats);

            GameObject Tortilla = Prefab.GetChild("TortillaBase");
            mats = new Material[] { MaterialUtils.GetExistingMaterial("Rice") };
            Tortilla.GetChild("Tortilla").ApplyMaterial(mats);

            GameObject Rice = Prefab.GetChild("Rice");
            mats = new Material[] { MaterialUtils.GetExistingMaterial("Rice") };
            Rice.GetChild("CookedRice").ApplyMaterial(mats);
        }
    }
    public class BurritoItemGroupView : ItemGroupView
    {
        internal void Setup(GameObject prefab) =>
            // This tells which sub-object of the prefab corresponds to each component of the ItemGroup
            // All of these sub-objects are hidden unless the item is present
            
            ComponentGroups = new()
            {
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Salad"),
                    Item = Mod.ChoppedLettuce
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Tomato - Chopped"),
                    Item = Mod.ChoppedTomato
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Meat - Chopped"),
                    Item = Mod.ChoppedMeatCooked
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "TortillaBase"),
                    Item = Mod.Tortilla
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Rice"),
                    Item = Mod.CookedRice
                }
            };
            
    }
}
