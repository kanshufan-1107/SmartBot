using Microsoft.VisualBasic.ApplicationServices;
using SmartBot.Plugins;
using SmartBot.Plugins.API;
using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace SmartBotKit.Plugins.KSF
{
    [Serializable]
    class KSFPluginData : PluginDataContainer
    {
        //卡组
        public string deckDruid_;

        public string deckMage_;

        public string deckHunter_;

        public string deckPaladin_;

        public string deckPriest_;

        public string deckRogue_;

        public string deckShaman_;

        public string deckWarrior_;

        public string deckWarlock_;

        private int Level_;

        //初始化
        public KSFPluginData()
        {
            this.Enabled = false;
            this.Name = "KSF";
        }

        //隐藏插件名称
        [Browsable(false)]
        public new string Name
        {
            get; set;
        }

        internal AssemblyInfo AssemblyInfo
        {
            get
            {
                return new AssemblyInfo(Assembly.GetExecutingAssembly());
            }
        }

        [Category("Plugin")]
        [DisplayName("Assembly Name")]
        public string AssemblyName
        {
            get
            {
                return Path.ChangeExtension(this.AssemblyInfo.AssemblyName, "dll");
            }
        }

        [Category("Plugin")]
        [DisplayName("Description")]
        public string Description
        {
            get
            {
                return "KSF插件整合";
            }
        }

        [Category("A.账号管理")]
        [DisplayName("1.是否启用互投账号管理")]
        public bool ManagerAccount { get; set; }

        [Category("A.账号管理")]
        [DisplayName("2.刷互投账号(邮箱)")]
        public string Account1 { get; set; }

        [Category("A.账号管理")]
        [DisplayName("3.刷互投账号(邮箱)")]
        public string Account2 { get; set; }

        [Category("A.账号管理")]
        [DisplayName("4.刷互投账号(邮箱)")]
        public string Account3 { get; set; }

        [Category("B.互投")]
        [DisplayName("a1.是否启用互投")]
        public bool ManagerAutoConde { get; set; }

        [Category("B.互投")]
        [DisplayName("a2.是否开启练级模式(若该职业1000胜刷满,未到\r\n60级,还会继续该职业)")]
        public bool LevelUp { get; set; }

        [Category("B.互投")]
        [DisplayName("b1.德鲁伊刷千胜卡组")]
        [ItemsSource(typeof(DeckSourceDruid))]
        public string Decks3
        {
            get
            {
                if (string.IsNullOrEmpty(this.deckDruid_))
                {
                    this.deckWarlock_ = "None";
                }
                return this.deckDruid_;
            }
            set
            {
                this.deckDruid_ = value;
            }
        }

        [Category("B.互投")]
        [DisplayName("b2.法师刷千胜卡组")]
        [ItemsSource(typeof(DeckSourceMage))]
        public string Decks4
        {
            get
            {
                if (string.IsNullOrEmpty(this.deckMage_))
                {
                    this.deckMage_ = "None";
                }
                return this.deckMage_;
            }
            set
            {
                this.deckMage_ = value;
            }
        }

        [Category("B.互投")]
        [DisplayName("b3.猎人刷千胜卡组")]
        [ItemsSource(typeof(DeckSourceHunter))]
        public string Decks5
        {
            get
            {
                if (string.IsNullOrEmpty(this.deckHunter_))
                {
                    this.deckHunter_ = "None";
                }
                return this.deckHunter_;
            }
            set
            {
                this.deckHunter_ = value;
            }
        }

        [Category("B.互投")]
        [DisplayName("b4.圣骑士刷千胜卡组")]
        [ItemsSource(typeof(DeckSourcePaladin))]
        public string Decks6
        {
            get
            {
                if (string.IsNullOrEmpty(this.deckPaladin_))
                {
                    this.deckPaladin_ = "None";
                }
                return this.deckPaladin_;
            }
            set
            {
                this.deckPaladin_ = value;
            }
        }

        [Category("B.互投")]
        [DisplayName("b5.牧师刷千胜卡组")]
        [ItemsSource(typeof(DeckSourcePriest))]
        public string Decks7
        {
            get
            {
                if (string.IsNullOrEmpty(this.deckPriest_))
                {
                    this.deckPriest_ = "None";
                }
                return this.deckPriest_;
            }
            set
            {
                this.deckPriest_ = value;
            }
        }

        [Category("B.互投")]
        [DisplayName("b6.潜行者刷千胜卡组")]
        [ItemsSource(typeof(DeckSourceRogue))]
        public string Decks8
        {
            get
            {
                if (string.IsNullOrEmpty(this.deckRogue_))
                {
                    this.deckRogue_ = "None";
                }
                return this.deckRogue_;
            }
            set
            {
                this.deckRogue_ = value;
            }
        }

        [Category("B.互投")]
        [DisplayName("b7.萨满祭司刷千胜卡组")]
        [ItemsSource(typeof(DeckSourceShaman))]
        public string Decks1
        {
            get
            {
                if (string.IsNullOrEmpty(this.deckShaman_))
                {
                    this.deckShaman_ = "None";
                }
                return this.deckShaman_;
            }
            set
            {
                this.deckShaman_ = value;
            }
        }

        [Category("B.互投")]
        [DisplayName("b8.战士刷千胜卡组")]
        [ItemsSource(typeof(DeckSourceWarrior))]
        public string Decks9
        {
            get
            {
                if (string.IsNullOrEmpty(this.deckWarrior_))
                {
                    this.deckWarrior_ = "None";
                }
                return this.deckWarrior_;
            }
            set
            {
                this.deckWarrior_ = value;
            }
        }

        [Category("B.互投")]
        [DisplayName("b9.术士刷千胜卡组")]
        [ItemsSource(typeof(DeckSourceWarlock))]
        public string Decks2
        {
            get
            {
                if (string.IsNullOrEmpty(this.deckWarlock_))
                {
                    this.deckWarlock_ = "None";
                }
                return this.deckWarlock_;
            }
            set
            {
                this.deckWarlock_ = value;
            }
        }

        [Category("C.升级截图")]
        [DisplayName("1.是否启用升级截图")]
        public bool ManagerScreenshot { get; set; }

        [Category("C.升级截图")]
        [DisplayName("2.指定等级")]
        public int Level
        {
            get
            {
                return this.Level_;
            }
            set
            {
                if (value < 0)
                {
                    this.Level_ = 0;
                    return;
                }
                else if (value > 50)
                {
                    this.Level_ = 50;
                    return;
                }

                this.Level_ = value;

            }
        }

        [Category("C.升级截图")]
        [DisplayName("3.延时(单位:S)")]
        public int Delay
        {
            get; set;
        }
    }

    //1.德鲁伊卡组
    public sealed class DeckSourceDruid : IItemsSource
    {
        public ItemCollection GetValues()
        {
            ItemCollection items = new ItemCollection();
            items.Add("None", "None");
            ItemCollection itemsTemp = items;
            try
            {
                foreach (Deck deck in Bot.GetDecks().FindAll(x => x.Class == Card.CClass.DRUID))
                {
                    itemsTemp.Add(deck.Name, deck.Name);
                }
            }
            catch (Exception)
            {
                Bot.Log("德鲁伊卡组查询出错...");
            }
            return itemsTemp;
        }
    }

    //2.猎人卡组
    public sealed class DeckSourceHunter : IItemsSource
    {
        public ItemCollection GetValues()
        {
            ItemCollection items = new ItemCollection();
            items.Add("None", "None");
            ItemCollection itemsTemp = items;
            try
            {
                foreach (Deck deck in Bot.GetDecks().FindAll(x => x.Class == Card.CClass.HUNTER))
                {
                    itemsTemp.Add(deck.Name, deck.Name);
                }
            }
            catch (Exception)
            {
                Bot.Log("猎人卡组查询出错...");
            }
            return itemsTemp;
        }
    }

    //3.法师卡组
    public sealed class DeckSourceMage : IItemsSource
    {
        public ItemCollection GetValues()
        {
            ItemCollection items = new ItemCollection();
            items.Add("None", "None");
            ItemCollection itemsTemp = items;
            try
            {
                foreach (Deck deck in Bot.GetDecks().FindAll(x => x.Class == Card.CClass.MAGE))
                {
                    itemsTemp.Add(deck.Name, deck.Name);
                }
            }
            catch (Exception)
            {
                Bot.Log("法师卡组查询出错...");
            }
            return itemsTemp;
        }

    }

    //4.圣骑士卡组
    public sealed class DeckSourcePaladin : IItemsSource
    {
        public ItemCollection GetValues()
        {
            ItemCollection items = new ItemCollection();
            items.Add("None", "None");
            ItemCollection itemsTemp = items;
            try
            {
                foreach (Deck deck in Bot.GetDecks().FindAll(x => x.Class == Card.CClass.PALADIN))
                {
                    itemsTemp.Add(deck.Name, deck.Name);
                }
            }
            catch (Exception)
            {
                Bot.Log("圣骑士卡组查询出错...");
            }
            return itemsTemp;
        }

    }

    //5.牧师卡组
    public sealed class DeckSourcePriest : IItemsSource
    {
        public ItemCollection GetValues()
        {
            ItemCollection items = new ItemCollection();
            items.Add("None", "None");
            ItemCollection itemsTemp = items;
            try
            {
                foreach (Deck deck in Bot.GetDecks().FindAll(x => x.Class == Card.CClass.PRIEST))
                {
                    itemsTemp.Add(deck.Name, deck.Name);
                }
            }
            catch (Exception)
            {
                Bot.Log("牧师卡组查询出错...");
            }
            return itemsTemp;
        }

    }

    //6.潜行者卡组
    public sealed class DeckSourceRogue : IItemsSource
    {
        public ItemCollection GetValues()
        {
            ItemCollection items = new ItemCollection();
            items.Add("None", "None");
            ItemCollection itemsTemp = items;
            try
            {
                foreach (Deck deck in Bot.GetDecks().FindAll(x => x.Class == Card.CClass.ROGUE))
                {
                    itemsTemp.Add(deck.Name, deck.Name);
                }
            }
            catch (Exception)
            {
                Bot.Log("潜行者卡组查询出错...");
            }
            return itemsTemp;
        }

    }

    //7.萨满祭司卡组
    public sealed class DeckSourceShaman : IItemsSource
    {
        public ItemCollection GetValues()
        {
            ItemCollection items = new ItemCollection();
            items.Add("None", "None");
            ItemCollection itemsTemp = items;
            try
            {
                foreach (Deck deck in Bot.GetDecks().FindAll(x => x.Class == Card.CClass.SHAMAN))
                {
                    itemsTemp.Add(deck.Name, deck.Name);
                }
            }
            catch (Exception)
            {
                Bot.Log("萨满祭司卡组查询出错...");
            }
            return itemsTemp;
        }

    }

    //8.战士卡组
    public sealed class DeckSourceWarlock : IItemsSource
    {
        public ItemCollection GetValues()
        {
            ItemCollection items = new ItemCollection();
            items.Add("None", "None");
            ItemCollection itemsTemp = items;
            try
            {
                foreach (Deck deck in Bot.GetDecks().FindAll(x => x.Class == Card.CClass.WARLOCK))
                {
                    itemsTemp.Add(deck.Name, deck.Name);
                }
            }
            catch (Exception)
            {
                Bot.Log("战士卡组查询出错...");
            }
            return itemsTemp;
        }

    }

    //9.术士卡组
    public sealed class DeckSourceWarrior : IItemsSource
    {
        public ItemCollection GetValues()
        {
            ItemCollection items = new ItemCollection();
            items.Add("None", "None");
            ItemCollection itemsTemp = items;
            try
            {
                foreach (Deck deck in Bot.GetDecks().FindAll(x => x.Class == Card.CClass.WARRIOR))
                {
                    itemsTemp.Add(deck.Name, deck.Name);
                }
            }
            catch (Exception)
            {
                Bot.Log("术士卡组查询出错...");
            }
            return itemsTemp;
        }
    }
}
