﻿using IngredientLib.Util;
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
        public override GameObject DisplayPrefab => Mod.Bundle.LoadAsset<GameObject>("TortillaWrappedIcon");
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
                Item = Mod.BurritoFoilWrapped,
                Phase = MenuPhase.Main,
                Weight = 1
            }
        };
        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            Mod.Wok,
            Mod.Tortilla,
            Mod.Rice,
            Mod.Chicken
        };
        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
            Mod.Cook,
            Mod.Chop,
            Mod.Knead,
            Mod.WrapInFoil
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Cook Chicken and shred, combine with tortilla, Cook rice and add to tortilla, Interact to wrap and then toast and wrap in foil" }
        };
        public override IDictionary<Locale, UnlockInfo> LocalisedInfo => new Dictionary<Locale, UnlockInfo>
        {
            { Locale.English, LocalisationUtils.CreateUnlockInfo("Burrito", "Adds Burrito as a Main", "Just for memes.") }
        };

        public override void OnRegister(GameDataObject gameDataObject)
        {
            Debug.Log("Base Burrito");

            Material[] mats = new Material[] { MaterialUtils.GetExistingMaterial("Bread - Inside") };
            DisplayPrefab.GetChild("Burrito").ApplyMaterial(mats);

            Debug.Log("Burrito Toasted");

            mats = new Material[] { MaterialUtils.GetExistingMaterial("Well-done Burger") };
            DisplayPrefab.GetChild("Burrito").ApplyMaterial(mats);

            Debug.Log("Foil Wrapped Burrito");

            //TO DO: Change to chicken
            GameObject FoilWrappedBurrito = DisplayPrefab.GetChild("FoilWrappedBurrito");
            mats = new Material[] { MaterialUtils.GetExistingMaterial("Metal- Shiny") };
            FoilWrappedBurrito.ApplyMaterial(mats);
            FoilWrappedBurrito.GetChild("Burrito.002").ApplyMaterial(mats);
            FoilWrappedBurrito.GetChild("Burrito.003").ApplyMaterial(mats);
            FoilWrappedBurrito.GetChild("Burrito.004").ApplyMaterial(mats);
            FoilWrappedBurrito.GetChild("Burrito.005").ApplyMaterial(mats);
        }
    }
}
