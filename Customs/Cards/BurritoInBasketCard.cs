using IngredientLib.Util;
using KitchenBurritoMod;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace BurritoMod.Customs.Cards
{
    internal class BurritoInBasketCard : CustomDish
    {
        public override string UniqueNameID => "BurritoInBasketCard";
        public override DishType Type => DishType.Main;
        public override GameObject DisplayPrefab => Mod.Bundle.LoadAsset<GameObject>("BaseBurritoInBasket");
        public override GameObject IconPrefab => DisplayPrefab;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.LargeDecrease;
        public override CardType CardType => CardType.Default;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Large;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override bool IsSpecificFranchiseTier => false;
        public override bool DestroyAfterModUninstall => false;
        public override bool IsUnlockable => true;
        public override HashSet<Item> BlockProviders => new()
        {
            Mod.BurritoFoilWrapped
        };
        public override List<Unlock> HardcodedRequirements => new()
        {
            Mod.BurritoDish
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
            Mod.Tortilla,
            Mod.Rice,
            Mod.Chicken,
            Mod.Foil,
            Mod.BurritoBasket
        };
        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
            Mod.Cook,
            Mod.Chop,
            Mod.Knead
        };
        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Add Burrito to basket and serve!" }
        };
        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateUnlockInfo("Burrito in a basket!", "You have to put your burrito in a basket", "Room for sides!") )
        };

        public override void OnRegister(GameDataObject gameDataObject)
        {
            Debug.Log("Foil Wrapped Burrito");
            GameObject FoilWrappedBurrito = DisplayPrefab.GetChild("FoilWrappedBurrito");
            Material[] mats = new Material[] { MaterialUtils.GetExistingMaterial("Metal- Shiny") };
            FoilWrappedBurrito.ApplyMaterial(mats);
            FoilWrappedBurrito.GetChild("FoilEnds").ApplyMaterial(mats);
        }
    }
}
