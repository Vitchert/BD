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
    public partial class Attendance : Form
    {

        private SqlConnection sqlConnection = null;
        private SqlDataAdapter sqlDataAdapter = null;
        private SqlCommandBuilder sqlCommandBuilder = null;
        private BindingSource bindingSource = null;
        private String selectQueryString = null;
        private DataTable DataTable = null;

        public Attendance()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable tempDT;
            tempDT = DataTable.GetChanges(DataRowState.Modified);
            if (tempDT != null)
                foreach (DataRow row in tempDT.Rows)
                {
                    try
                    {
                        string sqlQuery = String.Format("update Student_Lesson_Entry set Mark_Les = {4}, Attendance_Les = '{5}' where Id_Stud = {0} and Id_Gr = {1} and Id_Crs = {2} and Number_Les = {3};",
                                                        row[0], row[1], row[2], row[4], row[7], row[8]);
                           
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

        private void Attendance_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(SQLAdapter.connectionString);
            selectQueryString = "select Student_Lesson_Entry.Id_Stud, Student_Lesson_Entry.Id_Gr,  Student_Lesson_Entry.Id_Crs, Course.Name_Crs, Student_Lesson_Entry.Number_Les, Lesson.Type_Les, Lesson.Date_Les, Student_Lesson_Entry.Mark_Les, Student_Lesson_Entry.Attendance_Les, Student.Name_Stud, Group_Stud.Name_Gr " +
                                "from Student_Lesson_Entry " +
                                "left join Course on Course.Id_Crs = Student_Lesson_Entry.Id_Crs " +
                                "left join Group_Stud on Student_Lesson_Entry.Id_Gr = Group_Stud.Id_Gr " +
                                "left join Student on Student_Lesson_Entry.Id_Stud = Student.Id_Stud " +
                                "left join Lesson on (Student_Lesson_Entry.Number_Les = Lesson.Number_Les and Student_Lesson_Entry.Id_Gr = Lesson.Id_Gr and Student_Lesson_Entry.Id_Crs = Lesson.Id_Crs)"+
                                "order by Name_Crs";
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
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].ReadOnly = true;
            dataGridView1.Columns[4].ReadOnly = true;
            dataGridView1.Columns[5].ReadOnly = true;
            dataGridView1.Columns[6].ReadOnly = true;
            dataGridView1.Columns[9].ReadOnly = true;
            dataGridView1.Columns[10].ReadOnly = true;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToAddRows = false;
        }
    }
}
