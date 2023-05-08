using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaboratoryNumber_2_2_WinForms
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Menu());
        }
    }
    static class DataBank
    {
        public static int[] mass;
        public static CycleDoubleLinkedList L = new CycleDoubleLinkedList();
        public static string logicTask = "";
        public static void PrintListBox(ListBox listbox)
        {
            L.PrintDoubleList(listbox);
        }
        public static void ClearListL()
        {
            L.Clear();
        }
        public static void CreatMass(int[] dates)
        {
            mass = new int[dates.Length];
            for (int i = 0; i < dates.Length; i++) mass[i] = dates[i];
            L.Create(mass);
        }
        public static void AddElementesN(ListBox listbox, int number)
        {
            L.InsertBeforeFirst(number);
        }
        public static void AddElementesK(ListBox listbox, int number)
        {
            L.InsertAfterEnd(number);
        }
        public static void AddElementesR(ListBox listbox, int number)
        {
            L.InsertRandom(number);
        }
        public static void DelElementsN(ListBox listbox)
        {
            L.DeleteBeforeFirst();
        }
        public static void DelElementsK(ListBox listbox)
        {
            L.DeleteAfterEnd();
        }
        public static void DelElementsR(ListBox listbox)
        {
            L.DeleteRandom();
        }
    }
    public class DoubleNode
    {
        private int info;
        private DoubleNode next;
        private DoubleNode prev;

        public int Info
        {
            get { return info; }
            set { info = value; }
        }
        public DoubleNode Next
        {
            get { return next; }
            set { next = value; }
        }
        public DoubleNode Prev
        {
            get { return prev; }
            set { prev = value; }
        }

        public DoubleNode() { }
        public DoubleNode(int info) { this.info = info; }
        public DoubleNode(int info, DoubleNode next, DoubleNode prev) { this.Info = info; this.Next = next; this.Prev = prev; }
    }
    public class CycleDoubleLinkedList
    {
        private DoubleNode head; // ссылка на головной узел списка
        public CycleDoubleLinkedList() // создание элементарного двусвязного кольца
        {
            head = new DoubleNode();
            head.Next = head;
            head.Prev = head;
        }
        public void InsertRight(DoubleNode p, int data) // p – предварительно установленная ссылка; data – значение информационного поля узла списка
        {
            DoubleNode q; // q – ссылка на новый узел
            if (p != null) // ссылка p действительно установлена?
            {
                q = new DoubleNode(data); // создание и инициализация нового узла
                q.Next = p.Next; // 1 – установка связи нового узла со следуюшим
                q.Prev = p; // 2 – установка связи нового узла с предыдущим
                p.Next.Prev = q; // 3 – установка связи следующего узла с новым
                p.Next = q; // 4 - установка связи предыдущего узла с новым
            }
        }
        public void InsertLeft(DoubleNode p, int data) // p – предварительно установленная ссылка; data – значение информационного поля узла списка
        {
            DoubleNode q; // q – ссылка на новый узел
            if (p != null) // ссылка p действительно установлена?
            {
                q = new DoubleNode(data); // создание и инициализация нового узла
                q.Next = p; // 1 – установка связи нового узла со следуюшим
                q.Prev = p.Prev; // 2 – установка связи нового узла с предыдущим
                p.Prev.Next = q; // 3 – установка связи следующего узла с новым
                p.Prev = q; // 4 - установка связи предыдущего узла с новым
            }
        }
        public void Delete(DoubleNode p) // p – ссылка на исключаемый узел

        {
            if (head != null && head.Next != head // список не пуст и ссылка p
            && head.Prev != head && p != null) // установлена?
            {
                p.Prev.Next = p.Next; // изменить поле связи предыдущего узла
                p.Next.Prev = p.Prev; // изменить поле связи следующего узла
            }
        }
        public void Create(int[] dates) // cоздание циклического списка
        {
            DoubleNode p;
            for (int i = 0; i < dates.Length; i++)
            {
                p = new DoubleNode(dates[i]); // создание узла списка
                p.Next = head;
                p.Prev = head.Prev;
                head.Prev.Next = p;
                head.Prev = p;
            }
        }

        public void CreateOrdered(int[] dates)
        {
            if (head != null)
            {
                DoubleNode p, newnode;
                for (int i = 0; i < dates.Length; i++)
                {
                    p = head.Next;
                    newnode = new DoubleNode(dates[i]);
                    while (p != head && newnode.Info > p.Info) p = p.Next;
                    newnode.Next = p;
                    newnode.Prev = p.Prev;
                    p.Prev.Next = newnode;
                    p.Prev = newnode;
                }
            }
        }
        public DoubleNode Find(int data)
        {
            DoubleNode p = null;
            if (head != null)
            {
                p = head.Next;
                while (p != head && p.Info != data) p = p.Next;
                if (p == head) p = null;
            }
            return p;
        }
        public void PrintDoubleList(ListBox listbox)
        {
            DoubleNode p = head.Next;
            while (p != head)
            {
                listbox.Items.Add(p.Info);
                p = p.Next;
            }
        }

        public void InsertBeforeFirst(int data)
        {
            DoubleNode q = head;
            InsertRight(q, data);
        }
        public void InsertAfterEnd(int data)
        {
            DoubleNode q = head;
            InsertLeft(q, data);
        }
        public void InsertRandom(int data)
        {
            int count = 0;
            DoubleNode p = head.Next;
            while (p != head)
            {
                p = p.Next;
                count++;
            }
            Random rnd = new Random();
            int countRnd = rnd.Next(1, count); count = 0;
            p = head;
            while (p != null && count < countRnd)
            {
                p = p.Next;
                count++;
            }
            InsertLeft(p, data);
        }
        public void DeleteBeforeFirst()
        {
            DoubleNode q = head.Next;
            Delete(q);
        }
        public void DeleteAfterEnd()
        {
            DoubleNode p = head.Prev;
            Delete(p);
        }
        public void DeleteRandom()
        {
            int count = 0;
            DoubleNode p = head.Next;
            while (p != head)
            {
                p = p.Next;
                count++;
            }
            Random rnd = new Random();
            if (count > 0)
            {
                int countRnd = rnd.Next(1, count); count = 0;
                p = head;
                while (p != null && count < countRnd)
                {
                    p = p.Next;
                    count++;
                }
                Delete(p);
            }

        }
        public void Clear()
        {
            head = null;
        }
        public static void MergeLists(CycleDoubleLinkedList list1, CycleDoubleLinkedList list2, ListBox listbox)
        {
            CycleDoubleLinkedList mergedList = new CycleDoubleLinkedList();
            DoubleNode current1 = list1.head.Next;
            DoubleNode current2 = list2.head.Next;
            while (current1 != list1.head && current2 != list2.head)
            {
                if (current1 != null)
                {
                    mergedList.InsertRight(mergedList.head.Prev, current1.Info);
                    current1 = current1.Next;
                }
                if (current2 != null)
                {
                    mergedList.InsertRight(mergedList.head.Prev, current2.Info);
                    current2 = current2.Next;
                }
            }
            mergedList.PrintDoubleList(listbox);
        }
    }
}
