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

namespace Lab03
{
    public partial class Login : Form
    {
        SqlConnection conn;
        public Login(SqlConnection conn)
        {
            this.conn = conn;
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (conn.State == ConnectionState.Open)
            {
                String usuario = txtUsuario.Text;
                String password = txtPassword.Text;
                String sql = "SELECT * FROM tbl_usuario where usuario_nombre = '" + usuario + "' and usuario_password = '" + password + "'";
                //String sql = "Select * from tbl_usuario where usuario_nombre = 'rdmf' and usuario_password = 'pw12'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    MessageBox.Show(reader.HasRows.ToString() + ", El usuario existe");
                    var values = new Object[reader.FieldCount];
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    dataGridView1.DataSource = dt;
                    dataGridView1.Refresh();
                    reader.Close();
                }
                else
                {
                    MessageBox.Show(reader.HasRows.ToString() + ", No hay datos");
                    reader.Close();
                } 
            }
            else
            {
                MessageBox.Show("La conexión está cerrada");
            }
        }
    }
}
