using IngredientLib.Util;
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

namespace BurritoMod.Customs
{
    internal class BurritoWithExtrasCard : CustomDish
    {
        public override string UniqueNameID => "BurritoWithExtrasCard";
        public override DishType Type => DishType.Main;
        public override GameObject DisplayPrefab => Mod.Bundle.LoadAsset<GameObject>("TortillaWrappedIcon");
        public override GameObject IconPrefab => DisplayPrefab;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.LargeDecrease;
        public override CardType CardType => CardType.Default;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override bool IsSpecificFranchiseTier => false;
        public override bool DestroyAfterModUninstall => false;
        public override bool IsUnlockable => true;

        public override List<Unlock> HardcodedRequirements => new()
        {
            Mod.BurritoDish
        };

        public override HashSet<Dish.IngredientUnlock> IngredientsUnlocks => new HashSet<Dish.IngredientUnlock>
        {
            new Dish.IngredientUnlock
            {
                Ingredient = Mod.ChoppedLettuce,
                MenuItem = Mod.BaseBurritoAssembled
            }
        };
        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            Mod.Wok,
            Mod.Tortilla,
            Mod.Lettuce,
            Mod.Tomato,
            Mod.Rice,
            Mod.Chicken
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
            { Locale.English, "Combine chopped lettuce and tomato with the unwrapped base burrito, Interact to wrap and then toast and wrap in foil" }
        };
        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateUnlockInfo("Burrito with salad", "You have to add chopped lettuce and tomato to the burrito", "Gotta be healthy") )
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
