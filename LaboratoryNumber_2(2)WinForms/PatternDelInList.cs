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
    public partial class PatternDelInList : Form
    {
        public PatternDelInList()
        {
            InitializeComponent();
        }

        private void ButtonDel_Click(object sender, EventArgs e)
        {
            if (DataBank.logicTask == "-1")
            {
                listBoxPatternDelInList.Items.Clear();
                DataBank.DelElementsN(listBoxPatternDelInList);
                DataBank.PrintListBox(listBoxPatternDelInList);
                
            }
            else if (DataBank.logicTask == "-2")
            {
                listBoxPatternDelInList.Items.Clear();
                DataBank.DelElementsK(listBoxPatternDelInList);
                DataBank.PrintListBox(listBoxPatternDelInList);
                
            }
            else if (DataBank.logicTask == "-3")
            {
                listBoxPatternDelInList.Items.Clear();
                DataBank.DelElementsR(listBoxPatternDelInList);
                DataBank.PrintListBox(listBoxPatternDelInList);
            }
        }
    }
}
