using Kitchen;
using KitchenBurritoMod;
using KitchenData;
using KitchenLib.Colorblind;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;
using static KitchenData.ItemGroup;

namespace BurritoMod.Customs.BeefBurrito
{
    class BeefBurritoAssembled : CustomItemGroup<BeefBurritoAssembledItemGroupView>
    {
        public override string UniqueNameID => "BeefBurritoAssembled";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("BeefBurritoAssembly");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemValue ItemValue => ItemValue.Large;

        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Duration = 1,
                Process = Mod.Knead,
                Result = Mod.BeefBurritoCooked,
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
                    Mod.FlourTortilla,
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
                    Mod.ChoppedBeefCooked
                }
            }
        };

        //Well-done  Burger for spots on burrito
        //Bread - Inside Cooked for Main Burrito
        public override void OnRegister(ItemGroup gameDataObject)
        {
            Prefab.GetComponent<BeefBurritoAssembledItemGroupView>()?.Setup(Prefab);

            //TO DO : Change to chicken

            GameObject Beef = Prefab.GetChild("Meat - Chopped");
            Material[] mats = new Material[] { MaterialUtils.GetExistingMaterial("Well-done"), MaterialUtils.GetExistingMaterial("Well-done Fat") };
            Beef.GetChild("Meat - Chopped").ApplyMaterial(mats);


            GameObject Tortilla = Prefab.GetChild("Tortilla/Tortilla.002");
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
    public class BeefBurritoAssembledItemGroupView : ItemGroupView
    {
        internal void Setup(GameObject prefab)
        {
            // This tells which sub-object of the prefab corresponds to each component of the ItemGroup
            // All of these sub-objects are hidden unless the item is present

            ComponentGroups = new()
            {
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Meat - Chopped"),
                    Item = Mod.ChoppedBeefCooked
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Tortilla"),
                    Item = Mod.FlourTortilla
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Rice"),
                    Item = Mod.CookedRice
                }
            };
            ComponentLabels = new()
            {
                new()
                {
                    Text = "M",
                    Item = Mod.ChoppedBeefCooked
                },
                new()
                {
                    Text = "T",
                    Item = Mod.FlourTortilla
                },
                new()
                {
                    Text = "R",
                    Item = Mod.CookedRice
                }
            };
        }
    }
}
