﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L3C
{
    public enum ShapeType {Rectangle, Circle, Ellipse, Cuboid, Cylinder, Sphere}
    public abstract class Shape
    {
        public bool IsShape3D
        {
            get { 
                return this.ShapeType == ShapeType.Cuboid || 
                    this.ShapeType == ShapeType.Cylinder || 
                    this.ShapeType == ShapeType.Sphere;
            }
        }
        public ShapeType ShapeType { get; private set; }
        protected Shape(ShapeType shapeType)
        {
            ShapeType = shapeType;
        }
        public abstract string ToString(string format);
    }
    
}
