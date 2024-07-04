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
                // Строка приема полного имени загружаемой сборки.
                string path = openFileDialog1.FileName;

                try
                {
                    assembly = Assembly.LoadFile(path);

                    textBox1.Text += "СБОРКА    " + path + "  -  УСПЕШНО ЗАГРУЖЕНА" + Environment.NewLine + Environment.NewLine;
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                // Вывод информации о всех типах в сборке.
                textBox1.Text += "СПИСОК ВСЕХ ТИПОВ В СБОРКЕ:     " + assembly.FullName + Environment.NewLine + Environment.NewLine;

                Type[] types = assembly.GetTypes();

                foreach (Type type in types)
                {
                    textBox1.Text += "Тип:  " + type + Environment.NewLine;
                    var methods = type.GetMethods();
                    if (methods != null)
                    {
                        foreach (var method in methods)
                        {
                            string methStr = "Метод: " + method.Name + "\n";
                            
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