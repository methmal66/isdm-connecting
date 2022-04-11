using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace isdm_connecting
{
    public partial class Add : Form
    {
        public Add()
        {
            InitializeComponent();
        }

        private void Add_Load(object sender, EventArgs e)
        {
            DB db = new DB();
            DataTable table = db.getTable("select * from Student");
            this.dataGridView.ReadOnly = true;
            this.dataGridView.DataSource = table;
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            
           bool success = new Student()
                .setId(int.Parse(this.idField.Text))
                .setName(this.nameField.Text)
                .setAge(int.Parse(this.ageField.Text))
                .setAddress(this.addressField.Text)
                .addToDatabase();

            
            if (success)
            {
                string message = "Record Added Successfully";
                string caption = "Add new student";
                MessageBoxIcon icon = MessageBoxIcon.Information;
                MessageBox.Show(message, caption, MessageBoxButtons.OK, icon);
            }
            else
            {
                string message = "Failed to add record";
                string caption = "Add new student";
                MessageBoxIcon icon = MessageBoxIcon.Error;
                MessageBox.Show(message, caption, MessageBoxButtons.OK, icon);
            }
        }
    }
}
