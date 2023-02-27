using BurritoMod.Customs;
using BurritoMod.Customs.Cards;
using Kitchen;
using KitchenData;
using KitchenLib;
using KitchenLib.Customs;
using KitchenLib.Event;
using KitchenLib.References;
using KitchenLib.Utils;
using KitchenMods;
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
        public const string MOD_VERSION = "0.1.2";
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

        internal static ItemGroup BaseBurritoAssembled => GetModdedGDO<ItemGroup, BaseBurritoAssembled>();
        internal static ItemGroup BurritoWithExtrasAssembled => GetModdedGDO<ItemGroup, BurritoWithExtrasAssembled>();
        internal static Item BurritoWithExtrasWrapped => GetModdedGDO<Item, BurritoWithExtrasWrapped>();
        internal static Item BurritoWithExtrasCooked => GetModdedGDO<Item, BurritoWithExtrasCooked>();
        internal static Item BurritoFoilWrapped => GetModdedGDO<Item, BurritoFoilWrapped>();
        internal static Item BurritoWithExtrasFoilWrapped => GetModdedGDO<Item, BurritoWithExtrasFoilWrapped>();
        internal static Item FlourTortilla => GetModdedGDO<Item, FlourTortilla>();

        internal static Item BurritoWrapped => GetModdedGDO<Item, BurritoWrapped>();
        internal static Item BurritoCooked => GetModdedGDO<Item, BurritoCooked>();
        internal static Item Foil => GetModdedGDO<Item, Foil>();
        internal static Item BurritoBasket => GetModdedGDO<Item, BurritoBasket>();
        internal static Item BurritoWithExtrasInaBasket => GetModdedGDO<Item, BurritoWithExtrasInaBasket>();
        internal static Item BurritoInaBasket => GetModdedGDO<Item, BurritoInaBasket>();

        // Modded Dishes
        internal static Dish BurritoDish => GetModdedGDO<Dish, BurritoDish>();

        internal static Dish BurritoWithExtrasCard => GetModdedGDO<Dish, BurritoWithExtrasCard>();

        // Modded Appliances 
        internal static Appliance FoilProvider => GetModdedGDO<Appliance, FoilProvider>();
        internal static Appliance FlourTortillaProvider => GetModdedGDO<Appliance, FlourTortilla>();
        internal static Appliance BurritoBasketProvider => GetModdedGDO<Appliance, BurritoBasketProvider>();

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

            // Dishes
            AddGameDataObject<BurritoDish>();
            // Items
            AddGameDataObject<BurritoFoilWrapped>();
            AddGameDataObject<BurritoWithExtrasAssembled>();
            AddGameDataObject<BurritoWithExtrasCard>();
            AddGameDataObject<BurritoWithExtrasCooked>();
            AddGameDataObject<BurritoWithExtrasFoilWrapped>();
            AddGameDataObject<BurritoWithExtrasWrapped>();
            AddGameDataObject<BurritoCooked>();
            AddGameDataObject<BurritoWrapped>();
            AddGameDataObject<BaseBurritoAssembled>();
            AddGameDataObject<BurritoInaBasket>();
            AddGameDataObject<BurritoWithExtrasInaBasket>();
            AddGameDataObject<BurritoBasket>();
            AddGameDataObject<FlourTortilla>();
            AddGameDataObject<Foil>();

            AddGameDataObject<BurritoBasketProvider>();
            AddGameDataObject<FlourTortilla>();
            AddGameDataObject<FoilProvider>();
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
            };
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
