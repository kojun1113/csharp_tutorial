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

namespace WindowsFormsApp15
{
    public partial class Form1 : Form
    {
        public SqlConnection sqlConnection = null;
        public string connectionstring;
        public SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "해제";
        }



        // 서버 연결
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                builder.DataSource = @"DESKTOP-SDES1A8\SQLEXPRESS";    // 서버 이름  // 걍 microsoft sql server manage studio  에 나온 이름을 따오면 된다
                builder.InitialCatalog = textBox4.Text;                // DB 이름
                builder.UserID = textBox2.Text;
                builder.Password = textBox3.Text;
                connectionstring = builder.ConnectionString;


                sqlConnection = new SqlConnection(connectionstring);
               
                textBox1.Text = "연결";

                MessageBox.Show("서버 연결");
            }

            catch(Exception exception)
            {
                MessageBox.Show($"{exception.Message} caughted");
            }

        }

        // 디비 해제
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                sqlConnection.Close();
                MessageBox.Show("디비 해제");
            }
            catch (Exception exception)
            {
                MessageBox.Show($"{exception.Message} caughted");
            }
        }

        // 서버 해제
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                sqlConnection.Dispose();
                sqlConnection = null;
                textBox1.Text = "해제";
                MessageBox.Show("서버 해제");
            }
            catch (Exception exception)
            {
                MessageBox.Show($"{exception.Message} caughted");
            }
        }

        // 디비 연결
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                sqlConnection.Open();
                MessageBox.Show("디비 연결");
            }
            catch (Exception exception) {
                MessageBox.Show($"{exception.Message} caughted");
            }

        }
    }
}
