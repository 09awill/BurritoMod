using BurritoMod.Customs;
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
        public const string MOD_VERSION = "0.1.0";
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

        // Vanilla Items
        internal static Item Burnt => GetExistingGDO<Item>(ItemReferences.BurnedFood);
        internal static Item Meat => GetExistingGDO<Item>(ItemReferences.Meat);
        internal static Item ChoppedMeat => GetExistingGDO<Item>(ItemReferences.MeatChopped);
        internal static Item ChoppedMeatCooked => GetExistingGDO<Item>(ItemReferences.MeatChoppedContainerCooked);
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
        internal static Item Burrito => GetModdedGDO<Item, Burrito>();
        internal static Item Tortilla => GetModdedGDO<Item, Tortilla>();


        // Modded Dishes
        internal static Dish BurritoDish => GetModdedGDO<Dish, BurritoDish>();


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
            AddGameDataObject<Burrito>();
            AddGameDataObject<Tortilla>();

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

            LogInfo("Done loading asset bundle.");

            // Register custom GDOs
            AddGameData();

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
