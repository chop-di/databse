using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace database
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String login_user = textBox1.Text;
            String pass_user = textBox2.Text;

            database db = new database();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE  `login` =@Ul  AND  `pass` =@Up", db.getConnection()) ;
            command.Parameters.Add("@Ul", MySqlDbType.VarChar).Value = login_user;

            command.Parameters.Add("@Up", MySqlDbType.VarChar).Value = pass_user;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count  > 0)
            {
                this.Hide();
                home home = new home();
                home.Show();
            }    
            
                

            
            else
            
                MessageBox.Show("No");
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 registerForm = new Form1();
            registerForm.Show();
        }
    }
}
