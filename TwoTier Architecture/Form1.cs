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

namespace TwoTier_Architecture
{
    public partial class txtUserName : Form
    {
        string connectionString = "Server=DESKTOP-7LUIOU2\MSSQLSERVER01; database=SoftwareArchitectureCourse; Integrated Security=true";
        SqlConnection connection;

        public txtUserName()
        {
            InitializeComponent();
             connection = new SqlConnection(connectionString);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string command = "Select * from Users";

            SqlCommand sqlCommand = new SqlCommand(command, connection);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            DataTable dt = new DataTable();

            sqlDataAdapter.Fill(dt);

            dataGridView1.DataSource = dt;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string userFullName = txtFullName.Text;
            string username = textUserName.Text;
            string passwoed = txtPassword.Text;

            string command = $"Insert into Users values('{userFullName}', '{username}', '{passwoed}')";
            SqlCommand sqlCommand = new SqlCommand(command ,connection);

            if(connection.State != ConnectionState.Open)
                 connection.Open();

            sqlCommand.ExecuteNonQuery();

            connection.Close();
        }
    }
}
