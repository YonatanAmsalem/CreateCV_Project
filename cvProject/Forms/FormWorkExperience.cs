using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cvProject.Forms
{
    public partial class FormWorkExperience : Form
    {
        WorkExperience workExp = new WorkExperience();
        int index;
        public FormWorkExperience()
        {
            InitializeComponent();
            workExp.SetTitleAndOrder("Work Experience", 2);
            WorkExp_dv.ReadOnly = true;
        }
        public void SetWorkExpList()
        {
            // Clear existing rows from the DataGridView
            WorkExp_dv.Rows.Clear();
            //Populate the DataGridView with data from the list
            foreach (WorkExperience workexpe in Program.DataWorkExperinceList)
            {
                WorkExp_dv.Rows.Add(workexpe.INDEX, workexpe.COMPANY, workexpe.POSITION, workexpe.DURATION, workexpe.RESPONSIBILITIES);
            }
        }
        private void add_btn_Click(object sender, EventArgs e)
        {
            string index, Company, Position, StartDate, EndDate, Responsibilities, Duration;
            Company = company_tb.Text;
            Position = position_tb.Text;
            StartDate = startDate_time.Value.ToString("dd-MM-yyyy");
            EndDate = endDate_time.Value.ToString("dd-MM-yyyy");
            Responsibilities = responsibilities_tb.Text;
            Duration = " ";
            if (Program.checkValidInputName(Company) && Program.checkValidInputName(Position)
                && !string.IsNullOrWhiteSpace(Responsibilities))
            {
                index = WorkExp_dv.Rows.Count.ToString();
                workExp = new WorkExperience(index, Company, Position, StartDate, EndDate, Responsibilities, Duration);
                WorkExp_dv.Rows.Add(workExp.INDEX, workExp.COMPANY, workExp.POSITION, workExp.DURATION, workExp.RESPONSIBILITIES);
                workExp.addToList();
                clearForm();
            }
            else
            {
                MessageBox.Show("Invalid input");
            }
           
        }
        public void clearForm()
        {
            company_tb.Clear();
            position_tb.Clear();
            responsibilities_tb.Clear();
        }

        private void modify_btn_Click(object sender, EventArgs e)
        {
            if (WorkExp_dv.Rows.Count > 1 && WorkExp_dv.Rows[WorkExp_dv.CurrentRow.Index].Cells[1].Value != null)
            {
                //polymorphism
                index = WorkExp_dv.CurrentRow.Index;
                insertToTextBox(index);
                cvSections foundWe = new WorkExperience();
                foundWe = Program.DataWorkExperinceList.Find(workExp => workExp.RESPONSIBILITIES == WorkExp_dv.Rows[index].Cells[4].Value.ToString());
                foundWe.RemoveItemFromList();
                WorkExp_dv.Rows.RemoveAt(index);
            }
        }

        protected void insertToTextBox(int index)
        {
            company_tb.Text = WorkExp_dv.Rows[index].Cells[1].Value.ToString();
            position_tb.Text = WorkExp_dv.Rows[index].Cells[2].Value.ToString();
            responsibilities_tb.Text = WorkExp_dv.Rows[index].Cells[4].Value.ToString();
        }
        private void delete_btn_Click(object sender, EventArgs e)
        {
            //                                       check if the the current selected row value is empty
            if (WorkExp_dv.Rows.Count > 1 && WorkExp_dv.Rows[WorkExp_dv.CurrentRow.Index].Cells[1].Value != null)
            {
                index = WorkExp_dv.CurrentRow.Index; //current selected index
                //polymorphism
                cvSections foundWe = new WorkExperience();
                foundWe = Program.DataWorkExperinceList.Find(workExp => workExp.RESPONSIBILITIES == WorkExp_dv.Rows[index].Cells[4].Value.ToString());
                foundWe.RemoveItemFromList();
                WorkExp_dv.Rows.RemoveAt(index);
            }
        }
        //add numbers to each row
        private void WorkExp_dv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            WorkExp_dv.Rows[e.RowIndex].Cells[0].Value = e.RowIndex + 1;
        }

    }
}
