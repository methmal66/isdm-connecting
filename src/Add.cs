using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace isdm_connecting
{
    public partial class Add : Form
    {
        public Add()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private Add clearForm()
        {
            this.idField.Text = "";
            this.nameField.Text = "";
            this.ageField.Text = "";
            this.gpaField.Text = "";
            this.addressField.Text = "";
            return this;
        }

        private Add populateDataGridView()
        {
            DataTable table = new DB().getTable("select * from Student");
            this.dataGridView.ReadOnly = true;
            this.dataGridView.DataSource = table;
            return this;
        }

        private void Add_Load(object sender, EventArgs e)
        {
            populateDataGridView();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {          
           bool success = new Student()
                .setId(int.Parse(this.idField.Text))
                .setName(this.nameField.Text)
                .setAge(int.Parse(this.ageField.Text))
                .setGpa(float.Parse(this.gpaField.Text))
                .setAddress(this.addressField.Text)
                .insert();
            
            if (success)
            {
                string message = "Record inserted Successfully";
                string caption = "Insert new student";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearForm().populateDataGridView();
            }
            else
            {
                string message = "Failed to insert new record";
                string caption = "Insert new student";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            clearForm();
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            string message = "Do you really want to delete the selected Student?";
            string caption = "Delete student";
            DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                bool success = Student.delete(int.Parse(this.idField.Text));
                message = success ? "Student was deleted successfully!" : "Failed to delete Student";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearForm().populateDataGridView();
            }
            
        }
    }
}
