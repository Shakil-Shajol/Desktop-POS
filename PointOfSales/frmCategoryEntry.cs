using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSales
{
    public partial class frmCategoryEntry : Form
    {
        public frmCategoryEntry()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCategoryName.Text!="")
                {
                    Category cate = new Category(txtCategoryName.Text, txtCategoryDescription.Text);
                    cate.InsertCategory();
                    ClearForm();
                }
                else
                {
                    throw new Exception("Category name can't be empty.");
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            
        }

        private void ClearForm()
        {
            txtCategoryName.Clear();
            txtCategoryDescription.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
