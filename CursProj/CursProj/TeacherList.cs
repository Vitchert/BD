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
    public partial class TeacherList : Form
    {
        private SqlConnection sqlConnection = null;
        private SqlDataAdapter sqlDataAdapter = null;
        private SqlCommandBuilder sqlCommandBuilder = null;
        private BindingSource bindingSource = null;
        private String selectQueryString = null;
        private DataTable DataTable = null;

        public TeacherList()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable tempDT;
            //Groups
            tempDT = DataTable.GetChanges(DataRowState.Added);
            if (tempDT != null)
                foreach (DataRow row in tempDT.Rows)
                {
                    try
                    {
                        string sqlQuery = String.Format("Insert into Teacher (Name_Tch, Category_Tch) Values('{0}', '{1}');",
                                                        row[1], row[2]);
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
            tempDT = DataTable.GetChanges(DataRowState.Modified);
            if (tempDT != null)
                foreach (DataRow row in tempDT.Rows)
                {
                    try
                    {
                        string sqlQuery = String.Format("update Teacher set Name_Tch = '{1}', Category_Tch = '{2}' where Id_Tch = {0};", row[0], row[1], row[2]);
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
            tempDT = DataTable.GetChanges(DataRowState.Deleted);
            if (tempDT != null)
                foreach (DataRow row in tempDT.Rows)
                {
                    try
                    {
                        string sqlQuery = String.Format("delete from Teacher where Id_Tch = {0};", row[0, DataRowVersion.Original]);
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
        }

        private void TeacherList_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(SQLAdapter.connectionString);
            selectQueryString = "SELECT * FROM Teacher";

            sqlConnection.Open();

            sqlDataAdapter = new SqlDataAdapter(selectQueryString, sqlConnection);
            sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);

            DataTable = new DataTable();
            sqlDataAdapter.Fill(DataTable);
            bindingSource = new BindingSource();
            bindingSource.DataSource = DataTable;

            dataGridView1.DataSource = bindingSource;

            // if you want to hide Identity column
            dataGridView1.Columns[0].Visible = false;
        }
    }
}
