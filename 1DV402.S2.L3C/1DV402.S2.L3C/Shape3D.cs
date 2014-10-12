using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L3C
{
    class Shape3D : Shape, IComparable
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
                result = 1;
            }
            else if (!(obj is Shape3D))
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
            return string.Format("{0}:{1}:{2}:{3}:{4}:{5}:{6}:{7}:{8:}{9}:{10}:{11}", StringsFileR.Length, _baseShape.Length, StringsFileR.Width, _baseShape.Width, StringsFileR.Circuit, _baseShape.Perimeter, StringsFileR.Area, _baseShape.area, StringsFileR.MantelArea, MantelArea, StringsFileR.TotalSurFaceArea, TotalSurFaceArea, StringsFileR.Volume, Volume);
        }
        public override string ToString(string format)
        {
            if (format == "G" || format == null || format == "")
            {
                //returnera 
                return string.Format("{0}{1}:{2}{3}:{4}{5}:{6}{7}:{8}{9}:{10}{11}", StringsFileR.Length, _baseShape.Length, StringsFileR.Width, _baseShape.Width, StringsFileR.Circuit, _baseShape.Perimeter, StringsFileR.Area, _baseShape.area, StringsFileR.MantelArea, MantelArea, StringsFileR.TotalSurFaceArea, TotalSurFaceArea, StringsFileR.Volume, Volume);
            }
            if (format == "R")
            {
                // skriv in samma som ovan fast med endast beskrivning av vilket objekt det är.
                return string.Format("{0}{1, 16:f1}{2, 22:f1}{3, 28:f1}{4, 41:f1}{5, 54:f1}{6, 67:f1}", ShapeType, _baseShape.Length, _baseShape.Width, Height, MantelArea, TotalSurFaceArea, Volume);
            }
            throw new FormatException("fel format på parametern till tostring");
        }
    }
}
