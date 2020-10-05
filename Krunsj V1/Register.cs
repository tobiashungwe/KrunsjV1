using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Krunsj_V1
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            
        }

        
        //////////////////////////////
        // close button properties  //
        //////////////////////////////
        private void lblclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void lblclose_MouseEnter_1(object sender, EventArgs e)
        {
            lblclose.ForeColor = Color.Black;
        }
        private void lblclose_MouseLeave(object sender, EventArgs e)
        {
            lblclose.ForeColor = Color.Purple;
        }

        /////////////////////////////////////
        // From register screen to login  //
        ////////////////////////////////////

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            //add a new user
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `users`(`username`, `password`, `emailadress`) VALUES (@usn, @pass, @email)", db.GetConnection());

            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = txtusername.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = txtPassword.Text;
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = txtemail.Text;

            //open the connection 
            db.openConnection();

            //check if the textboxes conatins default values
            if(!checkTextBoxesValues() || bunifuCheckbox1.Checked)
            {
                //check if the password equals the confirm password
                if(txtPassword.Text.Equals(txtpasswordconfirm.Text))
                {
                    //check if the username already exists 
                    if (checkUsername())
                    {
                        MessageBox.Show("Deze gebruikersnaam is al gebruikt, kies een andere!", "Oepsie", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                    else
                    {
                        //execute the query
                        if (command.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Je account is succesvol gemaakt", "WE ZIJN ER BIJNA", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Error, er liep iets mis!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Oeie, ik denkt dat je bevestigende wachtwoord verkeerd is?", "Oepsie", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
            }
                
            else
            {
                MessageBox.Show("Vul je informatie Aub in!", "Oepsie", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            

            //close the connection
            db.closeConnection();

            
            

        }

        //check if username already exists
        public Boolean checkUsername()
        {
            DB db = new DB();

            String username = txtusername.Text;
          

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `username` = @usn", db.GetConnection());

            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;
            

            adapter.SelectCommand = command;

            adapter.Fill(table);


            // check if this user already exists in the database
            if (table.Rows.Count > 0)
            {

                return true;
            }
            else
            {
                return false;
            }
            //check if the textboxes contains the default values
            
            
        }
        public Boolean checkTextBoxesValues()
        {
            String uname = txtusername.Text;
            String Pass = txtPassword.Text;
            String email = txtemail.Text;

            if (uname.Equals("Volledige naam") || email.Equals("iemand@voorbeeld.com") || Pass.Equals("Password"))
            {
                return true;
            }
            else
            {
                return false;
            }


        }
        

        /////////////////////////////
        // TXTUSERNAME PROPERTIES  //
        ////////////////////////////
        // COLOR PRPOERTIES
        private void txtusername_Leave(object sender, EventArgs e)
        {
            string username = txtusername.Text;
            if(username.ToLower().Trim().Equals("Volledige naam") || username.Trim().Equals(""))
            {
                txtusername.Text = "Volledige naam";
                txtusername.ForeColor = Color.Gray;
                txtusername.HintForeColor = Color.Gray;
            }
            else
            {
                txtusername.ForeColor = Color.Black;
                txtusername.HintForeColor = Color.Black;
            }
        }

        //VOLLEDIGE NAAM NIET ALS USER
        private void txtusername_OnValueChanged(object sender, EventArgs e)
        {
            string username = txtusername.Text;
            if (username.ToLower().Trim().Equals("Volledige naam") || username.Equals("VOLLEDIGE NAAM"))
            {
                txtusername.Text = "";
                txtusername.ForeColor = Color.Black;
                txtusername.HintForeColor = Color.Black;
            }
        }
        ///////////////////////////////
        // TXTpasssword PROPERTIES  //
        //////////////////////////////
        //password settings

        private void txtPassword_OnValueChanged(object sender, EventArgs e)
        {
            txtPassword.isPassword = true;
            // string Password = txtPassword.Text;
            //
            // if ( Password.Length <= 4)
            //{
            // MessageBox.Show("Je wachtwoord Minimum 5 characters bevatten.");
            //}
        }
        /////////////////////////////////////
        // TXTpassswordconfirm PROPERTIES  //
        /////////////////////////////////////
        //password settings
        private void txtpasswordconfirm_OnValueChanged(object sender, EventArgs e)
        {
          
                txtpasswordconfirm.isPassword = true;
            //string Password = txtpasswordconfirm.Text;

            //if (Password.Length <= 4)
            //{
            //MessageBox.Show("Je wachtwoord Minimum 5 characters bevatten.");
            //}
        }

        ///////////////////////////////
        // See password button       //
        ///////////////////////////////
        private void btnToonwachtwoord_OnChange(object sender, EventArgs e)
        {
            Boolean condition = false;
            if(condition)
            {
                txtpasswordconfirm.isPassword = true;
                txtPassword.isPassword = true;
            }
            else
            {
                txtpasswordconfirm.isPassword = false;
                txtPassword.isPassword = false;
            }
        }

        ///////////////////////////////
        // TXTemail PROPERTIES       //
        ///////////////////////////////
        private void txtemail_OnValueChanged(object sender, EventArgs e)
        {
            string email = txtemail.Text;
            if (email.ToLower().Trim().Equals("iemand@voorbeeld.com") || email.Equals("IEMAND@VOORBEELD.COM"))
            {
                txtemail.Text = "";
                txtemail.ForeColor = Color.Black;
                txtemail.HintForeColor = Color.Black;
            }
        }

        private void txtemail_Leave(object sender, EventArgs e)
        {
            string email = txtemail.Text;
            if (email.ToLower().Trim().Equals("iemand@voorbeeld.com") || email.Trim().Equals(""))
            {
                txtemail.Text = "iemand@voorbeeld.com";
                txtemail.ForeColor = Color.Gray;
                txtemail.HintForeColor = Color.Gray;
            }
            else
            {
                txtemail.ForeColor = Color.Black;
                txtemail.HintForeColor = Color.Black;
            }
        }

        ///////////////////////////////
        // lblToLogin PROPERTIES     //
        ///////////////////////////////
        private void lblToLogin_MouseEnter(object sender, EventArgs e)
        {
            lblToLogin.ForeColor = Color.MediumPurple;
        }

        private void lblToLogin_MouseLeave(object sender, EventArgs e)
        {
            lblToLogin.ForeColor = Color.Purple;
        }

        private void lblToLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Officiallogin Login = new Officiallogin();
            Login.ShowDialog();
        }

        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {
            
                
          
        }
    }
    }

