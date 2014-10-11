﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L3C
{
    class Cuboid : Shape3D
    {
        public override double MantelArea
        {
            get { return (_baseShape.Perimeter * Height); }
        }
        public override double TotalSurFaceArea
        {
            get { return ((_baseShape.Area * 2) + MantelArea); }
        }
        public override double Volume
        {
            get { return (_baseShape.Area * Height); }
        }
        public Cuboid(double length, double width, double height) : base(ShapeType.Cuboid, new Rectangle(length, width), height)
        { }
    }
}
