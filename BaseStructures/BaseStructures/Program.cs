using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestStack();
            //TestQueue();
            //TestDoubleLinkedList();

            Console.ReadKey();
        }

        private static void TestDoubleLinkedList()
        {
            DoubleLinkedList<int> a = new DoubleLinkedList<int>();

            Console.WriteLine("Добавляем элемент {0} в список", 1);
            a.Add(1);
            Console.WriteLine("Добавляем элемент {0} в список", 2);
            a.Add(2);
            Console.WriteLine("Добавляем элемент {0} в список", 3);
            a.Add(3);
            Console.WriteLine("Добавляем элемент {0} в список", 4);
            a.Add(4);
            Console.WriteLine("Добавляем элемент {0} в список", 5);
            a.Add(5);

            Console.WriteLine("Список: {0}", a.ToString());
            var c = a.Search(3);
            Console.WriteLine("Найден елемент с значением {1}\nПредыдущий элемент: {0}\nСледующий элемент: {2}",
                c.Prev.Data, c.Data, c.Next.Data);

            a.Insert(6);
            var d = a.Delete(2);
            Console.WriteLine("Удален элемент с значением {1}\nПредыдущий элемент: {0}\nСледующий элемент: {2}",
                d.Prev.Data, d.Data, d.Next.Data);
            Console.WriteLine("Найден елемент с значением {1}\nПредыдущий элемент: {0}\nСледующий элемент: {2}",
                c.Prev.Data, c.Data, c.Next.Data);
            Console.WriteLine("Список после вставки и удаления: {0}", a.ToString());
        }
        private static void TestQueue()
        {
            Queue<int> a = new Queue<int>(10);

            Console.WriteLine("Добавим элемент : {0} в очередь",1);
            a.Enqueue(1);
            Console.WriteLine("Добавим элемент : {0} в очередь",2);
            a.Enqueue(2);
            Console.WriteLine("Добавим элемент : {0} в очередь",3);
            a.Enqueue(3);
            Console.WriteLine("Добавим элемент : {0} в очередь",4);
            a.Enqueue(4);
            Console.WriteLine("Добавим элемент : {0} в очередь",5);
            a.Enqueue(5);
            Console.WriteLine("Добавим элемент : {0} в очередь",6);
            a.Enqueue(6);
            Console.WriteLine("Очередь: {0}", a.ToString());

            a.Dequeue();
            Console.WriteLine("Удаляем элнмент из очереди");
            a.Dequeue();
            Console.WriteLine("Удаляем элнмент из очереди");
            a.Dequeue();
            Console.WriteLine("Удаляем элнмент из очереди");
            Console.WriteLine("Добавим элемент : {0} в очередь", 1);
            a.Enqueue(1);
            Console.WriteLine("Добавим элемент : {0} в очередь", 2);
            a.Enqueue(2);
            Console.WriteLine("Добавим элемент : {0} в очередь", 3);
            a.Enqueue(3);

            Console.WriteLine("Очередь: {0}", a.ToString());
        }
        private static void TestStack()
        {
            Stack<int> a = new Stack<int>(10);

            Console.WriteLine("Добавляем элемент {0} в стек",5);
            a.Push(5);
            Console.WriteLine("Добавляем элемент {0} в стек", 10);
            a.Push(10);
            Console.WriteLine("Добавляем элемент {0} в стек", 15);
            a.Push(15);

            Console.WriteLine("Массив: {0}", a.ToString());
            Console.WriteLine("Вершина стека(кол-во элементов): {0}", a.Top);
            Console.WriteLine("Стек пуст: {0}", a.StackEmpty());
            Console.ReadKey();
            Console.WriteLine();

            while (!a.StackEmpty())
            {
                Console.WriteLine("Удаляем элемент {0} из стека", a.Pop());
                Console.WriteLine("Массив: {0}", a.ToString());
                Console.WriteLine("Вершина стека(кол-во элементов): {0}", a.Top);
                Console.WriteLine("Стек пуст: {0}", a.StackEmpty());
            }
        }
    }

    //Stack realization
    public class Stack<T>
    {
        public Stack(int capacity)
        {
            Array = new T[capacity];
            Top = 0;
        }

        public T[] Array;
        public int Top;

        public T Pop()
        {
            if (Top > 0)
            {
                Top--;
                return Array[Top];
            }
            return default(T);
        }
        public void Push(T item)
        {
            if (Top + 1 < Array.Length)
            {
                Array[Top] = item;
                Top++;
            }
        }
        public bool StackEmpty()
        {
            if (Top == 0)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            string s = string.Empty;
            for (int i = 0; i < Top; i++)
            {
                s += Array[i].ToString();
                s += " ";
            }
            return s;
        }
    }
    //Queue realization
    public class Queue<T>
    {
        public Queue(int capacity)
        {
            Array = new T[capacity];
            Head = Tail = 1;
        }

        public T[] Array;

        public int Head;
        public int Tail;

        public void Enqueue(T item)
        {
            Array[Tail - 1] = item;
            Tail = Tail == Array.Length ? 1 : Tail + 1;
        }

        public T Dequeue()
        {
            T item = Array[Head - 1];
            Head = Head == Array.Length ? 1 : Head + 1;
            return item;
        }

        public override string ToString()
        {
            string s = string.Empty;
            if (Head <= Tail)
            {
                for (int i = Head - 1; i < Tail - 1; i++)
                {
                    s += Array[i].ToString();
                    s += " ";
                }
            }
            else
            {
                for (int i = Head - 1; i < Array.Length; i++)
                {
                    s += Array[i].ToString();
                    s += " ";
                }
                for (int i = 0; i < Tail - 1; i++)
                {
                    s += Array[i].ToString();
                    s += " ";
                }
            }
            return s;
        }
    }
    //Double LinkedList realization
    public class DoubleLinkedList<T>
    {
        public Link<T> Head { get; private set; }
        Link<T> Last;

        public void Add(T data)
        {
            var n = new Link<T> { Data = data };
            if (Last == null)
                Head = Last = n;
            else
            {
                Last.Next = n;
                n.Prev = Last;
                Last = n;
            }
        }

        public void Insert(T data)
        {
            var n = new Link<T> { Data = data, Next = Head};
            if (Head != null)
            {
                Head.Prev = n;
            }
            Head = n;
            n.Prev = null;
        }

        public Link<T> Delete(T item)
        {
            var n = Search(item);
            if (n.Prev != null)
            {
                n.Prev.Next = n.Next;
            }
            else
            {
                Head = n.Next;
            }
            if (n.Next != null)
            {
                n.Next.Prev = n.Prev;
            }
            return n; 
        }

        public Link<T> Search(T item)
        {
            foreach (var itm in Links())
            {
                if (itm.Data.GetHashCode() == item.GetHashCode())
                {
                    return itm;
                }
            }
            return null;
        }

        public IEnumerable<Link<T>> Links()
        {
            var cur = Head;
            while (cur != null)
            {
                yield return cur;
                cur = cur.Next;
            }
        }

        public Link<T> Link(int index)
        {
            int cur = 0;
            foreach (var itm in Links())
            {
                if (cur++ == index)
                {
                    return itm;
                }
            }
            return null;
        }

        public override string ToString()
        {
            string s = string.Empty;
            foreach (var itm in Links())
            {
                s += itm.Data.ToString();
                s += " ";
            }
            return s;
        }
    }
    public class Link<T>
    {
        public Link<T> Next;
        public Link<T> Prev;
        public T Data;
    }
}
