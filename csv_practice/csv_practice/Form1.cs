using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csv_practice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "CSV|*.csv", ValidateNames = true })
            {
                if(sfd.ShowDialog() == DialogResult.OK)
                {
                    using(var sw = new StreamWriter(sfd.FileName))
                    {
                        var csvWriter = new CsvHelper.CsvWriter(sw);
                        csvWriter.WriteHeader(typeof(Student));
                        csvWriter.NextRecord();
                        // Method 1
                        //foreach (Student s in studentBindingSource.DataSource as List<Student>)
                        //{
                        //    csvWriter.WriteRecord(s);
                        //    csvWriter.NextRecord();
                        //}

                        // Method 2
                        foreach (Student s in studentBindingSource.List)
                        {
                            csvWriter.WriteRecord(s);
                            csvWriter.NextRecord();
                        }
                    }

                    MessageBox.Show("Your data has been successfully saved", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog ofd = new OpenFileDialog() { Filter = "CSV|*.csv", ValidateNames = true })
            {
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    using (var sr = new StreamReader(new FileStream(ofd.FileName, FileMode.Open)))
                    {
                        var csvReader = new CsvHelper.CsvReader(sr);
                        studentBindingSource.DataSource = csvReader.GetRecords<Student>();
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            studentBindingSource.DataSource = new List<Student>();
        }
    }
}
