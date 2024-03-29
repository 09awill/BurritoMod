﻿using KitchenBurritoMod;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace BurritoMod.Customs.Cards
{
    class BeefBurritoDish : CustomDish
    {
        public override string UniqueNameID => "Beef Burrito Dish";
        public override DishType Type => DishType.Base;
        public override GameObject DisplayPrefab => Mod.Bundle.LoadAsset<GameObject>("BeefBurritoInBasketIcon");
        public override GameObject IconPrefab => DisplayPrefab;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override CardType CardType => CardType.Default;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Large;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override bool IsSpecificFranchiseTier => false;
        public override bool IsAvailableAsLobbyOption => true;
        public override bool DestroyAfterModUninstall => false;
        public override bool IsUnlockable => true;
        public override bool RequiredNoDishItem => true;
        public override List<Unlock> HardcodedBlockers => new()
        {
            Mod.BeefBurritoMainCard
        };
        public override List<string> StartingNameSet => new List<string>
        {
            "Hurricane Tortilla",
            "It's a wrap!",
            "Beef-o-Bell",
            "Un-Burrito-Ble!",
            "Neato Burrito",
            "Boo-Rito",
            "Gangster Wrap",
            "Epic Wrap Battle",
            "Danny Burrito",
            "Let's get Beefed!"
        };
        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
        {
            new Dish.MenuItem
            {
                Item = Mod.BeefBurritoInaBasket,
                Phase = MenuPhase.Main,
                Weight = 1
            }
        };
        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            Mod.Wok,
            Mod.FlourTortilla,
            Mod.Rice,
            Mod.Meat,
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
            { Locale.English, "Chop Meat and stir fry with rice, combine with tortilla, Interact to wrap and then wrap in foil. Serve in a basket!" },
            { Locale.French, "Hacher la viande et faire sauter avec du riz, mélanger avec une tortilla, interagir pour envelopper et ensuite envelopper dans du papier d'aluminium. Servir dans un panier !" },
            { Locale.German, "Fleisch hacken und mit Reis anbraten, mit Tortilla kombinieren, interagieren, umwickeln und dann in Folie einwickeln. In einem Korb servieren!" },
            { Locale.Spanish,  "Picar la carne y saltear con arroz, combinar con tortilla, interactuar para envolver y luego envolver en papel de aluminio. ¡Servir en una canasta!" },
            { Locale.Polish, "Posiekaj mięso i smaż z ryżem, połącz z tortillą, zetnij do zapakowania, a następnie zawijaj w folię. Podawaj w koszu!" },
            { Locale.Russian, "Измельчить мясо и обжарить с рисом, сочетать с тортильей, взаимодействовать, чтобы завернуть, а затем завернуть в фольгу. Подать в корзине!" },
            { Locale.PortugueseBrazil, "Picar a carne e refogar com arroz, combinar com a tortilla, interagir para enrolar e depois embrulhar em papel alumínio. Servir em uma cesta!" },
            { Locale.Japanese, "肉を刻んで炒め、ご飯と混ぜ、トルティーヤと組み合わせて包み、アルミホイルで包む。バスケットで提供！" },
            { Locale.ChineseSimplified, "切肉炒饭，与玉米饼混合，交互包裹，然后用锡纸包裹。装在篮子里上桌！" },
            { Locale.ChineseTraditional, "切肉炒飯，與墨西哥薄餅混合，交互包裹，然後用錫箔包裹。裝在籃子裡上桌！" },
            { Locale.Korean, "고기를 다져 밥과 볶아 토르티야와 함께 섞고 포장하고 호일에 싸서 제공하세요!" },
            { Locale.Turkish,  "Etleri doğrayıp pilavla kavurun, tortilla ile karıştırın, sararak birleştirin ve ardından folyoya sarın. Bir sepet içinde servis yapın!" },

        };

        public override List<(Locale, UnlockInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateUnlockInfo("Beef Burrito", "Adds Beef Burrito as a Base Dish", "It means little donkey.") ),
            ( Locale.French, LocalisationUtils.CreateUnlockInfo("Burrito de boeuf", "Ajoute le burrito de boeuf comme plat de base", "Cela signifie petit âne.") ),
            ( Locale.German, LocalisationUtils.CreateUnlockInfo("Rindfleisch-Burrito","Fügt den Rindfleisch-Burrito als Grundgericht hinzu", "Das bedeutet kleiner Esel.") ),
            ( Locale.Spanish, LocalisationUtils.CreateUnlockInfo("Burrito de carne de res", "Agrega el burrito de carne de res como plato base", "Significa pequeño burro.") ),
            ( Locale.Polish, LocalisationUtils.CreateUnlockInfo("Burrito z wołowiną", "Dodaj burrito z wołowiną jako danie podstawowe", "To znaczy mała osiołek.") ),
            ( Locale.Russian, LocalisationUtils.CreateUnlockInfo("Буррито с говядиной", "Добавьте буррито с говядиной в качестве основного блюда", "Это означает маленького осла.") ),
            ( Locale.PortugueseBrazil, LocalisationUtils.CreateUnlockInfo("Burrito de carne", "Adiciona o burrito de carne como prato base", "Significa burrinho.") ),
            ( Locale.Japanese, LocalisationUtils.CreateUnlockInfo("ビーフブリト", "ビーフブリトをベースの料理として追加", "それは小さなロバを意味します。") ),
            ( Locale.ChineseSimplified, LocalisationUtils.CreateUnlockInfo("牛肉卷饼", "将牛肉卷饼添加为基础菜品", "它的意思是小驴。") ),
            ( Locale.ChineseTraditional, LocalisationUtils.CreateUnlockInfo("牛肉捲餅", "將牛肉捲餅添加為基礎菜品", "它的意思是小驢。") ),
            ( Locale.Korean, LocalisationUtils.CreateUnlockInfo("소고기 부리또", "소고기 부리또를 기본 요리로 추가합니다", "이는 작은 당나귀를 의미합니다.") ),
            ( Locale.Turkish, LocalisationUtils.CreateUnlockInfo("Etli Burrito", "Etli Burrito'yu temel bir yemek olarak ekler", "Bu küçük eşek anlamına gelir.") ),
        };

        public override void OnRegister(Dish gameDataObject)
        {
            //TO DO: Change to chicken
            GameObject FoilWrappedBurrito = DisplayPrefab.GetChild("FoilWrappedBurrito");
            Material[] mats = new Material[] { MaterialUtils.GetExistingMaterial("Metal- Shiny") };
            FoilWrappedBurrito.ApplyMaterial(mats);
            FoilWrappedBurrito.GetChild("FoilEnds").ApplyMaterial(mats);

            mats = new Material[] { MaterialUtils.GetExistingMaterial("Well-done") };
            FoilWrappedBurrito.GetChild("StickerBeef").ApplyMaterial(mats);

            mats = new Material[] { MaterialUtils.GetExistingMaterial("Tomato") };
            DisplayPrefab.GetChild("BurritoBasket").ApplyMaterial(mats);
            mats = new Material[] { MaterialUtils.GetExistingMaterial("Cooked Pastry") };
            DisplayPrefab.GetChild("BurritoBasket").GetChild("Paper").ApplyMaterial(mats);


        }
    }
}
