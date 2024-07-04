using System.Reflection;
using System.Windows.Forms;

namespace Task001
{
    public partial class Form1 : Form
    {
        Assembly? assembly = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripMenuItemOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                // ������ ������ ������� ����� ����������� ������.
                string path = openFileDialog1.FileName;

                try
                {
                    assembly = Assembly.LoadFile(path);

                    textBox1.Text += "������    " + path + "  -  ������� ���������" + Environment.NewLine + Environment.NewLine;
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                // ����� ���������� � ���� ����� � ������.
                textBox1.Text += "������ ���� ����� � ������:     " + assembly.FullName + Environment.NewLine + Environment.NewLine;

                Type[] types = assembly.GetTypes();

                foreach (Type type in types)
                {
                    textBox1.Text += "���:  " + type + Environment.NewLine;
                    var methods = type.GetMethods();
                    if (methods != null)
                    {
                        foreach (var method in methods)
                        {
                            string methStr = "�����: " + method.Name + "\n";
                            
                            textBox1.Text += methStr + Environment.NewLine;
                        }
                    }
                }


            }
        }

        private void toolStripMenuItemClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}