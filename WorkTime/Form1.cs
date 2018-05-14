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

namespace WorkTime
{
	public partial class TimeTable : Form
	{
		SqlConnection SqlConnection;
		string connection = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\WorkTimeTableDB.mdf;Integrated Security = True";

		public TimeTable()
		{
			InitializeComponent();
			FillDeptCombo();
			label3.Text = "";
			dataGridView1.Visible = false;
		}

		void FillDeptCombo()
		{
            SqlCommand command = null;
            SqlDataReader sqlReader = null;

            try
			{
                SqlConnection = new SqlConnection(connection);
                SqlConnection.Open();

                command = new SqlCommand("select [department] from [Departments]", SqlConnection);

                string res = "";
				sqlReader = command.ExecuteReader();
				while (sqlReader.Read())
				{
					res = Convert.ToString(sqlReader["department"]);
					comboBox1.Items.Add(res);
				}
				sqlReader.Close();

			}
			catch (Exception ex)
			{
				ex.Message.ToString();
			}
			finally
			{
				if (sqlReader != null)
				{
					sqlReader.Close();
				}
				if (SqlConnection != null && SqlConnection.State != ConnectionState.Closed)
				{
					SqlConnection.Close();
				}
			}
		}

		private void ShowButton_Click(object sender, EventArgs e)
		{
            label3.Text = "";

            string month = comboBox2.Text;
			SqlCommand command = null;
			SqlDataReader sqlReader = null;

			try
			{
                SqlConnection = new SqlConnection(connection);
                SqlConnection.Open();

                string dept_id = "SELECT (dept_id) FROM [Departments] WHERE (department)=@department";
				command = new SqlCommand(dept_id, SqlConnection);
				command.Parameters.AddWithValue("department", comboBox1.Text);
				sqlReader = command.ExecuteReader();
				while (sqlReader.Read())
				{
					dept_id = Convert.ToString(sqlReader["dept_id"]).TrimEnd();
				}
				sqlReader.Close();

				string select = "SELECT * FROM Employees e JOIN " + comboBox2.Text + " m ON e.emp_id=m.emp_id WHERE e.dept_id = " + dept_id;
				command = new SqlCommand(select, SqlConnection);

				DataTable dt = new DataTable();
				dt.Load(command.ExecuteReader());
				dataGridView1.DataSource = dt;
				dataGridView1.Columns["position"].Visible = false;
				dataGridView1.Columns["period"].Visible = false;
				dataGridView1.Columns["dept_id"].Visible = false;
				dataGridView1.Columns["emp_id1"].Visible = false;
				dataGridView1.Visible = true;
				dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;


			}
			catch (Exception ex)
			{
				label3.Text = ex.Message.ToString();
			}
			finally
			{
				if (sqlReader != null)
				{
					sqlReader.Close();
				}
				if (SqlConnection != null && SqlConnection.State != ConnectionState.Closed)
				{
					SqlConnection.Close();
				}
			}
		}

		private void TimeTable_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (SqlConnection != null && SqlConnection.State != ConnectionState.Closed)
			{
				SqlConnection.Close();
			}
		}

		private void Deptbutton_Click(object sender, EventArgs e)
		{
			DeptForm deptForm = new DeptForm();
			deptForm.Show();
		}

		private void EmpButton_Click(object sender, EventArgs e)
		{
			EmpForm empForm = new EmpForm();
			empForm.Show();
		}

		private void buttonbuttonRefresh_Click(object sender, EventArgs e)
		{
			comboBox1.Items.Clear();
			FillDeptCombo();
		}
	}
}
