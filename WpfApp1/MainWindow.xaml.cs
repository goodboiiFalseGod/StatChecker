using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using SoulsMemory;
using System.Numerics;
using System.IO;
using MainApp.Crutches;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using System.Windows.Documents;
using System.Windows.Navigation;

namespace MainApp
{
    public partial class MainWindow : Window
    {
        public bool AllowUseEverywhere;
        public bool EnableHotkeys;
        Settings Settings_window;
        private LowLevelKeyboardListener _listener;
        public Dictionary<int, Hotkey> hotkeys;
        TextBlock[] PanelNames;
        Hyperlink[] PlayerLinks;
        TextBlock[] PanelLevels;
        TextBlock[] PanelStats;
        TextBlock[] PanelStatsCheck;
        StackPanel[] StackPanels;
        ImageBrush[] imageTiles;
        public static bool AutoreviveControl = false;
        public static bool AutoKick = false;
        public static bool FallFromFliffControl = false;
        public static bool KillAllMobs = false;
        public static bool TriggerCovenants = false;
        public static bool MapV = true;
        public static bool HighC = false;
        public static bool LowC = false;
        public static bool[] iswasempty = {true, true, true, true, true};
        public static bool PlayerKillVisibility = true;
        public static int IdleOccurance;
        public static int WatchDogOccurance;
        public static bool[] statscheck = {true, true, true, true, true};
        public static bool[] advancedflags = {false, false, false, false, false};
        public static bool[] Isplayerstruct = {false, false, false, false, false};
        public string Path;
        public string Path2;
        public static string[] steamids = JunkCode.GetOnlinePlayersSteamID();
        public static string[] names = JunkCode.GetOnlinePlayersNames();
        public readonly string gameName;
        public IntPtr _windowHandle;

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += Bonfires_Loaded;
            gameName = "DarkSoulsIII";
            PanelNames = new TextBlock[] {p1Name, p2Name, p3Name, p4Name, p5Name};
            PlayerLinks = new Hyperlink[] { p1Link, p2Link, p3Link, p4Link, p5Link };
            PanelLevels = new TextBlock[] {p1SoulLvL, p2SoulLvL, p3SoulLvL, p4SoulLvL, p5SoulLvL};
            PanelStats = new TextBlock[] {p1Stats, p2Stats, p3Stats, p4Stats, p5Stats};
            PanelStatsCheck = new TextBlock[] {p1Statscheck, p2Statscheck, p3Statscheck, p4Statscheck, p5Statscheck};
            StackPanels = new StackPanel[] {Player1, Player2, Player3, Player4, Player5};
            imageTiles = new ImageBrush[] {imageTile1, imageTile2, imageTile3, imageTile4, imageTile5};
            Memory.ProcessHandle = Memory.AttachProc(gameName);

            Thread ThreadUpdate = new Thread(new ThreadStart(Update));
            ThreadUpdate.Start();

            if (!File.Exists(Path + "PlayerBase.txt"))
            {
                StreamWriter Textbase = File.CreateText("PlayerBase.txt");
                Textbase.Close();
            }

            Path = Environment.CurrentDirectory + "\\PlayerBase.txt";
        }

        private void Bonfires_Loaded(object sender, RoutedEventArgs e)
        {
            var s = Toolz.LoadConf(false);
            this.bonfireListBox.Navigate(new Uri("/Crutches/Bonfires.xaml", UriKind.Relative));
            _windowHandle = new WindowInteropHelper(this).Handle;
            hotkeys = Toolz.Deserialize(s.hotkeys);
            _listener = new LowLevelKeyboardListener();
            _listener.OnKeyPressed += _listener_OnKeyPressed;
            _listener.HookKeyboard();
            AllowUseEverywhere = s.AllowUseEverywhere;
            EnableHotkeys = s.UseHotkeys;
        }
        void _listener_OnKeyPressed(object sender, KeyPressedArgs e)
        {
            if (Settings_window != null && !Settings_window.IsClosed) Settings_window.LastKeyPressed = e;
            this.HotkeyHandler(Toolz.GetVirtualKeyCode(e.KeyPressed, e.Modifiers));
        }
        private void KillPlayer(int PlayerNo)
        {
            int PlayerHandle = JunkCode.GetPlayerHandle();
            Vector3 Player1Pos = JunkCode.GetOnlinePlayersPositions(PlayerNo);
            BULLET_MAN.GenerateBullet(PlayerHandle, 0, 100091600, 0, 0, 0, false, false, PlayerKillVisibility,
                Player1Pos, Player1Pos, Player1Pos, Player1Pos);
        }

        private void KillButton_Click(object sender, RoutedEventArgs e)
        {
            var i = Int32.Parse((sender as Button).Tag.ToString()) - 1;
            if (!statscheck[i]) KillPlayer(i);
        }

        private void KickButton_Click(object sender, RoutedEventArgs e)
        {
            JunkCode.DisconnectFunc(Int32.Parse((sender as Button).Tag.ToString()));
        }

        public void Update()
        { 
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
                bool[] isplayerstruct = {false, false, false, false, false};
                string[] PreviousName = {"0", "0", "0", "0", "0"};
                string[] PreviousSteamId = {"0", "0", "0", "0", "0"};
                string[] name = {"0", "0", "0", "0", "0"};
                int[,] Weapons = JunkCode.GetOnlinePlayersWeapons();
                int[,] Armor = JunkCode.GetOnlinePlayersArmor();
                int[,] Ring = JunkCode.GetOnlinePlayersRings();
                int ji = 0;
                Dispatcher.Invoke(() =>
                {
                    AutoKickBtn.IsChecked = AutoKick;
                    AutoreviveCheckBox.IsChecked = AutoreviveControl;
                    CovsTrigger.IsChecked = TriggerCovenants;
                    Ember.IsChecked = JunkCode.GetEmberState();
                    MapVBtn.IsChecked = MapV;
                    HighCBtn.IsChecked = HighC;
                    LowCBtn.IsChecked = LowC;

                    if (bonfireListBox.IsLoaded && bonfireListBox.Content != null)
                    {
                        var l = Int32.Parse(JunkCode.GetLastBonfire());
                        if (l != Bonfires.GetValue())
                            (bonfireListBox.Content as Bonfires).SetValue(l);
                    }

                    for (int i = 0; i < 5; i++)
                    {
                        ji++;

                        if (ji % 50 == 0)
                        {
                            CHR_INS.WorldChrMan.ChrBasicInfo.ApplyEffect(91110);
                        }

                        string InfoTable =
                            "Level:        \t" + levels[i] + "|" + "Weapon left 1: \t" +
                            ItemNamer.WeaponName(Weapons[i, 0]) + "|\t" + "Helm:\t" +
                            ItemNamer.ArmorName(Armor[i, 0]) + "|" + "Ring 1:\t" + ItemNamer.RingName(Ring[i, 0]) +
                            "|\n" +
                            "Vigor:        \t" + stats[i, 0] + "|" + "Weapon left 2: \t" +
                            ItemNamer.WeaponName(Weapons[i, 1]) + "|\t" + "Chest:\t" +
                            ItemNamer.ArmorName(Armor[i, 1]) + "|" + "Ring 2:\t" + ItemNamer.RingName(Ring[i, 1]) +
                            "|\n" +
                            "Attunement:   \t" + stats[i, 1] + "|" + "Weapon left 3: \t" +
                            ItemNamer.WeaponName(Weapons[i, 2]) + "|\t" + "Gauntlets:\t" +
                            ItemNamer.ArmorName(Armor[i, 2]) + "|" + "Ring 3:\t" + ItemNamer.RingName(Ring[i, 2]) +
                            "|\n" +
                            "Endurance:    \t" + stats[i, 2] + "|" + "Weapon right 1: \t" +
                            ItemNamer.WeaponName(Weapons[i, 3]) + "|\t" + "Leggience:\t" +
                            ItemNamer.ArmorName(Armor[i, 3]) + " | " + "Ring 4:\t" +
                            ItemNamer.RingName(Ring[i, 3]) + "|\n" +
                            "Vitality:     \t" + stats[i, 3] + "|" + "Weapon right 2: \t" +
                            ItemNamer.WeaponName(Weapons[i, 4]) + "|\n" +
                            "Strenght:     \t" + stats[i, 4] + "|" + "Weapon right 3: \t" +
                            ItemNamer.WeaponName(Weapons[i, 5]) + "|\n" +
                            "Agility:      \t" + stats[i, 5] + "|\n" +
                            "Inteilligence:\t" + stats[i, 6] + "|\n" +
                            "Faith:        \t" + stats[i, 7] + "|\n" +
                            "Luck:         \t" + stats[i, 8] + "|\n";

                        StreamWriter Textbaseconnect = new StreamWriter(Path, true);

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
                                if (SteamID != 0) PlayerLinks[i].NavigateUri = new Uri(SteamProfile);
                                if (iswasempty[i])
                                {
                                    Textbaseconnect.WriteLine(System.DateTime.Now + "\t" + "Player " + (i + 1) + " " +
                                                              names[i] + "\n" + "SteamName: " +
                                                              Toolz.GetSteamProfileName(SteamProfile) + "\n" +
                                                              "SteamLink: " + SteamProfile + "\n" + InfoTable + "\n");
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
                            if (SteamID != 0) PlayerLinks[i].NavigateUri = new Uri(SteamProfile);
                            if (!isplayerstruct[i])
                            {
                                PanelStatsCheck[i].Text = "incorrect";
                                    Textbaseconnect.WriteLine(System.DateTime.Now + "\t" + "Idiot cheater: Player " +
                                                              (i + 1) + " " + names[i] + "\n" + "SteamName: " +
                                                              Toolz.GetSteamProfileName(SteamProfile) + "\n" +
                                                              "SteamLink: " + SteamProfile + "\n" + InfoTable + "\n");
                                if (AutoKick) JunkCode.DisconnectFunc(i + 1);
                            }

                            else
                            {
                                PanelStatsCheck[i].Text = "kinda sus";
                                long PreviousSteam = Convert.ToInt64(PreviousSteamId[i], 16);
                                Textbaseconnect.WriteLine(
                                    System.DateTime.Now + "\t" + "Possibly clever cheater: Player " + (i + 1) +
                                    " " + names[i] + "\n" + "SteamLink: " + SteamProfile + "\n" + "LastSteam:" +
                                    PreviousSteam.ToString());
                            }
                        }
                        switch (teamtypes[i])
                        {
                            case 0:
                                StackPanels[i].Opacity = 1;
                                break;
                            case 1:
                                imageTiles[i].ImageSource = (ImageSource)Resources["tile_host"];
                                StackPanels[i].Opacity = 1;
                                break;
                            case 2:
                                imageTiles[i].ImageSource = (ImageSource)Resources["tile_white"];
                                StackPanels[i].Opacity = 1;
                                break;
                            case 16:
                                imageTiles[i].ImageSource = (ImageSource)Resources["tile_red"];
                                StackPanels[i].Opacity = 1;
                                break;
                            case 17:
                                imageTiles[i].ImageSource = (ImageSource)Resources["tile_covs"];
                                StackPanels[i].Opacity = 1;
                                break;
                            case 18:
                                imageTiles[i].ImageSource = (ImageSource)Resources["tile_covs"];
                                StackPanels[i].Opacity = 1;
                                break;
                            case 31:
                                imageTiles[i].ImageSource = (ImageSource)Resources["tile_marauder"];
                                StackPanels[i].Opacity = 1;
                                break;
                            case 32:
                                imageTiles[i].ImageSource = (ImageSource)Resources["tile_marauder"];
                                StackPanels[i].Opacity = 1;
                                break;
                        }

                        
                        PreviousName[i] = name[i];

                        PreviousSteamId[i] = steamids[i];

                        Textbaseconnect.Close();
                    }
                });
            }
        }

        private void Hyperlink_Click(object sender, RequestNavigateEventArgs e)
        {
            if (e.Uri.OriginalString.Length < 1 || !e.Uri.IsAbsoluteUri) return;
            Console.WriteLine(e.Uri.ToString());
            Process.Start(new ProcessStartInfo("steam://openurl/" + e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void KillAllMobs_Click(object sender, RoutedEventArgs e)
        {
            var BurgerRadius = (float) JunkCode.SaveParam(0x388, 0xA01D0, 0x44, "Float");
            var BurgerLife = (float) JunkCode.SaveParam(0x388, 0xA01D0, 0x10, "Float");
            var BurgerDmg = (short) JunkCode.SaveParam(0x388, 0xA01D0, 0x10, "2Bytes");
            JunkCode.WriteParam(0x388, 0xA01D0, 0x10, JunkCode.ValueType.Float, 2);
            JunkCode.WriteParam(0x388, 0xA01D0, 0x44, JunkCode.ValueType.Float, 5000);
            JunkCode.WriteParam(0x2B0, 0x1F1068, 0x50, JunkCode.ValueType.Bytes2, 50000);
            Thread.Sleep(200);

            KillAllMobs = true;
            int PlayerHandle = JunkCode.GetPlayerHandle();

            BULLET_MAN.GenerateBullet(PlayerHandle, 0, 12403300, 0, 0, 0, false, false, true,
                CHR_INS.WorldChrMan.ChrBasicInfo.GetPosition(), new Vector3(0, 0, 0),
                new Vector3(0, 0, 0), new Vector3(0, 0, 0));

            Thread.Sleep(200);
            JunkCode.WriteParam(0x2B0, 0x1F1068, 0x50, JunkCode.ValueType.Bytes2, BurgerDmg);
            JunkCode.WriteParam(0x388, 0xA01D0, 0x10, JunkCode.ValueType.Float, BurgerLife);
            JunkCode.WriteParam(0x388, 0xA01D0, 0x44, JunkCode.ValueType.Float, BurgerRadius);
            KillAllMobs = false;
        }

        private void TeleportButton_Click(object sender, RoutedEventArgs e)
        {
            int ID = Bonfires.GetValue();
            if (ID == 0) homeward_btn.Text = "choose bonfire above";
            else 
            {
                homeward_btn.Text = "homeward to bonfire";
                JunkCode.SetLastBonfire(ID);
                CHR_INS.WorldChrMan.ChrBasicInfo.ApplyEffect(580);
            }
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
            TriggerCovenants = true;
            IdleOccurance = (int) JunkCode.SaveParam(0x4A8, 0x1BA70, 0x128, "4Byte");
            JunkCode.WriteParam(0x4A8, 0x1BA70, 0x128, JunkCode.ValueType.Bytes4, 9000);
            WatchDogOccurance = (int) JunkCode.SaveParam(0x4A8, 0xAC610, 0x128, "4Byte");
            JunkCode.WriteParam(0x4A8, 0xAC610, 0x128, JunkCode.ValueType.Bytes4, 9010);
        }

        private void CovsTrigger_Unchecked(object sender, RoutedEventArgs e)
        {
            TriggerCovenants = false;
            JunkCode.WriteParam(0x4A8, 0x1BA70, 0x128, JunkCode.ValueType.Bytes4, IdleOccurance);
            JunkCode.WriteParam(0x4A8, 0x1BA70, 0x128, JunkCode.ValueType.Bytes4, WatchDogOccurance);
        }

        private void button_Anim_start(object sender, MouseButtonEventArgs e)
        {
            (sender as Button).Width = (double)50;
            (sender as Button).Height = (double)50;
            Thickness margin = (sender as Button).Margin;
            margin.Left = 10;
            margin.Top = 5;
            margin.Right = 10;
            (sender as Button).Margin = margin;
        }

        private void button_Anim_end(object sender, MouseButtonEventArgs e)
        {
            (sender as Button).Width = (double)60;
            (sender as Button).Height = (double)60;
            Thickness margin = (sender as Button).Margin;
            margin.Left = 5;
            margin.Top = 0;
            margin.Right = 5;
            (sender as Button).Margin = margin;
        }

        private void HomewardButton_Click(object sender, RoutedEventArgs e)
        {
            CHR_INS.WorldChrMan.ChrBasicInfo.ApplyEffect(580);
        }

        private void LeaveWorldButton_Click(object sender, RoutedEventArgs e)
        {
            CHR_INS.WorldChrMan.ChrBasicInfo.ApplyEffect(7);
        }

        private void KillMySelfButton_Click(object sender, RoutedEventArgs e)
        {
            JunkCode.WriteAnimationId(90600);
        }

        private void UseTearsButton_Click(object sender, RoutedEventArgs e)
        {
            CHR_INS.WorldChrMan.ChrBasicInfo.ApplyEffect(103520000);
        }

        private void UseFingersButton_Click(object sender, RoutedEventArgs e)
        {
            if (!JunkCode.GetEmberState()) CHR_INS.WorldChrMan.ChrBasicInfo.ApplyEffect(3290);
            CHR_INS.WorldChrMan.ChrBasicInfo.ApplyEffect(28);
        }

        private void UseEmberButton_Click(object sender, RoutedEventArgs e)
        {
            CHR_INS.WorldChrMan.ChrBasicInfo.ApplyEffect(3290);
        }

        private void SetRTSRState_Click(object sender, RoutedEventArgs e)
        {
            JunkCode.WritePlayerHp(JunkCode.GetPlayerHp() / 6);
        }

        private void UseWhiteSoapstoneButton_Click(object sender, RoutedEventArgs e)
        {
            CHR_INS.WorldChrMan.ChrBasicInfo.ApplyEffect(4);
        }

        private void UseRedSoapstoneButton_Click(object sender, RoutedEventArgs e)
        {
            CHR_INS.WorldChrMan.ChrBasicInfo.ApplyEffect(10);
        }

        private void UseRedEyeButton_Click(object sender, RoutedEventArgs e)
        {
            CHR_INS.WorldChrMan.ChrBasicInfo.ApplyEffect(11);
        }

        private void UseBSCButton_Click(object sender, RoutedEventArgs e)
        {
            CHR_INS.WorldChrMan.ChrBasicInfo.ApplyEffect(7);
        }

        private void UseSeedButton_Click(object sender, RoutedEventArgs e)
        {
            CHR_INS.WorldChrMan.ChrBasicInfo.ApplyEffect(3700); //3710 - works only as invader
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }

        private void Autorevive()
        {
            string CurrentAnim;
            int MaxFp = JunkCode.GetPlayerMaxFp();
            while (AutoreviveControl)
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
                    JunkCode.WriteAnimationId(0);
                }

                if (indexofstringripost > -1 || indexofstringparry > -1 || indexofstringguardbreak > -1)
                {
                    CHR_INS.CHRDBG.SetPlayerNoDead(true);
                    if (JunkCode.GetPlayerHp() == 1)
                    {
                        int MaxHp = JunkCode.GetPlayerMaxHp();

                        JunkCode.WritePlayerHp(MaxHp);
                        JunkCode.WriteAnimationId(0);
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

        private void StatsButton_Click(object sender, RoutedEventArgs e)
        {
            CHR_INS.WorldChrMan.Animation.PlayAnimation("W_CultStart2");
        }

        private void AutoKick_Checked(object sender, RoutedEventArgs e)
        {
            AutoKick = true;
        }

        private void AutoKick_Unchecked(object sender, RoutedEventArgs e)
        {
            AutoKick = false;
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
            MapV = true;
            GAME_REND.GROUP_MASK.ShowMapParts(true);
            GAME_REND.GROUP_MASK.ShowObjects(true);
            GAME_REND.GROUP_MASK.ShowRemo(true);
        }

        private void MapCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            MapV = false;
            GAME_REND.GROUP_MASK.ShowMapParts(false);
            GAME_REND.GROUP_MASK.ShowObjects(false);
            GAME_REND.GROUP_MASK.ShowRemo(false);
        }

        private void HighPolyCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            HighC = true;
            HIT_INS.WORLD_HIT_MAN.EnableHighPolyColDisplay(true);
        }

        private void HighPolyCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            HighC = false;
            HIT_INS.WORLD_HIT_MAN.EnableHighPolyColDisplay(false);
        }

        private void LowPolyCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            LowC = true;
            Console.WriteLine("LowC done.");
            HIT_INS.WORLD_HIT_MAN.EnableLowPolyColDisplay(true);
        }

        private void LowPolyCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            LowC = false;
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
            Memory.ProcessHandle = Memory.AttachProc(gameName);
        }

        private void SettingsBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.Settings_window == null || this.Settings_window.IsClosed)
            {
                this.Settings_window = new Settings();
            }
            this.Settings_window.Owner = this;
            this.Settings_window.Top = this.Top + 20;
            this.Settings_window.Left = this.Left + 20;
            this.Settings_window.ShowDialog();
            this.Settings_window.Focus();
        }

        public void HotkeyHandler(int key)
        {
            if (!hotkeys.ContainsKey(key)) return;
            if (!AllowUseEverywhere && !GameFocused()) return;
            if (Settings_window == null || Settings_window.IsClosed)
                switch ((HK_Commands)hotkeys[key].Tag)
                    {
                        case HK_Commands.HK_Kick1: JunkCode.DisconnectFunc(1); break;
                        case HK_Commands.HK_Kick2: JunkCode.DisconnectFunc(2); break;
                        case HK_Commands.HK_Kick3: JunkCode.DisconnectFunc(3); break;
                        case HK_Commands.HK_Kick4: JunkCode.DisconnectFunc(4); break;
                        case HK_Commands.HK_Kick5: JunkCode.DisconnectFunc(5); break;
                        case HK_Commands.HK_Kill1: KillPlayer(0); break;
                        case HK_Commands.HK_Kill2: KillPlayer(1); break;
                        case HK_Commands.HK_Kill3: KillPlayer(2); break;
                        case HK_Commands.HK_Kill4: KillPlayer(3); break;
                        case HK_Commands.HK_Kill5: KillPlayer(4); break;
                        case HK_Commands.HK_KillAllMobs: KillAllMobs_Click(null, null); break;
                        case HK_Commands.HK_Homeward: HomewardButton_Click(null, null); break;
                        case HK_Commands.HK_HealMe: HealMySelfButton_Click(null, null); break;
                        case HK_Commands.HK_KillMe: KillMySelfButton_Click(null, null); break;
                        case HK_Commands.HK_Stats: StatsButton_Click(null, null); break;
                        case HK_Commands.HK_HealAll: HealEveryOneButton_Click(null, null); break;
                        case HK_Commands.HK_AutoRevive: AutoreviveControl = !AutoreviveControl; break;
                        case HK_Commands.HK_AutoKick: AutoKick = !AutoKick; break;
                        case HK_Commands.HK_TriggerCovs: TriggerCovenants = !TriggerCovenants; break;
                        case HK_Commands.HK_Ember: if (JunkCode.GetEmberState()) Ember_Checked(null, null);
                                else Ember_Unchecked(null, null); break;
                        case HK_Commands.HK_Mark: MarkButton_Click(null, null); break;
                        case HK_Commands.HK_Recall: RecallButton_Click(null, null); break;
                        case HK_Commands.HK_TearsOfDenial: UseTearsButton_Click(null, null); break;
                        case HK_Commands.HK_DriedFingers: UseFingersButton_Click(null, null); break;
                        case HK_Commands.HK_UseEmber: UseEmberButton_Click(null, null); break;
                        case HK_Commands.HK_WhiteSS: UseWhiteSoapstoneButton_Click(null, null); break;
                        case HK_Commands.HK_RedSS: UseRedSoapstoneButton_Click(null, null); break;
                        case HK_Commands.HK_RedEye: UseRedEyeButton_Click(null, null); break;
                        case HK_Commands.HK_BSC: UseBSCButton_Click(null, null); break;
                        case HK_Commands.HK_Seed: UseSeedButton_Click(null, null); break;
                        case HK_Commands.HK_MapV: MapV = !MapV; break;
                        case HK_Commands.HK_HighC: HighC = !HighC; break;
                        case HK_Commands.HK_LowC: LowC = !LowC; break;
                        case HK_Commands.HK_Reattach: AttachButton_Click(null, null); break;
                    }
        }
        public bool GameFocused()
        {
            string processName = null;
            try
            {
                var activatedHandle = GetForegroundWindow();
                Process[] processes = Process.GetProcesses();
                foreach (Process clsProcess in processes)
                    if (activatedHandle == clsProcess.MainWindowHandle)
                    { processName = clsProcess.ProcessName; break; }
            }
            catch { }
            return processName == gameName;
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr GetForegroundWindow();

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _listener.UnHookKeyboard();
        }

        public enum HK_Commands : int
        {
            HK_Kick1 = 1,
            HK_Kick2 = 2,
            HK_Kick3 = 3,
            HK_Kick4 = 4,
            HK_Kick5 = 5,
            HK_Kill1 = 6,
            HK_Kill2 = 7,
            HK_Kill3 = 8,
            HK_Kill4 = 9,
            HK_Kill5 = 10,
            HK_KillAllMobs = 11,
            HK_Homeward = 12,
            HK_HealMe = 13,
            HK_KillMe = 14,
            HK_Stats = 15,
            HK_HealAll = 16,
            HK_AutoRevive = 17,
            HK_AutoKick = 18,
            HK_TriggerCovs = 19,
            HK_Ember = 20,
            HK_Mark = 21,
            HK_Recall = 22,
            HK_TearsOfDenial = 23,
            HK_DriedFingers = 24,
            HK_UseEmber = 25,
            HK_WhiteSS = 26,
            HK_RedSS = 27,
            HK_RedEye = 28,
            HK_BSC = 29,
            HK_Seed = 30,
            HK_MapV = 31,
            HK_HighC = 32,
            HK_LowC = 33,
            HK_Reattach = 34
        }
    }
}