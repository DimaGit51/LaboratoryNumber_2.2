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
    public partial class PatternAddInList : Form
    {
        public PatternAddInList()
        {
            InitializeComponent();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (DataBank.logicTask == "1") {
                listBoxPatternAddInList.Items.Clear();
                int number;
                if ((!int.TryParse(textBoxAddPatternAdd.Text, out number)))
                {
                    MessageBox.Show("Вы ввели не число!!!");
                }
                else
                {
                    textBoxAddPatternAdd.Clear();
                    DataBank.AddElementesN(listBoxPatternAddInList, number);
                    DataBank.PrintListBox(listBoxPatternAddInList);
                }
            }
            else if (DataBank.logicTask == "2")
            {
                listBoxPatternAddInList.Items.Clear();
                int number;
                if ((!int.TryParse(textBoxAddPatternAdd.Text, out number)))
                {
                    MessageBox.Show("Вы ввели не число!!!");
                }
                else
                {
                    textBoxAddPatternAdd.Clear();
                    DataBank.AddElementesK(listBoxPatternAddInList, number);
                    DataBank.PrintListBox(listBoxPatternAddInList);
                }
            }
            else if (DataBank.logicTask == "3")
            {
                listBoxPatternAddInList.Items.Clear();
                int number;
                if ((!int.TryParse(textBoxAddPatternAdd.Text, out number)))
                {
                    MessageBox.Show("Вы ввели не число!!!");
                }
                else
                {
                    textBoxAddPatternAdd.Clear();
                    DataBank.AddElementesR(listBoxPatternAddInList, number);
                    DataBank.PrintListBox(listBoxPatternAddInList);
                }
            }
        }
    
    }
}
