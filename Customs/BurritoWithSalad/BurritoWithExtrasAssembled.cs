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
    class BurritoWithExtrasAssembled : CustomItemGroup<BurritoWithExtrasAssembledItemGroupView>
    {
        public override string UniqueNameID => "BurritoWithExtrasAssembled";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("ChickenBurritoExtrasAssembly");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemValue ItemValue => ItemValue.Large;

        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Duration = 1,
                Process = Mod.Knead,
                Result = Mod.BurritoWithExtrasCooked
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
                    Mod.ChoppedChickenCooked
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
            }, new ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    Mod.ChoppedLettuce,
                }
            },
        };

        //Well-done  Burger for spots on burrito
        //Bread - Inside Cooked for Main Burrito
        public override void OnRegister(ItemGroup gameDataObject)
        {
            Prefab.GetComponent<BurritoWithExtrasAssembledItemGroupView>()?.Setup(Prefab);

            GameObject lettuce = Prefab.GetChild("ChoppedLettuce");
            Material[] mats = new Material[] { MaterialUtils.GetExistingMaterial("Lettuce") };
            lettuce.GetChild("Salad.003").ApplyMaterial(mats);

            GameObject tomato = Prefab.GetChild("Tomato/Tomato - Chopped/Tomato Sliced");
            mats = new Material[] { MaterialUtils.GetExistingMaterial("Tomato Flesh") };
            tomato.GetChild("Liquid").ApplyMaterial(mats);

            mats = new Material[] { MaterialUtils.GetExistingMaterial("Tomato Flesh 2") };
            tomato.GetChild("Liquid.001").ApplyMaterial(mats);

            mats = new Material[] { MaterialUtils.GetExistingMaterial("Tomato") };
            tomato.GetChild("Skin").ApplyMaterial(mats);

            tomato = Prefab.GetChild("Tomato/Tomato - Chopped (1)/Tomato Sliced.001");
            mats = new Material[] { MaterialUtils.GetExistingMaterial("Tomato Flesh") };
            tomato.GetChild("Liquid.002").ApplyMaterial(mats);

            mats = new Material[] { MaterialUtils.GetExistingMaterial("Tomato Flesh 2") };
            tomato.GetChild("Liquid.003").ApplyMaterial(mats);

            mats = new Material[] { MaterialUtils.GetExistingMaterial("Tomato") };
            tomato.GetChild("Skin.001").ApplyMaterial(mats);

            //TO DO : Change to chicken

            Prefab.GetChild("Chicken - Chopped").ApplyMaterialToChild("Chicken - Chopped", "Cooked Batter", "Cooked Batter");

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
    public class BurritoWithExtrasAssembledItemGroupView : ItemGroupView
    {
        internal void Setup(GameObject prefab)
        {
            // This tells which sub-object of the prefab corresponds to each component of the ItemGroup
            // All of these sub-objects are hidden unless the item is present
            ComponentGroups = new()
            {
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "ChoppedLettuce"),
                    Item = Mod.ChoppedLettuce
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Tomato"),
                    Item = Mod.ChoppedTomato
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Chicken - Chopped"),
                    Item = Mod.ChoppedChickenCooked
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
                    Text = "Chi",
                    Item = Mod.ChoppedChickenCooked
                },
                new()
                {
                    Text = "Tor",
                    Item = Mod.FlourTortilla
                },
                new()
                {
                    Text = "R",
                    Item = Mod.CookedRice
                },new()
                {
                    Text = "L",
                    Item = Mod.ChoppedLettuce
                },
                new()
                {
                    Text = "Tom",
                    Item = Mod.ChoppedTomato
                }
            };
        }

    }
}
