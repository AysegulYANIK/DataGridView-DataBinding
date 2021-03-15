using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BindtoDataGridView_Doodle
{
    public enum Gender
    {
        Male,
        Female
    };
    public partial class Form1 : Form
    {

        private DataGridView dataGridView1 = new DataGridView();
        private BindingSource bindingSource1 = new BindingSource();

        public Form1()
        {
            this.Load += new System.EventHandler(EnumsAndComboBox_Load);
        }

        private void EnumsAndComboBox_Load(object sender, System.EventArgs e)
        {
            // Populate the data source.
            bindingSource1.Add(new Knight(Gender.Male, "Smith", true));
            bindingSource1.Add(new Knight(Gender.Male, "Brown", true));
            bindingSource1.Add(new Knight(Gender.Female, "Williams", false));
            bindingSource1.Add(new Knight(Gender.Female, "Andersen", true));
            bindingSource1.Add(new Knight(Gender.Female, "Lee", true));

            // Initialize the DataGridView.
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSize = true;
            dataGridView1.DataSource = bindingSource1;

            dataGridView1.Columns.Add(CreateComboBoxWithEnums());

            // Initialize and add a text box column.
            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Name";
            column.Name = "Family Name";
            dataGridView1.Columns.Add(column);

            // Initialize and add a check box column.
            column = new DataGridViewCheckBoxColumn();
            column.DataPropertyName = "Present";
            column.Name = "Present";
            dataGridView1.Columns.Add(column);

            // Initialize the form.
            this.Controls.Add(dataGridView1);
            this.AutoSize = true;
            this.Text = "Object Binding of DataGridViews";
        }

        DataGridViewComboBoxColumn CreateComboBoxWithEnums()
        {
            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            combo.DataSource = Enum.GetValues(typeof(Gender));
            combo.DataPropertyName = "Gender";
            combo.Name = "Gender";
            return combo;
        }

        private class Knight
        {
            private string h_Name;
            private bool present;
            private Gender h_gender;

            public Knight(Gender gender, string name, bool present)
            {
                h_gender = gender;
                h_Name = name;
                this.present = present;
            }

            public Knight()
            {
                h_gender = Gender.Female;
                h_Name = "<enter name>";
                present = true;
            }

            public string Name
            {
                get
                {
                    return h_Name;
                }

                set
                {
                    h_Name = value;
                }
            }

            public bool Present
            {
                get
                {
                    return present;
                }
                set
                {
                    present = value;
                }
            }

            public Gender Gender
            {
                get
                {
                    return h_gender;
                }
                set
                {
                    h_gender = value;
                }
            }
        }
    }
}
