using System;

namespace PR_15
{
    class Program
    {
        public struct Travel //объявление структуры
        {
            public char[] StartPoint; //начальный пункт маршрута
            public char[] FinalPoint; //конечный пункт маршрута
            public decimal Price;     //стоимость
            public double Time;       //продолжительность

            public Travel(uint num) //конструктор(инициализация)
            {
                this.StartPoint = new char[30];
                this.FinalPoint = new char[30];
                this.Price = 0;
                this.Time = 0;
            }
        }

        static void InfoAboutObjStuct(uint countTravel, Travel[] travels) //заполнение
        {
            try
            {
                
                for (int i = 0; i < countTravel; i++) //заполнение массива структур
                {
                    travels[i] = new Travel(0); //создание нового путешествия
                    Console.Write("\nНачальный пункт маршрута: ");
                    travels[i].StartPoint = Console.ReadLine().ToCharArray();
                    Console.Write("Конечный пункт маршрута: ");
                    travels[i].FinalPoint = Console.ReadLine().ToCharArray();
                    Console.Write("Продолжительность(в часах): ");
                    travels[i].Time = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Стоимость: ");
                    travels[i].Price = Convert.ToDecimal(Console.ReadLine());
                }
            }
            catch(FormatException fe)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка: " + fe.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка: " + e.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        static void FindObjStruct(char[] new_point, uint countTravel, Travel[] travels)
        {
            bool flag = false;
            for (int i = 0; i < countTravel; i++)
            {
                if ((String.Compare(new string(travels[i].StartPoint), new string(new_point)) == 0) || (String.Compare(new string(new_point), new string(travels[i].FinalPoint)) == 0))
                {
                    Console.WriteLine($"Путешествие из {new string(travels[i].StartPoint)} в {new string(travels[i].FinalPoint)} продолжительностью {travels[i].Time} часа(часов) и стоимостью {travels[i].Price}");
                    flag = true;
                }
                if (!flag) Console.Write("\nПутешествие по запросу не найдено.");
            }
        }

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Практическая работа №15");
                Console.Write("Укажите количество путешествий: ");
                uint countTravel = Convert.ToUInt32(Console.ReadLine());

                Travel[] travels = new Travel[countTravel];

                InfoAboutObjStuct(countTravel, travels);

                char[] new_point = new char[30];
                Console.Write("\n\nПоиск по названию пункта назначения: ");
                new_point = Console.ReadLine().ToCharArray();

                FindObjStruct(new_point, countTravel, travels);

            }
            catch (FormatException fe)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка: " + fe.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка: " + e.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
