using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CursProj
{
    public partial class LateStudents : Form
    {

        private SqlConnection sqlConnection = null;
        private SqlDataAdapter sqlDataAdapterCourse = null;
        private SqlDataAdapter sqlDataAdapterStudent = null;
        private SqlCommandBuilder sqlCommandBuilder = null;
        private BindingSource bindingSource = null;
        private String selectQueryString = null;
        private DataTable groupDataTable = null;
        private DataTable studentDataTable = null;

        public LateStudents()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Late_Students", sqlConnection);

            //specify that it is a stored procedure and not a normal proc
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            //list the parameters required and what they should be
            cmd.Parameters.AddWithValue("@id_group", dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].Value.ToString());
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Student_Name", typeof(string));
            dt.Columns.Add("Course", typeof(string));
            dt.Columns.Add("Average_Mark", typeof(string));
            do
            {
                while (reader.Read())
                {
                    dt.Rows.Add
                    (
                    reader["Student_Name"].ToString(),
                    reader["Course"].ToString(),
                    reader["Average_Mark"].ToString()
                    );
                }
            } while (reader.NextResult());
            dataGridView2.DataSource = dt;
            reader.Close();
        }

        private void LateStudents_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(SQLAdapter.connectionString);
            selectQueryString = "SELECT * FROM Group_Stud";

            sqlConnection.Open();

            sqlDataAdapterCourse = new SqlDataAdapter(selectQueryString, sqlConnection);
            sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapterCourse);

            groupDataTable = new DataTable();
            sqlDataAdapterCourse.Fill(groupDataTable);
            bindingSource = new BindingSource();
            bindingSource.DataSource = groupDataTable;

            dataGridView1.DataSource = bindingSource;

            // if you want to hide Identity column
            dataGridView1.Columns[0].Visible = false;
        }
    }
}
