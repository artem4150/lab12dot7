using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using лаба10;

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
            Node<T> current = Head;
            while (current != null)
            {
                if (current.Data.ToString() == name)
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

        public void Clear()
        {
            Head = null;
            Tail = null;
        }
    }
}
