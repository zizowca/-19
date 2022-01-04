using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_19
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Computer> ListComp = new List<Computer>()
            {
                new Computer () {ID=1, Name="Home", CPU = "Intel Core i5", Ghz=2.5,RAM = 16, HD=420, GC =4, Cost=60000,Num=36},
                new Computer () {ID=2, Name="Work", CPU = "Intel Core i5", Ghz=2.9,RAM = 16, HD=512, GC =8, Cost=75000,Num=18},
                new Computer () {ID=3, Name="Home Light", CPU = "Intel Pentium", Ghz=2.2,RAM = 8, HD=256, GC =4, Cost=30000,Num=40},
                new Computer () {ID=4, Name="Play", CPU = "Intel Core i7", Ghz=4.1,RAM = 32, HD=512, GC =8, Cost=130000,Num=8},
                new Computer () {ID=5, Name="Work light", CPU = "Intel Core i5", Ghz=2.5,RAM = 8, HD=256, GC =4, Cost=45000,Num=24},
                new Computer () {ID=6, Name="Play light", CPU = "AMD Ryzen", Ghz=3.4,RAM = 32, HD=512, GC =8, Cost=85000,Num=14},
                new Computer () {ID=7, Name="Home 2.0", CPU = "AMD Ryzen", Ghz=3.4,RAM = 16, HD=1000, GC =12, Cost=140000,Num=12},
                new Computer () {ID=8, Name="Work 2.0", CPU = "Intel Core i7", Ghz=4.1,RAM = 32, HD=1000, GC =12, Cost=90000,Num=18},
                new Computer () {ID=9, Name="Play 2.0", CPU = "Intel Core i9", Ghz=5.2,RAM = 64, HD=4000, GC =24, Cost=300000,Num=3},
                new Computer () {ID=10, Name="Work HD", CPU = "Intel Core i7", Ghz=4.1,RAM = 64, HD=1000, GC =12, Cost=200000,Num=6}
            };
            #region
            //Я подумала, что удобнее в запросе вводить код процессора, а не сам процессор, хотела код и название связать через словарь,
            //но не поняла, как передать словарю, что вводимый пользователем код - это ключ, и как значение этого ключа передать в метод Where
            //Console.WriteLine("Введите код интересующего вас процессора:\n1 - Intel Pentium, 2 - Intel Core i5, 3 - Intel Core i7, 4 -Intel core i9, 5 - AMD Ryzen");
            //int codCPU = Convert.ToInt32(Console.ReadLine());
            //Dictionary<int, string> cpu = new Dictionary<int, string>
            //{
            //    {1, "Intel Pentium" },
            //    {2, "Intel Core i5" },
            //    {3, "Intel Core i7" },
            //    {4, "Intel core i9" },
            //    {5, "AMD Ryzen" },
            //};
            #endregion

            //Выбор компьютера по процессору
            Console.WriteLine("Выберите интересующий вас процессора (напишите его название) :\nIntel Pentium,  Intel Core i5,  Intel Core i7,  Intel core i9,  AMD Ryzen");
            string nameCPU = Console.ReadLine();
            Console.WriteLine();
            List<Computer> compCPU = ListComp
                .Where(c => c.CPU == nameCPU)
                .ToList();
            foreach (Computer c in compCPU)
            {
                Console.WriteLine("ID: {0},\nНаименование: {1},\nПроцессор: {2},\nЧастота работы процессора: {3} Ггц,\nОбъем ОЗУ: {4} Гб,\nОбъем HDD: {5} Гб," +
                    "\nОбъем памяти видеокарты: {6} Гб,\nстоимость ПК: {7:N2} руб.",
                    c.ID, c.Name, c.CPU, c.Ghz, c.RAM, c.HD, c.GC, c.Cost);
                Console.WriteLine();
            }
            Console.ReadKey();

            //Выбор компьютера по ОЗУ
            Console.Write("Введите минимальный требуемый объем памяти:\t");
            int ram = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            List<Computer> compRam = ListComp
               .Where(c => c.RAM >= ram)
               .ToList();
            foreach (Computer c in compRam)
            {
                Console.WriteLine("ID: {0},\nНаименование: {1},\nПроцессор: {2},\nЧастота работы процессора: {3} Ггц,\nОбъем ОЗУ: {4} Гб,\nОбъем HDD: {5} Гб," +
                    "\nОбъем памяти видеокарты: {6} Гб,\nстоимость ПК: {7:N2} руб.",
                    c.ID, c.Name, c.CPU, c.Ghz, c.RAM, c.HD, c.GC, c.Cost);
                Console.WriteLine();
            }
            Console.ReadKey();

            //Сортировка компьютеров по стоимости
            Console.WriteLine("СОРТИРОВКА ВСЕХ КОМПЮТЕРОВ ПО СТОИМОСТИ");
            List<Computer> compCount = ListComp
                .OrderBy(c => c.Cost)
                .ToList();
            foreach (Computer c in compCount)
            {
                Console.WriteLine("ID: {0},  Наименование: {1},  стоимость ПК: {2:N2} руб.,  Процессор: {3},  Частота работы процессора: {4} Ггц,  Объем ОЗУ: {5} Гб,  Объем HDD: {6} Гб,  Объем памяти видеокарты: {7} Гб,  количество на складе: {8} шт.",
                    c.ID, c.Name, c.Cost, c.CPU, c.Ghz, c.RAM, c.HD, c.GC, c.Num);
                Console.WriteLine();
            }
            Console.ReadKey();


            //Группировка по типу процессора
            Console.WriteLine("ГРУППИРОВКА ВСЕХ КОМПЮТЕРОВ ПО ТИПУ ПРОЦЕССОРА");
            var compCpu = ListComp
                .GroupBy(c => c.CPU)
                .ToList();
            foreach (var c in compCpu)
            {
                Console.WriteLine(c.Key);
                foreach (var p in c)
                    Console.WriteLine("Наименование: {0},  стоимость ПК: {1:N2} руб.,  Процессор: {2},  Частота работы процессора: {3} Ггц",
                   p.Name, p.Cost, p.CPU, p.Ghz);
                Console.WriteLine();
            }
            Console.ReadKey();

            //Поиск самого дорого компьютера
            Console.WriteLine("САМЫЙ ДОРОГОГОЙ КОМПЮТЕР");
            var compMax = compCount
                .Last();
            Console.WriteLine("Наименование: {0},  стоимость ПК: {1:N2} руб.,  Процессор: {2},  Частота работы процессора: {3} Ггц,  Объем ОЗУ: {4} Гб,  Объем HDD: {5} Гб,  Объем памяти видеокарты: {6} Гб.",
                    compMax.Name, compMax.Cost, compMax.CPU, compMax.Ghz, compMax.RAM, compMax.HD, compMax.GC);
            Console.WriteLine(); 
            Console.ReadKey();

            //Поиск самого бюджетного компьютера
            Console.WriteLine("САМЫЙ БЮДЖЕТНЫЙ КОМПЮТЕР");
            var compMin = compCount
                .First();
            Console.WriteLine("Наименование: {0},  стоимость ПК: {1:N2} руб.,  Процессор: {2},  Частота работы процессора: {3} Ггц,  Объем ОЗУ: {4} Гб,  Объем HDD: {5} Гб,  Объем памяти видеокарты: {6} Гб.",
                     compMin.Name, compMin.Cost, compMin.CPU, compMin.Ghz, compMin.RAM, compMin.HD, compMin.GC);
            Console.WriteLine();
            Console.ReadKey();


            //Выбор компьютеров с остатком на складе более 30шт

            Console.WriteLine("В НАЛИЧИИ БОЛЕЕ 30 ШТ");
            List<Computer> compNum = ListComp
                .Where(c => c.Num>30)
                .ToList();
            foreach (Computer c in compNum)
            {
                Console.WriteLine("ID: {0},\nНаименование: {1},\nПроцессор: {2},\nЧастота работы процессора: {3} Ггц,\nОбъем ОЗУ: {4} Гб,\nОбъем HDD: {5} Гб," +
                    "\nОбъем памяти видеокарты: {6} Гб,\nстоимость ПК: {7:N2} руб.,  количество на складе: {8} шт.",
                    c.ID, c.Name, c.CPU, c.Ghz, c.RAM, c.HD, c.GC, c.Cost, c.Num);
                Console.WriteLine();
            }
            Console.ReadKey();


        }
    }
}
