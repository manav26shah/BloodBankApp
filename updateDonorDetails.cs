using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBankApp
{
    public partial class updateDonorDetails : Form
    {
        function fn = new function();
        public updateDonorDetails()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtDonorID.Text.ToString());
            String query = "select * from newDonor where did = " + id + "";
            DataSet ds = fn.getData(query);
                
            if(ds.Tables[0].Rows.Count != 0)
            {
                txtName.Text = ds.Tables[0].Rows[0][1].ToString();
                txtFName.Text = ds.Tables[0].Rows[0][2].ToString();
                txtMName.Text = ds.Tables[0].Rows[0][3].ToString();
                txtDOB.Text = ds.Tables[0].Rows[0][4].ToString();
                txtMobile.Text = ds.Tables[0].Rows[0][5].ToString();
                txtGender.Text = ds.Tables[0].Rows[0][6].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0][7].ToString();
                txtBloodGroup.Text = ds.Tables[0].Rows[0][8].ToString();
                txtCity.Text = ds.Tables[0].Rows[0][9].ToString();
                txtAddress.Text = ds.Tables[0].Rows[0][10].ToString();
            }
            else
            {
                MessageBox.Show("Invalid ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDonorID_TextChanged(object sender, EventArgs e)
        {
            if(txtDonorID.Text == "")
            {
                txtName.Clear();
                txtFName.Clear();
                txtMName.Clear();
                txtDOB.ResetText();
                txtMobile.Clear();
                txtGender.ResetText();
                txtEmail.Clear();
                txtBloodGroup.ResetText();
                txtCity.Clear();
                txtAddress.Clear();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtDonorID.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String query = "update newDonor set dname = '" + txtName.Text + "', fname = '" + txtFName.Text + "',mname =  '" + txtMName.Text + "',dob = '" + txtDOB.Text + "',mobile = '" + txtMobile.Text + "',gender = '" + txtGender.Text + "',email =  '" + txtEmail.Text + "',bloodgroup = '" + txtBloodGroup.Text + "',city = '" + txtCity.Text + "',daddress = '" + txtAddress.Text + "' where did = " + txtDonorID.Text +"";
            fn.setData(query);
            updateDonorDetails_Load(this, null);
        }

        private void updateDonorDetails_Load(object sender, EventArgs e)
        {
            txtDonorID.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtDonorID.Text == "" || txtName.Text=="")
            {
                MessageBox.Show("Please enter valid ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                String query = "delete from newDonor where did = " + txtDonorID.Text + "";
                fn.setData(query);
                updateDonorDetails_Load(this, null);
            }
        }
    }
}
