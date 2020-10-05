﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krunsj_V1
{
    public partial class Officiallogin : Form
    {

       

        public Officiallogin()
        {

            
            InitializeComponent();

           
        }
        public Officiallogin(bool doNotMakeInvisibile)
        {                  
               InitializeComponent();                       
        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register Register = new Register();
            Register.ShowDialog();
                        
        }


        


        private void btnLogin_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            String username = txtUsername.Text;
            String password = txtPassword.Text;

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `username` = @usn and `password` = @pass", db.GetConnection());

            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;

            adapter.SelectCommand = command;

            adapter.Fill(table);
            

            // check if there user exists or not 
            if (table.Rows.Count > 0)
            {
                Application.Exit();
                Mainwindow main = new Mainwindow(true);
                main.Visibility = System.Windows.Visibility.Visible;
                main.ShowDialog();
            }
            else
            {
                if(username.Trim().Equals(""))
                {
                    MessageBox.Show("Vul je gebruikersnaam in om in te loggen!", "Lege gebruikersnam", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (password.Trim().Equals(""))
                {
                    MessageBox.Show("Vul je wachtwoord in om in te loggen!", "Lege wachtwoord", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Oei, er klopt iets niet!", "Vul gegevens in", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            
        } 

        

        private void txtPassword_OnValueChanged(object sender, EventArgs e)
        {
            txtPassword.isPassword = true;
            
        }

        //////////////////////////////
        // close button properties  //
        //////////////////////////////
        private void lblclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void lblclose_MouseEnter(object sender, EventArgs e)
        {
            lblclose.ForeColor = Color.Black;

        }
        //////////////////////////////
        // btnsignup properties  //
        //////////////////////////////
        private void lblclose_MouseLeave(object sender, EventArgs e)
        {
            lblclose.ForeColor = Color.Purple;

        }

        private void bunifuCustomLabel1_MouseEnter(object sender, EventArgs e)
        {
            bunifuCustomLabel1.ForeColor = Color.MediumPurple;
        }

        private void bunifuCustomLabel1_MouseLeave(object sender, EventArgs e)
        {
            bunifuCustomLabel1.ForeColor = Color.Purple;
        }
        //////////////////////////////
        // Btnhelpenondersteuning properties  //
        //////////////////////////////
        private void bunifuCustomLabel2_MouseEnter(object sender, EventArgs e)
        {
            bunifuCustomLabel2.ForeColor = Color.MediumPurple;
        }

        private void bunifuCustomLabel2_MouseLeave(object sender, EventArgs e)
        {
            bunifuCustomLabel2.ForeColor = Color.Purple;
        }
    }
}
