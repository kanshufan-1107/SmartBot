using SmartBot.Plugins;
using SmartBot.Plugins.API;
using System;
using System.IO;
using System.Threading;
using dmNet;

namespace SmartBotKit.Plugins.KSF
{
    class KSFPlugin : Plugin
    {
        public KSFPlugin()
        {
            this.IsDll = true;
        }

        /// <summary>
        /// 插件配置信息
        /// </summary>
        private KSFPluginData PluginData => (KSFPluginData)DataContainer;

        /// <summary>
        /// 插件初始化
        /// </summary>
        public override void OnPluginCreated()
        {
            if (IsEnabled())
            {
                Bot.Log("KSF整合插件已初始化成功...");
            }
            base.OnPluginCreated();
        }

        /// <summary>
        /// SmartBot开始工作
        /// </summary>
        public override void OnStarted()
        {
            //当前账号
            string accountNow = Bot.GetCurrentAccount();

            //启用禁用互投
            if (PluginData.ManagerAccount)
            {
                if (accountNow == PluginData.Account1
                || accountNow == PluginData.Account2
                || accountNow == PluginData.Account3)
                {
                    PluginData.ManagerAutoConde = true;
                    Bot.Log("互投已开启...");
                }
                else
                {
                    PluginData.ManagerAutoConde = false;
                    Bot.Log("互投已关闭...");
                }
            }

            //选择卡组模式
            if (PluginData.ManagerAutoConde)
            {
                Bot.Log("选择卡组模式...");
                ChooseDeckAndMode();
            }
            base.OnStarted();
        }

        /// <summary>
        /// 回合开始
        /// </summary>
        public override void OnTurnBegin()
        {
            Bot.Log("投降...");

            //投降
            Bot.Concede();

            base.OnTurnBegin();
        }

        /// <summary>
        /// 游戏结束
        /// </summary>
        public override void OnGameEnd()
        {
            //当前账号
            string accountNow = Bot.GetCurrentAccount();

            //启用禁用互投
            if (PluginData.ManagerAccount)
            {
                if (accountNow == PluginData.Account1
                || accountNow == PluginData.Account2
                || accountNow == PluginData.Account3)
                {
                    PluginData.ManagerAutoConde = true;
                    Bot.Log("互投已开启...");
                }
                else
                {
                    PluginData.ManagerAutoConde = false;
                    Bot.Log("互投已关闭...");
                }
            }

            //选择卡组模式
            if (PluginData.ManagerAutoConde)
            {
                Bot.Log("选择卡组模式...");
                ChooseDeckAndMode();
            }
            base.OnGameEnd();
        }

        /// <summary>
        /// 游戏胜利
        /// </summary>
        public override void OnVictory()
        {
            if (PluginData.ManagerScreenshot && Bot.GetPlayerDatas().GetRank() == PluginData.Level)
            {
                string path = Environment.CurrentDirectory
                    + Path.DirectorySeparatorChar.ToString() + "LevelScreenshot"
                    + Path.DirectorySeparatorChar.ToString();
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string name =
                    DateTime.Now.Day + "-"
                    + DateTime.Now.Hour + "-"
                    + DateTime.Now.Minute + "-"
                    + DateTime.Now.Second + "_"
                    + Bot.GetCurrentAccount() + "_"
                    + Bot.GetPlayerDatas().GetRank() + "级"
                    + Bot.GetPlayerDatas().GetStars() + "星.png";
                Thread.Sleep(PluginData.Delay);
                Bot.Log("\r\n文件夹:" + path + "\r\n文件名:" + name);
                ImgSave(path, name);
            }
            base.OnVictory();
        }

        /// <summary>
        /// 选择卡组模式
        /// </summary>
        public void ChooseDeckAndMode()
        {
            //遍历九职业
            foreach (Card.CClass cclass in Enum.GetValues(typeof(Card.CClass)))
            {
                switch (cclass)
                {

                    //德鲁伊
                    case Card.CClass.DRUID:
                        {
                            //卡组名
                            string deckName = PluginData.Decks3;
                            //胜场数
                            int wins = Bot.GetPlayerDatas().GetGoldenHeroesDatas().DruidWins;
                            //等级
                            int level = Bot.GetPlayerDatas().GetLevel(Card.CClass.DRUID);
                            //找到卡组对象
                            Deck deck = Bot.GetDecks().Find(x => x.Name == deckName);

                            if (deck != null)
                            {
                                bool flag = Process(wins, deckName, level, PluginData.LevelUp);
                                if (flag) return;
                            }
                            break;
                        }
                    //猎人
                    case Card.CClass.HUNTER:
                        {
                            //卡组名
                            string deckName = PluginData.Decks5;
                            //胜场数
                            int wins = Bot.GetPlayerDatas().GetGoldenHeroesDatas().HunterWins;
                            //等级
                            int level = Bot.GetPlayerDatas().GetLevel(Card.CClass.HUNTER);
                            //找到卡组对象
                            Deck deck = Bot.GetDecks().Find(x => x.Name == deckName);
                            if (deck != null)
                            {
                                bool flag = Process(wins, deckName, level, PluginData.LevelUp);
                                if (flag) return;
                            }
                            break;
                        }
                    //法师
                    case Card.CClass.MAGE:
                        {
                            //卡组名
                            string deckName = PluginData.Decks4;
                            //胜场数
                            int wins = Bot.GetPlayerDatas().GetGoldenHeroesDatas().MageWins;
                            //等级
                            int level = Bot.GetPlayerDatas().GetLevel(Card.CClass.MAGE);
                            //找到卡组对象
                            Deck deck = Bot.GetDecks().Find(x => x.Name == deckName);
                            if (deck != null)
                            {
                                bool flag = Process(wins, deckName, level, PluginData.LevelUp);
                                if (flag) return;
                            }
                            break;
                        }
                    //圣骑士
                    case Card.CClass.PALADIN:
                        {
                            //卡组名
                            string deckName = PluginData.Decks6;
                            //胜场数
                            int wins = Bot.GetPlayerDatas().GetGoldenHeroesDatas().PaladinWins;
                            //等级
                            int level = Bot.GetPlayerDatas().GetLevel(Card.CClass.PALADIN);
                            //找到卡组对象
                            Deck deck = Bot.GetDecks().Find(x => x.Name == deckName);
                            if (deck != null)
                            {
                                bool flag = Process(wins, deckName, level, PluginData.LevelUp);
                                if (flag) return;
                            }
                            break;
                        }
                    //牧师
                    case Card.CClass.PRIEST:
                        {
                            //卡组名
                            string deckName = PluginData.Decks7;
                            //胜场数
                            int wins = Bot.GetPlayerDatas().GetGoldenHeroesDatas().PriestWins;
                            //等级
                            int level = Bot.GetPlayerDatas().GetLevel(Card.CClass.PRIEST);
                            //找到卡组对象
                            Deck deck = Bot.GetDecks().Find(x => x.Name == deckName);
                            if (deck != null)
                            {
                                bool flag = Process(wins, deckName, level, PluginData.LevelUp);
                                if (flag) return;
                            }
                            break;
                        }
                    //潜行者
                    case Card.CClass.ROGUE:
                        {
                            //卡组名
                            string deckName = PluginData.Decks8;
                            //胜场数
                            int wins = Bot.GetPlayerDatas().GetGoldenHeroesDatas().RogueWins;
                            //等级
                            int level = Bot.GetPlayerDatas().GetLevel(Card.CClass.ROGUE);
                            //找到卡组对象
                            Deck deck = Bot.GetDecks().Find(x => x.Name == deckName);
                            if (deck != null)
                            {
                                bool flag = Process(wins, deckName, level, PluginData.LevelUp);
                                if (flag) return;
                            }
                            break;
                        }
                    //萨满祭司
                    case Card.CClass.SHAMAN:
                        {
                            //卡组名
                            string deckName = PluginData.Decks1;
                            //胜场数
                            int wins = Bot.GetPlayerDatas().GetGoldenHeroesDatas().ShamanWins;
                            //等级
                            int level = Bot.GetPlayerDatas().GetLevel(Card.CClass.SHAMAN);
                            //找到卡组对象
                            Deck deck = Bot.GetDecks().Find(x => x.Name == deckName);
                            if (deck != null)
                            {
                                Process(wins, deckName, level, PluginData.LevelUp);
                            }
                            break;
                        }
                    //术士
                    case Card.CClass.WARLOCK:
                        {
                            //卡组名
                            string deckName = PluginData.Decks2;
                            //胜场数
                            int wins = Bot.GetPlayerDatas().GetGoldenHeroesDatas().WarlockWins;
                            //等级
                            int level = Bot.GetPlayerDatas().GetLevel(Card.CClass.WARLOCK);
                            //找到卡组对象
                            Deck deck = Bot.GetDecks().Find(x => x.Name == deckName);
                            if (deck != null)
                            {
                                bool flag = Process(wins, deckName, level, PluginData.LevelUp);
                                if (flag) return;
                            }
                            break;
                        }
                    //战士
                    case Card.CClass.WARRIOR:
                        {
                            //卡组名
                            string deckName = PluginData.Decks9;
                            //胜场数
                            int wins = Bot.GetPlayerDatas().GetGoldenHeroesDatas().WarriorWins;
                            //等级
                            int level = Bot.GetPlayerDatas().GetLevel(Card.CClass.WARRIOR);
                            //找到卡组对象
                            Deck deck = Bot.GetDecks().Find(x => x.Name == deckName);
                            if (deck != null)
                            {
                                bool flag = Process(wins, deckName, level, PluginData.LevelUp);
                                if (flag) return;
                            }
                            break;
                        }
                }
                continue;
            }
        }

        /// <summary>
        /// 处理程序
        /// </summary>
        /// <param name="wins">当前英雄胜场</param>
        /// <param name="deckName">卡组名</param>
        /// <param name="level">当前英雄等级</param>
        /// <param name="levelUp">是否还提升等级</param>
        public static bool Process(int wins, string deckName, int level, bool levelUp)
        {
            //胜场
            if (wins < 1000)
            {
                //改变模式
                Bot.ChangeMode(Bot.Mode.RankedStandard);

                //改变卡组
                Bot.ChangeDeck(deckName);

                Bot.Log("练胜场 => 卡组名:" + deckName + "胜场数:" + wins + "等级:" + level);
                return true;
            }
            //练等级
            else if (level < 60 && levelUp)
            {
                //改变模式
                Bot.ChangeMode(Bot.Mode.RankedStandard);

                //改变卡组
                Bot.ChangeDeck(deckName);

                Bot.Log("练等级 => 卡组名:" + deckName + "胜场数:" + wins + "等级:" + level);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 截屏
        /// </summary>
        /// <param name="path">文件夹地址</param>
        /// <param name="name">文件名</param>
        private static void ImgSave(string path, string name)
        {
            if (!File.Exists(path + name))
            {
                File.Create(path + name);
                Bot.Log("文件创建成功...");
            }
            dmsoft dmsoft = new dmsoft();
            int dm_ret = dmsoft.Reg("kanshufanb8857668706e4a29999f26d48a2a4df7", "");
            if (dm_ret == 1)
            {
                Bot.Log("注册大漠插件成功...");
                Bot.Log("大漠插件版本:" + dmsoft.Ver());

                //获取句柄
                var hwnd = dmsoft.FindWindow("UnityWndClass", "炉石传说");

                //绑定窗口
                dm_ret = dmsoft.BindWindowEx(hwnd, "dx2", "normal", "normal", "dx.public.active.api|dx.public.active.message", 103);
                if (dm_ret == 1)
                {
                    Bot.Log("炉石传说窗口绑定成功...");
                    //截屏
                    dm_ret = dmsoft.CapturePng(0, 0, 2000, 2000, Path.Combine(path, name));
                    if(dm_ret == 1)
                    {
                        Bot.Log("截屏成功...");
                    }
                    else
                    {
                        Bot.Log("截屏失败,错误码是:" + dmsoft.GetLastError());
                    }
                }
                else
                {
                    Bot.Log("炉石传说窗口绑定失败,错误码是:" + dmsoft.GetLastError());
                }

            }
            else
            {
                Bot.Log("大漠插件付费功能注册失败...");
            }

        }
    }
}
