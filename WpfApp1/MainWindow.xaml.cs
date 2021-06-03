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

namespace MainApp
{
    public partial class MainWindow : Window
    {
        TextBlock[] PanelNames;
        TextBlock[] PanelLevels;
        TextBlock[] PanelStats;
        TextBlock[] PanelStatsCheck;
        StackPanel[] StackPanels;
        ImageBrush[] imageTiles;
        public static bool AutoreviveControl = false;
        public static bool ArtoriasMode = false;
        public static bool FallFromFliffControl = false;
        public static bool KillAllMobs = false;
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

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += Bonfires_Loaded;
            PanelNames = new TextBlock[] {p1Name, p2Name, p3Name, p4Name, p5Name};
            PanelLevels = new TextBlock[] {p1SoulLvL, p2SoulLvL, p3SoulLvL, p4SoulLvL, p5SoulLvL};
            PanelStats = new TextBlock[] {p1Stats, p2Stats, p3Stats, p4Stats, p5Stats};
            PanelStatsCheck = new TextBlock[] {p1Statscheck, p2Statscheck, p3Statscheck, p4Statscheck, p5Statscheck};
            StackPanels = new StackPanel[] {Player1, Player2, Player3, Player4, Player5};
            imageTiles = new ImageBrush[] {imageTile1, imageTile2, imageTile3, imageTile4, imageTile5};

            Memory.ProcessHandle = Memory.AttachProc("DarkSoulsIII");

            Thread ThreadUpdate = new Thread(new ThreadStart(Update));
            ThreadUpdate.Start();

            if (!System.IO.File.Exists(Path + "PlayerBase.txt"))
            {
                System.IO.StreamWriter Textbase = File.CreateText("PlayerBase.txt");
                Textbase.Close();
            }

            Path = Environment.CurrentDirectory + "\\PlayerBase.txt";
        }

        private void Bonfires_Loaded(object sender, RoutedEventArgs e)
        {
            this.bonfireListBox.Navigate(new Uri("/Crutches/Bonfires.xaml", UriKind.Relative));
        }
        private void KillPlayer(int PlayerNo)
        {
            int PlayerHandle = JunkCode.GetPlayerHandle();
            System.Numerics.Vector3 Player1Pos = JunkCode.GetOnlinePlayersPositions(PlayerNo);
            BULLET_MAN.GenerateBullet(PlayerHandle, 0, 100091600, 0, 0, 0, false, false, PlayerKillVisibility,
                Player1Pos, Player1Pos, Player1Pos, Player1Pos);
        }

        private void KillButton_Click(object sender, RoutedEventArgs e)
        {
            KillPlayer(Int32.Parse((sender as Button).Tag.ToString()) -1);
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
                    AnimationText();
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

                                if (iswasempty[i])
                                {
                                    Textbaseconnect.WriteLine(System.DateTime.Now + "\t" + "Player " + (i + 1) + " " +
                                                              names[i] + "\n" + "SteamName: " +
                                                              Network.GetSteamProfileName(SteamProfile) + "\n" +
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

                            if (!isplayerstruct[i])
                            {
                                PanelStatsCheck[i].Text = "incorrect";
                                    Textbaseconnect.WriteLine(System.DateTime.Now + "\t" + "Idiot cheater: Player " +
                                                              (i + 1) + " " + names[i] + "\n" + "SteamName: " +
                                                              Network.GetSteamProfileName(SteamProfile) + "\n" +
                                                              "SteamLink: " + SteamProfile + "\n" + InfoTable + "\n");
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

                        //ARTORIAS
                        if (ArtoriasMode)
                        {
                            ApplyPerseveranceAndHP();
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
                        
                        switch (teamtypes[i])  //покрас недорого
                        {
                            case 0:
                                StackPanels[i].Opacity = 0;
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


        private void KillAllMobs_Click(object sender, RoutedEventArgs e)
        {
            float BurgerRadius = 0, BurgerLife = 0;
            short BurgerDmg = 0;

            BurgerRadius = (float) JunkCode.SaveParam(0x388, 0xA01D0, 0x44, "Float");
            BurgerLife = (float) JunkCode.SaveParam(0x388, 0xA01D0, 0x10, "Float");
            BurgerDmg = (short) JunkCode.SaveParam(0x388, 0xA01D0, 0x10, "2Bytes");
            JunkCode.WriteParam(0x388, 0xA01D0, 0x10, JunkCode.ValueType.Float, 2);
            JunkCode.WriteParam(0x388, 0xA01D0, 0x44, JunkCode.ValueType.Float, 5000);
            JunkCode.WriteParam(0x2B0, 0x1F1068, 0x50, JunkCode.ValueType.Bytes2, 50000);
            Thread.Sleep(200);

            KillAllMobs = true;
            int PlayerHandle = JunkCode.GetPlayerHandle();

            BULLET_MAN.GenerateBullet(PlayerHandle, 0, 12403300, 0, 0, 0, false, false, true,
                CHR_INS.WorldChrMan.ChrBasicInfo.GetPosition(), new System.Numerics.Vector3(0, 0, 0),
                new System.Numerics.Vector3(0, 0, 0), new System.Numerics.Vector3(0, 0, 0));

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
            IdleOccurance = (int) JunkCode.SaveParam(0x4A8, 0x1BA70, 0x128, "4Byte");
            JunkCode.WriteParam(0x4A8, 0x1BA70, 0x128, JunkCode.ValueType.Bytes4, 9000);
            WatchDogOccurance = (int) JunkCode.SaveParam(0x4A8, 0xAC610, 0x128, "4Byte");
            JunkCode.WriteParam(0x4A8, 0xAC610, 0x128, JunkCode.ValueType.Bytes4, 9010);
        }

        private void CovsTrigger_Unchecked(object sender, RoutedEventArgs e)
        {
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

        private void AnimationText()
        {
            //int Id = JunkCode.GetCurrentAnimationId();
            //string CurrentAnim = JunkCode.GetCurrentAnimationString();

            CurrentAnimText1.Text = Bonfires.GetValue().ToString();
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

        private void UseTreeCumButton_Click(object sender, RoutedEventArgs e)
        {
            CHR_INS.WorldChrMan.ChrBasicInfo.ApplyEffect(3700); //3710 - seems like it works only as invader
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

        private void ApplyPerseveranceAndHP()
        {
            string CurrentAnim = JunkCode.GetCurrentAnimationString();
            bool IsPlayersThere = false;
            int[] PlayersMaxHp = JunkCode.GetOnlinePlayersMaxHP();
            int indexofstringdeath = CurrentAnim.IndexOf("DeathStart");
            int indexofstringripost = CurrentAnim.IndexOf("ThrowDef");
            int indexofstringparry = CurrentAnim.IndexOf("DamageParry");
            int indexofstringguardbreak = CurrentAnim.IndexOf("GuardBreak");
            if (indexofstringripost > -1 || indexofstringparry > -1 || indexofstringguardbreak > -1)
                JunkCode.WriteAnimationId(0);

            for (int i = 0; i < 5; i++)
            {
                if (PlayersMaxHp[i] != 0)
                    IsPlayersThere = true;
            }

            if (IsPlayersThere && JunkCode.GetPlayerHp() > 0)
            
            {
                //CHR_INS.WorldChrMan.ChrBasicInfo.ApplyEffect(120700); // Perseverence
                //CHR_INS.WorldChrMan.ChrBasicInfo.ApplyEffect(110); // restore HP and DP
            }
                                                                   // 120700 - Perseverence
                                                                   // 110 - HP/DP

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
                    //SoulsMemory.CHR_INS.WorldChrMan.Animation.PlayAnimation("W_DragonFullEndBefore_Upper");
                    //SoulsMemory.CHR_INS.WorldChrMan.Animation.PlayAnimation("W_GuardDamageLarge");
                }

                if (indexofstringripost > -1 || indexofstringparry > -1 || indexofstringguardbreak > -1)
                {
                    CHR_INS.CHRDBG.SetPlayerNoDead(true);
                    if (JunkCode.GetPlayerHp() == 1)
                    {
                        int MaxHp = JunkCode.GetPlayerMaxHp();

                        JunkCode.WritePlayerHp(MaxHp);
                        JunkCode.WriteAnimationId(0);
                        //SoulsMemory.CHR_INS.WorldChrMan.Animation.PlayAnimation("W_GuardDamageLarge");
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

        private void ParryMeButton_Click(object sender, RoutedEventArgs e)
        {
            SoulsMemory.CHR_INS.WorldChrMan.Animation.PlayAnimation("W_DamageParry");
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
                if (CHR_INS.WorldChrMan.ChrBasicInfo.isOnGround())
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

        private void Artorias_Checked(object sender, RoutedEventArgs e)
        {
            ArtoriasMode = true;
        }

        private void Artorias_Unchecked(object sender, RoutedEventArgs e)
        {
            ArtoriasMode = false;
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