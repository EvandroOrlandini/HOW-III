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

namespace clube
{
    public partial class Form1 : Form
    {
        public Form1()
        {
          InitializeComponent();
        }

        private MySqlConnectionStringBuilder conexaoBanco()
        {
            MySqlConnectionStringBuilder conexaoBD = new MySqlConnectionStringBuilder();
            conexaoBD.Server = "localhost";
            conexaoBD.Server.Database = "clube";
            conexaoBD.UserID ="root";
            conexaoBD.Password = "";
            return conexaoBD;
        }

        private void atualizarGrid()
        { 
           MySqlConnectionStringBuilder conexaoBD = conexaoBanco();
           MySqlConnection realizaConexaoBD = new MySqlConnection(conexaoBD.ToString());
            try
            {
                realizaConexaoBD.Open();

                MySqlCommand comandoMySql = realizaConexaoBD.CreateCommand();
                comandoMySql.CommandText = "SELECT * FROM membro";
                MySqlDataReader reader = comandoMySql.ExecuteReader();

                dgClube.Rows.Clear(); 
                //ou membro

                while (reader.Read());
                {
                    DataGridViewRow row = (DataGridViewRow)dgClube.Rows[0].Clone();
                     
                    row.Cells[0].value = reader.GetInt32(0); //ID
                    row.Cells[1].value = reader.GetString(1); //NOME
                    row.Cells[2].value = reader.GetString(2); //TELEFONE
                    row.Cells[3].value = reader.GetString(3); //EMAIL
                    row.Cells[4].value = reader.GetString(4); // AULA
                    row.Cells[5].value = reader.GetString(5); //MENSALIDADE
                    row.CellsCells[6].value = reader.GetString(6); //ATIVO
                    dgClube.Rows.Add(row);
                }
                realizaConexaoBD.Close();
            }

            catch (Exception ex)
            { 
                MessageBox.Show("Can not open connection! ");
            Console.WriteLine(ex Message);

            }
                  
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            atualizarGrid();
        }
    }

   
