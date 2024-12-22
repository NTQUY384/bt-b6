using bt_b6.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace bt_b6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BindGrid(List<Student> liststudents)
        {
            dataGridView1.Rows.Clear();
            foreach (Student item in liststudents) {
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = item.id;
                dataGridView1.Rows[index].Cells[1].Value = item.fullname;
                dataGridView1.Rows[index].Cells[2].Value = item.avg;
                dataGridView1.Rows[index].Cells[3].Value = item.facultyid;

            }
        }

        private void combo(List<Student> listStudent)
        {
            this.comboBox1.DataSource = listStudent;
            this.comboBox1.DisplayMember = "Khoa";
            this.comboBox1.ValueMember = "facultyid";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Studentcontext studentcontext = new Studentcontext();
            List<Faculty> faculties = new List<Faculty>();
            List<Student> students = studentcontext.Students.ToList();
            List<Faculty> faculty = studentcontext.Faculties.ToList();
            combo(students);
            BindGrid(students);
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            Studentcontext context = new Studentcontext();
            {
                Student newStudent = new Student()
                {
                    id = txtma.Text,
                    fullname = txtten.Text,
                    facultyid = comboBox1.SelectedValue.ToString(),
                    avg = double.Parse(txtdiem.Text)
                };
                context.Students.Add(newStudent);
                context.SaveChanges();
                BindGrid(context.Students.ToList());
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            try
            {
                Studentcontext context = new Studentcontext();
                string Mã_Số_SV = txtma.Text;

                Student updateStudent = context.Students.FirstOrDefault(s => s.id == Mã_Số_SV);
                if (updateStudent != null)
                {
                    updateStudent.fullname = txtten.Text;
                    updateStudent.facultyid = comboBox1.SelectedValue.ToString();
                    updateStudent.avg = double.Parse(txtdiem.Text);

                    context.SaveChanges();
                    MessageBox.Show("Cập nhật thành công!");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sinh viên để cập nhật.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa dữ liệu: " + ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtma.Text = row.Cells[0].Value.ToString();
                txtten.Text = row.Cells[1].Value.ToString();
                comboBox1.SelectedValue = row.Cells[2].Value.ToString();
                txtdiem.Text = row.Cells[3].Value.ToString();
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            using (Studentcontext context = new Studentcontext())
            {
                string maSoSV = txtma.Text;
                Student student = context.Students.FirstOrDefault(s => s.id == maSoSV);
                if (student != null)
                {
                    context.Students.Remove(student);
                    context.SaveChanges();
                    BindGrid(context.Students.ToList());
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sinh viên để xóa.");
                }
            }
        }
    }
}
