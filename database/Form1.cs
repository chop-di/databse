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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            name.Text = "Введите имя";
            surname.Text = "Введите фамилию";
            textBox1.Text = "Введите логин";
            textBox2.Text= "Введите пароль";

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
             Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void name_Enter(object sender, EventArgs e)
        {
            if(name.Text=="Введите имя")

            name.Text = "";
            name.ForeColor = Color.Black;
        }

        private void name_Leave(object sender, EventArgs e)
        {
            if (name.Text == "")
            {
                name.Text = "Введите имя";
                name.ForeColor = Color.Gray;

            }    
                
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void surname_TextChanged(object sender, EventArgs e)
        {

        }

        private void surname_Enter(object sender, EventArgs e)
        {
            if (surname.Text == "Введите фамилию")

                surname.Text = "";
            surname.ForeColor = Color.Black;
        }

        private void surname_Leave(object sender, EventArgs e)
        {
            if (surname.Text == "")
            {
                surname.Text = "Введите фамилию";
                surname.ForeColor = Color.Gray;

            }

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Введите логин")

                textBox1.Text = "";
            textBox1.ForeColor = Color.Black;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Введите логин";
                textBox1.ForeColor = Color.Gray;

            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Введите пароль")

                textBox2.Text = "";
            textBox2.ForeColor = Color.Black;
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Введите пароль";
                textBox2.ForeColor = Color.Gray;

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (name.Text == "Введите имя")
            {
                MessageBox.Show("Введите имя");
                return;
            }
            if (surname.Text == "Введите фамилию")
            {
                MessageBox.Show("Введите фамилию");
                return;
            }

            if (textBox1.Text == "Введите логин")
            {
                MessageBox.Show("Введите логин");
                return;
            }

            if (textBox2.Text == "Введите пароль")
            {
                MessageBox.Show("Введите пароль");
                return;
            }

           if (checkUser())
            {
                return; 
            }

            database db = new database();
            MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`login`, `pass`, `name`, `surname`) VALUES ( @login, @pass, @name , @surname) ", db.getConnection()) ;
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textBox2.Text;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name.Text;
            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = surname.Text;


            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Аккаунт был успешно создан.");
            }

            else
            {
                MessageBox.Show("Аккаунт не создан.");
            }


            db.closeConnection();

        }
         
            

        public Boolean checkUser()
        {
            database db = new database();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE  `login` =@Ul  ", db.getConnection());
            command.Parameters.Add("@Ul", MySqlDbType.VarChar).Value = textBox1.Text;

        

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)

            {
                MessageBox.Show("Такой логин уже существует, введите другой.");
                    return true;
            }
                 

            else

                return false;

        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            login login = new login();
            login.Show();
        }
    }

}
