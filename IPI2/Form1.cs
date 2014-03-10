using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPI2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();//MOTHER FUCKERSSS
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Ouvrir un fichier TDMS";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                   //Code à changer ici pour fichier TDMS
                System.IO.StreamReader sr = new
                System.IO.StreamReader(ofd.FileName);
                MessageBox.Show(sr.ReadToEnd());
                sr.Close();
            }
        }
    }
}
