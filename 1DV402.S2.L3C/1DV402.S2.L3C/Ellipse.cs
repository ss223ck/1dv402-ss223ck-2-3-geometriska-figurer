using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L3C
{
    class Ellipse : Shape2D
    {
        public override double area
        {
            get { { return (Math.PI * Length * Width); } }
        }
        public override double Perimeter
        {
            get { return Math.PI * Math.Sqrt(Length * Length * 2) + (Width * Width * 2); }
        }
        //Speciallfallet Ellipse = cirkel
        public Ellipse(double diameter) : base(ShapeType.Ellipse, diameter, diameter)
        {}
        public Ellipse(double hDiameter, double vDiameter) : base(ShapeType.Circle, hDiameter, vDiameter)
        {}
    }
}
