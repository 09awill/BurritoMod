using IngredientLib.Util;
using KitchenAmericanBreakfast.Utils;
using KitchenBurritoMod;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using ModdedKitchen.Dishes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Entities;
using UnityEngine;

namespace BurritoMod.Customs
{
    class BurritoDish : ModDish
    {
        public override string UniqueNameID => "Burrito Dish";
        public override DishType Type => DishType.Base;
        public override GameObject DisplayPrefab => Mod.Bundle.LoadAsset<GameObject>("BurritoIcon");
        public override GameObject IconPrefab => DisplayPrefab;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.LargeDecrease;
        public override CardType CardType => CardType.Default;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Large;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override bool IsSpecificFranchiseTier => false;
        public override bool IsAvailableAsLobbyOption => true;
        public override bool DestroyAfterModUninstall => false;
        public override bool IsUnlockable => true;

        public override List<string> StartingNameSet => new List<string>
        {
            "Burrito Bandito",
            "Pico this peen",
            "JasonMakesBurritos"
        };
        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
        {
            new Dish.MenuItem
            {
                Item = Mod.Burrito,
                Phase = MenuPhase.Main,
                Weight = 1
            }
        };
        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            Mod.Wok,
            Mod.Tortilla,
            Mod.Lettuce,
            Mod.Tomato,
            Mod.Rice
        };
        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
            Mod.Cook,
            Mod.Chop
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Chop Lettuce, chop tomato, cook rice and combine with tortilla, optionally combine with cooked chopped meat. Cook and serve!" }
        };
        public override IDictionary<Locale, UnlockInfo> LocalisedInfo => new Dictionary<Locale, UnlockInfo>
        {
            { Locale.English, LocalisationUtils.CreateUnlockInfo("Burrito", "Adds Burrito as a Main", "Just for memes.") }
        };

        public override void OnRegister(GameDataObject gameDataObject)
        {
            GameObject lettuce = DisplayPrefab.GetChild("Salad");
            Material[] mats = new Material[] { MaterialUtils.GetExistingMaterial("Lettuce") };
            lettuce.GetChild("ChoppedLettuce").ApplyMaterial(mats);

            GameObject tomato = DisplayPrefab.GetChildFromPath("Tomato - Chopped/Tomato Sliced");
            mats = new Material[] { MaterialUtils.GetExistingMaterial("Tomato Flesh") };
            tomato.GetChild("ChoppedTomatoLiquid").ApplyMaterial(mats);

            mats = new Material[] { MaterialUtils.GetExistingMaterial("Tomato Flesh 2") };
            tomato.GetChild("ChoppedTomatoLiquid1").ApplyMaterial(mats);

            mats = new Material[] { MaterialUtils.GetExistingMaterial("Tomato") };
            tomato.GetChild("ChoppedTomatoSkin").ApplyMaterial(mats);

            GameObject Meat = DisplayPrefab.GetChild("Meat - Chopped");
            mats = new Material[] { MaterialUtils.GetExistingMaterial("Raw") };
            Meat.GetChild("ChoppedMeatCooked").ApplyMaterial(mats);

            GameObject Tortilla = DisplayPrefab.GetChild("TortillaBase");
            mats = new Material[] { MaterialUtils.GetExistingMaterial("Rice") };
            Tortilla.GetChild("Tortilla").ApplyMaterial(mats);

            GameObject Rice = DisplayPrefab.GetChild("Rice");
            mats = new Material[] { MaterialUtils.GetExistingMaterial("Rice") };
            Rice.GetChild("CookedRice").ApplyMaterial(mats);
        }
    }
}
