using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CursProj
{
    public partial class GroupListWindow : Form
    {
        private SqlConnection sqlConnection = null;
        private SqlDataAdapter sqlDataAdapterCourse = null;
        private SqlDataAdapter sqlDataAdapterGroup = null;
        private SqlCommandBuilder sqlCommandBuilder = null;
        private BindingSource bindingSource = null;
        private String selectQueryString = null;
        private DataTable groupDataTable = null;
        private DataTable courseDataTable = null;
        public GroupListWindow()
        {
            InitializeComponent();
        }

        private void GroupListWindow_Load(object sender, EventArgs e)
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

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0 && dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].Value.ToString() != "")
            {
          
                selectQueryString = "select Course.Id_Crs, Course.Name_Crs, Course.ID_Tch " +
                "from Course " +
                "inner join Schedule on Course.Id_Crs = Schedule.Id_Crs " +
                "inner join Group_Stud on Schedule.Id_Gr = Group_Stud.Id_Gr " +
                "where Group_Stud.Id_Gr = " + dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].Value.ToString();

                sqlDataAdapterGroup = new SqlDataAdapter(selectQueryString, sqlConnection);
                sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapterGroup);

                courseDataTable = new DataTable();
                sqlDataAdapterGroup.Fill(courseDataTable);
                bindingSource = new BindingSource();
                bindingSource.DataSource = courseDataTable;

                
                dataGridView2.DataSource = bindingSource;
                label2.Text = "Дисциплины для группы " + dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].Value.ToString();
                dataGridView2.Columns[0].Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable tempDT;
            //Groups
            tempDT = groupDataTable.GetChanges(DataRowState.Added);
            if (tempDT != null)
                foreach (DataRow row in tempDT.Rows)
                {
                    try
                    {
                        string sqlQuery = String.Format("Insert into Group_Stud (Name_Gr, Department_Gr) Values('{0}', '{1}');",
                                                        row[1], row[2]);
                        //Create a Command object
                        SqlCommand command = new SqlCommand(sqlQuery, sqlConnection);
                        command.ExecuteScalar();
                        //Close and dispose
                        command.Dispose();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                        return;
                    }
                }
            tempDT = groupDataTable.GetChanges(DataRowState.Modified);
            if (tempDT != null)
                foreach (DataRow row in tempDT.Rows)
                {
                    try { 
                    string sqlQuery = String.Format("update Group_Stud set Name_Gr = '{1}', Department_Gr = '{2}' where Id_Gr = {0};", row[0], row[1], row[2]);
                    //Create a Command object
                    SqlCommand command = new SqlCommand(sqlQuery, sqlConnection);
                    command.ExecuteScalar();
                    //Close and dispose
                    command.Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                        return;
                    }
                }
            tempDT = groupDataTable.GetChanges(DataRowState.Deleted);
            if (tempDT != null)
                foreach (DataRow row in tempDT.Rows)
                {
                    try {
                        string sqlQuery = String.Format("delete from Schedule where Id_Gr = {0};", row[0, DataRowVersion.Original]);
                        //Create a Command object
                        SqlCommand command = new SqlCommand(sqlQuery, sqlConnection);
                        command.ExecuteScalar();
                        //Close and dispose
                        command.Dispose();

                        sqlQuery = String.Format("delete from Group_Stud where Id_Gr = {0};", row[0, DataRowVersion.Original]);
                        //Create a Command object
                        command = new SqlCommand(sqlQuery, sqlConnection);
                        command.ExecuteScalar();
                        //Close and dispose
                        command.Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                        return;
                    }
                }



            //Courses
            tempDT = courseDataTable.GetChanges(DataRowState.Added);
            if (tempDT != null)
                foreach (DataRow row in tempDT.Rows)
                {
                    try
                    {
                        string sqlQuery = String.Format("Insert into Course (Name_Crs, Id_Tch) Values('{0}', {1});" + " Select @@Identity",
                                                        row[1], row[2]);
                        //Create a Command object
                        SqlCommand command = new SqlCommand(sqlQuery, sqlConnection);
                        int newCourseID = Convert.ToInt32((decimal)command.ExecuteScalar());
                        //Close and dispose
                        command.Dispose();

                        sqlQuery = String.Format("Insert into Schedule (Id_Gr, Id_Crs) Values({0}, {1});",
                                                        dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].Value.ToString(),
                                                        newCourseID);
                        //Create a Command object
                        command = new SqlCommand(sqlQuery, sqlConnection);
                        command.ExecuteScalar();
                        //Close and dispose
                        command.Dispose();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                        return;
                    }
                }
            tempDT = courseDataTable.GetChanges(DataRowState.Modified);
            if (tempDT != null)
                foreach (DataRow row in tempDT.Rows)
                {
                    try {
                        string sqlQuery = String.Format("update Course set Name_Crs = '{1}', ID_Tch = {2} where Id_Crs = {0};", row[0], row[1], row[2]);
                        //Create a Command object
                        SqlCommand command = new SqlCommand(sqlQuery, sqlConnection);
                        command.ExecuteScalar();
                        //Close and dispose
                        command.Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                        return;
                    }
                }
            tempDT = courseDataTable.GetChanges(DataRowState.Deleted);
            if (tempDT != null)
                foreach (DataRow row in tempDT.Rows)
                {
                    try {
                        string sqlQuery = String.Format("delete from Schedule where Id_Crs = {0};", row[0, DataRowVersion.Original]);
                        //Create a Command object
                        SqlCommand command = new SqlCommand(sqlQuery, sqlConnection);
                        command.ExecuteScalar();
                        //Close and dispose
                        command.Dispose();

                        sqlQuery = String.Format("delete from Course where Id_Crs = {0};", row[0, DataRowVersion.Original]);
                        //Create a Command object
                        command = new SqlCommand(sqlQuery, sqlConnection);
                        command.ExecuteScalar();
                        //Close and dispose
                        command.Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                        return;
                    }
                }
        }
    }
}
