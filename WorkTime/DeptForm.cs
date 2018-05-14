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
	public partial class DeptForm : Form
	{
		SqlConnection SqlConnection;
		string connection = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\WorkTimeTableDB.mdf;Integrated Security = True";

		public DeptForm()
		{
			InitializeComponent();
			dataGridView1.Visible = false;
			label3.Text = "";
		}

		// Добавление новой записи:
		private void buttonInsert_Click(object sender, EventArgs e)
		{
			if (textBox1.Text == "" || textBox2.Text == "")
			{
				label3.Text = "Заполните поля";
			}
			else
			{
				SqlCommand command = null;
				SqlDataReader sqlReader = null;

				try
				{
                    SqlConnection = new SqlConnection(connection);
                    SqlConnection.Open();

                    // проверка на совпадение:
                    string select = "SELECT (dept_id) FROM [Departments] WHERE (dept_id)=@dept_id";
					command = new SqlCommand(select, SqlConnection);
					command.Parameters.AddWithValue("dept_id", textBox1.Text);
					sqlReader = command.ExecuteReader();
					int count = 0;
					while (sqlReader.Read())
					{
						count++;
					}
					sqlReader.Close();
					if (count == 0)
					{
						string insert = "INSERT INTO [Departments] (dept_id, department) VALUES(@dept_id, @department)";
						command = new SqlCommand(insert, SqlConnection);
						command.Parameters.AddWithValue("dept_id", textBox1.Text);
						command.Parameters.AddWithValue("department", textBox2.Text);
						command.ExecuteNonQuery();

						label3.Text = "Запись добавлена";
					}
					else
					{
						label3.Text = "Запись уже существует";
					}
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
		}

		// Обновление записи:
		private void buttonUpdate_Click(object sender, EventArgs e)
		{
			if (textBox1.Text == "" || textBox2.Text == "")
			{
				label3.Text = "Заполните поля";
			}
			else
			{
				SqlCommand command = null;
				SqlDataReader sqlReader = null;

				try
				{
                    SqlConnection = new SqlConnection(connection);
                    SqlConnection.Open();

                    // проверка на наличие:
                    string select = "SELECT (dept_id) FROM [Departments] WHERE (dept_id)=@dept_id";
					command = new SqlCommand(select, SqlConnection);
					command.Parameters.AddWithValue("dept_id", textBox1.Text);
					sqlReader = command.ExecuteReader();
					int count = 0;
					while (sqlReader.Read())
					{
						count++;
					}
					sqlReader.Close();
					if (count != 0)
					{
						string insert = "UPDATE [Departments] SET department = @department WHERE dept_id=@dept_id";
						command = new SqlCommand(insert, SqlConnection);
						command.Parameters.AddWithValue("dept_id", textBox1.Text);
						command.Parameters.AddWithValue("department", textBox2.Text);
						command.ExecuteNonQuery();

						label3.Text = "Запись обновлена";
					}
					else
					{
						label3.Text = "Записи не существует";
					}
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
		}

		// Вывод данных таблицы:
		private void buttonShow_Click(object sender, EventArgs e)
		{
			SqlCommand command = null;
			try
			{
                SqlConnection = new SqlConnection(connection);
                SqlConnection.Open();

                string select = "SELECT * FROM Departments";
				command = new SqlCommand(select, SqlConnection);

				DataTable dt = new DataTable();
				dt.Load(command.ExecuteReader());
				dataGridView1.DataSource = dt;
				dataGridView1.Visible = true;
				dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			}
			catch (Exception ex)
			{
				label3.Text = ex.Message.ToString();
			}
			finally
			{
				if (SqlConnection != null && SqlConnection.State != ConnectionState.Closed)
				{
					SqlConnection.Close();
				}
			}

		}

		private void DeptForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (SqlConnection != null && SqlConnection.State != ConnectionState.Closed)
			{
				SqlConnection.Close();
			}
		}
	}
}
