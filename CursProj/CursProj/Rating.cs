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
    public partial class Rating : Form
    {

        private SqlConnection sqlConnection = null;
        private SqlDataAdapter sqlDataAdapterCourse = null;
        private SqlDataAdapter sqlDataAdapterStudent = null;
        private SqlCommandBuilder sqlCommandBuilder = null;
        private BindingSource bindingSource = null;
        private String selectQueryString = null;
        private DataTable groupDataTable = null;
        private DataTable studentDataTable = null;

        public Rating()
        {
            InitializeComponent();
        }

        private void Rating_Load(object sender, EventArgs e)
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0 && dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].Value.ToString() != "")
            {

                selectQueryString = "select Id_Stud, Name_Stud " +
                "from Student " +
                "where Student.Id_Gr = " + dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].Value.ToString();

                sqlDataAdapterStudent = new SqlDataAdapter(selectQueryString, sqlConnection);
                sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapterStudent);

                studentDataTable = new DataTable();
                sqlDataAdapterStudent.Fill(studentDataTable);
                bindingSource = new BindingSource();
                bindingSource.DataSource = studentDataTable;


                dataGridView2.DataSource = bindingSource;
                //label2.Text = "Дисциплины для группы " + dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].Value.ToString();
                dataGridView2.Columns[0].Visible = false;
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Rating", sqlConnection);

            //specify that it is a stored procedure and not a normal proc
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            //list the parameters required and what they should be
            cmd.Parameters.AddWithValue("@Id_Stud", dataGridView2.Rows[dataGridView2.SelectedCells[0].RowIndex].Cells[0].Value.ToString());
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Course", typeof(string));
            dt.Columns.Add("Student_Rating", typeof(string));
            dt.Columns.Add("Average_Mark", typeof(string));
            do { 
            while (reader.Read())
            {
                dt.Rows.Add
                (
                reader["Course"].ToString(),
                reader["Student_Rating"].ToString(),
                reader["Average_Mark"].ToString()             
                );
            }
            } while (reader.NextResult());
            dataGridView3.DataSource = dt;
            reader.Close();
        }
    }
}
