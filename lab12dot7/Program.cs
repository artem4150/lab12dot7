using _10lablib;
using laba12;
using System.ComponentModel.Design;
using лаба10;
using lab12dot7;
using System.Xml.Linq;
namespace laba12
{
    
        internal class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<MusicalInstrument> instrumentsList = new DoublyLinkedList<MusicalInstrument>();
            Random rand = new Random();
            while (true)
            {
                int pointsCaseMenu = 8;

                Console.WriteLine("\nМеню работы с двунаправленным списком");
                Console.WriteLine("1 - Формирование двунаправленного списка");
                Console.WriteLine("2 - Добавление элемента в список");
                Console.WriteLine("3 - Удаление элемента из списка");
                Console.WriteLine("4 - Печать списка");
                Console.WriteLine("5 - Добавление в список элементов с номерами 1, 3, 5 и т.д.");
                Console.WriteLine("6 - Удаление списка из памяти");
                Console.WriteLine("7 - Очистка истории");
                Console.WriteLine("8 - Клонирование списка");
                Console.WriteLine("0 - Выход из меню");

                int choiceCaseMenu = InputInt(0, pointsCaseMenu);

                if (choiceCaseMenu == 0)
                {
                    Console.WriteLine("\n0 - Выход из меню");
                    break;
                }

                switch (choiceCaseMenu)
                {
                    case 1:
                        {
                            Console.WriteLine("\n1 - Формирование двунаправленного списка");
                            Console.WriteLine("Введите количество объектов для формирования списка:");
                            int number = InputInt(1, 100);
                            
                            Console.WriteLine("Список:");
                            for (int i = 0; i < number; i++)
                            {
                                int r = rand.Next(1, 4);
                                switch (r)
                                {
                                    case 1:
                                        {
                                            ElectricGuitar e = new ElectricGuitar();
                                            e.RandomInit();
                                            instrumentsList.AddLast(e);
                                        }
                                        break;
                                    case 2:
                                        {
                                            Piano p = new Piano();
                                            p.RandomInit();
                                            instrumentsList.AddLast(p);
                                        }
                                        break;
                                    case 3:
                                        {
                                            Guitar g = new Guitar();
                                            g.RandomInit();
                                            instrumentsList.AddLast(g);
                                        }
                                        break;
                                    case 4:
                                        {
                                            MusicalInstrument m = new MusicalInstrument();
                                            m.RandomInit();
                                            instrumentsList.AddLast(m);
                                        }
                                        break;
                                }
                            }
                            Console.WriteLine("Формирование двунаправленного списка завершено");
                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("\n- Добавление элемента в список");
                            Console.WriteLine("1 - Электрогитара");
                            Console.WriteLine("2 - Пианино");
                            Console.WriteLine("3 - Гитара");
                            Console.WriteLine("4 - Музыкальный инструмент");

                            int z  = InputInt(0, 4);
                            switch (z)
                            {
                                case 1:
                                    {
                                        ElectricGuitar e = new ElectricGuitar();
                                        e.Init();
                                        instrumentsList.AddLast(e);
                                    }
                                    break;
                                case 2:
                                    {
                                        Piano p = new Piano();
                                        p.Init();
                                        instrumentsList.AddLast(p);
                                    }
                                    break;
                                case 3:
                                    {
                                        Guitar g = new Guitar();
                                        g.Init();
                                        instrumentsList.AddLast(g);
                                    }
                                    break;
                                case 4:
                                    {
                                        MusicalInstrument m = new MusicalInstrument();
                                        m.Init();
                                        instrumentsList.AddLast(m);
                                    }
                                    break;
                            }

                            
                            Console.WriteLine("Добавление элемента в список завершено");
                        }
                        break;
                    case 3:
                        {
                            

                            
                            Console.WriteLine("\n3 - Удаление элементов из списка");

                            // Запрашиваем у пользователя имя элемента для удаления
                            Console.WriteLine("Введите имя элемента для удаления:");
                            string nameToRemove = Console.ReadLine();

                            // Проверяем, есть ли элемент с заданным именем в списке и удаляем его со всеми последующими элементами
                            bool removed = instrumentsList.RemoveFrom(nameToRemove);

                            // Если удаление прошло успешно, сообщаем об этом пользователю
                            if (removed)
                            {
                                Console.WriteLine("Элементы, начиная с элемента с именем '{0}', были успешно удалены из списка.", nameToRemove);
                            }
                            else
                            {
                                Console.WriteLine("Не удалось удалить элементы, начиная с элемента с именем '{0}'.", nameToRemove);
                            }
                        }
                        break;
                    case 4:
                        {
                            Console.WriteLine("\n4 - Печать списка");
                            instrumentsList.Print();
                            Console.WriteLine("Печать списка завершена");
                        }
                        break;
                    case 5:
                        {
                            Console.WriteLine("\n5 - Добавление в список элементов с номерами 1, 3, 5 и т.д.");
                            instrumentsList = DoublyLinkedList<MusicalInstrument>.AddOddObjects(instrumentsList);
                            Console.WriteLine("Добавление в список элементов с номерами 1, 3, 5 и т.д. завершено");
                        }
                        break;
                    case 6:
                        {
                            Console.WriteLine("\n6 - Удаление списка из памяти");
                            instrumentsList = null;
                            Console.WriteLine("Удаление списка из памяти завершено");
                        }
                        break;
                    case 7:
                        {
                            Console.Clear();
                            Console.WriteLine("История была очищена");
                        }
                        break;
                    case 8:
                        {
                            Console.WriteLine("\nВывод клонированного списка:");
                            DoublyLinkedList<MusicalInstrument> clonedList = instrumentsList.DeepClone();
                            clonedList.Print();
                            Console.WriteLine("\nВывод оригинального списка списка:");
                            instrumentsList.Print();
                            break;
                        }
                }
            }

        }
        
        private static int InputInt(int min, int max)
        {
            int number;
            bool inputCheck;
            do
            {
                Console.Write("Ввод: ");
                inputCheck = int.TryParse(Console.ReadLine(), out number) && number >= min && number <= max;
                if (!inputCheck) Console.WriteLine("Ошибка ввода! Введите целое число в пределах от {0} до {1} (включительно)", min, max);
            } while (!inputCheck);
            return number;
        }
        

        static void tusk1()
        {
            // Создание списка и добавление объектов
            DoublyLinkedList<MusicalInstrument> instrumentsList = new DoublyLinkedList<MusicalInstrument>();
            instrumentsList.AddLast(new ElectricGuitar("батарейки", "Fender Stratocaster", 6, 1));
            instrumentsList.AddLast(new Piano(88, "Yamaha Grand Piano", "октавная", 2));
            // Добавьте сюда другие объекты из иерархии классов

            // Распечатка списка
            Console.WriteLine("Список музыкальных инструментов:");
            instrumentsList.Print();

            // Добавление элементов с номерами 1, 3, 5 и т.д.
            Random rnd = new Random();
            for (int i = 1; i <= instrumentsList.Count; i += 2)
            {
                // Создание объекта для добавления в список
                MusicalInstrument newItem;
                if (i % 2 == 0)
                {
                    newItem = new ElectricGuitar("USB", $"Custom Guitar {i}", rnd.Next(6, 12), i + 1);
                }
                else
                {
                    newItem = new Piano(76, $"Digital Piano {i}", "шкальная", i + 1);
                }
                instrumentsList.AddLast(newItem);
            }

            // Удаление из списка всех элементов, начиная с элемента с заданным именем, и до конца списка
            string startName = "Custom Guitar 3"; // Имя, с которого начинается удаление

            Node<MusicalInstrument> current = instrumentsList.FindByName(startName);
            while (current != null)
            {
                Node<MusicalInstrument> next = current.Next;
                instrumentsList.Remove(current);
                current = next;
            }

            // Распечатка списка после удаления
            Console.WriteLine("\nСписок музыкальных инструментов после обработки:");
            instrumentsList.Print();

            // Глубокое клонирование списка
            DoublyLinkedList<MusicalInstrument> clonedList = new DoublyLinkedList<MusicalInstrument>();
            Node<MusicalInstrument> currentCloned = instrumentsList.Head;
            while (currentCloned != null)
            {
                MusicalInstrument clonedItem = (MusicalInstrument)currentCloned.Data.Clone();
                clonedList.AddLast(clonedItem);
                currentCloned = currentCloned.Next;
            }
            Console.WriteLine("\nВывод клонированного списка:");
            clonedList.Print();

            // Очистка памяти, освобождение ресурсов
            instrumentsList.Clear();
            Console.WriteLine("\nВывод удаленного списка:");
            instrumentsList.Print();
        }
    }
}
