using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Numerics;

namespace DS3_Tools
{
    class MiniMap
    {
        public static Graphics DrawPlayer(Graphics FrameGr, double RadialPlayerAngle, double RadialCameraAngle, Point PanelOffset)
        {

            //double Angle = RadianToDegree(RadialPlayerAngle) - RadianToDegree(RadialCameraAngle);
            FrameGr.DrawImage(Properties.Resources.player, new Point(PanelOffset.X - 8, (PanelOffset.Y - 8)));
            return FrameGr;
        }
        public static Graphics DrawEntity(Graphics FrameGr, double RadialCameraAngle, double OnlinePlayerAngle, Vector3 PlayerPos, Vector3 OnlinePlayerPos, Point PanelOffset)
        {

            double Angle = RadianToDegree(OnlinePlayerAngle) - RadianToDegree(RadialCameraAngle);
            float Xpos = (PlayerPos.X - OnlinePlayerPos.X ) * 0.7f;
            float Ypos = (PlayerPos.Z - OnlinePlayerPos.Z ) * 0.7f;
            float nXpos = (float)(Math.Cos(RadialCameraAngle + Math.PI) * Xpos - Math.Sin(RadialCameraAngle + Math.PI) * Ypos);
            float nYpos = (float)(Math.Sin(RadialCameraAngle + Math.PI) * Xpos + Math.Cos(RadialCameraAngle + Math.PI) * Ypos);

            Xpos = (float)(-nXpos + PanelOffset.X) - 8;
            Ypos = (float)(nYpos + PanelOffset.Y) - 8;

            Point NavPosition = new Point((int)Xpos, (int)Ypos);

            FrameGr.DrawImage(RotateImage(Properties.Resources.enemy, (float)Angle), NavPosition);

            return FrameGr;
        }

        public static Bitmap RotateImage(Bitmap b, float angle)
        {
            //create a new empty bitmap to hold rotated image
            Bitmap returnBitmap = new Bitmap(b.Width, b.Height);
            //make a graphics object from the empty bitmap
            using (Graphics g = Graphics.FromImage(returnBitmap))
            {
                //move rotation point to center of image
                g.TranslateTransform((float)b.Width / 2, (float)b.Height / 2);
                //rotate
                g.RotateTransform(angle);
                //move image back
                g.TranslateTransform(-(float)b.Width / 2, -(float)b.Height / 2);
                //draw passed in image onto graphics object
                g.DrawImage(b, new Point(0, 0));
            }
            return returnBitmap;
        }

        public static double RadianToDegree(double angle)
        {
            return angle * (180.0 / Math.PI);
        }
    }
}
