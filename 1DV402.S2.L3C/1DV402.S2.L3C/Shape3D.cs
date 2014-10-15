using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L3C
{
    public abstract class Shape3D : Shape, IComparable
    {
        protected Shape2D _baseShape;
        private Double _height;
        public double Height
        {
            get { return _height; }
            set 
            {
                if (value >= 0)
                {
                    _height = value;
                }
                else
                {
                    throw new ArgumentException("Värdet är mindre än 0 för 3dfiguren");
                }
            }
        }
        public abstract double MantelArea { get; }
        public abstract double TotalSurFaceArea { get; }
        public abstract double Volume { get; }
        public int CompareTo(object obj)
        {
            int result;
            Shape3D objShape3D = obj as Shape3D;
            if (obj == null)
            {
                return 1;
            }
            
            if (!(obj is Shape3D))
            {
                throw new ArgumentException("parametern i CompareTo är inte av typen Shape3D");
            }
            result = Volume.CompareTo(objShape3D.Volume);
            return result;
        }
        protected Shape3D(ShapeType shapeType, Shape2D baseShape, double height) : base(shapeType)
        {
            _baseShape = baseShape;
            Height = height;
        }
        public override string ToString()
        {
            return ToString("G");
        }
        public override string ToString(string format)
        {
            if (format == "G" || format == null || format == "")
            {
                return string.Format("{0}:{1:f1}:{2}:{3:f1}:{4}:{5:f1}:{6}:{7:f1}:{8}:{9:f1}:{10}:{11:f1}:{12}:{13:f1}", StringsFileR.Length, _baseShape.Length, StringsFileR.Width, _baseShape.Width, StringsFileR.Heigth, this.Height, StringsFileR.Circuit, _baseShape.Perimeter, StringsFileR.Area, _baseShape.Area, StringsFileR.MantelArea, this.MantelArea, StringsFileR.TotalSurFaceArea, this.TotalSurFaceArea, StringsFileR.Volume, this.Volume);
            }
            if (format == "R")
            {
                if (ShapeType == L3C.ShapeType.Cuboid)
                {
                    return string.Format("{0}{1, 10:f1}{2, 6:f1}{3, 6:f1}{4, 13:f1}{5, 13:f1}{6, 13:f1}", ShapeType, _baseShape.Length, _baseShape.Width, this.Height, this.MantelArea, this.TotalSurFaceArea, this.Volume);
                }
                else if (ShapeType == L3C.ShapeType.Cylinder)
                {
                    return string.Format("{0}{1, 8:f1}{2, 6:f1}{3, 6:f1}{4, 13:f1}{5, 13:f1}{6, 13:f1}", ShapeType, _baseShape.Length, _baseShape.Width, this.Height, this.MantelArea, this.TotalSurFaceArea, this.Volume);
                }
                else
                {
                    return string.Format("{0}{1, 10:f1}{2, 6:f1}{3, 6:f1}{4, 13:f1}{5, 13:f1}{6, 13:f1}", ShapeType, _baseShape.Length, _baseShape.Width, this.Height, this.MantelArea, this.TotalSurFaceArea, this.Volume);
                }
            }
            throw new FormatException("fel format på parametern till tostring");
        }
    }
}
