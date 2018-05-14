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
    public partial class EmpForm : Form
    {
        SqlConnection SqlConnection;
        string connection = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\WorkTimeTableDB.mdf;Integrated Security = True";

        public EmpForm()
        {
            InitializeComponent();
            label6.Text = "";
            dataGridView1.Visible = false;
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox5.Text == "")
            {
                label6.Text = "Заполните поля";
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
                    string select = "SELECT (emp_id) FROM [Employees] WHERE (emp_id)=@emp_id";
                    command = new SqlCommand(select, SqlConnection);
                    command.Parameters.AddWithValue("emp_id", textBox1.Text);
                    sqlReader = command.ExecuteReader();
                    int count = 0;
                    while (sqlReader.Read())
                    {
                        count++;
                    }
                    sqlReader.Close();
                    if (count == 0)
                    {
                        // добавление нового сотрудника в таблицу Employees:
                        string insert = "INSERT INTO [Employees] (emp_id, first_name, last_name, position, dept_id) VALUES(@emp_id, @first_name, @last_name, @position, @dept_id)";
                        command = new SqlCommand(insert, SqlConnection);
                        command.Parameters.AddWithValue("emp_id", textBox1.Text);
                        command.Parameters.AddWithValue("first_name", textBox2.Text);
                        command.Parameters.AddWithValue("last_name", textBox3.Text);
                        command.Parameters.AddWithValue("position", textBox4.Text);
                        command.Parameters.AddWithValue("dept_id", textBox5.Text);
                        command.ExecuteNonQuery();

                        // добавление этого сотрудника в таблицы месяцев:
                        List<string> months = new List<string>();
                        months.Add("January");
                        months.Add("February");
                        months.Add("March");
                        months.Add("April");
                        months.Add("May");
                        months.Add("June");
                        months.Add("July");
                        months.Add("August");
                        months.Add("September");
                        months.Add("October");
                        months.Add("November");
                        months.Add("December");

                        foreach (string m in months)
                        {
                            insert = "INSERT INTO [" + m + "] (emp_id) VALUES(@emp_id)";
                            command = new SqlCommand(insert, SqlConnection);
                            command.Parameters.AddWithValue("emp_id", textBox1.Text);
                            command.ExecuteNonQuery();
                        }

                        label6.Text = "Запись добавлена";
                    }
                    else
                    {
                        label6.Text = "Запись уже существует";
                    }
                }
                catch (Exception ex)
                {
                    label6.Text = ex.Message.ToString();
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

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox5.Text == "")
            {
                label6.Text = "Заполните поля";
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
                    string select = "SELECT (emp_id) FROM [Employees] WHERE (emp_id)=@emp_id";
                    command = new SqlCommand(select, SqlConnection);
                    command.Parameters.AddWithValue("emp_id", textBox1.Text);
                    sqlReader = command.ExecuteReader();
                    int count = 0;
                    while (sqlReader.Read())
                    {
                        count++;
                    }
                    sqlReader.Close();
                    if (count != 0)
                    {
                        string insert = "UPDATE [Employees] SET first_name=@first_name, last_name=@last_name, position=@position, dept_id=@dept_id WHERE emp_id=@emp_id";
                        command = new SqlCommand(insert, SqlConnection);
                        command.Parameters.AddWithValue("emp_id", textBox1.Text);
                        command.Parameters.AddWithValue("first_name", textBox2.Text);
                        command.Parameters.AddWithValue("last_name", textBox3.Text);
                        command.Parameters.AddWithValue("position", textBox4.Text);
                        command.Parameters.AddWithValue("dept_id", textBox5.Text);
                        command.ExecuteNonQuery();

                        label6.Text = "Запись обновлена";
                    }
                    else
                    {
                        label6.Text = "Записи не существует";
                    }
                }
                catch (Exception ex)
                {
                    label6.Text = ex.Message.ToString();
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

        private void buttonShow_Click(object sender, EventArgs e)
        {
            SqlCommand command = null;
            try
            {
                SqlConnection = new SqlConnection(connection);
                SqlConnection.Open();

                string select = "SELECT * FROM Employees";
                command = new SqlCommand(select, SqlConnection);

                DataTable dt = new DataTable();
                dt.Load(command.ExecuteReader());
                dataGridView1.DataSource = dt;
                dataGridView1.Visible = true;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
            catch (Exception ex)
            {
                label6.Text = ex.Message.ToString();
            }
            finally
            {
                if (SqlConnection != null && SqlConnection.State != ConnectionState.Closed)
                {
                    SqlConnection.Close();
                }
            }

        }

        private void EmpForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SqlConnection != null && SqlConnection.State != ConnectionState.Closed)
            {
                SqlConnection.Close();
            }
        }
    }
}
