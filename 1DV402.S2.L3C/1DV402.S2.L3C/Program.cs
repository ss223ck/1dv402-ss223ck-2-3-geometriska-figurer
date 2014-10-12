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
            // skapa objekt och retunera referensen, 
            // AsText ska översätta ShapeTypeEnum till text så kalla på den
            //CenterAligne sätter texten i mitten för Utskriften
        }
        static void Main(string[] args)
        {
            ViewMenu();
            // väljer användare att skapa objekt ska CreateShape kallas
            //skicka med vilken form av objekt som ska göras för att sedan skickas med viewShapeDetail
            ViewShapeDetail(CreateShape());
        }
        private static Shape2D[] Randomize2DShapes()
        {
            Random randomInstance = new Random();
            int numberOfFiguers = randomInstance.Next(5, 21);
            Shape2D[] returnArray = new Shape2D[numberOfFiguers];

            for (int i = 0; i < numberOfFiguers; i++)
            {
                int randomShape = randomInstance.Next(0, 4);
                double length = (randomInstance.NextDouble() * (100 - 5) + 5);
                double width = (randomInstance.NextDouble() * (100 - 5) + 5);
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
                double height = (randomInstance.NextDouble() * (100 - 5) + 5);
                double length = (randomInstance.NextDouble() * (100 - 5) + 5);
                double width = (randomInstance.NextDouble() * (100 - 5) + 5);
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
                        Console.WriteLine(StringsFileR.ErrorMessageDimensions_Prompt);
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
                            Console.WriteLine(StringsFileR.ErrorMessageDimensions_Prompt);
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
            Console.WriteLine(StringsViewMenu.MiddleFramOfEquals);
            Console.WriteLine(StringsViewMenu.OnlyEquals);
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

        }
        private static void ViewShapeDetail(Shape shape)
        {

        }
        private static void ViewShapes(Shape[] shapes)
        {

        }
    }
}
