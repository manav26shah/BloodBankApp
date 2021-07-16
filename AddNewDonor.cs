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
    public partial class AddNewDonor : Form
    {
        function fn = new function();
        public AddNewDonor()
        {
            InitializeComponent();
        }

       

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddNewDonor_Load(object sender, EventArgs e)
        {
            String query = "select max(did) from newDonor";
            DataSet ds = fn.getData(query);
            //int temp = 5;
            int count = int.Parse(ds.Tables[0].Rows[0][0].ToString());
            count++;
            labelNewID.Text = count.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtName.Text != "" && txtFName.Text != "" && txtMName.Text != "" && txtDOB.Text != "" && txtMobile.Text != ""
                && txtGender.Text != "" && txtEmail.Text != "" && txtBloodGroup.Text != "" && txtCity.Text != "" && txtAddress.Text != "")
            {
                String dname = txtName.Text;
                String fname = txtFName.Text;
                String mname = txtMName.Text;
                String dob = txtDOB.Text;
                Int64 mobile = Int64.Parse(txtMobile.Text);
                String gender = txtGender.Text;
                String email = txtEmail.Text;
                String bg = txtBloodGroup.Text;
                String city = txtCity.Text;
                String address = txtAddress.Text;

                String query = "insert into newDonor (dname, fname, mname, dob, mobile, gender, email, bloodgroup, city, daddress) values ('"+dname+"', '"+fname+ "', '" + mname + "','" + dob + "', '" + mobile + "', '" + gender + "', '" + email + "', '" + bg + "', '" + city + "', '" + address + "')";
                fn.setData(query);
            }
            else
            {
                MessageBox.Show("Fill all Fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
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
}
