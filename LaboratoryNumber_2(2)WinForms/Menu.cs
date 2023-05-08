using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaboratoryNumber_2_2_WinForms
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void созданиеСпискаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataBank.L = new CycleDoubleLinkedList();
            int[] dates = new int[listBox.Items.Count];
            for (int i = 0; i < listBox.Items.Count; i++) dates[i] = int.Parse(listBox.Items[i].ToString());
            DataBank.CreatMass(dates);
            PrintCreateList Fprntlst = new PrintCreateList();
            Fprntlst.Show();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            int number;
            if ((!int.TryParse(textBoxAdd.Text, out number)))
            {
                MessageBox.Show("Вы ввели не число!!!");
            }
            else
            {
                listBox.Items.Add(number);
                textBoxAdd.Clear();
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex > -1) listBox.Items.RemoveAt(listBox.SelectedIndex);
        }

        private void вНачалоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataBank.logicTask = "1";
            PatternAddInList PtrnAddLst = new PatternAddInList();
            PtrnAddLst.Show();
        }

        private void вКонецToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataBank.logicTask = "2";
            PatternAddInList PtrnAddLst = new PatternAddInList();
            PtrnAddLst.Show();
        }

        private void вПроизвольнуюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataBank.logicTask = "3";
            PatternAddInList PtrnAddLst = new PatternAddInList();
            PtrnAddLst.Show();
        }

        private void вНачалоToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataBank.logicTask = "-1";
            PatternDelInList PtrnAddLst = new PatternDelInList();
            PtrnAddLst.Show();
        }

        private void вКонецToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataBank.logicTask = "-2";
            PatternDelInList PtrnAddLst = new PatternDelInList();
            PtrnAddLst.Show();
        }

        private void вПроизвольнуюToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataBank.logicTask = "-3";
            PatternDelInList PtrnAddLst = new PatternDelInList();
            PtrnAddLst.Show();
        }
    }
}
