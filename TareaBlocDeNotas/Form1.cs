using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TareaBlocDeNotas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           DirectoryInfo directoryInfo = new DirectoryInfo(directory);
            treeView1.Nodes.Add(ReadFiles(directoryInfo));
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

            System.IO.StreamReader OpenFile = new System.IO.StreamReader(openFileDialog1.FileName);
            this.Text = openFileDialog1.FileName;

            richTextBox1.Text = OpenFile.ReadToEnd();
            OpenFile.Close();

        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var FileName = openFileDialog1.FileName;

            if (FileName == "")
            {

                saveFileDialog1.Title = "Guardar Como";
                saveFileDialog1.Filter = "Text (*.txt)|*.txt|Word Doc (*.doc)|*.doc";
                saveFileDialog1.DefaultExt = "txt";

                saveFileDialog1.ShowDialog();
                System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(saveFileDialog1.FileName);

                SaveFile.WriteLine(richTextBox1.Text);

                SaveFile.Close();

            }
            else
            {

                richTextBox1.SaveFile(this.Text, RichTextBoxStreamType.PlainText);

            }



        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "Guardar Como";
            saveFileDialog1.Filter = "Text (*.txt)|*.txt|Word Doc (*.doc)|*.doc";
            saveFileDialog1.DefaultExt = "txt";

            saveFileDialog1.ShowDialog();
            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(saveFileDialog1.FileName);

            SaveFile.WriteLine(richTextBox1.Text);

            SaveFile.Close();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        

        string directory = @"C:\\Users\\Roger\\Desktop";

        public TreeNode ReadFiles(DirectoryInfo directoryInfo)
        {

            TreeNode treeNode = new TreeNode(directoryInfo.Name);
            foreach (var item in directoryInfo.GetDirectories())
            {
                treeNode.Nodes.Add(ReadFiles(item));
            }
            foreach (var item in directoryInfo.GetFiles())
            {
                treeNode.Nodes.Add(new TreeNode(item.Name));
            }
            return treeNode;
        }

    }
}
