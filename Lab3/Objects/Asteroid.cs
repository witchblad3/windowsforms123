﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsApp3Asteroids.Objects
{
    internal class Asteroid : Star
    {
        private static readonly Image[] astImages = new Image[]
        {
            Image.FromFile(@"Images\Asteroid1.png"),
            Image.FromFile(@"Images\Asteroid2.png"),
            Image.FromFile(@"Images\Asteroid5.png"),
        };
        public static int CountImages => astImages.Length;
        private int currentImage;
        private float angle = 0.0F;
        private float angledir;
        public Asteroid(Point pos, Point dir, Size size, int currentImage, float angledir) : base(pos, dir, size)
        {
            this.currentImage = currentImage;
            this.angledir = angledir;
        }
        public override void Update()
        {
            pos.X += dir.X;
            pos.Y += dir.Y;
            if (pos.X + size.Width < 0)
                Reset();
        }
        public override void Reset()
        {
            pos.X = Game.Size.Width + size.Width + Game.Rand.Next(Game.Size.Width);
            pos.Y = Game.Rand.Next(Game.Size.Height - size.Height);
            currentImage = Game.Rand.Next(CountImages);
        }
        public override void Draw(Graphics g)
        {
            Image image = Tools.RotateBitmapAsteroid(astImages[currentImage], new PointF(50, 50), angle);
            angle += angledir;
            //Image image = astImages[currentImage];
            g.DrawImage(image, new Rectangle(pos, size));
        }
    }
}
