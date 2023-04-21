namespace Project_5._6._1_HW_03_SF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintInfo(EnterUser());
        }

        static (string Name, string LastName, int Age, string[] Pets, string[] Favcolors) EnterUser()
        {
            (string Name, string LastName, int Age, string[] Pets, string[] Favcolors) User;

            Console.WriteLine("Введите ваше имя:");

            string s1;
            while (!TryString(Console.ReadLine(), out s1))
                Console.WriteLine("Повторите ввод:");

            User.Name = s1;

            Console.WriteLine("Введите вашу фамилию:");

            string s2;
            while (!TryString(Console.ReadLine(), out s2))
                Console.WriteLine("Повторите ввод:");

            User.LastName = s2;

            string age;
            int intage;

            do
            {
                Console.WriteLine("Введите возраст цифрами");
                age = Console.ReadLine();
            } while (CheckNum(age, out intage));

            User.Age = intage;

            User.Pets = null;
            Console.WriteLine("Есть ли у вас питомцы?");

            string hasPets = Console.ReadLine();

            string petsNumber;
            int intPetsNumber;

            if (hasPets == "да")
            {
                do
                {
                    Console.WriteLine("Сколько питомцев у вас есть?");
                    petsNumber = Console.ReadLine();

                } while (CheckNum(petsNumber, out intPetsNumber));
                User.Pets = CreateArrayPets(intPetsNumber);
            }

            User.Favcolors = null;

            string colorsNumber;
            int intcolorsNumber;

            do
            {
                Console.WriteLine("Сколько у вас любимых цветов?");

                colorsNumber = Console.ReadLine();
            } while (CheckNum(colorsNumber, out intcolorsNumber));

            User.Favcolors = CreateArrayFavcolors(intcolorsNumber);

            return User;
        }

        static bool TryString(string s, out string r)
        {
            r = s;
            for (int i = 0; i <= 9; ++i)
                if (s.Contains(i.ToString()))
                    return false;
            return true;
        }

        static bool CheckNum(string number, out int correctnum)
        {
            if (int.TryParse(number, out int intnum))
            {
                if (intnum > 0)
                {
                    correctnum = intnum;
                    return false;
                }
            }

            {
                correctnum = 0;
                return true;
            }
        }

        static string[] CreateArrayPets(int number)
        {
            string[] arr = new string[number];

            for (int i = 0; i < number; i++)
            {
                Console.WriteLine("Введите кличку питомца номер {0}", i + 1);
                arr[i] = Console.ReadLine();
            }

            return arr;

        }


        static string[] CreateArrayFavcolors(int number)
        {
            string[] arr = new string[number];

            for (int i = 0; i < number; i++)
            {
                Console.WriteLine("Введите любимый цвет номер {0}", i + 1);
                arr[i] = Console.ReadLine();
            }

            return arr;

        }

        static void PrintInfo((string Name, string LastName, int Age, string[] Pets, string[] Favcolors) User)
        {

            Console.WriteLine("Имя: {0}", User.Name);
            Console.WriteLine("Фамилия: {0}", User.LastName);
            Console.WriteLine("Возраст: {0}", User.Age);

            if (User.Pets == null)
            {
                Console.Write("Питомцы: нет домашних питомцев");
            }
            else
            {
                Console.Write("Питомцы:");
                foreach (string pet in User.Pets)
                {
                    Console.Write(" " + pet + " ");
                }
            }
            Console.WriteLine(" ");
            Console.Write("Любимые цвета:");
            foreach (string color in User.Favcolors)
            {
                Console.Write(" " + color + " ");
            }

        }
    }
}