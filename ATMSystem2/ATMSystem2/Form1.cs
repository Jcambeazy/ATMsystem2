using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATMSystem2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("server=localhost;database=ATMsys;UID=sa;password=123456789");
                SqlCommand cmd = new SqlCommand("select * from UserLogins where UserName=@UserName and Password=@Password", con);
                cmd.Parameters.AddWithValue("@UserName", Username.Text);
                cmd.Parameters.AddWithValue("@Password", Passwd.Text);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                con.Open();
                con.Close();

                if (dt.Rows.Count > 0)
                {
                    SettingsForm WelcomePage = new SettingsForm();

                    Hide();
                    WelcomePage.ShowDialog();
                    Close();
                }
                else
                {
                    MessageBox.Show("Wrong User Info");


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
