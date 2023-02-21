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
    class BaseBurritoAssembled : CustomItemGroup<BaseBurritoAssembledItemGroupView>
    {
        public override string UniqueNameID => "BurritoAssembled";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("TortillaAssembled");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
        public override ItemValue ItemValue => ItemValue.Medium;

        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Duration = 1,
                Process = Mod.Knead,
                Result = Mod.BurritoWrapped,
            }
        };
        public override List<ItemSet> Sets => new List<ItemSet>()
        {
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
                Min = 1,
                Items = new List<Item>()
                {
                    Mod.ShreddedChicken
                }
            }
        };

        //Well-done  Burger for spots on burrito
        //Bread - Inside Cooked for Main Burrito
        public override void OnRegister(GameDataObject gameDataObject)
        {
            Prefab.GetComponent<BaseBurritoAssembledItemGroupView>()?.Setup(Prefab);

            //TO DO : Change to chicken

            GameObject Chicken = Prefab.GetChild("Shredded Chicken");
            Material[] mats = new Material[] { MaterialUtils.GetExistingMaterial("Cooked Batter") };
            Chicken.GetChild("Shaving0").ApplyMaterial(mats);
            Chicken.GetChild("Shaving1").ApplyMaterial(mats);
            Chicken.GetChild("Shaving2").ApplyMaterial(mats);
            Chicken.GetChild("Shaving3").ApplyMaterial(mats);
            Chicken.GetChild("Shaving4").ApplyMaterial(mats);


            GameObject Tortilla = Prefab.GetChildFromPath("Tortilla/Tortilla.002");
            mats = new Material[] { MaterialUtils.GetExistingMaterial("Bread - Inside") };
            Tortilla.GetChild("Wrap").ApplyMaterial(mats);

            mats = new Material[] { MaterialUtils.GetExistingMaterial("Well-done  Burger") };
            Tortilla.GetChild("Wrap").GetChild("Tortilla_Charred").ApplyMaterial(mats);

            GameObject Rice = Prefab.GetChild("Rice");
            mats = new Material[] { MaterialUtils.GetExistingMaterial("Rice") };
            Rice.GetChild("Cube").ApplyMaterial(mats);
            Rice.GetChild("Cylinder.001").ApplyMaterial(mats);
        }
    }
    public class BaseBurritoAssembledItemGroupView : ItemGroupView
    {
        internal void Setup(GameObject prefab) =>
            // This tells which sub-object of the prefab corresponds to each component of the ItemGroup
            // All of these sub-objects are hidden unless the item is present
            
            ComponentGroups = new()
            {
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Shredded Chicken"),
                    Item = Mod.ShreddedChicken
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Tortilla"),
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
