using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPhotoshop
{
    public struct Pixel
    {
        public Pixel(double r, double g, double b)
        {
            this.r = this.g = this.b = 0;
            this.R = r;
            this.G = g;
            this.B = b;
        }

        private double r;

        public double R
        {
            get => r;
            set
            {
                r = Check(value);
            }
        }

        private double g;

        public double G
        {
            get => g;
            set
            {
                g = Check(value);
            }
        }

        private double b;

        public double B
        {
            get => b;
            set
            {
                b = Check(value);
            }
        }

        public double Check(double value)
        {
            return (value < 0 || value > 1) ? throw new ArgumentException() : value;
        }

        public static double Trim(double value)
        {
            if (value < 0) return 0;
            if (value > 1) return 1;
            return value;
        }

        public static Pixel operator *(Pixel p, double c)
        {
            return new Pixel(
                Pixel.Trim(p.R * c),
                Pixel.Trim(p.G * c),
                Pixel.Trim(p.B * c));
        }

        public static Pixel operator *(double c, Pixel p)
        {
            return new Pixel(
                Pixel.Trim(p.R * c),
                Pixel.Trim(p.G * c),
                Pixel.Trim(p.B * c));
        }

        public static implicit operator Pixel(double v)
        {
            return new Pixel(v, v, v);
        }
    }
}
