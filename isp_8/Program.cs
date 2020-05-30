using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isp_8
{
    delegate void Info(string lastname, string firstname);
    delegate void End(string lastname);
    public abstract class Furniture
        {
            private int date; //дата производства
            private string type; //вид мебели
            private string material; //материал

            public Furniture(string type, int date, string material)//конструктор с 3 аргументами
            {
                this.type = type;
                this.date = date;
                this.material = material;
            }

            public Furniture(int date, string material)//конструктор с двумя аргументами
            {
                this.date = date;
                type = "Шкаф";
                this.material = material;
            }

            public Furniture(int date) //конструктор с одним аргументом
            {
                this.date = date;
                type = "Шкаф";
                material = "Фанера";
            }

            public string Type
            {
                get
                {
                    return type;
                }
                set
                {
                    type = value;
                }
            }

            public int Date
            {
                get
                {
                    return date;
                }
                set
                {
                    date = value;
                }
            }

            public string Material
            {
                get
                {
                    return material;
                }
                set
                {
                    material = value;
                }
            }

            public virtual void ShowInfo()
            {
                Console.WriteLine("Класс: Мебель");
                Console.WriteLine("Вид мебели: {0}", type);
                Console.WriteLine("Дата производства: {0}", Convert.ToString(date));
                Console.WriteLine("Материал: {0}", material);
            }
        }

        public class Shkaf : Furniture
        {
            private string color; //цвет шкафа
            private static int count = 0; //счетчик

            public Shkaf(int date, string material, string color) : base(date, material)//конструктор
            {
                this.color = color;
                count++;
            }

            public Shkaf(int date, string color) : base(date)//конструктор
            {
                this.color = color;
                count++;
            }

            public string Color
            {
                get
                {
                    return color;
                }
                set
                {
                    color = value;
                }
            }

            public override void ShowInfo()
            {
                base.ShowInfo();
                Console.WriteLine("Класс: Шкаф");
                Console.WriteLine("Цвет шкафа: {0}", color);

            }

            public static void HowManyShkafs()
            {
                Console.WriteLine("Количество шкафов: {0}", count);
            }

        }

        public class ForPosuda : Shkaf, IComparable<ForPosuda>
        {
            private string model; //модель
            public ForPosuda(int date, string material, string color, string model) : base(date, material, color) //конструктор
            {
                this.model = model;
            }

            public ForPosuda(int date, string color, string model) : base(date, color) //конструктор
            {
                this.model = model;
            }

            public string Model
            {
                get
                {
                    return model;
                }
                set
                {
                    model = value;
                }
            }

            public override void ShowInfo()
            {
                base.ShowInfo();
                Console.WriteLine("Класс: для посуды");
                Console.WriteLine("Модель для посуды: {0}", model);
            }

            public int CompareTo(ForPosuda o)
            {
                ForPosuda e = o as ForPosuda;

                if (e != null)
                {
                    return this.Date.CompareTo(o.Date);
                }
                else
                {
                    throw new Exception("Параметр должен быть типа ForPosuda");
                }
            }
        }

        public class ForObuv : Shkaf
        {
            private string model; //модель
            public ForObuv(int date, string material, string color, string model) : base(date, material, color)//конструктор
            {
                this.model = model;
            }

            public ForObuv(int date, string color, string model) : base(date, color)//конструктор
            {
                this.model = model;
            }

            public string Model
            {
                get
                {
                    return model;
                }
                set
                {
                    model = value;
                }
            }

            public new void ShowInfo()
            {
                base.ShowInfo();
                Console.WriteLine("Класс: для обуви");
                Console.WriteLine("модель для обуви: {0}", model);
            }
        }


        public class ForOdejda : Shkaf
        {
            enum size
            {
                small,
                middle,
                big
            }
            ForOdejda[] data;
            private int Size = 0;
            private string model; //модель
            public ForOdejda this[int index]
            {
                get
                {
                    return data[index];
                }
                set
                {
                    data[index] = value;
                }
            }

            public ForOdejda(int date, string material, string color, string model, int s) : base(date, material, color)//конструктор
            {
                this.Size = s;
                this.model = model;
            }

            public ForOdejda(int date, string color, string model) : base(date, color)//конструктор
            {
                this.model = model;
            }

            public string Model
            {
                get
                {
                    return model;
                }
                set
                {
                    model = value;
                }
            }

            public override void ShowInfo()
            {
                base.ShowInfo();
                Console.WriteLine("Класс: для одежды");
                Console.WriteLine("Модель для одежды: {0}", model);
                switch (Size)
                {
                    case 0:
                        Console.WriteLine(" габариты: {0}", size.small);
                        break;
                    case 1:
                        Console.WriteLine(" габариты: {0}", size.middle);
                        break;
                    case 2:
                        Console.WriteLine(" габариты: {0}", size.big);
                        break;
                }
            }
        }
        interface ITable
        {
            string Name { get; }
            string Material { get; }
        }
        struct Table : ITable
        {
            public string Name { get; }
            public string Material { get; }
            string legs;

            public string Legs
            {
                get
                {
                    return legs;
                }
                set
                {
                    legs = value;
                }
            }

            public void GetInfoAboutTable()
            {
                Console.Write($"Информация о столе:\n1.название стола: {Name}\n2.название материала: {Material}" +
                $"\n3.кол-во ножек стола: {legs}\n");
            }
        }

        class Program
        {
        static void Hello(string lastName, string firstName)
        {
            Console.WriteLine($"Привет, {lastName} {firstName}");
        }

        static void Bay(string lastName, string firstName)
        {
            Console.WriteLine($"Пока, {lastName} {firstName}");
        }

        static void Main(string[] args)
            {
                Furniture furniture = new Shkaf(2019, "Дуб", "Сереневый");
                furniture.ShowInfo();
                Table t = new Table();
                t.Legs = "4";
                t.GetInfoAboutTable();
                Shkaf.HowManyShkafs();
                Console.WriteLine();
                Shkaf shkaf = new Shkaf(2019, "Сереневый");
                shkaf.Color = "Бордовый";
                shkaf.ShowInfo();
                Console.WriteLine();
                ForPosuda ForPosuda = new ForPosuda(2017, "Черный", "с стеклянными матовыми дверцами");
                ForPosuda.ShowInfo();
                Console.WriteLine();
                Shkaf.HowManyShkafs();
                Console.WriteLine();
                ForObuv ForObuv = new ForObuv(2015, "Бежевый", "с стеклянными глянцевыми дверцами");
                ForObuv.ShowInfo();
                Console.WriteLine();
                ForOdejda ForOdejda = new ForOdejda(1950, "Мореный дуб", "Черный", "с позолоченными ручками", 2);
                ForOdejda.ShowInfo();
                Console.WriteLine();
                Shkaf.HowManyShkafs();
                Info welcome = Hello;
            welcome += Bay;
            welcome(specialist.GetLastName(), specialist.GetFirstName());

            End handler = delegate (string str)
            {
                Console.WriteLine("Пока " + str);
            };

            handler(specialist.GetLastName());
            Console.ReadLine();
            }
        }
}
