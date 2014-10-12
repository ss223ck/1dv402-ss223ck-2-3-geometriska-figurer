using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L3C
{
    static class Extentions
    {
        public static string AsText(this ShapeType shapeType)
        {
            string returnValueString = "";
            if (shapeType == ShapeType.Circle)
            {
                returnValueString = StringsFileR.Circle;
            }
            else if (shapeType == ShapeType.Cuboid)
            {
                returnValueString = StringsFileR.Cuboid;
            }
            else if (shapeType == ShapeType.Cylinder)
            {
                returnValueString = StringsFileR.Cylinder;
            }
            else if (shapeType == ShapeType.Ellipse)
            {
                returnValueString = StringsFileR.Ellipse;
            }
            else if (shapeType == ShapeType.Rectangle)
            {
                returnValueString = StringsFileR.Rektangle;
            }
            else if (shapeType == ShapeType.Sphere)
            {
                returnValueString = StringsFileR.Sphere;
            }
            return returnValueString;
        }
        public static string CenterAlignText(this string s, string other)
        {

        }
    }
}
