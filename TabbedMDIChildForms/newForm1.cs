using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TabbedMDIChildForms
{
    public partial class newForm1 : Form
    {
        public newForm1()
        {
            InitializeComponent();
        }

        private void newForm1_Load(object sender, EventArgs e)
        {
            //string conStr = "Data Source=localhost;Initial Catalog=QL_SinhVien;Persist Security Info=True;User ID=sa;Password=150280";
            //SqlConnection conn = new SqlConnection(conStr);
            //SqlCommand command = new SqlCommand();
            //command.Connection = conn;
            //command.CommandType = CommandType.StoredProcedure;
            //command.CommandText = "LayDSSinhVien";

            //SqlParameter para = new SqlParameter();
            //para.ParameterName = "@Ten";
            //para.Value = "H";
            //command.Parameters.Add(para);



            //// string sSql = "SELECT * FROM SINHVIEN";
            //SqlDataAdapter myDataAdapter = new SqlDataAdapter(command);
            //DataSet myDataSet = new DataSet();
            //myDataAdapter.Fill(myDataSet, "SV");
            //DataTable myTable = myDataSet.Tables["SV"];            //dataGridView1.DataSource = myTable;
            dataGridView1.AutoGenerateColumns = false;
            DataTable dt = connectionSQL.GetDataTable("LayDSSinhVien", new object[] { "H" });
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SinhVien a = new SinhVien(tbMaSV.Text);
            a.HoDem = tbTenSV.Text;

            connectionSQL.ExecuteQuery("CapNhatTenSinhVien", new object[] { tbMaSV.Text, tbTenSV.Text });
            dataGridView1.DataSource = connectionSQL.GetDataTable("LayDSSinhVien", new object[] { "H" });
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                tbMaSV.Text = dataGridView1.CurrentRow.Cells["MaSV"].Value.ToString();
                tbTenSV.Text = dataGridView1.CurrentRow.Cells["HoDem"].Value.ToString();
            }
            catch (Exception)
            {

                //     throw;
            }

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SinhVien sv = new SinhVien(dataGridView1.CurrentRow.Cells["MaSV"].Value.ToString());
                if (e.ColumnIndex == 1) sv.HoDem = dataGridView1.CurrentRow.Cells["HoDem"].Value.ToString();

            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.ToString());
               
            }

        }
    }
}