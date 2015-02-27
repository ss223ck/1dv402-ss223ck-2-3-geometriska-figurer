using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L3C
{
    class Program
    {
        private static Shape CreateShape(ShapeType shapeType)
        {
            double[] ReturnArray;
            string shapeName = shapeType.AsText();

            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(StringsFileR.FrameEqual);
            Console.WriteLine(shapeName.CenterAlignText(StringsViewMenu.EqualsFormat));
            Console.WriteLine(StringsFileR.FrameEqual);
            Console.BackgroundColor = ConsoleColor.Black;

            ReturnArray = ReadDimensions(shapeType);
            if (shapeType == ShapeType.Circle)
            {
                return new Ellipse(ReturnArray[0]);
            }
            else if (shapeType == ShapeType.Rectangle)
            {
                return new Rectangle(ReturnArray[0], ReturnArray[1]);
            }
            else if (shapeType == ShapeType.Cuboid)
            {
                return new Cuboid(ReturnArray[0], ReturnArray[1], ReturnArray[2]);
            }
            else if (shapeType == ShapeType.Cylinder)
            {
                return new Cylinder(ReturnArray[0], ReturnArray[1], ReturnArray[2]);
            }
            else if (shapeType == ShapeType.Ellipse)
            {
                return new Ellipse(ReturnArray[0], ReturnArray[1]);
            }
            return new Sphere(ReturnArray[0]);
        }
        static void Main(string[] args)
        {
            string recievedValue;
            int valueConverted;

            do
            {
                ViewMenu();
                recievedValue = Console.ReadLine();
                if (recievedValue == "0" || recievedValue == "1" || recievedValue == "2" || recievedValue == "3" || recievedValue == "4" || recievedValue == "5" || recievedValue == "6" || recievedValue == "7" || recievedValue == "8")
                {
                    valueConverted = int.Parse(recievedValue);
                    switch (valueConverted)
                    {
                        case 0:
                            return;
                        case 1:
                            ViewShapeDetail(CreateShape(ShapeType.Rectangle));
                            break;
                        case 2:
                            ViewShapeDetail(CreateShape(ShapeType.Circle));
                            break;
                        case 3:
                            ViewShapeDetail(CreateShape(ShapeType.Ellipse));
                            break;
                        case 4:
                            ViewShapeDetail(CreateShape(ShapeType.Cuboid));
                            break;
                        case 5:
                            ViewShapeDetail(CreateShape(ShapeType.Cylinder));
                            break;
                        case 6:
                            ViewShapeDetail(CreateShape(ShapeType.Sphere));
                            break;
                        case 7:
                            ViewShapes(Randomize2DShapes());
                            break;
                        case 8:
                            ViewShapes(Randomize3DShapes());
                            break;
                    }
                }
                else
                {
                Console.WriteLine(StringsFileR.ErrorMessageNumberWrong_Prompt);
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine(StringsFileR.Continue_Prompt);
                Console.ReadKey();
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Black;
                break;
                }
                
            } while (true);
        }
        private static Shape2D[] Randomize2DShapes()
        {
            Random randomInstance = new Random();
            int numberOfFiguers = randomInstance.Next(5, 21);
            Shape2D[] returnArray = new Shape2D[numberOfFiguers];

            for (int i = 0; i < numberOfFiguers; i++)
            {
                int randomShape = randomInstance.Next(0, 3);
                double length = (randomInstance.NextDouble() * (99 - 5) + 5);
                double width = (randomInstance.NextDouble() * (99 - 5) + 5);
                switch (randomShape)
                {
                    case 0:
                        returnArray[i] = new Ellipse(length, width);
                        break;
                    case 1:
                        returnArray[i] = new Ellipse(length);
                        break;
                    case 2:
                        returnArray[i] = new Rectangle(length, width);
                        break;
                }
            }
            return returnArray;
        }
        private static Shape3D[] Randomize3DShapes()
        {
            Random randomInstance = new Random();
            int numberOfFiguers = randomInstance.Next(5, 21);
            Shape3D[] returnArray = new Shape3D[numberOfFiguers];

            for (int i = 0; i < numberOfFiguers; i++)
            {
                int randomShape = randomInstance.Next(3, 6);
                double height = (randomInstance.NextDouble() * (99 - 5) + 5);
                double length = (randomInstance.NextDouble() * (99 - 5) + 5);
                double width = (randomInstance.NextDouble() * (99 - 5) + 5);
                switch (randomShape)
                {
                    case 3:
                        returnArray[i] = new Cuboid(length, width, height);
                        break;
                    case 4:
                        returnArray[i] = new Cylinder(length, width, height);
                        break;
                    case 5:
                        returnArray[i] = new Sphere(length);
                        break;
                }
            }
            return returnArray;
        }
        private static double[] ReadDimensions(ShapeType shapeType)
        {
            double[] returnArrayDimensions = new double[1];

            if (shapeType == ShapeType.Circle || shapeType == ShapeType.Sphere)
            {
                //Code for reading one value
                if (shapeType == ShapeType.Circle)
                {
                    returnArrayDimensions = ReadDoubleGreaterThenZero(StringsFileR.Circle_Propmt);
                }
                else
                {
                    returnArrayDimensions = ReadDoubleGreaterThenZero(StringsFileR.Sphere);
                }
            }
            else if (shapeType == ShapeType.Rectangle || shapeType == ShapeType.Ellipse)
            {
                //Code for reading two values
                returnArrayDimensions = ReadDoubleGreaterThenZero(StringsFileR.LengthNWidth_Prompt, 2);
            }
            else if (shapeType == ShapeType.Cylinder || shapeType == ShapeType.Cuboid)
            {
                //Code for reading three values
                returnArrayDimensions = ReadDoubleGreaterThenZero(StringsFileR.LengthWidthNHeight_Prompt, 3);
            }
            return returnArrayDimensions;
        }
        private static double[] ReadDoubleGreaterThenZero(string prompt, int NumberOfValues = 1)
        {
            double[] returnArray = new double[NumberOfValues];
            string[] stringSplittedArray;
            bool checkInValue = true;

            // I made a loop so i can check if the value(s) that got typed in are good.
            do
            {
                Console.Write(prompt);
                string mainReturnstring = Console.ReadLine();
                if (NumberOfValues == 1)
                {
                    returnArray[0] = double.Parse(mainReturnstring);
                    if (returnArray[0] > 0)
                    {
                        checkInValue = false;
                    }
                    else
                    {
                        ViewMenuErrorMessage();
                    }
                }
                else
                {
                    stringSplittedArray = mainReturnstring.Split(' ');
                    int i = 0;
                    foreach (string v in stringSplittedArray)
                    {
                        returnArray[i] = int.Parse(v);
                        if (returnArray[i] > 0)
                        {
                            checkInValue = false;
                        }
                        else
                        {
                            checkInValue = true;
                            ViewMenuErrorMessage();
                        }
                        i++;
                    }
                }
            } while (checkInValue);
            return returnArray;
        }
        private static void ViewMenu()
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(StringsViewMenu.FramOfEquals);
            Console.WriteLine(StringsViewMenu.OnlyEquals);
            Console.WriteLine(StringsViewMenu.MiddleFrameGeometriska);
            Console.WriteLine(StringsViewMenu.OnlyEquals);
            Console.WriteLine(StringsViewMenu.FramOfEquals);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
            Console.WriteLine(StringsViewMenu.Quit_Prompt);
            Console.WriteLine(StringsViewMenu.Rektangle_Prompt);
            Console.WriteLine(StringsViewMenu.Circle_Prompt);
            Console.WriteLine(StringsViewMenu.Ellipse_Prompt);
            Console.WriteLine(StringsViewMenu.Cuboid_Prompt);
            Console.WriteLine(StringsViewMenu.Cylinder_Prompt);
            Console.WriteLine(StringsViewMenu.Sphere_Prompt);
            Console.WriteLine(StringsViewMenu.Random2D_Prompt);
            Console.WriteLine(StringsViewMenu.Random3D_Prompt);
            Console.WriteLine();
            Console.WriteLine(StringsViewMenu.FramOfEquals);
            Console.WriteLine();
            Console.Write(StringsViewMenu.ReadNumber_Prompt);
        }
        private static void ViewMenuErrorMessage()
        {
            Console.WriteLine(StringsFileR.ErrorMessageDimensions_Prompt);
        }
        private static void ViewShapeDetail(Shape shape)
        {
            string[] arraySplittedString;
            string objectValues;
            string colon = ":";

            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(StringsViewMenu.FramOfEquals);
            Console.WriteLine(StringsViewMenu.OnlyEquals);
            Console.WriteLine(StringsViewMenu.MiddleFrameDetails);
            Console.WriteLine(StringsViewMenu.OnlyEquals);
            Console.WriteLine(StringsViewMenu.FramOfEquals);
            Console.BackgroundColor = ConsoleColor.Black;

            objectValues = shape.ToString();
            arraySplittedString = objectValues.Split(':');

            int i = 0;
            do
            {
                Console.WriteLine(string.Format("{0}{1}{2}", arraySplittedString[i], colon, arraySplittedString[i + 1]));
                i = i + 2;
            } while (i < arraySplittedString.Length);
            Console.WriteLine();
            Console.WriteLine(StringsViewMenu.OnlyEquals);
            Console.WriteLine();
        }
        private static void ViewShapes(Shape[] shapes)
        {
            string[] arraySplittedString = new string[shapes.Length];

            int i = 0;
            foreach (Shape s in shapes)
            {
                arraySplittedString[i] = s.ToString("R");
                i++;
            }
            Console.BackgroundColor = ConsoleColor.DarkRed;
            //if statement to see what to write in the console
            if (shapes[0].IsShape3D)
            {
                Console.WriteLine(StringsViewMenu.FrameMinus);
                Console.WriteLine(StringsViewMenu.FrameSpecifiedTwo);
                Console.WriteLine(StringsViewMenu.FrameMinus);
                Console.BackgroundColor = ConsoleColor.Black;
                foreach (string s in arraySplittedString)
                {
                    Console.WriteLine(s);
                }
            }
            else
            {
                Console.WriteLine(StringsViewMenu.FrameMinusTwo);
                Console.WriteLine(StringsViewMenu.FramSpecifiedOne);
                Console.WriteLine(StringsViewMenu.FrameMinusTwo);
                Console.BackgroundColor = ConsoleColor.Black;
                foreach (string s in arraySplittedString)
                {
                    Console.WriteLine(s);
                }
            }
            Console.WriteLine();
            Console.WriteLine(StringsViewMenu.OnlyEquals);
            Console.WriteLine();
        }
    }
}
