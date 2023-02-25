using FRRobot;
using FRRobotNeighborhood;
using FRRNSelect;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;

namespace FRRobotDemoCSharp
{
    public partial class frmPickPlace : Form
    {

        // Declarations
        private FRCPosition mobjPos;
        private FRCXyzWpr mobjXyzWpr;
        private FRCSysGroupPosition mobjGrpPos;
        private FRCSysPosition mobjPosReg;
        private FRCSysPositions mobjPosRegs;
        private int mintPRNum;
        public static int XPos1_Saved;
        public static int XPos2_Saved;
        public static int XPos3_Saved;
        public static int XPos4_Saved;
        public static int XPos5_Saved;
        public static int XPos6_Saved;
        public static int XPos7_Saved;
        public static int XPos8_Saved;
        public static int XPos9_Saved;
        public static int XPos10_Saved;
        public static int YPos1_Saved;
        public static int YPos2_Saved;
        public static int YPos3_Saved;
        public static int YPos4_Saved;
        public static int YPos5_Saved;
        public static int YPos6_Saved;
        public static int YPos7_Saved;
        public static int YPos8_Saved;
        public static int YPos9_Saved;
        public static int YPos10_Saved;
        
        public frmPickPlace()
        {
            InitializeComponent();
        }

        // Initialize positions
        private void frmPickPlace_Load(object sender, EventArgs e)
        {
            frmPickPlace_LoadChanger();

            txtXPosCalibrate.Text = "1.0885";
            txtYPosCalibrate.Text = "1.0885";
            txtXOffset.Text = "100";
            txtYOffset.Text = "100";
        }



        // Visual updates for X position
        private void txtXPos1_TextChanged(object sender, EventArgs e)
        {
            if (float.Parse(txtXPos1.Text) > 605 && float.Parse(txtXPos1.Text) < 1053)
            {

                int tempY = picPlace1.Location.Y;
                picPlace1.Location = new System.Drawing.Point(int.Parse(txtXPos1.Text), tempY);
            }

        }
        private void txtXPos2_TextChanged(object sender, EventArgs e)
        {
            if (float.Parse(txtXPos2.Text) > 605 && float.Parse(txtXPos2.Text) < 1053)
            {
                int tempY = picPlace2.Location.Y;
                picPlace2.Location = new System.Drawing.Point(int.Parse(txtXPos2.Text), tempY);
            }

        }
        private void txtXPos3_TextChanged(object sender, EventArgs e)
        {
            if (float.Parse(txtXPos3.Text) > 605 && float.Parse(txtXPos3.Text) < 1053)
            {
                int tempY = picPlace3.Location.Y;
                picPlace3.Location = new System.Drawing.Point(int.Parse(txtXPos3.Text), tempY);
            }

        }
        private void txtXPos4_TextChanged(object sender, EventArgs e)
        {
            if (float.Parse(txtXPos4.Text) > 605 && float.Parse(txtXPos4.Text) < 1053)
            {
                int tempY = picPlace4.Location.Y;
                picPlace4.Location = new System.Drawing.Point(int.Parse(txtXPos4.Text), tempY);
            }

        }
        private void txtXPos5_TextChanged(object sender, EventArgs e)
        {
            if (float.Parse(txtXPos5.Text) > 605 && float.Parse(txtXPos5.Text) < 1053)
            {
                int tempY = picPlace5.Location.Y;
                picPlace5.Location = new System.Drawing.Point(int.Parse(txtXPos5.Text), tempY);
            }

        }
        private void txtXPos6_TextChanged(object sender, EventArgs e)
        {
            if (float.Parse(txtXPos6.Text) > 605 && float.Parse(txtXPos6.Text) < 1053)
            {
                int tempY = picPlace6.Location.Y;
                picPlace6.Location = new System.Drawing.Point(int.Parse(txtXPos6.Text), tempY);
            }

        }
        private void txtXPos7_TextChanged(object sender, EventArgs e)
        {
            if (float.Parse(txtXPos7.Text) > 605 && float.Parse(txtXPos7.Text) < 1053)
            {
                int tempY = picPlace7.Location.Y;
                picPlace7.Location = new System.Drawing.Point(int.Parse(txtXPos7.Text), tempY);
            }

        }
        private void txtXPos8_TextChanged(object sender, EventArgs e)
        {
            if (float.Parse(txtXPos8.Text) > 605 && float.Parse(txtXPos8.Text) < 1053)
            {
                int tempY = picPlace8.Location.Y;
                picPlace8.Location = new System.Drawing.Point(int.Parse(txtXPos8.Text), tempY);
            }

        }
        private void txtXPos9_TextChanged(object sender, EventArgs e)
        {
            if (float.Parse(txtXPos9.Text) > 605 && float.Parse(txtXPos9.Text) < 1053)
            {
                int tempY = picPlace9.Location.Y;
                picPlace9.Location = new System.Drawing.Point(int.Parse(txtXPos9.Text), tempY);
            }
        }
        private void txtXPos10_TextChanged(object sender, EventArgs e)
        {
            if (float.Parse(txtXPos10.Text) > 605 && float.Parse(txtXPos10.Text) < 1053)
            {
                int tempY = picPlace10.Location.Y;
                picPlace10.Location = new System.Drawing.Point(int.Parse(txtXPos10.Text), tempY);
            }
        }

        // Visual updates for Y position
        private void txtYPos1_TextChanged(object sender, EventArgs e)
        {
            if (float.Parse(txtYPos1.Text) > 342 && float.Parse(txtYPos1.Text) < 700)
            {
                int tempX = picPlace1.Location.X;
                picPlace1.Location = new System.Drawing.Point(tempX, int.Parse(txtYPos1.Text));
            }

        }
        private void txtYPos2_TextChanged(object sender, EventArgs e)
        {
            if (float.Parse(txtYPos2.Text) > 342 && float.Parse(txtYPos2.Text) < 700)
            {
                int tempX = picPlace2.Location.X;
                picPlace2.Location = new System.Drawing.Point(tempX, int.Parse(txtYPos2.Text));
            }

        }
        private void txtYPos3_TextChanged(object sender, EventArgs e)
        {
            if (float.Parse(txtYPos3.Text) > 342 && float.Parse(txtYPos3.Text) < 700)
            {
                int tempX = picPlace3.Location.X;
                picPlace3.Location = new System.Drawing.Point(tempX, int.Parse(txtYPos3.Text));
            }

        }
        private void txtYPos4_TextChanged(object sender, EventArgs e)
        {
            if (float.Parse(txtYPos4.Text) > 342 && float.Parse(txtYPos4.Text) < 700)
            {
                int tempX = picPlace4.Location.X;
                picPlace4.Location = new System.Drawing.Point(tempX, int.Parse(txtYPos4.Text));
            }

        }
        private void txtYPos5_TextChanged(object sender, EventArgs e)
        {
            if (float.Parse(txtYPos5.Text) > 342 && float.Parse(txtYPos5.Text) < 700)
            {
                int tempX = picPlace5.Location.X;
                picPlace5.Location = new System.Drawing.Point(tempX, int.Parse(txtYPos5.Text));
            }

        }
        private void txtYPos6_TextChanged(object sender, EventArgs e)
        {
            if (float.Parse(txtYPos6.Text) > 342 && float.Parse(txtYPos6.Text) < 700)
            {
                int tempX = picPlace6.Location.X;
                picPlace6.Location = new System.Drawing.Point(tempX, int.Parse(txtYPos6.Text));
            }

        }
        private void txtYPos7_TextChanged(object sender, EventArgs e)
        {
            if (float.Parse(txtYPos7.Text) > 342 && float.Parse(txtYPos7.Text) < 700)
            {
                int tempX = picPlace7.Location.X;
                picPlace7.Location = new System.Drawing.Point(tempX, int.Parse(txtYPos7.Text));
            }

        }
        private void txtYPos8_TextChanged(object sender, EventArgs e)
        {
            if (float.Parse(txtYPos8.Text) > 342 && float.Parse(txtYPos8.Text) < 700)
            {
                int tempX = picPlace8.Location.X;
                picPlace8.Location = new System.Drawing.Point(tempX, int.Parse(txtYPos8.Text));
            }

        }
        private void txtYPos9_TextChanged(object sender, EventArgs e)
        {
            if (float.Parse(txtYPos9.Text) > 342 && float.Parse(txtYPos9.Text) < 700)
            {
                int tempX = picPlace9.Location.X;
                picPlace9.Location = new System.Drawing.Point(tempX, int.Parse(txtYPos9.Text));
            }

        }
        private void txtYPos10_TextChanged(object sender, EventArgs e)
        {
            if (float.Parse(txtYPos10.Text) > 342 && float.Parse(txtYPos10.Text) < 700)
            {
                int tempX = picPlace10.Location.X;
                picPlace10.Location = new System.Drawing.Point(tempX, int.Parse(txtYPos10.Text));
            }

        }

        // Up position control for X
        private void txtXPosUp1_Click(object sender, EventArgs e)
        {
            txtXPos1.Text = (int.Parse(txtXPos1.Text) + 1).ToString();
        }
        private void txtXPosUp2_Click(object sender, EventArgs e)
        {
            txtXPos2.Text = (int.Parse(txtXPos2.Text) + 1).ToString();
        }
        private void txtXPosUp3_Click(object sender, EventArgs e)
        {
            txtXPos3.Text = (int.Parse(txtXPos3.Text) + 1).ToString();
        }
        private void txtXPosUp4_Click(object sender, EventArgs e)
        {
            txtXPos4.Text = (int.Parse(txtXPos4.Text) + 1).ToString();
        }
        private void txtXPosUp5_Click(object sender, EventArgs e)
        {
            txtXPos5.Text = (int.Parse(txtXPos5.Text) + 1).ToString();
        }
        private void txtXPosUp6_Click(object sender, EventArgs e)
        {
            txtXPos6.Text = (int.Parse(txtXPos6.Text) + 1).ToString();
        }
        private void txtXPosUp7_Click(object sender, EventArgs e)
        {
            txtXPos7.Text = (int.Parse(txtXPos7.Text) + 1).ToString();
        }
        private void txtXPosUp8_Click(object sender, EventArgs e)
        {
            txtXPos8.Text = (int.Parse(txtXPos8.Text) + 1).ToString();
        }
        private void txtXPosUp9_Click(object sender, EventArgs e)
        {
            txtXPos9.Text = (int.Parse(txtXPos9.Text) + 1).ToString();
        }
        private void txtXPosUp10_Click(object sender, EventArgs e)
        {
            txtXPos10.Text = (int.Parse(txtXPos10.Text) + 1).ToString();
        }

        // Up position control for Y
        private void txtYPosUp1_Click(object sender, EventArgs e)
        {
            txtYPos1.Text = (int.Parse(txtYPos1.Text) + 1).ToString();
        }
        private void txtYPosUp2_Click(object sender, EventArgs e)
        {
            txtYPos2.Text = (int.Parse(txtYPos2.Text) + 1).ToString();
        }
        private void txtYPosUp3_Click(object sender, EventArgs e)
        {
            txtYPos3.Text = (int.Parse(txtYPos3.Text) + 1).ToString();
        }
        private void txtYPosUp4_Click(object sender, EventArgs e)
        {
            txtYPos4.Text = (int.Parse(txtYPos4.Text) + 1).ToString();
        }
        private void txtYPosUp5_Click(object sender, EventArgs e)
        {
            txtYPos5.Text = (int.Parse(txtYPos5.Text) + 1).ToString();
        }
        private void txtYPosUp6_Click(object sender, EventArgs e)
        {
            txtYPos6.Text = (int.Parse(txtYPos6.Text) + 1).ToString();
        }
        private void txtYPosUp7_Click(object sender, EventArgs e)
        {
            txtYPos7.Text = (int.Parse(txtYPos7.Text) + 1).ToString();
        }
        private void txtYPosUp8_Click(object sender, EventArgs e)
        {
            txtYPos8.Text = (int.Parse(txtYPos8.Text) + 1).ToString();
        }
        private void txtYPosUp9_Click(object sender, EventArgs e)
        {
            txtYPos9.Text = (int.Parse(txtYPos9.Text) + 1).ToString();
        }
        private void txtYPosUp10_Click(object sender, EventArgs e)
        {
            txtYPos10.Text = (int.Parse(txtYPos10.Text) + 1).ToString();
        }


        // Down position control for X
        private void txtXPosDown1_Click(object sender, EventArgs e)
        {
            txtXPos1.Text = (int.Parse(txtXPos1.Text) - 1).ToString();
        }
        private void txtXPosDown2_Click(object sender, EventArgs e)
        {
            txtXPos2.Text = (int.Parse(txtXPos2.Text) - 1).ToString();
        }
        private void txtXPosDown3_Click(object sender, EventArgs e)
        {
            txtXPos3.Text = (int.Parse(txtXPos3.Text) - 1).ToString();
        }
        private void txtXPosDown4_Click(object sender, EventArgs e)
        {
            txtXPos4.Text = (int.Parse(txtXPos4.Text) - 1).ToString();
        }
        private void txtXPosDown5_Click(object sender, EventArgs e)
        {
            txtXPos5.Text = (int.Parse(txtXPos5.Text) - 1).ToString();
        }
        private void txtXPosDown6_Click(object sender, EventArgs e)
        {
            txtXPos6.Text = (int.Parse(txtXPos6.Text) - 1).ToString();
        }
        private void txtXPosDown7_Click(object sender, EventArgs e)
        {
            txtXPos7.Text = (int.Parse(txtXPos7.Text) - 1).ToString();
        }
        private void txtXPosDown8_Click(object sender, EventArgs e)
        {
            txtXPos8.Text = (int.Parse(txtXPos8.Text) - 1).ToString();
        }
        private void txtXPosDown9_Click(object sender, EventArgs e)
        {
            txtXPos9.Text = (int.Parse(txtXPos9.Text) - 1).ToString();
        }
        private void txtXPosDown10_Click(object sender, EventArgs e)
        {
            txtXPos10.Text = (int.Parse(txtXPos10.Text) - 1).ToString();
        }

        // Down position control for Y
        private void txtYPosDown1_Click(object sender, EventArgs e)
        {
            txtYPos1.Text = (int.Parse(txtYPos1.Text) - 1).ToString();
        }
        private void txtYPosDown2_Click(object sender, EventArgs e)
        {
            txtYPos2.Text = (int.Parse(txtYPos2.Text) - 1).ToString();
        }
        private void txtYPosDown3_Click(object sender, EventArgs e)
        {
            txtYPos3.Text = (int.Parse(txtYPos3.Text) - 1).ToString();
        }
        private void txtYPosDown4_Click(object sender, EventArgs e)
        {
            txtYPos4.Text = (int.Parse(txtYPos4.Text) - 1).ToString();
        }
        private void txtYPosDown5_Click(object sender, EventArgs e)
        {
            txtYPos5.Text = (int.Parse(txtYPos5.Text) - 1).ToString();
        }
        private void txtYPosDown6_Click(object sender, EventArgs e)
        {
            txtYPos6.Text = (int.Parse(txtYPos6.Text) - 1).ToString();
        }
        private void txtYPosDown7_Click(object sender, EventArgs e)
        {
            txtYPos7.Text = (int.Parse(txtYPos7.Text) - 1).ToString();
        }
        private void txtYPosDown8_Click(object sender, EventArgs e)
        {
            txtYPos8.Text = (int.Parse(txtYPos8.Text) - 1).ToString();
        }
        private void txtYPosDown9_Click(object sender, EventArgs e)
        {
            txtYPos9.Text = (int.Parse(txtYPos9.Text) - 1).ToString();
        }
        private void txtYPosDown10_Click(object sender, EventArgs e)
        {
            txtYPos10.Text = (int.Parse(txtYPos10.Text) - 1).ToString();
        }

        //Handles drag and drop of the bowling pins, pin 1
        private int xPos1;
        private int yPos1;
        private void picPlace1_DragDrop(object sender, DragEventArgs e)
        {
            String[] imagePaths = (String[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string path in imagePaths)
            {
                Point point = picPlace1.PointToClient(Cursor.Position);

                PictureBox pb = new PictureBox();
                pb.ImageLocation = path;
                pb.Left = point.X;
                pb.Top = point.Y;

                picPlace1.Controls.Add(pb);
                //g.DrawImage(Image.FromFile(path), point);
            }
        }
        private void pb_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                xPos1 = e.X;
                yPos1 = e.Y;
            }
        }

        private void pb_MouseMove(object sender, MouseEventArgs e)
        {
            PictureBox p = sender as PictureBox;

            if (p != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    p.Top += (e.Y - yPos1);
                    p.Left += (e.X - xPos1);
                    txtXPos1.Text = Convert.ToString(e.X - xPos1 + Convert.ToInt16(txtXPos1.Text));
                    txtYPos1.Text = Convert.ToString(e.Y - yPos1 + Convert.ToInt16(txtYPos1.Text));
                }
            }
        }
        private void picPlace1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        //Handles drag and drop of the bowling pins, pin 2
        private int xPos2;
        private int yPos2;
        private void picPlace2_DragDrop(object sender, DragEventArgs e)
        {
            String[] imagePaths = (String[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string path in imagePaths)
            {
                Point point = picPlace2.PointToClient(Cursor.Position);

                PictureBox pb = new PictureBox();
                pb.ImageLocation = path;
                pb.Left = point.X;
                pb.Top = point.Y;

                picPlace2.Controls.Add(pb);
                //g.DrawImage(Image.FromFile(path), point);
            }
        }
        private void picPlace2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                xPos2 = e.X;
                yPos2 = e.Y;
            }
        }

        private void picPlace2_MouseMove(object sender, MouseEventArgs e)
        {
            PictureBox p = sender as PictureBox;

            if (p != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    p.Top += (e.Y - yPos2);
                    p.Left += (e.X - xPos2);
                    txtXPos2.Text = Convert.ToString(e.X - xPos2 + Convert.ToInt16(txtXPos2.Text));
                    txtYPos2.Text = Convert.ToString(e.Y - yPos2 + Convert.ToInt16(txtYPos2.Text));
                }
            }
        }
        private void picPlace2_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        //Handles drag and drop of the bowling pins, pin 3
        private int xPos3;
        private int yPos3;
        private void picPlace3_DragDrop(object sender, DragEventArgs e)
        {
            String[] imagePaths = (String[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string path in imagePaths)
            {
                Point point = picPlace3.PointToClient(Cursor.Position);

                PictureBox pb = new PictureBox();
                pb.ImageLocation = path;
                pb.Left = point.X;
                pb.Top = point.Y;

                picPlace3.Controls.Add(pb);
                //g.DrawImage(Image.FromFile(path), point);
            }
        }
        private void picPlace3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                xPos3 = e.X;
                yPos3 = e.Y;
            }
        }

        private void picPlace3_MouseMove(object sender, MouseEventArgs e)
        {
            PictureBox p = sender as PictureBox;

            if (p != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    p.Top += (e.Y - yPos3);
                    p.Left += (e.X - xPos3);
                    txtXPos3.Text = Convert.ToString(e.X - xPos3 + Convert.ToInt16(txtXPos3.Text));
                    txtYPos3.Text = Convert.ToString(e.Y - yPos3 + Convert.ToInt16(txtYPos3.Text));
                }
            }
        }
        private void picPlace3_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        //Handles drag and drop of the bowling pins, pin 4
        private int xPos4;
        private int yPos4;
        private void picPlace4_DragDrop(object sender, DragEventArgs e)
        {
            String[] imagePaths = (String[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string path in imagePaths)
            {
                Point point = picPlace4.PointToClient(Cursor.Position);

                PictureBox pb = new PictureBox();
                pb.ImageLocation = path;
                pb.Left = point.X;
                pb.Top = point.Y;

                picPlace4.Controls.Add(pb);
                //g.DrawImage(Image.FromFile(path), point);
            }
        }
        private void picPlace4_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                xPos4 = e.X;
                yPos4 = e.Y;
            }
        }

        private void picPlace4_MouseMove(object sender, MouseEventArgs e)
        {
            PictureBox p = sender as PictureBox;

            if (p != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    p.Top += (e.Y - yPos4);
                    p.Left += (e.X - xPos4);
                    txtXPos4.Text = Convert.ToString(e.X - xPos4 + Convert.ToInt16(txtXPos4.Text));
                    txtYPos4.Text = Convert.ToString(e.Y - yPos4 + Convert.ToInt16(txtYPos4.Text));
                }
            }
        }
        private void picPlace4_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        //Handles drag and drop of the bowling pins, pin 5
        private int xPos5;
        private int yPos5;
        private void picPlace5_DragDrop(object sender, DragEventArgs e)
        {
            String[] imagePaths = (String[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string path in imagePaths)
            {
                Point point = picPlace5.PointToClient(Cursor.Position);

                PictureBox pb = new PictureBox();
                pb.ImageLocation = path;
                pb.Left = point.X;
                pb.Top = point.Y;

                picPlace5.Controls.Add(pb);
                //g.DrawImage(Image.FromFile(path), point);
            }
        }
        private void picPlace5_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                xPos5 = e.X;
                yPos5 = e.Y;
            }
        }

        private void picPlace5_MouseMove(object sender, MouseEventArgs e)
        {
            PictureBox p = sender as PictureBox;

            if (p != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    p.Top += (e.Y - yPos5);
                    p.Left += (e.X - xPos5);
                    txtXPos5.Text = Convert.ToString(e.X - xPos5 + Convert.ToInt16(txtXPos5.Text));
                    txtYPos5.Text = Convert.ToString(e.Y - yPos5 + Convert.ToInt16(txtYPos5.Text));
                }
            }
        }
        private void picPlace5_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }


        //Handles drag and drop of the bowling pins, pin 6
        private int xPos6;
        private int yPos6;
        private void picPlace6_DragDrop(object sender, DragEventArgs e)
        {
            String[] imagePaths = (String[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string path in imagePaths)
            {
                Point point = picPlace6.PointToClient(Cursor.Position);

                PictureBox pb = new PictureBox();
                pb.ImageLocation = path;
                pb.Left = point.X;
                pb.Top = point.Y;

                picPlace6.Controls.Add(pb);
                //g.DrawImage(Image.FromFile(path), point);
            }
        }
        private void picPlace6_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                xPos6 = e.X;
                yPos6 = e.Y;
            }
        }

        private void picPlace6_MouseMove(object sender, MouseEventArgs e)
        {
            PictureBox p = sender as PictureBox;

            if (p != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    p.Top += (e.Y - yPos6);
                    p.Left += (e.X - xPos6);
                    txtXPos6.Text = Convert.ToString(e.X - xPos6 + Convert.ToInt16(txtXPos6.Text));
                    txtYPos6.Text = Convert.ToString(e.Y - yPos6 + Convert.ToInt16(txtYPos6.Text));
                }
            }
        }
        private void picPlace6_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        //Handles drag and drop of the bowling pins, pin 7
        private int xPos7;
        private int yPos7;
        private void picPlace7_DragDrop(object sender, DragEventArgs e)
        {
            String[] imagePaths = (String[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string path in imagePaths)
            {
                Point point = picPlace7.PointToClient(Cursor.Position);

                PictureBox pb = new PictureBox();
                pb.ImageLocation = path;
                pb.Left = point.X;
                pb.Top = point.Y;

                picPlace7.Controls.Add(pb);
                //g.DrawImage(Image.FromFile(path), point);
            }
        }
        private void picPlace7_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                xPos7 = e.X;
                yPos7 = e.Y;
            }
        }

        private void picPlace7_MouseMove(object sender, MouseEventArgs e)
        {
            PictureBox p = sender as PictureBox;

            if (p != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    p.Top += (e.Y - yPos7);
                    p.Left += (e.X - xPos7);
                    txtXPos7.Text = Convert.ToString(e.X - xPos7 + Convert.ToInt16(txtXPos7.Text));
                    txtYPos7.Text = Convert.ToString(e.Y - yPos7 + Convert.ToInt16(txtYPos7.Text));
                }
            }
        }
        private void picPlace7_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        //Handles drag and drop of the bowling pins, pin 8
        private int xPos8;
        private int yPos8;
        private void picPlace8_DragDrop(object sender, DragEventArgs e)
        {
            String[] imagePaths = (String[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string path in imagePaths)
            {
                Point point = picPlace8.PointToClient(Cursor.Position);

                PictureBox pb = new PictureBox();
                pb.ImageLocation = path;
                pb.Left = point.X;
                pb.Top = point.Y;

                picPlace8.Controls.Add(pb);
                //g.DrawImage(Image.FromFile(path), point);
            }
        }
        private void picPlace8_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                xPos8 = e.X;
                yPos8 = e.Y;
            }
        }

        private void picPlace8_MouseMove(object sender, MouseEventArgs e)
        {
            PictureBox p = sender as PictureBox;

            if (p != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    p.Top += (e.Y - yPos8);
                    p.Left += (e.X - xPos8);
                    txtXPos8.Text = Convert.ToString(e.X - xPos8 + Convert.ToInt16(txtXPos8.Text));
                    txtYPos8.Text = Convert.ToString(e.Y - yPos8 + Convert.ToInt16(txtYPos8.Text));
                }
            }
        }
        private void picPlace8_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        //Handles drag and drop of the bowling pins, pin 9
        private int xPos9;
        private int yPos9;
        private void picPlace9_DragDrop(object sender, DragEventArgs e)
        {
            String[] imagePaths = (String[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string path in imagePaths)
            {
                Point point = picPlace9.PointToClient(Cursor.Position);

                PictureBox pb = new PictureBox();
                pb.ImageLocation = path;
                pb.Left = point.X;
                pb.Top = point.Y;

                picPlace9.Controls.Add(pb);
                //g.DrawImage(Image.FromFile(path), point);
            }
        }
        private void picPlace9_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                xPos9 = e.X;
                yPos9 = e.Y;
            }
        }

        private void picPlace9_MouseMove(object sender, MouseEventArgs e)
        {
            PictureBox p = sender as PictureBox;

            if (p != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    p.Top += (e.Y - yPos9);
                    p.Left += (e.X - xPos9);
                    txtXPos9.Text = Convert.ToString(e.X - xPos9 + Convert.ToInt16(txtXPos9.Text));
                    txtYPos9.Text = Convert.ToString(e.Y - yPos9 + Convert.ToInt16(txtYPos9.Text));
                }
            }
        }
        private void picPlace9_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        //Handles drag and drop of the bowling pins, pin 10
        private int xPos10;
        private int yPos10;
        private void picPlace10_DragDrop(object sender, DragEventArgs e)
        {
            String[] imagePaths = (String[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string path in imagePaths)
            {
                Point point = picPlace10.PointToClient(Cursor.Position);

                PictureBox pb = new PictureBox();
                pb.ImageLocation = path;
                pb.Left = point.X;
                pb.Top = point.Y;

                picPlace10.Controls.Add(pb);
                //g.DrawImage(Image.FromFile(path), point);
            }
        }
        private void picPlace10_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                xPos10 = e.X;
                yPos10 = e.Y;
            }
        }

        private void picPlace10_MouseMove(object sender, MouseEventArgs e)
        {
            PictureBox p = sender as PictureBox;

            if (p != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    p.Top += (e.Y - yPos10);
                    p.Left += (e.X - xPos10);
                    txtXPos10.Text = Convert.ToString(e.X - xPos10 + Convert.ToInt16(txtXPos10.Text));
                    txtYPos10.Text = Convert.ToString(e.Y - yPos10 + Convert.ToInt16(txtYPos10.Text));
                }
            }
        }
        private void picPlace10_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }



        // Calibration functions
        public static float CalibrateX(int XPos, float XCalibration)
        {
            float XCalibrated;
            return XCalibrated = XPos * XCalibration;
        }
        public static float CalibrateY(int YPos, float YCalibration)
        {
            float YCalibrated;
            return YCalibrated = YPos * YCalibration;
        }
        // Send solution
        private void btnSendSolution_Click_1(object sender, EventArgs e)
        {
            mobjPosRegs = FRRobotDemo.gobjRobot.RegPositions;
            float[] XPos = new float[11];
            float[] YPos = new float[11]; int n = 10;
            for (int i = 1; i <= n; i++)
            {
                switch (i)
                {
                    case 1:
                        // Position 1
                        mintPRNum = 79 + i;
                        mobjPosReg = mobjPosRegs[mintPRNum];
                        mobjGrpPos = mobjPosReg.Group[(short)(1)];
                        mobjPos = (FRCPosition)mobjGrpPos;
                        mobjXyzWpr = mobjPos.Formats[FRETypeCodeConstants.frXyzWpr];
                        mobjPosReg.Update();
                        XPos[i] = CalibrateX(int.Parse(txtXPos1.Text), float.Parse(txtXPosCalibrate.Text)) + float.Parse(txtXOffset.Text);
                        YPos[i] = CalibrateY(int.Parse(txtYPos1.Text), float.Parse(txtYPosCalibrate.Text)) + float.Parse(txtYOffset.Text);
                        mobjXyzWpr.X = (XPos[i]);
                        mobjXyzWpr.Y = (YPos[i]);
                        mobjPos.Update();
                        break;
                    case 2:
                        // Position 2
                        mintPRNum = 79 + i;
                        mobjPosReg = mobjPosRegs[mintPRNum];
                        mobjGrpPos = mobjPosReg.Group[(short)(1)];
                        mobjPos = (FRCPosition)mobjGrpPos;
                        mobjXyzWpr = mobjPos.Formats[FRETypeCodeConstants.frXyzWpr];
                        mobjPosReg.Update();
                        XPos[i] = CalibrateX(int.Parse(txtXPos2.Text), float.Parse(txtXPosCalibrate.Text)) + float.Parse(txtXOffset.Text);
                        YPos[i] = CalibrateY(int.Parse(txtYPos2.Text), float.Parse(txtYPosCalibrate.Text)) + float.Parse(txtYOffset.Text);
                        mobjXyzWpr.X = (XPos[i]);
                        mobjXyzWpr.Y = (YPos[i]);
                        mobjPos.Update();
                        break;
                    case 3:
                        // Position 1
                        mintPRNum = 79 + i;
                        mobjPosReg = mobjPosRegs[mintPRNum];
                        mobjGrpPos = mobjPosReg.Group[(short)(1)];
                        mobjPos = (FRCPosition)mobjGrpPos;
                        mobjXyzWpr = mobjPos.Formats[FRETypeCodeConstants.frXyzWpr];
                        mobjPosReg.Update();
                        XPos[i] = CalibrateX(int.Parse(txtXPos3.Text), float.Parse(txtXPosCalibrate.Text)) + float.Parse(txtXOffset.Text);
                        YPos[i] = CalibrateY(int.Parse(txtYPos3.Text), float.Parse(txtYPosCalibrate.Text))+ float.Parse(txtYOffset.Text);
                        mobjXyzWpr.X = (XPos[i]);
                        mobjXyzWpr.Y = (YPos[i]);
                        mobjPos.Update();
                        break;
                    case 4:
                        // Position 4
                        mintPRNum = 79 + i;
                        mobjPosReg = mobjPosRegs[mintPRNum];
                        mobjGrpPos = mobjPosReg.Group[(short)(1)];
                        mobjPos = (FRCPosition)mobjGrpPos;
                        mobjXyzWpr = mobjPos.Formats[FRETypeCodeConstants.frXyzWpr];
                        mobjPosReg.Update();
                        XPos[i] = CalibrateX(int.Parse(txtXPos4.Text), float.Parse(txtXPosCalibrate.Text)) + float.Parse(txtXOffset.Text);
                        YPos[i] = CalibrateY(int.Parse(txtYPos4.Text), float.Parse(txtYPosCalibrate.Text)) + float.Parse(txtYOffset.Text);
                        mobjXyzWpr.X = (XPos[i]);
                        mobjXyzWpr.Y = (YPos[i]);
                        mobjPos.Update();
                        break;
                    case 5:
                        // Position 5
                        mintPRNum = 79 + i;
                        mobjPosReg = mobjPosRegs[mintPRNum];
                        mobjGrpPos = mobjPosReg.Group[(short)(1)];
                        mobjPos = (FRCPosition)mobjGrpPos;
                        mobjXyzWpr = mobjPos.Formats[FRETypeCodeConstants.frXyzWpr];
                        mobjPosReg.Update();
                        XPos[i] = CalibrateX(int.Parse(txtXPos5.Text), float.Parse(txtXPosCalibrate.Text)) + float.Parse(txtXOffset.Text);
                        YPos[i] = CalibrateY(int.Parse(txtYPos5.Text), float.Parse(txtYPosCalibrate.Text)) + float.Parse(txtYOffset.Text);
                        mobjXyzWpr.X = (XPos[i]);
                        mobjXyzWpr.Y = (YPos[i]);
                        mobjPos.Update();
                        break;
                    case 6:
                        // Position 6
                        mintPRNum = 79 + i;
                        mobjPosReg = mobjPosRegs[mintPRNum];
                        mobjGrpPos = mobjPosReg.Group[(short)(1)];
                        mobjPos = (FRCPosition)mobjGrpPos;
                        mobjXyzWpr = mobjPos.Formats[FRETypeCodeConstants.frXyzWpr];
                        mobjPosReg.Update();
                        XPos[i] = CalibrateX(int.Parse(txtXPos6.Text), float.Parse(txtXPosCalibrate.Text)) + float.Parse(txtXOffset.Text);
                        YPos[i] = CalibrateY(int.Parse(txtYPos6.Text), float.Parse(txtYPosCalibrate.Text)) + float.Parse(txtYOffset.Text);
                        mobjXyzWpr.X = (XPos[i]);
                        mobjXyzWpr.Y = (YPos[i]);
                        mobjPos.Update();
                        break;
                    case 7:
                        // Position 7
                        mintPRNum = 79 + i;
                        mobjPosReg = mobjPosRegs[mintPRNum];
                        mobjGrpPos = mobjPosReg.Group[(short)(1)];
                        mobjPos = (FRCPosition)mobjGrpPos;
                        mobjXyzWpr = mobjPos.Formats[FRETypeCodeConstants.frXyzWpr];
                        mobjPosReg.Update();
                        XPos[i] = CalibrateX(int.Parse(txtXPos7.Text), float.Parse(txtXPosCalibrate.Text)) + float.Parse(txtXOffset.Text);
                        YPos[i] = CalibrateY(int.Parse(txtYPos7.Text), float.Parse(txtYPosCalibrate.Text)) + float.Parse(txtYOffset.Text);
                        mobjXyzWpr.X = (XPos[i]);
                        mobjXyzWpr.Y = (YPos[i]);
                        mobjPos.Update();
                        break;
                    case 8:
                        // Position 8
                        mintPRNum = 79 + i;
                        mobjPosReg = mobjPosRegs[mintPRNum];
                        mobjGrpPos = mobjPosReg.Group[(short)(1)];
                        mobjPos = (FRCPosition)mobjGrpPos;
                        mobjXyzWpr = mobjPos.Formats[FRETypeCodeConstants.frXyzWpr];
                        mobjPosReg.Update();
                        XPos[i] = CalibrateX(int.Parse(txtXPos8.Text), float.Parse(txtXPosCalibrate.Text)) + float.Parse(txtXOffset.Text);
                        YPos[i] = CalibrateY(int.Parse(txtYPos8.Text), float.Parse(txtYPosCalibrate.Text)) + float.Parse(txtYOffset.Text);
                        mobjXyzWpr.X = (XPos[i]);
                        mobjXyzWpr.Y = (YPos[i]);
                        mobjPos.Update();
                        break;
                    case 9:
                        // Position 9
                        mintPRNum = 79 + i;
                        mobjPosReg = mobjPosRegs[mintPRNum];
                        mobjGrpPos = mobjPosReg.Group[(short)(1)];
                        mobjPos = (FRCPosition)mobjGrpPos;
                        mobjXyzWpr = mobjPos.Formats[FRETypeCodeConstants.frXyzWpr];
                        mobjPosReg.Update();
                        XPos[i] = CalibrateX(int.Parse(txtXPos9.Text), float.Parse(txtXPosCalibrate.Text)) + float.Parse(txtXOffset.Text);
                        YPos[i] = CalibrateY(int.Parse(txtYPos9.Text), float.Parse(txtYPosCalibrate.Text)) + float.Parse(txtYOffset.Text);
                        mobjXyzWpr.X = (XPos[i]);
                        mobjXyzWpr.Y = (YPos[i]);
                        mobjPos.Update();
                        break;
                    case 10:
                        // Position 10
                        mintPRNum = 79 + i;
                        mobjPosReg = mobjPosRegs[mintPRNum];
                        mobjGrpPos = mobjPosReg.Group[(short)(1)];
                        mobjPos = (FRCPosition)mobjGrpPos;
                        mobjXyzWpr = mobjPos.Formats[FRETypeCodeConstants.frXyzWpr];
                        mobjPosReg.Update();
                        XPos[i] = CalibrateX(int.Parse(txtXPos10.Text), float.Parse(txtXPosCalibrate.Text)) + float.Parse(txtXOffset.Text);
                        YPos[i] = CalibrateY(int.Parse(txtYPos10.Text), float.Parse(txtYPosCalibrate.Text)) + float.Parse(txtYOffset.Text);
                        mobjXyzWpr.X = (XPos[i]);
                        mobjXyzWpr.Y = (YPos[i]);
                        mobjPos.Update();
                        break;
                        
                        
                        
                }
            }





        }
        public void frmPickPlace_LoadChanger()
        {
            if (AlreadyClosed == true)
            {
                txtXPos1.Text = XPos1_Saved.ToString(); //picPlace1.Location.X.ToString();
                txtXPos2.Text = XPos2_Saved.ToString(); //picPlace2.Location.X.ToString();
                txtXPos3.Text = XPos3_Saved.ToString(); //picPlace3.Location.X.ToString();
                txtXPos4.Text = XPos4_Saved.ToString(); //picPlace4.Location.X.ToString();
                txtXPos5.Text = XPos5_Saved.ToString(); //picPlace5.Location.X.ToString();
                txtXPos6.Text = XPos6_Saved.ToString(); //picPlace6.Location.X.ToString();
                txtXPos7.Text = XPos7_Saved.ToString(); //picPlace7.Location.X.ToString();
                txtXPos8.Text = XPos8_Saved.ToString(); //picPlace8.Location.X.ToString();
                txtXPos9.Text = XPos9_Saved.ToString(); //picPlace9.Location.X.ToString();
                txtXPos10.Text = XPos10_Saved.ToString(); //picPlace10.Location.X.ToString();
                txtYPos1.Text = YPos1_Saved.ToString(); // picPlace1.Location.Y.ToString();
                txtYPos2.Text = YPos2_Saved.ToString(); //picPlace2.Location.Y.ToString();
                txtYPos3.Text = YPos3_Saved.ToString(); //picPlace3.Location.Y.ToString();
                txtYPos4.Text = YPos4_Saved.ToString(); //picPlace4.Location.Y.ToString();
                txtYPos5.Text = YPos5_Saved.ToString(); //picPlace5.Location.Y.ToString();
                txtYPos6.Text = YPos6_Saved.ToString(); //picPlace6.Location.Y.ToString();
                txtYPos7.Text = YPos7_Saved.ToString(); //picPlace7.Location.Y.ToString();
                txtYPos8.Text = YPos8_Saved.ToString(); //picPlace8.Location.Y.ToString();
                txtYPos9.Text = YPos9_Saved.ToString(); //picPlace9.Location.Y.ToString();
                txtYPos10.Text = YPos10_Saved.ToString(); //picPlace10.Location.Y.ToString();
            }
            else
            {
                txtXPos1.Text = picPlace1.Location.X.ToString();
                txtXPos2.Text = picPlace2.Location.X.ToString();
                txtXPos3.Text = picPlace3.Location.X.ToString();
                txtXPos4.Text = picPlace4.Location.X.ToString();
                txtXPos5.Text = picPlace5.Location.X.ToString();
                txtXPos6.Text = picPlace6.Location.X.ToString();
                txtXPos7.Text = picPlace7.Location.X.ToString();
                txtXPos8.Text = picPlace8.Location.X.ToString();
                txtXPos9.Text = picPlace9.Location.X.ToString();
                txtXPos10.Text = picPlace10.Location.X.ToString();
                txtYPos1.Text = picPlace1.Location.Y.ToString();
                txtYPos2.Text = picPlace2.Location.Y.ToString();
                txtYPos3.Text = picPlace3.Location.Y.ToString();
                txtYPos4.Text = picPlace4.Location.Y.ToString();
                txtYPos5.Text = picPlace5.Location.Y.ToString();
                txtYPos6.Text = picPlace6.Location.Y.ToString();
                txtYPos7.Text = picPlace7.Location.Y.ToString();
                txtYPos8.Text = picPlace8.Location.Y.ToString();
                txtYPos9.Text = picPlace9.Location.Y.ToString();
                txtYPos10.Text = picPlace10.Location.Y.ToString();
            }

        }

            private void frmPickPlace_FormClosing(object sender, FormClosingEventArgs e)
        {

            XPos1_Saved = int.Parse(txtXPos1.Text);
            XPos2_Saved = int.Parse(txtXPos2.Text);
            XPos3_Saved = int.Parse(txtXPos3.Text);
            XPos4_Saved = int.Parse(txtXPos4.Text);
            XPos5_Saved = int.Parse(txtXPos5.Text);
            XPos6_Saved = int.Parse(txtXPos6.Text);
            XPos7_Saved = int.Parse(txtXPos7.Text);
            XPos8_Saved = int.Parse(txtXPos8.Text);
            XPos9_Saved = int.Parse(txtXPos9.Text);
            XPos10_Saved = int.Parse(txtXPos10.Text);
            YPos1_Saved = int.Parse(txtYPos1.Text);
            YPos2_Saved = int.Parse(txtYPos2.Text);
            YPos3_Saved = int.Parse(txtYPos3.Text);
            YPos4_Saved = int.Parse(txtYPos4.Text);
            YPos5_Saved = int.Parse(txtYPos5.Text);
            YPos6_Saved = int.Parse(txtYPos6.Text);
            YPos7_Saved = int.Parse(txtYPos7.Text);
            YPos8_Saved = int.Parse(txtYPos8.Text);
            YPos9_Saved = int.Parse(txtYPos9.Text);
            YPos10_Saved = int.Parse(txtYPos10.Text);
    }
        public static bool AlreadyClosed = false;
        private void frmPickPlace_FormClosed(object sender, FormClosedEventArgs e)
        {
            AlreadyClosed = true;
        }
    }
}

