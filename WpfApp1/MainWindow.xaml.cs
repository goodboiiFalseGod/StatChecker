using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SoulsMemory;
using System.Reflection;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Numerics;
using System.IO;
using System.Speech.Synthesis;

namespace MainApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TextBlock[] PanelNames;
        TextBlock[] PanelLevels;
        TextBlock[] PanelStats;
        TextBlock[] PanelStatsCheck;
        StackPanel[] StackPanels;
        public static bool AutoreviveControl = false;
        public static bool FallFromFliffControl = false;
        public static bool NaziWindowBool = false;
        public static bool KillAllMobs = false;
        public static bool[] iswasempty = { true, true, true, true, true };
        Window1 Nazi;
        public static bool PlayerKillVisibility = false;
        public static int IdleOccurance;
        public static int WatchDogOccurance;
        public static bool[] statscheck = { true, true, true, true, true };
        public static bool[] advancedflags = { false, false, false, false, false };
        public static bool[] Isplayerstruct = { false, false, false, false, false };
        public string Path;
        public string Path2;

        public static string[] steamids = JunkCode.GetOnlinePlayersSteamID();
        public static string[] names = JunkCode.GetOnlinePlayersNames();

        public MainWindow()
        {

            InitializeComponent();

            PanelNames = new TextBlock[] { p1Name, p2Name, p3Name, p4Name, p5Name };
            PanelLevels = new TextBlock[] { p1SoulLvL, p2SoulLvL, p3SoulLvL, p4SoulLvL, p5SoulLvL };
            PanelStats = new TextBlock[] { p1Stats, p2Stats, p3Stats, p4Stats, p5Stats };
            PanelStatsCheck = new TextBlock[] { p1Statscheck, p2Statscheck, p3Statscheck, p4Statscheck, p5Statscheck };
            StackPanels = new StackPanel[] { Player1, Player2, Player3, Player4, Player5 };

            Memory.ProcessHandle = Memory.AttachProc("DarkSoulsIII");

            Thread ThreadUpdate = new Thread(new ThreadStart(Update));
            ThreadUpdate.Start();
            Thread thread = new Thread(new ThreadStart(UseHotkeys));
            thread.Start();

            if (!System.IO.File.Exists(Path + "PlayerBase.txt"))
            {
                System.IO.StreamWriter Textbase = File.CreateText("PlayerBase.txt");
            }

            Path = Environment.CurrentDirectory + "\\PlayerBase.txt";

            if (!System.IO.File.Exists(Path2 + "HotkeysSettings.txt"))
            {
                System.IO.StreamWriter TextHotkey = File.CreateText("HotkeysSettings.txt");
                Path2 = Environment.CurrentDirectory + "\\HotkeysSettings.txt";
                Thread.Sleep(100);
                TextHotkey.WriteLine("#Hotkeys Settings \n" + "#to edit hotkeys do like that \"Function = [virtual key] or Function = [virtual key],[virtual key], ...\" \n" + "#list of virtual keys https://docs.microsoft.com/ru-ru/windows/win32/inputdev/virtual-key-codes \n" +
                "Teleport = 0x0\nKillMyself = 0x0\nKillAllMobs = 0x0\nApplyEffect = 0x0\nShrineTeleport = 0x0\nPontiffTeleport = 0x0\nLeaveWorld = 0x0\nHomeward = 0x0\nWhiteSign = 0x0\nRedSign = 0x0\nRedEyeOrb = 0x0\nAddSouls = 0x0\nHealMyself = 0x0\nStatsRespec = 0x0\nHealAll = 0x0\n#KillPlayers(works only with wrong stats ppls)\nKillPlayerOne = 0x0\nKillPlayerTwo = 0x0\nKillPlayerThree = 0x0\nKillPlayerFour = 0x0\nKillPlayerFive = 0x0\n#KickPlayers\nKickPlayerOne = 0x0\nKickPlayerTwo = 0x0\nKickPlayerThree = 0x0\nKickPlayerFour = 0x0\nKickPlayerFive = 0x0\nMark = 0x0\nRecall = 0x0\nEmber = 0x0\nAutoRevive = 0x0");
                TextHotkey.Close();
            }

            Path2 = Environment.CurrentDirectory + "\\HotkeysSettings.txt";

        }
        #region Кнопки хуепки

        //        <Button HorizontalAlignment = "Center"  Click="HardKickButton_Click1" Margin="5">
        //    <TextBlock Text = "HardKicklPlayer" FontSize="20" Name="HardKickPlayer5"/>
        //</Button>

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            Task.Run(async () =>
            {
                await Task.Delay(0);
                int PlayerNo = 1 - 1;
                int PlayerHandle = JunkCode.GetPlayerHandle();

                int currentHp = JunkCode.GetOnlinePlayersHP(PlayerNo);
                int count = 0;

                if (!statscheck[0])
                    while (currentHp > 0 && count < 10)
                    {
                        System.Numerics.Vector3 Player1Pos = JunkCode.GetOnlinePlayersPositions(PlayerNo);
                        BULLET_MAN.GenerateBullet(PlayerHandle, 0, 100091600, 0, 0, 0, false, false, PlayerKillVisibility, Player1Pos, Player1Pos, Player1Pos, Player1Pos);
                        count++;
                        currentHp = JunkCode.GetOnlinePlayersHP(PlayerNo);
                        Thread.Sleep(50);
                    }

            });
        }

        private void KickButton_Click1(object sender, RoutedEventArgs e)
        {
            JunkCode.DisconnectFunc(1);
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            Task.Run(async () =>
            {
                await Task.Delay(0);
                int PlayerNo = 2 - 1;
                int PlayerHandle = JunkCode.GetPlayerHandle();

                int currentHp = JunkCode.GetOnlinePlayersHP(PlayerNo);
                int count = 0;

                if (!statscheck[1])
                    while (currentHp > 0 && count < 10)
                    {
                        System.Numerics.Vector3 Player1Pos = JunkCode.GetOnlinePlayersPositions(PlayerNo);
                        BULLET_MAN.GenerateBullet(PlayerHandle, 0, 100091600, 0, 0, 0, false, false, PlayerKillVisibility, Player1Pos, Player1Pos, Player1Pos, Player1Pos);
                        count++;
                        currentHp = JunkCode.GetOnlinePlayersHP(PlayerNo);
                        Thread.Sleep(50);
                    }

            });
        }

        private void KickButton_Click2(object sender, RoutedEventArgs e)
        {
            JunkCode.DisconnectFunc(2);
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            Task.Run(async () =>
            {
                await Task.Delay(0);
                int PlayerNo = 3 - 1;
                int PlayerHandle = JunkCode.GetPlayerHandle();

                int currentHp = JunkCode.GetOnlinePlayersHP(PlayerNo);
                int count = 0;

                if (!statscheck[2])
                    while (currentHp > 0 && count < 10)
                    {
                        System.Numerics.Vector3 Player1Pos = JunkCode.GetOnlinePlayersPositions(PlayerNo);
                        BULLET_MAN.GenerateBullet(PlayerHandle, 0, 100091600, 0, 0, 0, false, false, PlayerKillVisibility, Player1Pos, Player1Pos, Player1Pos, Player1Pos);
                        count++;
                        currentHp = JunkCode.GetOnlinePlayersHP(PlayerNo);
                        Thread.Sleep(50);
                    }

            });

        }

        private void KickButton_Click3(object sender, RoutedEventArgs e)
        {
            JunkCode.DisconnectFunc(3);
        }

        private void Button_Click4(object sender, RoutedEventArgs e)
        {

            Task.Run(async () =>
            {
                await Task.Delay(0);
                int PlayerNo = 4 - 1;
                int PlayerHandle = JunkCode.GetPlayerHandle();

                int currentHp = JunkCode.GetOnlinePlayersHP(PlayerNo);
                int count = 0;

                if (!statscheck[3])
                    while (currentHp > 0 && count < 10)
                    {
                        System.Numerics.Vector3 Player1Pos = JunkCode.GetOnlinePlayersPositions(PlayerNo);
                        BULLET_MAN.GenerateBullet(PlayerHandle, 0, 100091600, 0, 0, 0, false, false, PlayerKillVisibility, Player1Pos, Player1Pos, Player1Pos, Player1Pos);
                        count++;
                        currentHp = JunkCode.GetOnlinePlayersHP(PlayerNo);
                        Thread.Sleep(50);
                    }

            });
        }

        private void KickButton_Click4(object sender, RoutedEventArgs e)
        {
            JunkCode.DisconnectFunc(4);
        }

        private void Button_Click5(object sender, RoutedEventArgs e)
        {

            Task.Run(async () =>
            {
                await Task.Delay(0);
                int PlayerNo = 5 - 1;
                int PlayerHandle = JunkCode.GetPlayerHandle();

                int currentHp = JunkCode.GetOnlinePlayersHP(PlayerNo);
                int count = 0;

                if (!statscheck[4])
                    while (currentHp > 0 && count < 10)
                    {
                        System.Numerics.Vector3 Player1Pos = JunkCode.GetOnlinePlayersPositions(PlayerNo);
                        BULLET_MAN.GenerateBullet(PlayerHandle, 0, 100091600, 0, 0, 0, false, false, PlayerKillVisibility, Player1Pos, Player1Pos, Player1Pos, Player1Pos);
                        count++;
                        currentHp = JunkCode.GetOnlinePlayersHP(PlayerNo);
                        Thread.Sleep(50);
                    }

            });
        }

        private void KickButton_Click5(object sender, RoutedEventArgs e)
        {
            JunkCode.DisconnectFunc(5);
        }


        #endregion

        /*            <WrapPanel Margin="0,7">
                <TextBlock Text="Visibility" FontSize="20"/>
                <CheckBox x:Name="VisibilityOfKill" RenderTransformOrigin="0.5,0.5" Checked="VisibilityOfKill_Checked" Unchecked="VisibilityOfKill_Unchecked">
                    <CheckBox.RenderTransform>
                        <TransformGroup>
                            <ScaleTransform/>
                            <SkewTransform/>
                            <RotateTransform/>
                            <TranslateTransform Y="10" X="30"/>
                        </TransformGroup>
                    </CheckBox.RenderTransform>
                </CheckBox>
            </WrapPanel>
            <WrapPanel>
                <TextBlock Text="AdvancedMode"/>
                <CheckBox Name="AdvancedMod" Checked="AdvancedMod_Checked" RenderTransformOrigin="0.5,0.5">
                    <CheckBox.RenderTransform>
                        <TransformGroup>
                            <ScaleTransform/>
                            <SkewTransform/>
                            <RotateTransform/>
                            <TranslateTransform X="20"/>
                        </TransformGroup>
                    </CheckBox.RenderTransform>
                </CheckBox>                
            </WrapPanel>*/


        public void Update()
        {
            bool[] soundcontrol = { true, true, true, true, true };

            while (true)
            {
                Thread.Sleep(250);
                steamids = JunkCode.GetOnlinePlayersSteamID();
                names = JunkCode.GetOnlinePlayersNames();

                int[] maxhp = JunkCode.GetOnlinePlayersMaxHP();                
                int[] levels = JunkCode.GetOnlinePlayersLvl();
                int[,] stats = JunkCode.GetOnlinePlayersStats();
                statscheck = JunkCode.StatChecker(stats, levels);
                bool[] badmule = JunkCode.BadMule(stats, levels);
                int[] teamtypes = JunkCode.GetOnlinePlayersTeam();                
                bool[] isplayerstruct = { false, false, false, false, false };
                string[] PreviousName = { "0", "0", "0", "0", "0" };
                string[] PreviousSteamId = { "0", "0", "0", "0", "0" };
                string[] name = { "0", "0", "0", "0", "0" };
                int[,] Weapons = JunkCode.GetOnlinePlayersWeapons();
                int[,] Armor = JunkCode.GetOnlinePlayersArmor();
                int[,] Ring = JunkCode.GetOnlinePlayersRings();

                int ji = 0;
                Dispatcher.Invoke(() =>
                {

                    if (JunkCode.GetEmberState())
                    {
                        Ember.IsChecked = true;
                    }
                    else
                    {
                        Ember.IsChecked = false;
                    }

                    for (int i = 0; i < 5; i++)
                    {

                        ji++;

                        if (ji % 50 == 0)
                        {
                            CHR_INS.WorldChrMan.ChrBasicInfo.ApplyEffect(91110);
                        }

                        string InfoTable =
                        "Level:        \t" + levels[i] + "|" + "Weapon left 1: \t\t\t" + ItemNamer.WeaponName(Weapons[i, 0]) + "|\t\t\t" + "Helm:\t\t\t" + ItemNamer.ArmorName(Armor[i, 0]) + "|" + "Ring 1:\t\t\t" + ItemNamer.RingName(Ring[i, 0]) + "|\n" +
                        "Vigor:        \t" + stats[i, 0] + "|" + "Weapon left 2: \t\t\t" + ItemNamer.WeaponName(Weapons[i, 1]) + "|\t\t\t" + "Chest:\t\t\t" + ItemNamer.ArmorName(Armor[i, 1]) + "|" + "Ring 2:\t\t\t" + ItemNamer.RingName(Ring[i, 1]) + "|\n" +
                        "Attunement:   \t" + stats[i, 1] + "|" + "Weapon left 3: \t\t\t" + ItemNamer.WeaponName(Weapons[i, 2]) + "|\t\t\t" + "Gauntlets:\t\t\t" + ItemNamer.ArmorName(Armor[i, 2]) + "|" + "Ring 3:\t\t\t" + ItemNamer.RingName(Ring[i, 2]) + "|\n" +
                        "Endurance:    \t" + stats[i, 2] + "|" + "Weapon right 1: \t\t\t" + ItemNamer.WeaponName(Weapons[i, 3]) + "|\t\t\t" + "Leggience:\t\t\t" + ItemNamer.ArmorName(Armor[i, 3]) + " | " + "Ring 4:\t\t\t" + ItemNamer.RingName(Ring[i, 3]) + "|\n" +
                        "Vitality:     \t" + stats[i, 3] + "|" + "Weapon right 2: \t\t\t" + ItemNamer.WeaponName(Weapons[i, 4]) + "|\n" +
                        "Strenght:     \t" + stats[i, 4] + "|" + "Weapon right 3: \t\t\t" + ItemNamer.WeaponName(Weapons[i, 5]) + "|\n" +
                        "Agility:      \t" + stats[i, 5] + "|\n" +
                        "Inteilligence:\t" + stats[i, 6] + "|\n" +
                        "Faith:        \t" + stats[i, 7] + "|\n" +
                        "Luck:         \t" + stats[i, 8] + "|\n";

                        System.IO.StreamWriter Textbaseconnect = new System.IO.StreamWriter(Path, true);

                        name[i] = names[i];

                        if (PanelNames[i].Text == "Empty")
                        {
                            iswasempty[i] = true;
                        }
                        else if (PanelNames[i].Text != "Empty")
                        {
                            iswasempty[i] = false;
                        }

                        //Names
                        if (maxhp[i] == 0)
                        {
                            name[i] = "Empty";
                            PanelNames[i].Text = name[i];
                        }
                        else
                        {
                            if (PanelNames[i].Text != name[i] && !iswasempty[i])
                            {
                                isplayerstruct[i] = true;
                            }
                            name[i] = names[i];
                            PanelNames[i].Text = name[i];
                        }

                        //if (name == "Empty")
                        //    iswasempty[i] = 0;

                        //Levels
                        PanelLevels[i].Text = levels[i].ToString();

                        //Stats
                        string output = string.Empty;
                        for (int j = 0; j < 9; j++)
                        {
                            output += stats[i, j].ToString() + "\n";
                        }

                        PanelStats[i].Text = output;

                        string Allinfotable = string.Empty;


                        //IsStatsTrue
                        if (maxhp[i] == 0)
                        {
                            PanelStatsCheck[i].Text = "empty";
                            soundcontrol[i] = true;
                        }

                        else if (statscheck[i])
                        {
                            if (!isplayerstruct[i])
                            {
                                PanelStatsCheck[i].Text = "correct";
                                long SteamID = 0;
                                try
                                {
                                    SteamID = Convert.ToInt64(steamids[i], 16);
                                }
                                catch
                                {
                                    SteamID = 0;
                                }
                                string SteamProfile = "http://steamcommunity.com/profiles/" + SteamID.ToString();

                                if (iswasempty[i])
                                {
                                    Textbaseconnect.WriteLine(System.DateTime.Now + "\t" + "Player " + (i + 1) + " " + names[i] + "\n" +"SteamName: " + Network.GetSteamProfileName(SteamProfile) + "\n" + "SteamLink: " + SteamProfile + "\n" + InfoTable + "\n");
                                }
                            }
                            else
                            {
                                PanelStatsCheck[i].Text = "playerstruct";
                            }

                        }


                        else if (!statscheck[i])
                        {
                            long SteamID = 0;
                            try
                            {
                                SteamID = Convert.ToInt64(steamids[i], 16);
                            }
                            catch
                            {
                                SteamID = 0;
                            }
                            string SteamProfile = "http://steamcommunity.com/profiles/" + SteamID.ToString();
                            //Clipboard.SetText(SteamProfile);

                            if (!isplayerstruct[i])
                            {
                                PanelStatsCheck[i].Text = "incorrect";
                                if (soundcontrol[i])
                                {
                                    /*System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                                    player.Stream = Properties.Resources.Alert;
                                    player.Play();*/
                                    soundcontrol[i] = false;
                                    //Clipboard.SetText("Idiot cheater: Player " + (i + 1) + " " + names[i] + "\n" + "SteamLink: " + SteamProfile);

                                    Textbaseconnect.WriteLine(System.DateTime.Now + "\t" + "Idiot cheater: Player " + (i + 1) + " " + names[i] + "\n" +  "SteamName: " + Network.GetSteamProfileName(SteamProfile) + "\n" + "SteamLink: " + SteamProfile + "\n" + InfoTable + "\n");
                                    SpeechSynthesizer Someonegay = new SpeechSynthesizer();
                                    if(badmule[i])
                                    {
                                        Someonegay.SetOutputToDefaultAudioDevice();
                                        Someonegay.Speak("Player " + (i + 1) + " " + names[i] + "has bad mule");
                                    }
                                    else
                                    {
                                        Someonegay.SetOutputToDefaultAudioDevice();
                                        Someonegay.Speak("Player " + (i + 1) + " " + names[i] + "has small pp and watch anime");
                                        JunkCode.ShowErrorMessage("P" + (i + 1) + " " + names[i] + " is cheater SteamName " + Network.GetSteamProfileName(SteamProfile) + " SL is " + JunkCode.RealSl(stats, i));
                                        Clipboard.SetText(SteamProfile);
                                    }
                                }
                            }

                            else
                            {
                                PanelStatsCheck[i].Text = "PlayerStruct";
                                if (soundcontrol[i])
                                {
                                    long PreviousSteam = Convert.ToInt64(PreviousSteamId[i], 16);
                                    System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                                    //player.Stream = MainApp.Properties.Resources.WeebAlert;
                                    player.Play();
                                    soundcontrol[i] = false;
                                    //Clipboard.SetText("Possibly clever cheater: Player " + (i + 1) + " " + names[i] + "\n" + "SteamLink: " + SteamProfile + "\n" + "LastSteam:" + PreviousSteam.ToString());
                                    Task.Run(() =>
                                    {
                                        if (Msgboxcheck.IsChecked == true)
                                        {
                                            MessageBox.Show("Possibly clever cheater: Player " + (i + 1) + " " + names[i] + "\n" + "SteamLink: " + SteamProfile + "\n" + "LassName: " + PreviousName[i] + "LastSteam:" + PreviousSteam.ToString());
                                        }
                                        Clipboard.SetText(SteamProfile);
                                    });
                                    Textbaseconnect.WriteLine(System.DateTime.Now + "\t" + "Possibly clever cheater: Player " + (i + 1) + " " + names[i] + "\n" + "SteamLink: " + SteamProfile + "\n" + "LastSteam:" + PreviousSteam.ToString());
                                }
                            }

                        }

                        GradientStopCollection gsc = new GradientStopCollection();
                        gsc.Add(new GradientStop()
                        {
                            Color = Color.FromRgb(145, 27, 29),
                            Offset = 0.0
                        });
                        gsc.Add(new GradientStop()
                        {
                            Color = Color.FromRgb(90, 133, 200),
                            Offset = 0.5
                        });


                        if (teamtypes[i] == 18 || teamtypes[i] == 17)
                            StackPanels[i].Background = new LinearGradientBrush(gsc, 0)
                            {
                                StartPoint = new Point(0.5, 0),
                                EndPoint = new Point(0.5, 1)
                            };
                        else if (teamtypes[i] == 16)
                            StackPanels[i].Background = new SolidColorBrush(Color.FromRgb(180, 40, 40));
                        else if (teamtypes[i] == 1 || teamtypes[i] == 8)
                            StackPanels[i].Background = new SolidColorBrush(Color.FromRgb(60, 60, 60));
                        else if (teamtypes[i] == 2)
                            StackPanels[i].Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                        else if (teamtypes[i] == 0)
                            StackPanels[i].Background = new SolidColorBrush(Color.FromRgb(170, 170, 170));
                        else if (teamtypes[i] == 31)
                            StackPanels[i].Background = new SolidColorBrush(Color.FromRgb(164, 51, 138));
                        else if (teamtypes[i] == 32)
                            StackPanels[i].Background = new SolidColorBrush(Color.FromRgb(164, 51, 138));

                        PreviousName[i] = name[i];

                        PreviousSteamId[i] = steamids[i];

                        Textbaseconnect.Close();
                    }
                });

            }
        }

        /*                <Button Width="60" Height="20" Margin="0,0,0,0" Click="ButtonNazi_Click">
                    <TextBlock Text="NAZI" FontSize="12"/>
                </Button>*/
        private void ButtonNazi_Click(object sender, RoutedEventArgs e)
        {
            if (!NaziWindowBool)
            {
                Nazi = new Window1();
                Nazi.Activate();
                Nazi.Show();
                NaziWindowBool = true;
            }
            else
            {
                NaziWindowBool = false;
                Nazi.Close();
            }
        }

        private void KillAllMobs_Click(object sender, RoutedEventArgs e)
        {
            bool IsPlayersThere = false;
            int[] PlayersMaxHp = JunkCode.GetOnlinePlayersMaxHP();

            for (int i = 0; i < 5; i++)
            {
                if (PlayersMaxHp[i] != 0)
                    IsPlayersThere = true;
            }

            if (!IsPlayersThere)
            {
                float BurgerRadius = 0, BurgerLife = 0;
                short BurgerDmg = 0;

                BurgerRadius = (float)JunkCode.SaveParam(0x388, 0xA01D0, 0x44, "Float");
                BurgerLife = (float)JunkCode.SaveParam(0x388, 0xA01D0, 0x10, "Float");
                BurgerDmg = (short)JunkCode.SaveParam(0x388, 0xA01D0, 0x10, "2Bytes");
                JunkCode.WriteParam(0x388, 0xA01D0, 0x10, JunkCode.ValueType.Float, 2);
                JunkCode.WriteParam(0x388, 0xA01D0, 0x44, JunkCode.ValueType.Float, 5000);
                JunkCode.WriteParam(0x2B0, 0x1F1068, 0x50, JunkCode.ValueType.Bytes2, 50000);
                Thread.Sleep(200);

                KillAllMobs = true;
                int PlayerHandle = JunkCode.GetPlayerHandle();

                BULLET_MAN.GenerateBullet(PlayerHandle, 0, 12403300, 0, 0, 0, false, false, true, CHR_INS.WorldChrMan.ChrBasicInfo.GetPosition(), new System.Numerics.Vector3(0, 0, 0), new System.Numerics.Vector3(0, 0, 0), new System.Numerics.Vector3(0, 0, 0));

                Thread.Sleep(200);
                JunkCode.WriteParam(0x2B0, 0x1F1068, 0x50, JunkCode.ValueType.Bytes2, BurgerDmg);
                JunkCode.WriteParam(0x388, 0xA01D0, 0x10, JunkCode.ValueType.Float, BurgerLife);
                JunkCode.WriteParam(0x388, 0xA01D0, 0x44, JunkCode.ValueType.Float, BurgerRadius);
                KillAllMobs = false;
            }
        }

        private void TeleportButton_Click(object sender, RoutedEventArgs e)
        {
            CHR_INS.CHRDBG.DbgTeleport.ForceTeleport(new System.Numerics.Vector3(558.5f, -183.5f, -1120.5f));
        }

        private void ApplyEffectButton_Click(object sender, RoutedEventArgs e)
        {
            CHR_INS.WorldChrMan.ChrBasicInfo.ApplyEffect(103520000);
            CHR_INS.WorldChrMan.ChrBasicInfo.ApplyEffect(3290);
            CHR_INS.WorldChrMan.ChrBasicInfo.ApplyEffect(28);
            CHR_INS.WorldChrMan.ChrBasicInfo.ApplyEffect(110);
        }

        private void VisibilityOfKill_Checked(object sender, RoutedEventArgs e)
        {
            PlayerKillVisibility = true;
        }

        private void VisibilityOfKill_Unchecked(object sender, RoutedEventArgs e)
        {
            PlayerKillVisibility = false;
        }

        private void CovsTrigger_Checked(object sender, RoutedEventArgs e)
        {
            IdleOccurance = (int)JunkCode.SaveParam(0x4A8, 0x1BA70, 0x128, "4Byte");
            JunkCode.WriteParam(0x4A8, 0x1BA70, 0x128, JunkCode.ValueType.Bytes4, 9000);
            WatchDogOccurance = (int)JunkCode.SaveParam(0x4A8, 0xAC610, 0x128, "4Byte");
            JunkCode.WriteParam(0x4A8, 0xAC610, 0x128, JunkCode.ValueType.Bytes4, 9010);
        }

        private void CovsTrigger_Unchecked(object sender, RoutedEventArgs e)
        {
            JunkCode.WriteParam(0x4A8, 0x1BA70, 0x128, JunkCode.ValueType.Bytes4, IdleOccurance);
            JunkCode.WriteParam(0x4A8, 0x1BA70, 0x128, JunkCode.ValueType.Bytes4, WatchDogOccurance);
        }

        private void ShrineTpButton_Click(object sender, RoutedEventArgs e)
        {
            CHR_INS.WorldChrMan.ChrBasicInfo.ApplyEffect(3221);
        }

        private void PontiffTpButton_Click(object sender, RoutedEventArgs e)
        {

                JunkCode.SetLastBonfire(3702951);
                CHR_INS.WorldChrMan.ChrBasicInfo.ApplyEffect(580);
        }

        private void HomewardButton_Click(object sender, RoutedEventArgs e)
        {
            CHR_INS.WorldChrMan.ChrBasicInfo.ApplyEffect(580);
        }

        private void LeaveWorldButton_Click(object sender, RoutedEventArgs e)
        {
            CHR_INS.WorldChrMan.ChrBasicInfo.ApplyEffect(7);
        }

        private void PlaceWSignButton_Click(object sender, RoutedEventArgs e)
        {
            CHR_INS.WorldChrMan.ChrBasicInfo.ApplyEffect(4);
        }

        private void PlaceRSignButton_Click(object sender, RoutedEventArgs e)
        {
            CHR_INS.WorldChrMan.ChrBasicInfo.ApplyEffect(10);
        }

        private void RedEyeButton_Click(object sender, RoutedEventArgs e)
        {
            CHR_INS.WorldChrMan.ChrBasicInfo.ApplyEffect(11);
        }
        
        private void KillMySelfButton_Click(object sender, RoutedEventArgs e)
        {
            JunkCode.WriteAnimationId(90600);
        }

        private void UseHotkeys()
        {
            Dictionary<string, int[]> Hotkeyslist = TextReader.GetHotkeys();
            bool isHotkeyPressed = false;
            bool CheckBoxHotkeys = false;

            while (true)
            {
                #region TEST
                /*//Teleport
                int[] TeleportKeys = Hotkeyslist["Teleport"];
                int TeleportState = 0;
                if (TeleportKeys[0] != 0)
                {
                    for (int i = 0; i < TeleportKeys.Length; i++)
                    {
                        short[] state = new short[TeleportKeys.Length];
                        state[i] = Kernel32.GetAsyncKeyState(TeleportKeys[i]);
                        if (state[i] != 0)
                        {
                            TeleportState++;
                        }
                        else if (state[i] == 0)
                        {
                            TeleportState--;
                        }

                        if (TeleportState == TeleportKeys.Length)
                        {
                            TeleportButton_Click(null, null);
                            Thread.Sleep(250);
                        }
                    }
                }*/

                #endregion

                #region Hotkeys

                Dispatcher.Invoke(() =>
                {
                    if (JunkCode.IsKeysPressed(Hotkeyslist["Ember"]) && Ember.IsChecked == true && !CheckBoxHotkeys)
                    {
                        Ember_Unchecked(null, null);
                        CheckBoxHotkeys = true;
                    }

                    if (JunkCode.IsKeysPressed(Hotkeyslist["Ember"]) && Ember.IsChecked == false && !CheckBoxHotkeys)
                    {
                        Ember_Checked(null, null);
                        CheckBoxHotkeys = true;
                    }

                    if (JunkCode.IsKeysPressed(Hotkeyslist["AutoRevive"]) && AutoreviveControl == false && !CheckBoxHotkeys)
                    {
                        ReviveCheckBox_Checked(null, null);
                        AutoreviveCheckBox.IsChecked = true;
                        CheckBoxHotkeys = true;
                    }

                    if (JunkCode.IsKeysPressed(Hotkeyslist["AutoRevive"]) && AutoreviveControl == true && !CheckBoxHotkeys)
                    {
                        ReviveCheckBox_Unchecked(null, null);
                        AutoreviveCheckBox.IsChecked = false;
                        CheckBoxHotkeys = true;
                    }

                    if (!JunkCode.IsKeysPressed(Hotkeyslist["Ember"]) && !JunkCode.IsKeysPressed(Hotkeyslist["AutoRevive"]) && CheckBoxHotkeys)
                    {
                        CheckBoxHotkeys = false;
                    }
                });

                if (JunkCode.IsKeysPressed(Hotkeyslist["Teleport"]))
                {
                    TeleportButton_Click(null, null);
                    isHotkeyPressed = true;
                }

                if (JunkCode.IsKeysPressed(Hotkeyslist["KillMyself"]))
                {
                    KillMySelfButton_Click(null, null);
                    isHotkeyPressed = true;
                }

                if (JunkCode.IsKeysPressed(Hotkeyslist["KillAllMobs"]))
                {
                    KillAllMobs_Click(null, null);
                    isHotkeyPressed = true;
                }

                if (JunkCode.IsKeysPressed(Hotkeyslist["ApplyEffect"]))
                {
                    ApplyEffectButton_Click(null, null);
                    isHotkeyPressed = true;
                }

                if (JunkCode.IsKeysPressed(Hotkeyslist["ShrineTeleport"]))
                {
                    ShrineTpButton_Click(null, null);
                    isHotkeyPressed = true;
                }

                if (JunkCode.IsKeysPressed(Hotkeyslist["PontiffTeleport"]))
                {
                    PontiffTpButton_Click(null, null);
                    isHotkeyPressed = true;
                }

                if (JunkCode.IsKeysPressed(Hotkeyslist["LeaveWorld"]))
                {
                    LeaveWorldButton_Click(null, null);
                    isHotkeyPressed = true;
                }

                if (JunkCode.IsKeysPressed(Hotkeyslist["Homeward"]))
                {
                    HomewardButton_Click(null, null);
                    isHotkeyPressed = true;
                }

                if (JunkCode.IsKeysPressed(Hotkeyslist["WhiteSign"]))
                {
                    PlaceWSignButton_Click(null, null);
                    isHotkeyPressed = true;
                }

                if (JunkCode.IsKeysPressed(Hotkeyslist["RedSign"]))
                {
                    PlaceRSignButton_Click(null, null);
                    isHotkeyPressed = true;
                }

                if (JunkCode.IsKeysPressed(Hotkeyslist["RedEyeOrb"]))
                {
                    RedEyeButton_Click(null, null);
                    isHotkeyPressed = true;
                }

                if (JunkCode.IsKeysPressed(Hotkeyslist["AddSouls"]))
                {
                    AddSoulsButton_Click(null, null);
                    isHotkeyPressed = true;
                }

                if (JunkCode.IsKeysPressed(Hotkeyslist["HealMyself"]))
                {
                    HealMySelfButton_Click(null, null);
                    isHotkeyPressed = true;
                }

                if (JunkCode.IsKeysPressed(Hotkeyslist["StatsRespec"]))
                {
                    StatsRespecButton_Click(null, null);
                    isHotkeyPressed = true;
                }

                if (JunkCode.IsKeysPressed(Hotkeyslist["HealAll"]))
                {
                    HealEveryOneButton_Click(null, null);
                    isHotkeyPressed = true;
                }

                if (JunkCode.IsKeysPressed(Hotkeyslist["KillPlayerOne"]))
                {
                    Button_Click1(null, null);
                    isHotkeyPressed = true;
                }

                if (JunkCode.IsKeysPressed(Hotkeyslist["KillPlayerTwo"]))
                {
                    Button_Click2(null, null);
                    isHotkeyPressed = true;
                }

                if (JunkCode.IsKeysPressed(Hotkeyslist["KillPlayerThree"]))
                {
                    Button_Click3(null, null);
                    isHotkeyPressed = true;
                }

                if (JunkCode.IsKeysPressed(Hotkeyslist["KillPlayerFour"]))
                {
                    Button_Click4(null, null);
                    isHotkeyPressed = true;
                }

                if (JunkCode.IsKeysPressed(Hotkeyslist["KillPlayerFive"]))
                {
                    Button_Click5(null, null);
                    isHotkeyPressed = true;
                }

                if (JunkCode.IsKeysPressed(Hotkeyslist["KickPlayerOne"]))
                {
                    KickButton_Click1(null, null);
                    isHotkeyPressed = true;
                }

                if (JunkCode.IsKeysPressed(Hotkeyslist["KickPlayerTwo"]))
                {
                    KickButton_Click2(null, null);
                    isHotkeyPressed = true;
                }

                if (JunkCode.IsKeysPressed(Hotkeyslist["KickPlayerThree"]))
                {
                    KickButton_Click3(null, null);
                    isHotkeyPressed = true;
                }

                if (JunkCode.IsKeysPressed(Hotkeyslist["KickPlayerFour"]))
                {
                    KickButton_Click4(null, null);
                    isHotkeyPressed = true;
                }

                if (JunkCode.IsKeysPressed(Hotkeyslist["KickPlayerFive"]))
                {
                    KickButton_Click5(null, null);
                    isHotkeyPressed = true;
                }

                if (JunkCode.IsKeysPressed(Hotkeyslist["Mark"]))
                {
                    MarkButton_Click(null, null);
                    isHotkeyPressed = true;
                }

                if (JunkCode.IsKeysPressed(Hotkeyslist["Recall"]))
                {
                    RecallButton_Click(null, null);
                    isHotkeyPressed = true;
                }
                #endregion

                if (isHotkeyPressed)
                {
                    isHotkeyPressed = false;
                    Thread.Sleep(100);
                }

                Thread.Sleep(10);
            }
        }

        private void Autorevive()
        {
            string CurrentAnim;            
            int MaxFp = JunkCode.GetPlayerMaxFp();
            while(AutoreviveControl)
            {                
                CurrentAnim = JunkCode.GetCurrentAnimationString();
                Console.WriteLine(CurrentAnim);

                int indexofstringdeath = CurrentAnim.IndexOf("DeathStart");
                int indexofstringripost = CurrentAnim.IndexOf("ThrowDef");
                int indexofstringparry = CurrentAnim.IndexOf("DamageParry");
                int indexofstringguardbreak = CurrentAnim.IndexOf("GuardBreak");
                if (indexofstringdeath > -1)
                {
                    int MaxHp = JunkCode.GetPlayerMaxHp();

                    JunkCode.WritePlayerHp(MaxHp);
                    JunkCode.WritePlayerFp(MaxFp);
                    //SoulsMemory.CHR_INS.WorldChrMan.Animation.PlayAnimation("W_DragonFullEndBefore_Upper");
                    SoulsMemory.CHR_INS.WorldChrMan.Animation.PlayAnimation("W_GuardDamageLarge");
                }

                if (indexofstringripost > -1 || indexofstringparry > -1 || indexofstringguardbreak > -1)
                {
                    CHR_INS.CHRDBG.SetPlayerNoDead(true);
                    if (JunkCode.GetPlayerHp() == 1)
                    {
                        int MaxHp = JunkCode.GetPlayerMaxHp();

                        JunkCode.WritePlayerHp(MaxHp);
                        SoulsMemory.CHR_INS.WorldChrMan.Animation.PlayAnimation("W_GuardDamageLarge");
                    }                    
                }
                else
                    CHR_INS.CHRDBG.SetPlayerNoDead(false);

                Thread.Sleep(25);
            }
        }

        private void StatsRespecButton_Click(object sender, RoutedEventArgs e)
        {
            SoulsMemory.CHR_INS.WorldChrMan.Animation.PlayAnimation("W_CultStart2");
        }

        private void HealEveryOneButton_Click(object sender, RoutedEventArgs e)
        {
            JunkCode.WriteParam(0x388, 0x11DD0, 0x44, JunkCode.ValueType.Float, 5000);
            JunkCode.WriteParam(0x388, 0x11DD0, 0x48, JunkCode.ValueType.Float, 5000);
            JunkCode.WriteParam(0x388, 0x11DD0, 0x6C, JunkCode.ValueType.Bytes4, 110);
            JunkCode.WriteParam(0x388, 0x11DD0, 0x70, JunkCode.ValueType.Bytes4, 103508000);
            JunkCode.WriteParam(0x388, 0x11DD0, 0x74, JunkCode.ValueType.Bytes4, 103520000);

            Thread.Sleep(250);

            BULLET_MAN.GenerateBullet(130, true, CHR_INS.WorldChrMan.ChrBasicInfo.GetPosition());

            Thread.Sleep(250);

            JunkCode.WriteParam(0x388, 0x11DD0, 0x44, JunkCode.ValueType.Float, 0);
            JunkCode.WriteParam(0x388, 0x11DD0, 0x48, JunkCode.ValueType.Float, 0);
            JunkCode.WriteParam(0x388, 0x11DD0, 0x6C, JunkCode.ValueType.Bytes4, 0);
            JunkCode.WriteParam(0x388, 0x11DD0, 0x70, JunkCode.ValueType.Bytes4, 0);
            JunkCode.WriteParam(0x388, 0x11DD0, 0x74, JunkCode.ValueType.Bytes4, 0);
        }

        private void HealMySelfButton_Click(object sender, RoutedEventArgs e)
        {
            JunkCode.WritePlayerFp(9000);
            JunkCode.WritePlayerHp(9000);
            JunkCode.WriteAnimationId(0);            
        }

        private void AddSoulsButton_Click(object sender, RoutedEventArgs e)
        {
            CHR_INS.WorldChrMan.ChrBasicInfo.AddSouls(999999999);
        }        

        private void FallProt()
        {

            /*<WrapPanel Margin="0, 5">
                <TextBlock Text="FallProt"/>
                <CheckBox RenderTransformOrigin="0.5,0.5" Checked="FallProtCheckBox_Checked" Unchecked="FallProtCheckBox_Unchecked">
                    <CheckBox.RenderTransform>
                        <TransformGroup>
                            <ScaleTransform/>
                            <SkewTransform/>
                            <RotateTransform/>
                            <TranslateTransform X="60" Y="2"/>
                        </TransformGroup>
                    </CheckBox.RenderTransform>
                </CheckBox>
            </WrapPanel>*/

            Vector3 PlayerPos = CHR_INS.WorldChrMan.ChrBasicInfo.GetPosition();
            float PlayerAngle = CHR_INS.WorldChrMan.ChrBasicInfo.GetPosAngle();
            while (FallFromFliffControl)
            {
                if(CHR_INS.WorldChrMan.ChrBasicInfo.isOnGround())
                {
                    PlayerPos = CHR_INS.WorldChrMan.ChrBasicInfo.GetPosition();
                    PlayerAngle = CHR_INS.WorldChrMan.ChrBasicInfo.GetPosAngle();
                }
                else
                {
                    CHR_INS.CHRDBG.DbgTeleport.ForceTeleport(PlayerPos);
                    CHR_INS.WorldChrMan.ChrBasicInfo.WriteAngle(PlayerAngle);
                }
                Thread.Sleep(1400);
            }
        }

        private void FallProtCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            FallFromFliffControl = true;
            Thread FallProt = new Thread(new ThreadStart(this.FallProt));
            FallProt.Start();
        }

        private void FallProtCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            FallFromFliffControl = false;
        }

        private void ReviveCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            AutoreviveControl = true;
            Thread Autorevive = new Thread(new ThreadStart(this.Autorevive));
            Autorevive.Start();
        }

        private void ReviveCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            AutoreviveControl = false;
        }

        private void MapCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            GAME_REND.GROUP_MASK.ShowMapParts(true);
            GAME_REND.GROUP_MASK.ShowObjects(true);
            GAME_REND.GROUP_MASK.ShowRemo(true); 
        }

        private void MapCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            GAME_REND.GROUP_MASK.ShowMapParts(false);
            GAME_REND.GROUP_MASK.ShowObjects(false);
            GAME_REND.GROUP_MASK.ShowRemo(false);
        }

        private void HighPolyCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            HIT_INS.WORLD_HIT_MAN.EnableHighPolyColDisplay(true);
        }

        private void HighPolyCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            HIT_INS.WORLD_HIT_MAN.EnableHighPolyColDisplay(false);
        }

        private void LowPolyCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            HIT_INS.WORLD_HIT_MAN.EnableLowPolyColDisplay(true);
        }

        private void LowPolyCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            HIT_INS.WORLD_HIT_MAN.EnableLowPolyColDisplay(false);
        }

        private void Ember_Checked(object sender, RoutedEventArgs e)
        {
            JunkCode.SetEmberState(true);
        }

        private void Ember_Unchecked(object sender, RoutedEventArgs e)
        {
            JunkCode.SetEmberState(false);
        }

        /*<TextBlock Text = "UnlockWorld" />
                < CheckBox Name="UnlockWorld" Checked="UnlockWorld_Checked" IsChecked="False"/>*/
        /*private void UnlockWorld_Checked(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                while (UnlockWorld.IsChecked == true)
                {
                    JunkCode.SetPlayerCount(1);
                    Thread.Sleep(250);
                }
            });
        }*/

        /*private void AdvancedMod_Checked(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
           {
               while (AdvancedMod.IsChecked == true)
               {
                   int?[] currenthp = JunkCode.GetOnlinePlayersHP();
                   int[] maxhp = JunkCode.GetOnlinePlayersMaxHP();
                   int?[] animationid = JunkCode.GetOnlinePlayersAnimation();
                   Vector3[] playersposition = JunkCode.GetOnlinePlayersPositions();
                   bool[] isdead = { false, false, false, false, false };
                   bool[] isteleported = { false, false, false, false, false };
                   Vector3[] previousposition = { new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0) };
                   float[] distances = { 0, 0, 0, 0, 0 };

                   for (int i = 0; i < 5; i++)
                   {
                       distances[i] = (float)Math.Sqrt(Math.Pow(playersposition[i].X - previousposition[i].X, 2) + Math.Pow(playersposition[i].Z - previousposition[i].Z, 2));

                       if (distances[i] > 25 && !iswasempty[i] == false && previousposition[i].Z != 0)
                       {
                           SpeechSynthesizer Someonegay = new SpeechSynthesizer();
                           Someonegay.SetOutputToDefaultAudioDevice();
                           Someonegay.Speak("Player " + (i + 1) + " " + names[i] + "has teleporeted");
                           long SteamID = 0;
                           try
                           {
                               SteamID = Convert.ToInt64(steamids[i], 16);
                           }
                           catch
                           {
                               SteamID = 0;
                           }
                           string SteamProfile = "http://steamcommunity.com/profiles/" + SteamID.ToString();
                           Clipboard.SetText(SteamProfile);
                           Task.Run(() =>
                           {
                               MessageBox.Show("Teleport detected: Player " + (i + 1) + " " + names[i] + "\n" + "SteamLink: " + SteamProfile);
                           });
                       }

                       if (currenthp[i] == 0 && maxhp[i] != 0)
                       {
                           isdead[i] = true;
                       }

                       if (isdead[i] == true && currenthp[i] != 0)
                       {
                           SpeechSynthesizer Someonegay = new SpeechSynthesizer();
                           Someonegay.SetOutputToDefaultAudioDevice();
                           Someonegay.Speak("Player " + (i + 1) + " " + names[i] + "has revived");
                           long SteamID = 0;
                           try
                           {
                               SteamID = Convert.ToInt64(steamids[i], 16);
                           }
                           catch
                           {
                               SteamID = 0;
                           }
                           string SteamProfile = "http://steamcommunity.com/profiles/" + SteamID.ToString();
                           Clipboard.SetText(SteamProfile);
                           Task.Run(() =>
                           {
                               MessageBox.Show("Revive detected: Player " + (i + 1) + " " + names[i] + "\n" + "SteamLink: " + SteamProfile);
                           });
                       }

                       if (iswasempty[i] == true)
                       {
                           isdead[i] = false;
                       }

                       previousposition = playersposition;
                   }

                   Thread.Sleep(25);
               }
           });
           
        }*/

        public static Vector3 Mark = new Vector3(0, 0, 0);

        private void MarkButton_Click(object sender, RoutedEventArgs e)
        {
            Mark = CHR_INS.WorldChrMan.ChrBasicInfo.GetPosition();
        }

        private void RecallButton_Click(object sender, RoutedEventArgs e)
        {
            CHR_INS.WorldChrMan.ChrBasicInfo.WritePosition(Mark);
        }

        private void AttachButton_Click(object sender, RoutedEventArgs e)
        {
            Memory.ProcessHandle = Memory.AttachProc("DarkSoulsIII");
        }
    }   
}
