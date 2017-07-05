/*
Welcome all
this is sample code for practice c# with teamtreehouse.com
if you find any bug or mistake please contact me cfndiaye@gmail.com
Thank you
 */

using System;
namespace treehouse
{
    class Polygone
    {
         private int _numberSide{get; set;}//ok
         private int _numberVertice{get; set;}//ok
         private int _numberLineSymmetric{get; set;}
         private int _numberParalelleSide{get; set;}//ok


         public int numberSide
         {
             get {
                 return _numberSide;
             }
             set {
                 _numberSide = value;
             }
         }

         public int numberVertice
         {
             get {
                 return _numberVertice;
             }
             set {
                 _numberVertice = value;
             }
         }

         public int numberParalelleSide
         {
             get {
                 return _numberParalelleSide;
             }
             set {
                 _numberParalelleSide = value;
             }
         }

          public int numberLineSymmetric
         {
             get {
                 return _numberLineSymmetric;
             }
             set {
                 _numberLineSymmetric = value;
             }
         }



        public virtual double Perimeter() => 0.0;

        public virtual double SumAngle() => 180 * (numberSide-2);

        public virtual double LonguestDimension(double l) => l;

        public virtual double Aera() =>  0.0;

        public virtual double Volume() => 0.0;

    }
    class Square : Polygone
    {
        private double _lengthSide;

        public Square(double lengthSide)
        {
            numberSide = 4;
            numberVertice = 4;
            numberParalelleSide =4;
            numberLineSymmetric = 2;
            _lengthSide = lengthSide;
            //LonguestDimension(lengthSide);

        }

        public override double Perimeter() => _lengthSide * 4;

        public override double SumAngle() => 180 * (numberSide-2);

        public override double LonguestDimension(double L) => L;

        public override double Aera() =>  _lengthSide * _lengthSide;

    }

    class Rectangle : Polygone
    {
        private double _smallLength;
        private double _bigLength;

        public Rectangle(double smallLength, double longuestDimension)
        {
            numberSide = 4;
            numberParalelleSide = 4;
            numberVertice = 4;
            numberLineSymmetric = 2;
            _smallLength = smallLength;
            _bigLength = longuestDimension;
            //LonguestDimension(longuestDimension);
        }

        public override double Perimeter() => (_smallLength +  _bigLength) * 2;

        public override double SumAngle() => 180 * (numberSide-2);

        public override double LonguestDimension(double L) => L;

        public override double Aera() =>  _smallLength * _bigLength;

    }

    class Triangle : Polygone
    {
        private double _lengthSideA;
        private double _lengthSideB;
        private double _lengthSideC;

        private double[] _dimension = new double[3];

        public Triangle(double lengthSide1, double lengthSide2, double lengthSide3)
        {
            _lengthSideA = lengthSide1;
            _lengthSideB = lengthSide2;
            _lengthSideC = lengthSide3;
            numberSide = 3;
            numberVertice = 3;
            numberParalelleSide =0;
            numberLineSymmetric = 0;
            _dimension[0]= _lengthSideA;
            _dimension[1]= _lengthSideB;
            _dimension[2]= _lengthSideC;

        }


        //
        public double getMax(Array list)
        {
                double max = 0.0;
                for(int i=0; i<list.Length; i++)
                {
                    if((double)list.GetValue(i) > max){
                        max = (double)list.GetValue(i);
                    }
                }
            return max;
        }
        //
        public string TriangleType()
        {
            //if two side are equals => triangle equilateral
            //if three side are equals => isosceles triangle
            //other irregular triangle

            //PITHAGORE
            //HYPOTHESE 1
            double c = Math.Sqrt((_lengthSideA * _lengthSideA) + (_lengthSideB * _lengthSideB));
            //HYPOTHESE 2
            double a = Math.Sqrt((_lengthSideB * _lengthSideB) + (_lengthSideC * _lengthSideC));
            //HYPOTHESE 3
            double b = Math.Sqrt((_lengthSideA * _lengthSideA) + (_lengthSideC * _lengthSideC));

            if(_lengthSideA == _lengthSideB  && _lengthSideA == _lengthSideC)
            {
                return "TRIANGLE EQUILATERAL";
            }
            else
            if(_lengthSideA == _lengthSideB || _lengthSideA == _lengthSideC || _lengthSideB == _lengthSideC)
            {
                return "ISOSCELES TRIANGLE";
            }
            else
            if(a == _lengthSideA || b == _lengthSideB || c == _lengthSideC)
            {
                return "RECTANGLE TRIANGLE";
            }
            else
            {
                return "IRREGULAR TRIANGLE";
            }
        }


        public override double Perimeter() => _lengthSideA + _lengthSideB + _lengthSideC;

        public override double SumAngle() => 180 * (numberSide-2);

        public override double LonguestDimension(double l) => getMax(_dimension);

        public override double Aera() =>  0.0;

        public override string ToString()
        {
            var result = " A = " + _lengthSideA + "\n B = " + _lengthSideB + "\n C = " + _lengthSideC + "\n Type Rectangle: " + TriangleType() + "\n";
                result += " Perimeter: " + Perimeter() + "\n";
                result += " Sum of Angle: " + SumAngle() + "\n";
                result += " Longuest Dimension: " + LonguestDimension(0.0) + "\n";
                result += " Aera: " + Aera();

                return result;
        }
    }

    class Circle : Polygone
    {
      private double _diameter;

      public Circle(double diameter)
      {
        _diameter = diameter;
      }

      public override double Perimeter() => ( Math.PI +  _diameter);

      public override double SumAngle() => 0;

      public override double LonguestDimension(double D) => D;

      public override double Aera() =>  Math.PI * (_diameter * _diameter)/4;

      public override string ToString()
      {
          var result = " Diameter = " + _diameter + "\n";
              result += " Perimeter: " + Perimeter() + "\n";
              result += " Sum of Angle: " + SumAngle() + "\n";
              result += " Longuest Dimension: " + LonguestDimension(_diameter) + "\n";
              result += " Aera: " + Aera();

              return result;
      }
    }

    class GeometryCalculator
    {
        public static void Main()
        {
            while (true)
            {
                Console.WriteLine("Welcole to GeometriyCalculator");
                Console.WriteLine("Type \"C\" FOR CIRCLE \"Q\" FOR SQUARE \"T\" FOR TRIANGLE" );
                var entry= Console.ReadLine();
                if(entry.ToLower() == "quit"){
                    Console.WriteLine("GoodBye!");
                    break;
                }
                if(entry.ToLower() == "c"){
                    Console.WriteLine("Circle calculation!");
                    double diameter = 0.0;
                    while (true) {
                      Console.WriteLine("Enter the diameter of Circle:");
                      var d = Console.ReadLine();
                      try{
                        diameter = double.Parse(d);
                        break;

                      }catch{
                        Console.WriteLine("Invalide Input the diameter must be numeric");
                        continue;
                      }
                    }
                    Circle circle = new Circle(diameter);
                    Console.WriteLine(circle.ToString());
                    Console.WriteLine("Job Done!"); //calculation done
                    continue;
                }
                if(entry.ToLower() == "q"){
                    Console.WriteLine("Square calculation!");
                    continue;
                }
                if(entry.ToLower() == "t"){
                    Console.WriteLine("Triangle calculation!");
                    Console.WriteLine("You Must enter three dimension!");
                    double A =0.0;
                    double B =0.0;
                    double C =0.0;
                  
                    while(true)
                    {
                        Console.WriteLine("Entrer first Dimension:");
                        var a = Console.ReadLine();
                        try
                        {
                            A = double.Parse(a);
                            break;
                        }catch
                        {
                            Console.WriteLine("Input no valid please try again!");
                            continue;
                        }
                    }
                    while(true)
                    {
                        Console.WriteLine("Entrer second Dimension:");
                        var b = Console.ReadLine();
                        try
                        {
                            B = double.Parse(b);
                            break;
                        }catch
                        {
                            Console.WriteLine("Input no valid please try again!");
                            continue;
                        }
                    }
                    while(true)
                    {
                        Console.WriteLine("Entrer third Dimension:");
                        var c = Console.ReadLine();
                        try
                        {
                            C = double.Parse(c);
                            break;
                        }catch
                        {
                            Console.WriteLine("Input no valid please try again!");
                            continue;
                        }
                    }
                    //
                    Triangle myTriangle = new Triangle(A,B,C);
                    Console.WriteLine(myTriangle.ToString());
                    Console.WriteLine("Job done!");

                    continue;
                }
            }

        }
    }
}
