using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AccesoBaseDatos1
{
    public partial class Form1 : Form
    {
        private string mySQLServidor = "localhost";
        private string mySQLBasedatos = "ESCOLAR";
        private string mySQLUsuarioId = "root";
        private string mySQLPassword = "berenice";

        private string sqlServerServidor = @"DESKTOP-9S7MKPO\SQLEXPRESS2022";
        private string sqlServerBasedatos = "ESCOLAR";
        private string sqlServerUsuarioId = "sa";
        private string sqlServerPassword = "berenice";

        public  Form1()
        {
            InitializeComponent();
            chkMySQL.Checked = true;
            chkSQLServer.Checked = true;
        }

        private void EjecutarEnTodasLasBases(Action<IDbConnection> accion)
        {
            if (chkMySQL.Checked)
            {
                try
                {
                    string strConn = $"Server={mySQLServidor};Database={mySQLBasedatos};User Id={mySQLUsuarioId};Password={mySQLPassword};";
                    using (var conn = new MySqlConnection(strConn))
                    {
                        conn.Open();
                        accion(conn);
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"MySQL Error: {ex.Message}");
                }
            }

            if (chkSQLServer.Checked)
            {
                try
                {
                    string strConn = $"Server={sqlServerServidor};Database={sqlServerBasedatos};User Id={sqlServerUsuarioId};Password={sqlServerPassword};";
                    using (var conn = new SqlConnection(strConn))
                    {
                        conn.Open();
                        accion(conn);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"SQL Server Error: {ex.Message}");
                }
            }
        }

        private void LlenarGrid()
        {
            try
            {
                if (chkMySQL.Checked)
                {
                    string strConn = $"Server={mySQLServidor};Database={mySQLBasedatos};User Id={mySQLUsuarioId};Password={mySQLPassword};";
                    using (var conn = new MySqlConnection(strConn))
                    {
                        conn.Open();
                        string sqlQuery = "SELECT * FROM Alumnos";
                        MySqlDataAdapter adp = new MySqlDataAdapter(sqlQuery, conn);
                        DataSet ds = new DataSet();
                        adp.Fill(ds, "Alumnos");
                        dgvAlumnos.DataSource = ds.Tables[0];
                    }
                }
                else if (chkSQLServer.Checked)
                {
                    string strConn = $"Server={sqlServerServidor};Database={sqlServerBasedatos};User Id={sqlServerUsuarioId};Password={sqlServerPassword};";
                    using (var conn = new SqlConnection(strConn))
                    {
                        conn.Open();
                        string sqlQuery = "SELECT * FROM Alumnos";
                        SqlDataAdapter adp = new SqlDataAdapter(sqlQuery, conn);
                        DataSet ds = new DataSet();
                        adp.Fill(ds, "Alumnos");
                        dgvAlumnos.DataSource = ds.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnCrearBD_Click(object sender, EventArgs e)
        {
            if (chkMySQL.Checked)
            {
                try
                {
                    string strConn = $"Server={mySQLServidor};User Id={mySQLUsuarioId};Password={mySQLPassword};";
                    using (var conn = new MySqlConnection(strConn))
                    {
                        conn.Open();

                        var cmdCheck = new MySqlCommand($"SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = 'ESCOLAR'", conn);
                        var exists = cmdCheck.ExecuteScalar() != null;

                        if (exists)
                        {
                            MessageBox.Show("La base de datos MySQL 'ESCOLAR' ya existe");
                        }
                        else
                        {
                            var cmdCreate = new MySqlCommand("CREATE DATABASE ESCOLAR", conn);
                            cmdCreate.ExecuteNonQuery();
                            MessageBox.Show("Base de datos MySQL creada exitosamente");
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"MySQL Error: {ex.Message}");
                }
            }

            if (chkSQLServer.Checked)
            {
                try
                {
                    string strConn = $"Server={sqlServerServidor};Database=master;User Id={sqlServerUsuarioId};Password={sqlServerPassword};";
                    using (var conn = new SqlConnection(strConn))
                    {
                        conn.Open();

                        var cmdCheck = new SqlCommand($"SELECT name FROM master.dbo.sysdatabases WHERE name = 'ESCOLAR'", conn);
                        var exists = cmdCheck.ExecuteScalar() != null;

                        if (exists)
                        {
                            MessageBox.Show("La base de datos SQL Server 'ESCOLAR' ya existe");
                        }
                        else
                        {
                            var cmdCreate = new SqlCommand("CREATE DATABASE ESCOLAR", conn);
                            cmdCreate.ExecuteNonQuery();
                            MessageBox.Show("Base de datos SQL Server creada exitosamente");
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Error de SQL Server: {ex.Message}");
                }
            }
        }

        private void btnCrearTabla_Click(object sender, EventArgs e)
        {
            EjecutarEnTodasLasBases(conn =>
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "CREATE TABLE Alumnos (NoControl varchar(10), Nombre varchar(50), Carrera int)";
                cmd.ExecuteNonQuery();
                MessageBox.Show($"Tabla creada en {(conn is MySqlConnection ? "MySQL" : "SQL Server")}");
            });
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNoControl.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtCarrera.Text))
            {
                MessageBox.Show("Todos los campos son requeridos");
                return;
            }

            EjecutarEnTodasLasBases(conn =>
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO Alumnos (NoControl, Nombre, Carrera) VALUES (@NoControl, @Nombre, @Carrera)";

                if (conn is MySqlConnection)
                {
                    ((MySqlCommand)cmd).Parameters.AddWithValue("@NoControl", txtNoControl.Text);
                    ((MySqlCommand)cmd).Parameters.AddWithValue("@Nombre", txtNombre.Text);
                    ((MySqlCommand)cmd).Parameters.AddWithValue("@Carrera", txtCarrera.Text);
                }
                else
                {
                    ((SqlCommand)cmd).Parameters.AddWithValue("@NoControl", txtNoControl.Text);
                    ((SqlCommand)cmd).Parameters.AddWithValue("@Nombre", txtNombre.Text);
                    ((SqlCommand)cmd).Parameters.AddWithValue("@Carrera", txtCarrera.Text);
                }

                cmd.ExecuteNonQuery();
                MessageBox.Show($"Registro insertado en {(conn is MySqlConnection ? "MySQL" : "SQL Server")}");
            });

            LlenarGrid();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvAlumnos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un registro para actualizar");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNoControl.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtCarrera.Text))
            {
                MessageBox.Show("Todos los campos son requeridos");
                return;
            }

            EjecutarEnTodasLasBases(conn =>
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Alumnos SET Nombre = @Nombre, Carrera = @Carrera WHERE NoControl = @NoControl";

                if (conn is MySqlConnection)
                {
                    ((MySqlCommand)cmd).Parameters.AddWithValue("@NoControl", txtNoControl.Text);
                    ((MySqlCommand)cmd).Parameters.AddWithValue("@Nombre", txtNombre.Text);
                    ((MySqlCommand)cmd).Parameters.AddWithValue("@Carrera", txtCarrera.Text);
                }
                else
                {
                    ((SqlCommand)cmd).Parameters.AddWithValue("@NoControl", txtNoControl.Text);
                    ((SqlCommand)cmd).Parameters.AddWithValue("@Nombre", txtNombre.Text);
                    ((SqlCommand)cmd).Parameters.AddWithValue("@Carrera", txtCarrera.Text);
                }

                int rowsAffected = cmd.ExecuteNonQuery();
                MessageBox.Show($"{rowsAffected} registro(s) actualizado(s) en {(conn is MySqlConnection ? "MySQL" : "SQL Server")}");
            });

            LlenarGrid();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvAlumnos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un registro para eliminar");
                return;
            }

            var noControl = dgvAlumnos.SelectedRows[0].Cells["NoControl"].Value.ToString();

            if (MessageBox.Show($"¿Está seguro de eliminar el registro {noControl}?", "Confirmar",
                MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }

            EjecutarEnTodasLasBases(conn =>
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Alumnos WHERE NoControl = @NoControl";

                if (conn is MySqlConnection)
                {
                    ((MySqlCommand)cmd).Parameters.AddWithValue("@NoControl", noControl);
                }
                else
                {
                    ((SqlCommand)cmd).Parameters.AddWithValue("@NoControl", noControl);
                }

                int rowsAffected = cmd.ExecuteNonQuery();
                MessageBox.Show($"{rowsAffected} registro(s) eliminado(s) en {(conn is MySqlConnection ? "MySQL" : "SQL Server")}");
            });

            LlenarGrid();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string criterio = txtBuscar.Text.Trim();
            if (string.IsNullOrWhiteSpace(criterio))
            {
                MessageBox.Show("Ingrese un criterio de búsqueda");
                return;
            }

            try
            {
                
                if (chkMySQL.Checked)
                {
                    string strConn = $"Server={mySQLServidor};Database={mySQLBasedatos};User Id={mySQLUsuarioId};Password={mySQLPassword};";
                    using (var conn = new MySqlConnection(strConn))
                    {
                        conn.Open();
                        string sqlQuery = "SELECT * FROM Alumnos WHERE NoControl LIKE @Criterio OR Nombre LIKE @Criterio";
                        var cmd = new MySqlCommand(sqlQuery, conn);
                        cmd.Parameters.AddWithValue("@Criterio", $"%{criterio}%");

                        MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adp.Fill(ds, "Alumnos");
                        dgvAlumnos.DataSource = ds.Tables[0];
                    }
                }
                else if (chkSQLServer.Checked)
                {
                    string strConn = $"Server={sqlServerServidor};Database={sqlServerBasedatos};User Id={sqlServerUsuarioId};Password={sqlServerPassword};";
                    using (var conn = new SqlConnection(strConn))
                    {
                        conn.Open();
                        string sqlQuery = "SELECT * FROM Alumnos WHERE NoControl LIKE @Criterio OR Nombre LIKE @Criterio";
                        var cmd = new SqlCommand(sqlQuery, conn);
                        cmd.Parameters.AddWithValue("@Criterio", $"%{criterio}%");

                        SqlDataAdapter adp = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adp.Fill(ds, "Alumnos");
                        dgvAlumnos.DataSource = ds.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void dgvAlumnos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAlumnos.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvAlumnos.SelectedRows[0];
                txtNoControl.Text = row.Cells["NoControl"].Value.ToString();
                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtCarrera.Text = row.Cells["Carrera"].Value.ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
    }
}
