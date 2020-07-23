using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Numerics;
using System.Threading;
using System.ComponentModel;

namespace MainApp
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private static bool IsWorking = false;
        public Window1()
        {   
            InitializeComponent();
        }
        static void PortableNazi(int bullet, float Height, float Distance, float multiplier, float multiplierstep, bool isFollow, bool isCircle, int steplatency, int latency)
        {

            float PlayerAngle = SoulsMemory.CHR_INS.WorldChrMan.ChrBasicInfo.GetPosAngle();
            Vector3 CharPos = SoulsMemory.CHR_INS.WorldChrMan.ChrBasicInfo.GetPosition();
            Vector3 NewBulletPos = SoulsMemory.JunkCode.BulletAhead(true, true, PlayerAngle, CharPos, 0, -1, 0);
            Vector3 nullAngleZ = new Vector3(0, 0, 0);
            if (!isFollow)
            {

                CharPos = SoulsMemory.CHR_INS.WorldChrMan.ChrBasicInfo.GetPosition();
                PlayerAngle = SoulsMemory.CHR_INS.WorldChrMan.ChrBasicInfo.GetPosAngle();

            }
            double RandomAngle = 0;
            Vector3 NewPos;

            if (isCircle)
                for (int i = 0; i < 36; i++)
                {
                    RandomAngle += ((2 * Math.PI) / 36) - Math.PI;
                    NewPos = SoulsMemory.JunkCode.BulletAhead(false, false, (float)RandomAngle, CharPos, 0, -3, 1.5);
                    Vector3 AngleZ = new Vector3((float)Math.Sin(RandomAngle), 0, (float)Math.Cos(RandomAngle));
                    SoulsMemory.BULLET_MAN.GenerateBullet(0, 0, 130, 0, 0, 0, false, false, true, NewPos, NewPos, NewPos, AngleZ);
                }

            SoulsMemory.GenerateBullet bullet1 = new SoulsMemory.GenerateBullet(0, 0, bullet, 0, 0, 0, false, true, true, NewBulletPos, CharPos, CharPos, nullAngleZ);

            do
            {
                if (!IsWorking)
                    break;

                if (isFollow)
                {
                    CharPos = SoulsMemory.CHR_INS.WorldChrMan.ChrBasicInfo.GetPosition();
                    PlayerAngle = SoulsMemory.CHR_INS.WorldChrMan.ChrBasicInfo.GetPosAngle();
                }
                //Vector3 AngleZ = new Vector3(-(float)Math.Sin(PlayerAngle), 0, -(float)Math.Cos(PlayerAngle));

                for (float i = -1f * multiplier; i <= 1f * multiplier; i += 1f * multiplierstep) //горизонтальная линия
                {
                    NewBulletPos = SoulsMemory.JunkCode.BulletAhead(false, false, PlayerAngle, CharPos, i, Distance, Height);
                    bullet1.SetAllArguments(0, 0, bullet, 0, 0, 0, false, true, true, NewBulletPos, CharPos, CharPos, nullAngleZ);
                    bullet1.SpawnBullet();
                    Thread.Sleep(steplatency);
                }
                for (float i = -1f * multiplier; i <= 1f * multiplier; i += 1f * multiplierstep) //вертикальная линия
                {
                    NewBulletPos = SoulsMemory.JunkCode.BulletAhead(false, false, PlayerAngle, CharPos, 0, Distance, i + Height);
                    bullet1.SetAllArguments(0, 0, bullet, 0, 0, 0, false, true, true, NewBulletPos, CharPos, CharPos, nullAngleZ);
                    bullet1.SpawnBullet();
                    Thread.Sleep(steplatency);
                }

                Task.Run(async () =>
                {
                    for (float i = -1f * multiplier; i <= 0; i += 1f * multiplierstep) //вертикальная линия слева
                    {
                        NewBulletPos = SoulsMemory.JunkCode.BulletAhead(false, false, PlayerAngle, CharPos, -1f * multiplier, Distance, i + Height);
                        bullet1.SetAllArguments(0, 0, bullet, 0, 0, 0, false, true, true, NewBulletPos, CharPos, CharPos, nullAngleZ);
                        bullet1.SpawnBullet();
                        Thread.Sleep(steplatency);
                    }

                });

                for (float i = 0; i <= 1f * multiplier; i += 1f * multiplierstep) //вертикальная линия справа
                {
                    NewBulletPos = SoulsMemory.JunkCode.BulletAhead(false, false, PlayerAngle, CharPos, 1f * multiplier, Distance, i + Height);
                    bullet1.SetAllArguments(0, 0, bullet, 0, 0, 0, false, true, true, NewBulletPos, CharPos, CharPos, nullAngleZ);
                    bullet1.SpawnBullet();
                    Thread.Sleep(steplatency);
                }

                Task.Run(async () =>
                {
                    for (float i = -1f * multiplier; i <= 0; i += 1f * multiplierstep) //горизонтальная сверху
                    {
                        NewBulletPos = SoulsMemory.JunkCode.BulletAhead(false, false, PlayerAngle, CharPos, i, Distance, 1f * multiplier + Height);
                        bullet1.SetAllArguments(0, 0, bullet, 0, 0, 0, false, true, true, NewBulletPos, CharPos, CharPos, nullAngleZ);
                        bullet1.SpawnBullet();
                        Thread.Sleep(steplatency);
                    }

                });

                for (float i = 0; i <= 1f * multiplier; i += 1f * multiplierstep) //горизонтальная линия снизу
                {
                    NewBulletPos = SoulsMemory.JunkCode.BulletAhead(false, false, PlayerAngle, CharPos, i, Distance, -1f * multiplier + Height);
                    bullet1.SetAllArguments(0, 0, bullet, 0, 0, 0, false, true, true, NewBulletPos, CharPos, CharPos, nullAngleZ);
                    bullet1.SpawnBullet();
                    Thread.Sleep(steplatency);
                }

                Thread.Sleep(latency);

            } while (true);
            
        }

        void NaziWindow_Closing(object sender, CancelEventArgs e)
        {
            MainWindow NaziWindowState = new MainWindow();
            MainWindow.NaziWindowBool = false;
            IsWorking = false;
        }

        private void NaziButton_Click(object sender, RoutedEventArgs e)
        {
            int bulletid = int.Parse(this.BulletID.Text);
            float height = float.Parse(this.Height.Text);
            float distance = float.Parse(this.Distance.Text);
            float sizemult = float.Parse(this.SizeMult.Text);
            float stepmult = float.Parse(this.StepMult.Text);
            bool isfollow = this.IsFollow.IsChecked == null || this.IsFollow.IsChecked == false ? false : true;
            bool isspawncircle = this.IsSpawnCircle.IsChecked == null || this.IsSpawnCircle.IsChecked == false ? false : true;
            int steplatency = int.Parse(this.StepLatency.Text);
            int latency = int.Parse(this.Latency.Text);


            if (!IsWorking)
            {
                this.NaziButton.Text = "ON";

                IsWorking = true;
                Task.Run( () =>
                {
                    PortableNazi(bulletid, height, distance, sizemult, stepmult, isfollow, isspawncircle, steplatency, latency);
                });
            }
            else
            {
                IsWorking = false;
                this.NaziButton.Text = "OFF"; 
            }
        }
    }
}
