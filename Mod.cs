using BurritoMod.Customs;
using BurritoMod.Customs.BaseBurrito;
using BurritoMod.Customs.BeefBurrito;
using BurritoMod.Customs.BeefBurritoWithSalad;
using BurritoMod.Customs.BurritoSharedItems;
using BurritoMod.Customs.BurritoWithSalad;
using BurritoMod.Customs.Cards;
using BurritoMod.Customs.Providers;
using IngredientLib.Ingredient.Items;
using IngredientLib.Ingredient.Providers;
using Kitchen;
using KitchenData;
using KitchenLib;
using KitchenLib.Customs;
using KitchenLib.Event;
using KitchenLib.References;
using KitchenLib.Utils;
using KitchenMods;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TMPro;
using UnityEngine;

// Namespace should have "Kitchen" in the beginning
namespace KitchenBurritoMod
{
    public class Mod : BaseMod, IModSystem
    {
        // GUID must be unique and is recommended to be in reverse domain name notation
        // Mod Name is displayed to the player and listed in the mods menu
        // Mod Version must follow semver notation e.g. "1.2.3"
        public const string MOD_GUID = "Madvion.PlateUp.BurritoMod";
        public const string MOD_NAME = "Burrito Mod";
        public const string MOD_VERSION = "0.1.4";
        public const string MOD_AUTHOR = "Madvion";
        public const string MOD_GAMEVERSION = ">=1.1.3";
        // Game version this mod is designed for in semver
        // e.g. ">=1.1.3" current and all future
        // e.g. ">=1.1.3 <=1.2.3" for all from/until

        // Boolean constant whose value depends on whether you built with DEBUG or RELEASE mode, useful for testing
#if DEBUG
        public const bool DEBUG_MODE = true;
#else
        public const bool DEBUG_MODE = false;
#endif

        public static AssetBundle Bundle;

        // Vanilla Processes
        internal static Process Cook => GetExistingGDO<Process>(ProcessReferences.Cook);
        internal static Process Chop => GetExistingGDO<Process>(ProcessReferences.Chop);
        internal static Process Knead => GetExistingGDO<Process>(ProcessReferences.Knead);

        // Vanilla Items
        internal static Item Burnt => GetExistingGDO<Item>(ItemReferences.BurnedFood);
        internal static Item Meat => GetExistingGDO<Item>(ItemReferences.Meat);

        internal static Item ChoppedBeef => GetExistingGDO<Item>(ItemReferences.MeatChopped);
        internal static Item ChoppedBeefCooked => GetExistingGDO<Item>(ItemReferences.MeatChoppedContainerCooked);


        internal static Item Tomato => GetExistingGDO<Item>(ItemReferences.Tomato);
        internal static Item ChoppedTomato => GetExistingGDO<Item>(ItemReferences.TomatoChopped);
        internal static Item Lettuce => GetExistingGDO<Item>(ItemReferences.Lettuce);
        internal static Item ChoppedLettuce => GetExistingGDO<Item>(ItemReferences.LettuceChopped);
        internal static Item Rice => GetExistingGDO<Item>(ItemReferences.Rice);
        internal static Item CookedRice => GetExistingGDO<Item>(ItemReferences.RiceContainerCooked);
        internal static Item Wok => Find<Item>(ItemReferences.Wok);
        internal static Item Plate => Find<Item>(ItemReferences.Plate);
        internal static Item DirtyPlate => Find<Item>(ItemReferences.PlateDirty);

        // Modded Items
        internal static Item Chicken => Find<Item>(IngredientLib.References.GetIngredient("Chicken"));
        internal static Item CookedChicken => Find<Item>(IngredientLib.References.GetIngredient("Cooked Chicken"));
        internal static Item ShreddedChicken => Find<Item>(IngredientLib.References.GetIngredient("Shredded Chicken"));
        internal static Item FlourTortilla => Find<Item>(IngredientLib.References.GetIngredient("Flour Tortillas"));

        internal static ItemGroup BaseBurritoAssembled => GetModdedGDO<ItemGroup, BaseBurritoAssembled>();
        internal static ItemGroup BeefBurritoAssembled => GetModdedGDO<ItemGroup, BeefBurritoAssembled>();
        internal static ItemGroup BeefBurritoWithExtrasAssembled => GetModdedGDO<ItemGroup, BeefBurritoWithExtrasAssembled>();
        internal static ItemGroup BurritoWithExtrasAssembled => GetModdedGDO<ItemGroup, BurritoWithExtrasAssembled>();
        internal static Item ChoppedChickenCooked => GetModdedGDO<Item, ChoppedChickenCooked>();


        internal static Item BurritoWrapped => GetModdedGDO<Item, BurritoWrapped>();
        internal static Item BeefBurritoWrapped => GetModdedGDO<Item, BeefBurritoWrapped>();
        internal static Item BeefBurritoWithExtrasWrapped => GetModdedGDO<Item, BeefBurritoWithExtrasWrapped>();
        internal static Item BurritoWithExtrasWrapped => GetModdedGDO<Item, BurritoWithExtrasWrapped>();

        internal static Item BurritoCooked => GetModdedGDO<Item, BurritoCooked>();
        internal static Item BeefBurritoCooked => GetModdedGDO<Item, BeefBurritoCooked>();
        internal static Item BeefBurritoWithExtrasCooked => GetModdedGDO<Item, BeefBurritoWithExtrasCooked>();
        internal static Item BurritoWithExtrasCooked => GetModdedGDO<Item, BurritoWithExtrasCooked>();

        internal static Item BurritoFoilWrapped => GetModdedGDO<Item, BurritoFoilWrapped>();
        internal static Item BeefBurritoFoilWrapped => GetModdedGDO<Item, BeefBurritoFoilWrapped>();
        internal static Item BeefBurritoWithExtrasFoilWrapped => GetModdedGDO<Item, BeefBurritoWithExtrasFoilWrapped>();
        internal static Item BurritoWithExtrasFoilWrapped => GetModdedGDO<Item, BurritoWithExtrasFoilWrapped>();

        internal static Item BurritoInaBasket => GetModdedGDO<Item, BurritoInaBasket>();
        internal static Item BeefBurritoInaBasket => GetModdedGDO<Item, BeefBurritoInaBasket>();
        internal static Item BeefBurritoWithExtrasInaBasket => GetModdedGDO<Item, BeefBurritoWithExtrasInaBasket>();
        internal static Item BurritoWithExtrasInaBasket => GetModdedGDO<Item, BurritoWithExtrasInaBasket>();

        internal static Item Foil => GetModdedGDO<Item, Foil>();
        internal static Item BurritoBasket => GetModdedGDO<Item, BurritoBasket>();


        // Modded Dishes
        internal static Dish BurritoDish => GetModdedGDO<Dish, BurritoDish>();
        internal static Dish BeefBurritoDish => GetModdedGDO<Dish, BeefBurritoDish>();
        internal static Dish BurritoWithExtrasCard => GetModdedGDO<Dish, BurritoWithExtrasCard>();

        // Modded Appliances 
        internal static Appliance FoilProvider => GetModdedGDO<Appliance, FoilProvider>();
        internal static Appliance BurritoBasketProvider => GetModdedGDO<Appliance, BurritoBasketProvider>();
        internal static Appliance ChickenProvider => GetModdedGDO<Appliance, ChickenProvider>();


        //Processes
        public static Process WrapInFoil => GetModdedGDO<Process, WrapInFoil>();


        public Mod() : base(MOD_GUID, MOD_NAME, MOD_AUTHOR, MOD_VERSION, MOD_GAMEVERSION, Assembly.GetExecutingAssembly()) { }

        protected override void OnInitialise()
        {
            LogWarning($"{MOD_GUID} v{MOD_VERSION} in use!");
        }

        private void AddGameData()
        {
            LogInfo("Attempting to register game data...");

            // Dishes and Cards
            AddGameDataObject<BurritoDish>();
            AddGameDataObject<BeefBurritoDish>();
            AddGameDataObject<BeefBurritoWithExtrasCard>();
            AddGameDataObject<BurritoWithExtrasCard>();

            // Items
            AddGameDataObject<BaseBurritoAssembled>();
            AddGameDataObject<BeefBurritoAssembled>();
            AddGameDataObject<BeefBurritoWithExtrasAssembled>();
            AddGameDataObject<BurritoWithExtrasAssembled>();

            AddGameDataObject<BurritoWrapped>();
            AddGameDataObject<BeefBurritoWrapped>();
            AddGameDataObject<BeefBurritoWithExtrasWrapped>();
            AddGameDataObject<BurritoWithExtrasWrapped>();

            AddGameDataObject<BurritoCooked>();
            AddGameDataObject<BeefBurritoCooked>();
            AddGameDataObject<BeefBurritoWithExtrasCooked>();
            AddGameDataObject<BurritoWithExtrasCooked>();

            AddGameDataObject<BurritoFoilWrapped>();
            AddGameDataObject<BeefBurritoFoilWrapped>();
            AddGameDataObject<BeefBurritoWithExtrasFoilWrapped>();
            AddGameDataObject<BurritoWithExtrasFoilWrapped>();

            AddGameDataObject<BurritoInaBasket>();
            AddGameDataObject<BeefBurritoInaBasket>();
            AddGameDataObject<BeefBurritoWithExtrasInaBasket>();
            AddGameDataObject<BurritoWithExtrasInaBasket>();

            AddGameDataObject<BurritoBasket>();
            AddGameDataObject<Foil>();

            AddGameDataObject<ChoppedChicken>();
            AddGameDataObject<ChoppedChickenCooked>();



            //Providers
            AddGameDataObject<BurritoBasketProvider>();
            AddGameDataObject<FoilProvider>();

            //Processes
            AddGameDataObject<WrapInFoil>();
            LogInfo("Done loading game data.");
        }

        protected override void OnUpdate()
        {
        }

        protected override void OnPostActivate(KitchenMods.Mod mod)
        {
            // TODO: Uncomment the following if you have an asset bundle.
            // TODO: Also, make sure to set EnableAssetBundleDeploy to 'true' in your ModName.csproj

            LogInfo("Attempting to load asset bundle...");
            Bundle = mod.GetPacks<AssetBundleModPack>().SelectMany(e => e.AssetBundles).First();
            Bundle.LoadAllAssets<Texture2D>();
            Bundle.LoadAllAssets<Sprite>();
            Bundle.LoadAllAssets<AudioClip>();

            var spriteAsset = Bundle.LoadAsset<TMP_SpriteAsset>("Foil_Icon-01");
            TMP_Settings.defaultSpriteAsset.fallbackSpriteAssets.Add(spriteAsset);
            spriteAsset.material = Object.Instantiate(TMP_Settings.defaultSpriteAsset.material);
            spriteAsset.material.mainTexture = Bundle.LoadAsset<Texture2D>("Foil_Icon-01Tex");
            LogInfo("Done loading asset bundle.");

            // Register custom GDOs
            AddGameData();

            //AudioUtils.AddProcessAudioClip(WrapInFoil.ID, AudioUtils.GetProcessAudioClip(GetExistingGDO<Process>(ProcessReferences.Cook).ID));

            // Perform actions when game data is built
            Events.BuildGameDataEvent += delegate (object s, BuildGameDataEventArgs args)
            {
                ItemGroup stirFryRaw = args.gamedata.Get<ItemGroup>(ItemGroupReferences.StirFryRaw);
                GameObject rawPork = Mod.Bundle.LoadAsset<GameObject>("Pork - Chopped");
                GameObject cookedPork = Mod.Bundle.LoadAsset<GameObject>("Pork - Chopped Cooked");

                GameObject rawChicken = Mod.Bundle.LoadAsset<GameObject>("Chicken - Chopped");
                GameObject cookedChicken = Mod.Bundle.LoadAsset<GameObject>("Chicken - Chopped Cooked");


                rawPork.transform.parent = stirFryRaw.Prefab.GetChild("Raw").transform;
                rawPork.transform.position = new Vector3(0, 0.05f, 0);
                cookedPork.transform.parent = stirFryRaw.Prefab.GetChild("Cooked").transform;
                cookedPork.transform.position = new Vector3(0, 0.05f, 0);
                rawChicken.transform.parent = stirFryRaw.Prefab.GetChild("Raw").transform;
                rawChicken.transform.position = new Vector3(0, 0.05f, 0);
                cookedChicken.transform.parent = stirFryRaw.Prefab.GetChild("Cooked").transform;
                cookedChicken.transform.position = new Vector3(0, 0.05f, 0);
                rawPork.SetActive(false);
                cookedPork.SetActive(false);
                rawChicken.SetActive(false);
                cookedChicken.SetActive(false);

                ItemGroupView stirFryView = stirFryRaw.Prefab.GetComponent<ItemGroupView>();
                Mod.LogWarning("Made it to Got Item Group View");

                // Itemsets
                Mod.LogWarning("Made it to item sets");
                Item choppedPorkRaw = GDOUtils.GetCastedGDO<Item, ChoppedPork>();
                Item choppedPorkCooked = GDOUtils.GetCastedGDO<Item, Bacon>();
                Item choppedChickenRaw = GDOUtils.GetCastedGDO<Item, ChoppedChicken>();
                Item choppedChickenCooked = GDOUtils.GetCastedGDO<Item, ChoppedChickenCooked>();
                Mod.LogWarning("Made it to retrieved casted GDO's");

                Mod.LogWarning(choppedPorkRaw);
                Mod.LogWarning(choppedPorkCooked);
                Mod.LogWarning(choppedChickenRaw);
                Mod.LogWarning(choppedChickenCooked);
                Mod.LogWarning("printed  retrieved casted GDO's");

                if (stirFryRaw.DerivedSets != null)
                {
                    Mod.LogWarning("Derived sets were not null");

                    ItemGroup.ItemSet porkSet = new ItemGroup.ItemSet()
                    {
                        Items = new List<Item>() { choppedPorkRaw, choppedPorkCooked },
                        Min = 0,
                        Max = 1,
                        RequiresUnlock = true
                    };
                    Mod.LogWarning("porkSet");
                    Mod.LogWarning(porkSet);


                    stirFryRaw.DerivedSets.Add(porkSet);

                    ItemGroup.ItemSet chickenSet = new ItemGroup.ItemSet()
                    {
                        Items = new List<Item>() { choppedChickenRaw, choppedChickenCooked },
                        Min = 0,
                        Max = 1,
                        RequiresUnlock = true
                    };
                    Mod.LogWarning("chickenSet");
                    Mod.LogWarning(chickenSet);

                    stirFryRaw.DerivedSets.Add(chickenSet);
                }
                else Mod.LogWarning("Derived sets for stir fry was null");



                Mod.LogWarning("Made it to just before component accessor");
                foreach (Transform child in stirFryRaw.Prefab.GetChild("Raw").GetComponentInChildren<Transform>())
                {
                    Mod.LogWarning($"child name is : {child.gameObject.name}");
                }

                ComponentAccesserUtil.AddComponent(stirFryView, (choppedPorkRaw, stirFryRaw.Prefab.GetChild("Raw/Pork - Chopped")), (choppedPorkCooked, stirFryRaw.Prefab.GetChild("Cooked/Pork - Chopped Cooked")), (choppedChickenRaw, stirFryRaw.Prefab.GetChild("Raw/Chicken - Chopped")), (choppedChickenCooked, stirFryRaw.Prefab.GetChild("Cooked/Chicken - Chopped Cooked")));
                //ComponentAccesserUtil.AddComponent(stirFryView, (choppedPorkCooked, stirFryRaw.Prefab.GetChild("Cooked/Pork - Chopped Cooked")));
                //ComponentAccesserUtil.AddComponent(stirFryView, (choppedChickenRaw, stirFryRaw.Prefab.GetChild("Raw/Chicken - Chopped")));
                //ComponentAccesserUtil.AddComponent(stirFryView, (choppedChickenCooked, stirFryRaw.Prefab.GetChild("Cooked/Chicken - Chopped Cooked")));

                Item choppedPork = GDOUtils.GetCastedGDO<Item, ChoppedPork>();
                Item chicken = GDOUtils.GetCastedGDO<Item, Chicken>();
                
                Mod.LogWarning("Made it to Applying processes");


                Item.ItemProcess cookProc = new Item.ItemProcess()
                {
                    Process = Mod.Cook,
                    Result = choppedPorkCooked,
                    Duration = 4,
                    IsBad = false,
                    RequiresWrapper = true,
                };
                choppedPork.DerivedProcesses.Add(cookProc);

                Item.ItemProcess chopProc = new Item.ItemProcess()
                {
                    Process = Mod.Chop,
                    Result = choppedChickenRaw,
                    Duration = 2.4f,
                    IsBad = false,
                };
                chicken.DerivedProcesses.Add(chopProc);
                Mod.LogWarning("Finished On Post Activate");
            };
        }

        internal class ComponentAccesserUtil : ItemGroupView
        {
            private static FieldInfo componentGroupField = ReflectionUtils.GetField<ItemGroupView>("ComponentGroups");


            public static void AddComponent(ItemGroupView viewToAddTo, params (Item item, GameObject gameObject)[] addedGroups)
            {
                List<ComponentGroup> componentGroups = componentGroupField.GetValue(viewToAddTo) as List<ComponentGroup>;
                foreach (var group in addedGroups)
                {
                    componentGroups.Add(new()
                    {
                        Item = group.item,
                        GameObject = group.gameObject
                    });
                }
                componentGroupField.SetValue(viewToAddTo, componentGroups);
                viewToAddTo.DrawComponents = null;
                
            }
        }

        private static T1 GetModdedGDO<T1, T2>() where T1 : GameDataObject
        {
            return (T1)GDOUtils.GetCustomGameDataObject<T2>().GameDataObject;
        }
        private static T GetExistingGDO<T>(int id) where T : GameDataObject
        {
            return (T)GDOUtils.GetExistingGDO(id);
        }
        internal static T Find<T>(int id) where T : GameDataObject
        {
            return (T)GDOUtils.GetExistingGDO(id) ?? (T)GDOUtils.GetCustomGameDataObject(id)?.GameDataObject;
        }

        internal static T Find<T, C>() where T : GameDataObject where C : CustomGameDataObject
        {
            return GDOUtils.GetCastedGDO<T, C>();
        }

        internal static T Find<T>(string modName, string name) where T : GameDataObject
        {
            return GDOUtils.GetCastedGDO<T>(modName, name);
        }
        #region Logging
        public static void LogInfo(string _log) { Debug.Log($"[{MOD_NAME}] " + _log); }
        public static void LogWarning(string _log) { Debug.LogWarning($"[{MOD_NAME}] " + _log); }
        public static void LogError(string _log) { Debug.LogError($"[{MOD_NAME}] " + _log); }
        public static void LogInfo(object _log) { LogInfo(_log.ToString()); }
        public static void LogWarning(object _log) { LogWarning(_log.ToString()); }
        public static void LogError(object _log) { LogError(_log.ToString()); }
        #endregion
    }
}
