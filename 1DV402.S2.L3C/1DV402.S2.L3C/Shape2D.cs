using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L3C
{
    public abstract class Shape2D : Shape
    {
        private double _length;
        private double _width;

        public abstract double area { get; }
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
            if (obj.area > area)
            {
                return -1;
            }
            if (obj.area < area)
            {
                return 1;
            }
            if (obj.area == area)
            {
                return 0;
            }
        }
        protected Shape2D(ShapeType shapeType, double length, double width)
        : base(shapeType)
        {
            Length = length;
            Width = width;
        }
        public string ToString()
        {
            return string.Format("{0}{1}:{2}{3}:{4}{5}:{6}{7}", StringsFileR.Length, Length, StringsFileR.Width, Width, StringsFileR.Circuit, Perimeter, StringsFileR.Area, area);
        }
        public override string ToString(string format)
        {
            if (format == "G" || format == null || format == "")
            {
                //returnera 
                return string.Format("{0}{1}:{2}{3}:{4}{5}:{6}{7}", StringsFileR.Length, Length, StringsFileR.Width, Width, StringsFileR.Circuit, Perimeter, StringsFileR.Area, area);
            }
            if (format == "R")
            {
                // skriv in samma som ovan fast med endast beskrivning av vilket objekt det är.
                return string.Format("{0}");
            }
            return;
        }
    }
}
