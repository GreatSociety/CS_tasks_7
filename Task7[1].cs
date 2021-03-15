using System;

namespace Tasks7
{
    class Program
    {
        static void Main()
        {

            Vector2 first = new Vector2(1, 1);
            Vector2 second = new Vector2(2, 2);
            Vector2 third = first + second;                 // 3, 3
            Console.WriteLine($"{third.x}, {third.y}");     
            Vector2 fourth = third - first;                 // 2, 2 
            Console.WriteLine($"{fourth.x}, {fourth.y}");   
            first++;                                        // 2, 2
            Console.WriteLine($"{first.x}, {first.y}");
            first--;                                        // 1, 1
            Console.WriteLine($"{first.x}, {first.y}");

            Console.WriteLine(first == second);             // 1, 1 == 2, 2 - false
            Console.WriteLine(fourth == second);            // 2, 2 == 2, 2 - true
            Console.WriteLine(first != second);             // 1, 1 != 2, 2 - true  
            Console.WriteLine(fourth != second);            // 2, 2 != 2, 2 - false

            Console.WriteLine(first.GetHashCode());         // 2
            Console.WriteLine(fourth.Equals(second));       // True
            Console.WriteLine(second.ToString());           // Vector: x , y

            Console.ReadKey();
        }
    }

    /*
		♦ Создать класс или структуру Vector2
		
		• Объявить поля/свойства для хранения координат X, Y
		• Создать конструктор с параметрами
		• Перегрузить операторы +, -, ++, --, ==, !=
		• Переопределить методы GetHashCode, Equals, ToString
		• Создать 2 открытых статических поля, характеризующих нулевой (0, 0) и единичный (0, 1) векторы
    */

    struct Vector2
    {

        public static Vector2 zeroVector = new Vector2(0, 0);
        public static Vector2 unitVector = new Vector2(0, 1);

        public int x;
        public int y;

        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static Vector2 operator +(Vector2 vectorX, Vector2 vectorY)
        {
            return new Vector2(vectorX.x + vectorY.x, vectorX.y + vectorY.y);
        }

        public static Vector2 operator -(Vector2 vectorX, Vector2 vectorY)
        {
            return new Vector2(vectorX.x - vectorY.x, vectorX.y - vectorY.y);
        }

        public static Vector2 operator ++(Vector2 vectorX)
        {
            vectorX.y++;
            vectorX.x++;

            return vectorX;
        }

        public static Vector2 operator --(Vector2 vectorX)
        {
            vectorX.y--;
            vectorX.x--;

            return vectorX;
        }

        public static bool operator ==(Vector2 vectorX, Vector2 vectorY)
        {
            return vectorX.x == vectorY.y && vectorX.y == vectorY.y;
        }
        public static bool operator !=(Vector2 vectorX, Vector2 vectorY)
        {
            return vectorX.x != vectorY.y && vectorX.y != vectorY.y;
        }

        public override int GetHashCode()
        {
            return this.x.GetHashCode() + this.y.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if(obj is Vector2 objectType)
            {
                return this.x == objectType.x && this.y == objectType.y;
            }

            return base.Equals(obj);
        }

        public override string ToString()
        {
            return "Vector: " + this.x.ToString() +", "+ this.y.ToString();
        }

    }
}
