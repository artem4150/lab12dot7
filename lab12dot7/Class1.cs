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
            try
            {
                // Проверяем, есть ли элемент с заданным именем в списке
                Node<T> elementToRemove = FindByName(name);
                if (elementToRemove == null)
                {
                    Console.WriteLine("Элемент с именем '{0}' не найден в списке.", name);
                    return false;
                }

                // Удаление всех элементов, начиная с элемента с заданным именем, и до конца списка
                while (elementToRemove != null)
                {
                    Node<T> next = elementToRemove.Next;
                    Remove(elementToRemove);
                    elementToRemove = next;
                }

                Console.WriteLine("Элементы, начиная с элемента с именем '{0}', были удалены из списка.", name);
                return true;
            }
            catch { Console.WriteLine("Ошибка"); return false; }
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
        
        public int GetCount()
        {
            int i = 0;
            Node<T> p = Head;
            while (p != null)
            {
                i++;
                p = p.Next; 
            }
            return i;
        }
        public void Clear()
        {
            Head = null;
            Tail = null;
        }
        

        public static DoublyLinkedList<T> AddElementAtIndex(DoublyLinkedList<T> list, T data, int index)
        {
            // Создаем новый узел с данными
            Node<T> newNode = new Node<T>(data);

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
            if (current == null || current.Next == null)
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
                current.Next.Previous = newNode; 
                current.Next = newNode;
            }

            return list;
        }

        public DoublyLinkedList<MusicalInstrument> Clone(DoublyLinkedList<MusicalInstrument> instrumentsList)
        {
            DoublyLinkedList<MusicalInstrument> clonedList = new DoublyLinkedList<MusicalInstrument>();
            Node<MusicalInstrument> currentCloned = instrumentsList.Head;
            while (currentCloned != null)
            {
                MusicalInstrument clonedItem = (MusicalInstrument)currentCloned.Data.Clone();
                clonedList.AddLast(clonedItem);
                currentCloned = currentCloned.Next;
            }
            
            return clonedList;
        }

        public DoublyLinkedList<T> DeepClone()
        {
            DoublyLinkedList<T> clonedList = new DoublyLinkedList<T>();

            
            Node<T> current = Head;
            while (current != null)
            {
                
                if (current.Data is ICloneable)
                {
                    
                    T clonedData = (T)((ICloneable)current.Data).Clone();
                    clonedList.AddLast(clonedData);
                }
                else
                {
                    
                    clonedList.AddLast(current.Data);
                }

                current = current.Next;
            }

            return clonedList;
        }


        public static Node<T> MakeRandomNode()
        {
            
            MusicalInstrument randomInstrument = new MusicalInstrument();
            randomInstrument.RandomInit();

            // Создаем новый узел с рандомными данными
            Node<T> newNode = new Node<T>((T)Convert.ChangeType(randomInstrument, typeof(T)));

            return newNode;
        }
        
        public static DoublyLinkedList<T> AddOddObjects(DoublyLinkedList<T> list)
        {
            if (list.GetCount() >= 1000)
            {
                Console.WriteLine("Ошибка! Список имеет не меньше 100 элементов");
                Console.WriteLine("Добавление в список элементов с номерами 1, 3, 5 и т.д. не завершено");
                return list;
            }

            int count = list.GetCount();
            for (int i = count + 1; i <= count * 2; i += 2)
            {
                list = AddElementAtIndex(list, GenerateRandomData(), i);
            }

            Console.WriteLine("Добавление в список элементов с номерами 1, 3, 5 и т.д. завершено");
            return list;
        }
        public Node<T> MakeRandomNoden()
{
    
    MusicalInstrument randomInstrument = new MusicalInstrument();
    randomInstrument.RandomInit();

    // Создаем новый узел с рандомными данными
    Node<T> newNode = new Node<T>((T)Convert.ChangeType(randomInstrument, typeof(T)));

    return newNode;
}
        public static T GenerateRandomData()
        {
            MusicalInstrument randomInstrument = new MusicalInstrument();
            randomInstrument.RandomInit();

            // Преобразуем объект в тип T и возвращаем
            return (T)Convert.ChangeType(randomInstrument, typeof(T));
        }

    }
}
