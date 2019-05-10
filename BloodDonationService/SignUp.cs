using BloodDonationService.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodDonationService
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }
        SQLHandler sqlH = new SQLHandler();
        private object txtContact;

        private void cBxNewsletter_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (txtFullName.Text == "" || txtIDNumber.Text == "" || txtFullName.Text == "" || txtEmail.Text == "" || txtContactNo.Text == "" || txtLocation.Text == "" || txtUsername.Text == "" || txtPassword.Text == "" || txtConfirmPassword.Text == "")

            {
                MessageBox.Show("Please fill mandatory fields");
            }


            else if(txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Password dont match");

            }

            else
            {
                sqlH.FullName = txtFullName.Text;
                sqlH.IDNumber = Convert.ToInt32(txtIDNumber.Text);
                sqlH.Email = txtEmail.Text;
                sqlH.Contact = txtContactNo.Text;
                sqlH.Location = txtLocation.Text;
                sqlH.Username = txtUsername.Text;
                sqlH.Password = txtPassword.Text;


                //INSERT data into database using the method created (inserted)
                bool Success = sqlH.Insert(sqlH);

                if (Success == true)
                {
                    //successfully created
                    const string message = "New User Successfully Inserted";
                    const string caption = "New User";
                    var result = MessageBox.Show(message, caption, MessageBoxButtons.OK);

                    if (result == DialogResult.OK)
                    {
                        LoginPage lp = new LoginPage();
                        lp.Show();
                        this.Hide();
                    }
                    else
                    {
                        this.Close();

                    }


                }
                else

                {
                    //failed to add new user
                    MessageBox.Show("Failed to add New User. Try again");
                }



            }
        }

        private void Clear()
        {
            txtFullName.Text = "";
            txtIDNumber.Text = "";
            txtEmail.Text = "";
            txtContactNo.Text = "";
            txtLocation.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";


        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            LoginPage frmLoginPage = new LoginPage();
            frmLoginPage.Show();
            this.Hide();
        }
    }
}
