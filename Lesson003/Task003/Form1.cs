using System.IO.Compression;
using System.Windows.Forms;

namespace Task003
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GetDrivers();
        }

        void GetDrivers()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                if (drive.DriveType == DriveType.CDRom)
                {
                    continue;
                }
                checkedListBox1.Items.Add(String.Format(drive.Name));
            }

        }
        string file;

        bool SearchFile(string dirName, string fileName)
        {
            DirectoryInfo dir = new DirectoryInfo(dirName);
            if (!dir.Exists)
            {
                return false;
            }

            FileInfo[] files = null;

            try
            {
                files = dir.GetFiles(fileName);
            }
            catch (Exception)
            {
                return false;
            }

            if (files.Length == 0)
            {
                DirectoryInfo[] subDirectories = dir.GetDirectories();
                if (subDirectories.Length == 0)
                {
                    return false;
                }
                foreach (var directory in subDirectories)
                {
                    if (directory.Attributes.Equals(FileAttributes.System | FileAttributes.Hidden | FileAttributes.Directory))
                    {
                        continue;
                    }

                    if (SearchFile(directory.FullName, fileName))
                    {
                        return true;
                    }
                }
                return false;

            }
            else
            {
                file = files[0].FullName;
                return true;
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    if (SearchFile(checkedListBox1.Items[i].ToString(), textBoxFileName.Text))
                    {
                        textBox1.Text = "Файл" + file + "найден";
                    }
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader reader = new StreamReader(file);
            textBox1.Text = reader.ReadToEnd();
            reader.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream source = File.OpenRead(file);
                FileStream destination = File.Create(saveFileDialog1.FileName);

                // Создание компрессора.
                GZipStream compressor = new GZipStream(destination, CompressionMode.Compress);

                // Заполнение архива информацией из файла.
                int theByte = source.ReadByte();
                while (theByte != -1)
                {
                    compressor.WriteByte((byte)theByte);
                    theByte = source.ReadByte();
                }

                // Удаление компрессора.
                compressor.Close();
            }
        }
    }
}