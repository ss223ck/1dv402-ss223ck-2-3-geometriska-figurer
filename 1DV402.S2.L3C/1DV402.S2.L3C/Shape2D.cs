using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L3C
{
    public abstract class Shape2D : Shape, IComparable
    {
        private double _length;
        private double _width;

        public abstract double Area { get; }
        public double Length
        {
            get { return _length; }
            set { 
                if (value < 0)
                {
                    throw new ArgumentException("värdet för length är mindre än 0");
                }
                _length = value; 
            }
        }
        public abstract double Perimeter { get; }
        public double Width
        {
            get { return _width; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("värdet för width är mindre än 0");
                }
                _width = value;
            }
        }
        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            if (!(obj is Shape2D))
            {
                throw new ArgumentException("parametern i CompareTo är inte av typen Shape2D");
            }
            Shape2D objShaped2D = obj as Shape2D;
            return Area.CompareTo(objShaped2D.Area);
        }
        protected Shape2D(ShapeType shapeType, double length, double width)
        : base(shapeType)
        {
            Length = length;
            Width = width;
        }
        public override string ToString()
        {
            return ToString("G");
        }
        public override string ToString(string format)
        {
            if (format == "G" || format == null || format == "")
            {
                return string.Format("{0}:{1:f1}:{2}:{3:f1}:{4}:{5:f1}:{6}:{7:f1}", StringsFileR.Length, Length, StringsFileR.Width, Width, StringsFileR.Circuit, Perimeter, StringsFileR.Area, Area);
            }
            if (format == "R")
            {
                if (ShapeType == L3C.ShapeType.Ellipse)
                {
                    return string.Format("{0}{1, 9:f1}{2, 6:f1}{3, 9:f1}{4, 8:f1}", ShapeType, Length, Width, Perimeter, Area);
                }
                else if(ShapeType == L3C.ShapeType.Rectangle)
                {
                    return string.Format("{0}{1, 7:f1}{2, 6:f1}{3, 9:f1}{4, 8:f1}", ShapeType, Length, Width, Perimeter, Area);
                }
                else
                {
                    return string.Format("{0}{1, 10:f1}{2, 6:f1}{3, 9:f1}{4, 8:f1}", ShapeType, Length, Width, Perimeter, Area);
                }
            }
            throw new FormatException("fel format på parametern till tostring");
        }
    }
}
