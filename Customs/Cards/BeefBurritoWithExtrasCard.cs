﻿using KitchenBurritoMod;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace BurritoMod.Customs
{
    internal class BeefBurritoWithExtrasCard : CustomDish
    {
        public override string UniqueNameID => "BeefBurritoWithExtrasCard";
        public override DishType Type => DishType.Main;
        public override GameObject DisplayPrefab => Mod.Bundle.LoadAsset<GameObject>("BeefBurritoWithExtrasInBasketIcon");
        public override GameObject IconPrefab => DisplayPrefab;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.LargeDecrease;
        public override CardType CardType => CardType.Default;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Large;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override bool IsSpecificFranchiseTier => false;
        public override bool DestroyAfterModUninstall => false;
        public override bool IsUnlockable => true;
        public override bool RequiredNoDishItem => true;

        public override List<Unlock> HardcodedRequirements => new()
        {
            Mod.BeefBurritoDish
        };

        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
        {
            new Dish.MenuItem
            {
                Item = Mod.BeefBurritoWithExtrasInaBasket,
                Phase = MenuPhase.Main,
                Weight = 1
            }
        };
        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            Mod.Wok,
            Mod.FlourTortilla,
            Mod.Lettuce,
            Mod.Tomato,
            Mod.Rice,
            Mod.Meat,
            Mod.Foil,
            Mod.BurritoBasket
        };
        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
            Mod.Cook,
            Mod.Chop,
            Mod.Knead
        };
        //Locale.English, "Combine chopped lettuce and tomato with the unwrapped base burrito, Interact to wrap and then toast and wrap in foil"
        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Combine chopped lettuce and tomato with the unwrapped beef burrito, Interact to wrap and then wrap in foil. Serve in a basket!" }
        };
        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateUnlockInfo("Beef Burrito with salad", "You have to add chopped lettuce and tomato to the burrito", "Gotta be healthy") )
        };

        public override void OnRegister(Dish gameDataObject)
        {
            //TO DO: Change to chicken
            GameObject FoilWrappedBurrito = DisplayPrefab.GetChild("FoilWrappedBurrito");
            Material[] mats = new Material[] { MaterialUtils.GetExistingMaterial("Metal- Shiny") };
            FoilWrappedBurrito.ApplyMaterial(mats);
            FoilWrappedBurrito.GetChild("FoilEnds").ApplyMaterial(mats);

            mats = new Material[] { MaterialUtils.GetExistingMaterial("Lettuce") };
            FoilWrappedBurrito.GetChild("StickerLettuce").ApplyMaterial(mats);

            mats = new Material[] { MaterialUtils.GetExistingMaterial("Tomato") };
            FoilWrappedBurrito.GetChild("StickerTomato").ApplyMaterial(mats);
            mats = new Material[] { MaterialUtils.GetExistingMaterial("Well-done") };
            FoilWrappedBurrito.GetChild("StickerBeef").ApplyMaterial(mats);


            mats = new Material[] { MaterialUtils.GetExistingMaterial("Tomato") };
            DisplayPrefab.GetChild("BurritoBasket").ApplyMaterial(mats);
            mats = new Material[] { MaterialUtils.GetExistingMaterial("Cooked Pastry") };
            DisplayPrefab.GetChild("BurritoBasket/Paper").ApplyMaterial(mats);
        }
    }
}
