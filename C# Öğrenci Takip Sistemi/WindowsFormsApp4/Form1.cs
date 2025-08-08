using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       

        public string Constr = "@Data Source=USER\\SQLEXPRESS;Initial Catalog=C:\\USERS\\USER\\DOCUMENTS\\EYECAREDB.MDF;Integrated Security=True;Connect Timeout=30";
        SqlConnection Con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter();


        public DataTable GetData(string Query)
        {
            dt = new DataTable();
            sda = new SqlDataAdapter(Query, Constr);
            sda.Fill(dt);

            return dt;
        }

        public void AddData(String Query)
        {
            sda = new SqlDataAdapter(Query, Constr);

        }

        public int SetData(string Query)
        {
            int Cnt = 0;
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
            cmd.CommandText = Query;
            Cnt = cmd.ExecuteNonQuery();
            Con.Close();
            return Cnt;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int ıd = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            this.ıd = ıd;
            tbxAdi.Text = (string)dataGridView1.CurrentRow.Cells[1].Value;
            tbxTel.Text = Convert.ToInt32((int)dataGridView1.CurrentRow.Cells[2].Value);
            tbxAdres.Text = (string)dataGridView1.CurrentRow.Cells[3].Value;
            tbxTarih.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            tbxCins.Text = (string)dataGridView1.CurrentRow.Cells[5].Value;
            tbxAlerji.Text = (string)dataGridView1.CurrentRow.Cells[6].Value;
        }
        // Button1 -> Güncelleme-Görüntüleme 
        private void button1_Click(object sender, EventArgs e)
        {
            Functions func = new Functions();
            func.SetData("update PatientTbl set PatName='" + tbxAdi.Text + "',PatPhone='" + tbxTel.Text + "',PatAdress='" + tbxAdres.Text + "',PatDOB='" + tbxTarih.Text + "',PatGender='" + cbxCins.Text + "',PatAllergies='" + tbxAlerji.Text + "' where PatId=" + ıd);
            loadData("PatientTbl");

            Functions func = new Functions();
            func.SetData("update AppoitmentTb set PatName='" + tbxAdi.Text + "',PatPhone='" + tbxTel.Text + "',PatAdress='" + tbxAdres.Text + "',PatDOB='" + tbxPatient.Text + "',PatGender='" + tbxAppDate.Text + "',PatAllergies='" + tbxAppTime.Text + "' where PatId=" + ıd);
            loadData("AppoitmentTb");


            Functions func = new Functions();
            func.SetData("update PrescriptionTb set PatName='"'PatPhone='" + tbxApId.Text + "',PatAdress='" + tbxTedavi.Text + "',PatDOB='" + tbxİlaç.Text + "',PatGender='" + tbxMiktar.Text + "',PatAllergies='" + tbxFiyat.Text +"');
            loadData("PrescriptionTb");

            Functions func = new Functions();
            func.SetData("update TreatmentTb set PatName='" + tbxTedaviİd.Text + "',PatPhone='" + tbxTedaviİsmi.Text + "',PatAdress='" + tbxTedaviMaliyeti.Text + "',PatDOB='" + tbxTedaviAçıklaması.Text + '");
            loadData("TreatmentTb");


        }

        // Button 2 ekleme işlemleri
        private void button2_Click(object sender, EventArgs e)
        {
            Functions func = new Functions();
            func.SetData("insert into PatientTb values('" + tbxAdi.Text + "','" + tbxTel.Text + "','" + tbxAdres.Text + "','" + tbxTarih.Text + "','" + cbxCins.Text + "','" + tbxAlerji.Text + "')");
            loadData("PatientTb");

            func.SetData("insert into AppoitmentTb values('" + tbxApId.Text + "','" + tbxPatient.Text + "','" + tbxAppDate.Text + "','" + tbxAppTime.Text+"')");
            loadData("AppoitmentTb");

            func.SetData("insert into PrescriptionTb values('" + tbxApReçeteİd.Text + "','" + tbxRandevu.Text + "','" + tbxTedavi.Text + "','" + tbxİlaç.Text + tbxMiktar.Text + "','" + tbxFiyat.Text + "')");
            loadData("PrescriptionTb");

            func.SetData("insert into TreatmentTb values('" + tbxTedaviİd.Text + "','" + tbxTedaviİsmi.Text + "','" + tbxTedaviMaliyeti.Text + "','" + tbxTedaviAçıklaması.Text +"')");
            loadData(" TreatmentTb ");
        }
        // Button3 silme işlemleri
        private void button3_Click(object sender, EventArgs e)
        {
            ("delete * from PatientTb");
            ("delete * from AppoitmentTb");
            ("delete * from PrescriptionTb");
            ("delete * from TreatmentTb");
        }
    }
}
