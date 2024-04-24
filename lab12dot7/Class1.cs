using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using лаба10;
using static System.Net.Mime.MediaTypeNames;

namespace lab12dot7
{
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }
        public Node<T> Previous { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
            Previous = null;
        }
        


    }

    public class DoublyLinkedList<T>
    {
        public Node<T> Head { get; private set; }
        public Node<T> Tail { get; private set; }

        public void AddLast(T data)
        {
            Node<T> newNode = new Node<T>(data);
            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                Tail.Next = newNode;
                newNode.Previous = Tail;
                Tail = newNode;
            }
        }

        public bool RemoveFrom(string name)
        {
            // Проверяем, есть ли элемент с заданным именем в списке
            Node<T> elementToRemove = FindByName(name);
            if (elementToRemove == null)
            {
                Console.WriteLine("Элемент с именем '{0}' не найден в списке.", name);
                return false; // Возвращаем false, так как элемент не найден
            }

            // Удаление всех элементов, начиная с элемента с заданным именем, и до конца списка
            while (elementToRemove != null)
            {
                Node<T> next = elementToRemove.Next; // Сохраняем ссылку на следующий элемент перед удалением текущего
                Remove(elementToRemove); // Удаляем текущий элемент
                elementToRemove = next; // Переходим к следующему элементу
            }

            Console.WriteLine("Элементы, начиная с элемента с именем '{0}', были удалены из списка.", name);
            return true; // Возвращаем true, чтобы указать, что удаление выполнено успешно
        }

        public void Print()
        {
            Node<T> current = Head;
            while (current != null)
            {
                Console.WriteLine(current.Data.ToString());
                current = current.Next;
            }
        }

        public int Count
        {
            get
            {
                int count = 0;
                Node<T> current = Head;
                while (current != null)
                {
                    count++;
                    current = current.Next;
                }
                return count;
            }
        }

        public Node<T> FindByName(string name)
        {
            int nameCode = name.GetHashCode();
            Node<T> current = Head;
            while (current != null)
            {
                if (current.Data.GetHashCode() == nameCode)
                    return current;
                current = current.Next;
            }
            return null;
        }

        public void Remove(Node<T> node)
        {
            if (node == null)
                return;

            if (node.Previous != null)
                node.Previous.Next = node.Next;
            else
                Head = node.Next;

            if (node.Next != null)
                node.Next.Previous = node.Previous;
            else
                Tail = node.Previous;
        }
        //public static int GetCount(DoublyLinkedList<T> beg)
        //{
        //    int i = 0;
        //    DoublyLinkedList<T> p = beg;
        //    while (p != null)
        //    {
        //        i++;
        //        p = p.Next; // переход к следующему элементу
        //    }
        //    return i;
        //}
        public int GetCount(DoublyLinkedList<T> beg)
        {
            int i = 0;
            Node<T> p = Head;
            while (p != null)
            {
                i++;
                p = p.Next; // переход к следующему элементу
            }
            return i;
        }
        public void Clear()
        {
            Head = null;
            Tail = null;
        }
        //static Node<T> MakePoint(MusicalInstrument a)
        //{
        //    Node<T> p = new Node<T>(a);
        //    return p;
        //}
        //public static DoublyLinkedList<T> AddPoint(DoublyLinkedList<T> beg, int number)
        //{
        //    MusicalInstrument a = new MusicalInstrument();
        //    a.RandomInit();
        //    Console.WriteLine("\nЭлемент {0} добавляется ...", a.ToString());
        //    // создаем новый элемент
        //    Node<T> NewPoint = MakePoint((MusicalInstrument)a.Clone());
        //    if (beg == null) // список пустой
        //    {
        //        beg = beg.AddLast(a);
        //        return beg;
        //    }
        //    if (number == 1) //добавление в начало списка
        //    {
        //        beg.pred = NewPoint;
        //        NewPoint.Next = beg;
        //        beg = NewPoint;
        //        return beg;
        //    }
        //    // вспом. переменная для прохода по списку
        //    PointBiList p = beg;
        //    // идем по списку до нужного элемента
        //    for (int i = 1; i < number - 1 && p != null; i++)
        //        p = p.next;
        //    // добавляем новый элемент
        //    NewPoint.pred = p;
        //    NewPoint.next = p.next;
        //    p.next = NewPoint;
        //    return beg;
        public static DoublyLinkedList<T> AddElementAtIndex(DoublyLinkedList<T> list, int index)
        {
            // Создаем новый узел с данными
            Node<T> newNode;
            newNode = MakeRandomNode();
            // Если список пустой или индекс равен 1, добавляем в начало списка
            if (list == null || index == 1)
            {
                newNode.Next = list.Head;
                if (list.Head != null)
                    list.Head.Previous = newNode;
                list.Head = newNode;

                // Если список был пуст, новый узел становится и концом списка
                if (list.Tail == null)
                    list.Tail = newNode;

                return list;
            }

            // Иначе ищем место для вставки
            Node<T> current = list.Head;
            int currentIndex = 1;
            while (current != null && currentIndex < index - 1)
            {
                current = current.Next;
                currentIndex++;
            }

            // Если достигнут конец списка, добавляем в конец
            if (current == null)
            {
                list.Tail.Next = newNode;
                newNode.Previous = list.Tail;
                list.Tail = newNode;
            }
            else
            {
                // Вставляем новый узел между текущим и следующим узлом
                newNode.Next = current.Next;
                newNode.Previous = current;
                if (current.Next != null)
                    current.Next.Previous = newNode;
                current.Next = newNode;
            }

            return list;
        }
        public static Node<T> MakeRandomNode()
        {
            // Создаем случайные данные для нового узла
            // Здесь можно использовать любой механизм генерации случайных данных для вашего типа T
            // Например, если T - это int, вы можете использовать:
            // Random rnd = new Random();
            // int randomData = rnd.Next();
            // T data = (T)Convert.ChangeType(randomData, typeof(T));

            // Для примера, предположим, что T - это MusicalInstrument
            MusicalInstrument randomInstrument = new MusicalInstrument();
            randomInstrument.RandomInit();

            // Создаем новый узел с рандомными данными
            Node<T> newNode = new Node<T>((T)Convert.ChangeType(randomInstrument, typeof(T)));

            return newNode;
        }
        public DoublyLinkedList<T> AddOddObjects1(DoublyLinkedList<T> beg)
        {
            int size = GetCount(beg) * 2;
            for (int i = 0; i <= size; i += 2)
            {
                Node<T > оl = MakeRandomNode();
                beg = AddElementAtIndex(beg, i + 1);
            }
            return beg;
        }
        public static DoublyLinkedList<T> AddOddObjects(DoublyLinkedList<T> list)
        {
            if (list.GetCount(list) >= 100)
            {
                Console.WriteLine("Ошибка! Список имеет не меньше 100 элементов");
                Console.WriteLine("Добавление в список элементов с номерами 1, 3, 5 и т.д. не завершено");
                return list;
            }

            for (int i = 1; i <= list.Count * 2; i += 2)
            {
                list = AddElementAtIndex(list, i);
            }

            Console.WriteLine("Добавление в список элементов с номерами 1, 3, 5 и т.д. завершено");
            return list;
        }

    }
}
