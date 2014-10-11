﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L3C
{
    class Sphere : Shape3D
    {
        public override double MantelArea
        {
            get { return (_baseShape.Area * 4); }
        }
        public override double TotalSurFaceArea
        {
            get { return (_baseShape.Area * 4); }
        }
        public override double Volume
        {
            get { return ((4/3) * _baseShape.Area * 4); }
        }
        public Sphere(double radius) : base(ShapeType.Sphere, new Ellipse((radius * 2)), radius)
        { }
    }
}
