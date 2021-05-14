﻿using IGXAuthoringToolbar.Controllers;
using System;
using System.Windows.Forms;

namespace IGXAuthoringToolbar.Views
{
    public partial class UserAuthForm : Form
    {
        public UserAuthForm()
        {
            InitializeComponent();
        }

        private void UserAuthForm_Load(object sender, EventArgs e)
        {
            membershipProviderCombo.Items.AddRange(UserAuthController.getMembershipProviders().ToArray());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void usrPasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            passwordTextBox.PasswordChar = '*';

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            UserAuthInput input = new UserAuthInput()
            {
                username = usernameTextBox.Text,
                password = passwordTextBox.Text,
                membershipProvier = membershipProviderCombo.Text
            };

            //sets current user
            UserAuthController.currentUser = input;

            this.Close();
        }
    }
}
