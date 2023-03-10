using BurritoMod.Registry;
using IngredientLib.Util;
using Kitchen;
using KitchenBurritoMod;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace BurritoMod.Customs.Cards
{
    class BurritoDish : ModDish
    {
        public override string UniqueNameID => "Burrito Dish";
        public override DishType Type => DishType.Base;
        public override GameObject DisplayPrefab => Mod.Bundle.LoadAsset<GameObject>("BaseBurritoInBasketIcon");
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
            "Hurricane Tortilla",
            "It's a wrap!",
            "Chick-o-Bell",
            "Un-Burrito-Ble!",
            "Neato Burrito",
            "Boo-Rito",
            "Gangster Wrap",
            "Epic Wrap Battle",
            "Danny Burrito",
            "Let's get shredded!"
        };
        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
        {
            new Dish.MenuItem
            {
                Item = Mod.BurritoInaBasket,
                Phase = MenuPhase.Main,
                Weight = 1
            }
        };
        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            Mod.Wok,
            Mod.FlourTortilla,
            Mod.Rice,
            Mod.Chicken,
            Mod.Foil,
            Mod.BurritoBasket
        };
        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
            Mod.Cook,
            Mod.Chop,
            Mod.Knead,
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Cook Chicken and shred, combine with tortilla, Cook rice and add to tortilla, Interact to wrap and then toast and wrap in foil. Serve in a basket!" }
        };
        public override IDictionary<Locale, UnlockInfo> LocalisedInfo => new Dictionary<Locale, UnlockInfo>
        {
            { Locale.English, LocalisationUtils.CreateUnlockInfo("Burrito", "Adds Burrito as a Main", "It means little donkey.") }
        };

        public override void OnRegister(GameDataObject gameDataObject)
        {
            //TO DO: Change to chicken
            GameObject FoilWrappedBurrito = DisplayPrefab.GetChild("FoilWrappedBurrito");
            Material[] mats = new Material[] { MaterialUtils.GetExistingMaterial("Metal- Shiny") };
            FoilWrappedBurrito.ApplyMaterial(mats);
            FoilWrappedBurrito.GetChild("FoilEnds").ApplyMaterial(mats);

            mats = new Material[] { MaterialUtils.GetExistingMaterial("Tomato") };
            DisplayPrefab.GetChild("BurritoBasket").ApplyMaterial(mats);
            mats = new Material[] { MaterialUtils.GetExistingMaterial("Cooked Pastry") };
            DisplayPrefab.GetChild("BurritoBasket").GetChild("Paper").ApplyMaterial(mats);

        }
    }
}
