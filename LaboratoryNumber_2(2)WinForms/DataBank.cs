using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaboratoryNumber_2_2_WinForms
{
    static class DataBank
    {
        public static int[] massL1;
        public static int[] massL2;

        public static CycleDoubleLinkedList L1 = new CycleDoubleLinkedList();
        public static CycleDoubleLinkedList L2 = new CycleDoubleLinkedList();

        public static string logicTask = "";
        public static void PrintListBox(ListBox listbox)
        {
            L1.PrintDoubleList(listbox);
        }
        public static void ClearListL()
        {
            L1.Clear();
        }
        public static void DestroyL()
        {
            L1.Destroy();
        }
        public static void CreatMassL1(int[] dates)
        {
            massL1 = new int[dates.Length];
            for (int i = 0; i < dates.Length; i++) massL1[i] = dates[i];
            L1.Create(massL1);
        }
        public static void CreatMassL2(int[] dates)
        {
            massL2 = new int[dates.Length];
            for (int i = 0; i < dates.Length; i++) massL2[i] = dates[i];
            L2.Create(massL2);
        }
        public static void MergeListsElements(ListBox listbox)
        {
            CycleDoubleLinkedList mergedList = new CycleDoubleLinkedList();
            CycleDoubleLinkedList.MergeLists(L1, L2, listbox);
        }
        public static void AddElementesN(ListBox listbox, int number)
        {
            L1.InsertBeforeFirst(number);
        }
        public static void AddElementesK(ListBox listbox, int number)
        {
            L1.InsertAfterEnd(number);
        }
        public static void AddElementesR(int element, int number)
        {
            DoubleNode tmp = L1.Find(element);
            if (tmp != null) L1.InsertRight(tmp, number);
            else MessageBox.Show("Узел не Найден!!!");
        }
        public static void DelElementsN(ListBox listbox)
        {
            L1.DeleteBeforeFirst();
        }
        public static void DelElementsK(ListBox listbox)
        {
            L1.DeleteAfterEnd();
        }
        public static void DelElementsR(int element)
        {
            DoubleNode tmp = L1.Find(element);
            if (tmp != null) L1.Delete(tmp);
            else MessageBox.Show("Узел не Найден!!!");
        }
    }
}
