
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
            //MusicalInstrument[] instruments = new MusicalInstrument[10]; // Замените размер массива и инициализацию элементов в соответствии с вашими объектами
            
            int arraySize = 10; // Размер массива

            MusicalInstrument[] instrumentsArray = new MusicalInstrument[arraySize];

            

            // Заполнение массива рандомными объектами MusicalInstrument
            for (int i = 0; i < arraySize; i++)
            {
                switch (rand.Next(3)) // Выбор случайного инструмента
                {
                    case 0:
                        instrumentsArray[i] = new Guitar();
                        break;
                    case 1:
                        instrumentsArray[i] = new Piano();
                        break;
                    case 2:
                        instrumentsArray[i] = new ElectricGuitar();
                        break;
                }

                // Инициализация объекта
                instrumentsArray[i].RandomInit();
            }
            BalancedBinaryTree<MusicalInstrument> tree = new BalancedBinaryTree<MusicalInstrument>(instrumentsArray);

            while (true)
            {
                int pointsMainMenu = 4;

                Console.WriteLine("\nМеню приложения:");

                Console.WriteLine("1 - Меню работы с двунаправленным списком");
                Console.WriteLine("2 - Меню работы с идеально сбалансированным деревом");
                Console.WriteLine("3 - ");
                Console.WriteLine("0 - Выйти из приложения");

                int choiceMainMenu = InputInt(0, pointsMainMenu);

                if (choiceMainMenu == 0)
                {
                    Console.WriteLine("\n0 - Выход из приложения");
                    break;
                }

                switch (choiceMainMenu)
                {
                    case 1:
                        BiCaseMenu(ref instrumentsList);
                        break;
                    case 2:
                        TreeCaseMenu(ref tree);
                        break;
                    case 3:

                        break;
                    case 4:

                        break;



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
        private static void TreeCaseMenu(ref BalancedBinaryTree<MusicalInstrument> tree)
        {
            while (true)
            {
                int pointsCaseMenu = 7;

                Console.WriteLine("\nМеню работы с идеально сбалансированным деревом:");
                Console.WriteLine("1 - Формирование дерева");
                Console.WriteLine("2 - Добавление элемента в дерево");
                Console.WriteLine("3 - Печать дерева");
                Console.WriteLine("4 - Поиск максимального элемента в дереве");
                Console.WriteLine("5 - Удаление дерева из памяти");
                Console.WriteLine("6 - Создание дерева поиска");
                Console.WriteLine("7 - Очистка истории");
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
                            // 1. Сформировать идеально сбалансированное бинарное дерево
                            //MusicalInstrument[] instruments = new MusicalInstrument[10]; // Замените размер массива и инициализацию элементов в соответствии с вашими объектами
                            //BalancedBinaryTree<MusicalInstrument> tree = new BalancedBinaryTree<MusicalInstrument>(instruments);

                            // 2. Распечатать полученное дерево
                            Console.WriteLine("Идеально сбалансированное бинарное дерево:");
                            tree.PrintLevelOrder();

                            // 3. Выполнить обработку дерева
                            MusicalInstrument maxInstrument = tree.FindMax();
                            Console.WriteLine("Максимальный элемент в дереве: " + maxInstrument);

                            // 4. Преобразовать в дерево поиска
                            BalancedBinaryTree<MusicalInstrument> searchTree = tree.Balance();

                            // 5. Распечатать полученное дерево поиска
                            Console.WriteLine("\nПреобразованное дерево поиска:");
                            searchTree.PrintLevelOrder();
                        }
                
                        break;
                    case 2:
                        {
                            
                        }
                        break;
                    case 3:
                        {
                            
                        }
                        break;
                    case 4:
                        {
                            
                        }
                        break;
                    case 5:
                        {
                      
                        }
                        break;
                    case 6:
                        {
                            
                        }
                        break;
                    case 7:
                        {
                            Console.Clear();
                            Console.WriteLine("История была очищена");
                        }
                        break;
                }
            }
        }

        private static void BiCaseMenu(ref DoublyLinkedList<MusicalInstrument> instrumentsList)
        {

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

                            int z = InputInt(0, 4);
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
                            instrumentsList.Clear();
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
                            DoublyLinkedList<MusicalInstrument> clonedList = instrumentsList.Clone(instrumentsList);
                            clonedList.Print();
                            Console.WriteLine("\nВывод оригинального списка списка:");
                            instrumentsList.Print();
                            break;
                        }
                }
            }

        }
    }
}
