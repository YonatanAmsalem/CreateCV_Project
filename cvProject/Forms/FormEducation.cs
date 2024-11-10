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
    public partial class FormEducation : Form
    {
        Education education = new Education();
        int index;
        public FormEducation()
        {
            InitializeComponent();
            Education_dv.ReadOnly = true;            
            education.SetTitleAndOrder("Education", 1);
        }
        public void SetEducationList()
        {
            // Clear existing rows from the DataGridView
            Education_dv.Rows.Clear();
            //Populate the DataGridView with data from the list
            foreach (Education education in Program.DataEducationList)
            {
                Education_dv.Rows.Add(education.INDEX, education.INSTITUTION, education.DEGREE, education.MAJOR, education.STARTDATE, education.ENDDATE, education.DESCRIPTION);
            }
        }
        private void add_btn_Click(object sender, EventArgs e)
        {
            string institution, degree, major, description;
            string startDate, EndDate, index;
            institution = institution_tb.Text;
            degree = degree_tb.Text;
            major = major_tb.Text;
            description = description_tb.Text;
            startDate = startDate_tb.Text;
            EndDate = endDate_tb.Text;

            if (Program.checkValidInputName(institution) && Program.checkValidInputName(degree)
                && Program.checkValidInputName(major) && !string.IsNullOrWhiteSpace(description) &&
               Program.checkValidInputNumeric(startDate) && Program.checkValidInputNumeric(EndDate) && startDate.Length == 4 && EndDate.Length == 4) // change to function get object(template)
            {
                index = Education_dv.Rows.Count.ToString();
                education = new Education(institution, degree, major, description, startDate, EndDate, index);
                Education_dv.Rows.Add(Education_dv.Rows.Count, education.INSTITUTION, education.DEGREE, education.MAJOR, education.STARTDATE, education.ENDDATE, education.DESCRIPTION);
                education.addToList();
                clearForm();
            }
            else
            {
                MessageBox.Show("Invalid input");
            }           
        }
        public void clearForm()
        {
            institution_tb.Clear();
            degree_tb.Clear();
            major_tb.Clear();
            description_tb.Clear();
            startDate_tb.Clear();
            endDate_tb.Clear();
        }
        private void delete_btn_Click(object sender, EventArgs e)
        {
           
            //                                       check if the the current selected row value is empty
            if (Education_dv.Rows.Count > 1 && Education_dv.Rows[Education_dv.CurrentRow.Index].Cells[1].Value != null)
            {
                index = Education_dv.CurrentRow.Index; //current selected index

                //polymorphism
                cvSections found = new Education();
                found = Program.DataEducationList.Find(education => education.DESCRIPTION == Education_dv.Rows[index].Cells[6].Value.ToString());
                found.RemoveItemFromList();
                Education_dv.Rows.RemoveAt(index);               
            }           
                  
        }
        

        private void modify_btn_Click(object sender, EventArgs e)
        {

            if (Education_dv.Rows.Count > 1 && Education_dv.Rows[Education_dv.CurrentRow.Index].Cells[1].Value != null)
            {
                index = Education_dv.CurrentRow.Index;
                insertInfoToTextBox(index);
                //polymorphism
                cvSections foundEducation = new Education();
                foundEducation = Program.DataEducationList.Find(education => education.DESCRIPTION == description_tb.Text.ToString());
                foundEducation.RemoveItemFromList();
                Education_dv.Rows.RemoveAt(index);
            }
        }
        protected void insertInfoToTextBox(int index)
        {            
            institution_tb.Text = Education_dv.Rows[index].Cells[1].Value.ToString();
            degree_tb.Text = Education_dv.Rows[index].Cells[2].Value.ToString();
            major_tb.Text = Education_dv.Rows[index].Cells[3].Value.ToString();
            startDate_tb.Text = Education_dv.Rows[index].Cells[4].Value.ToString();
            endDate_tb.Text = Education_dv.Rows[index].Cells[5].Value.ToString();
            description_tb.Text = Education_dv.Rows[index].Cells[6].Value.ToString();            
        }
        //show the number in dataGridView for each row
        private void Education_dv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            Education_dv.Rows[e.RowIndex].Cells[0].Value = e.RowIndex + 1;
        }
    }
}
