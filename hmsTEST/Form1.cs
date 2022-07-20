using System.Data;
using System.Data.SqlClient;

namespace hmsTEST
{
    public partial class Form1 : Form
    {
        string connectionString = "Server=(LocalDB)\\LocalDBDemo;Database=staff;Trusted_Connection=True;";
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSave(object sender, EventArgs e)
        {
            try
            {
                String name = txtName.Text;
                String ID = txtID.Text;
                String adress = txtAdress.Text;
                String occupation = txtOccupation.Text;

                SqlConnection con = new SqlConnection(connectionString);

                String query = "INSERT INTO dbo.staffData (name,ID,adress,occupation) VALUES (@name,@ID,@adress, @occupation)";

                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@adress", adress);
                command.Parameters.AddWithValue("@occupation", occupation);
                con.Open();
                command.ExecuteNonQuery();

                data();
                txtName.Clear();
                txtID.Clear();
                txtAdress.Clear();
                txtOccupation.Clear();
           
                MessageBox.Show("Data Stored.");
            }
            catch(Exception)
            {
                MessageBox.Show("Error");
            }
            

        }
        private void data()
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = "SELECT TOP (1000)  [name],[ID],[adress] from staffData";
            con.Open();
            SqlCommand command = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();

            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void formLoad(object sender, EventArgs e)
        {
            data();

        }

        private void removeStaff(object sender, EventArgs e)
        {
          
            int id = Int32.Parse(txtRemove.Text);
            SqlConnection con = new SqlConnection(connectionString);
            string query = "DELETE FROM  staffData " + " WHERE [ID]" + " = '" + id + "'";
            con.Open();
            SqlCommand sqlCommand = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds;
            con.Close();
            data();

            MessageBox.Show("Staff member removed.");
        }
    }
}