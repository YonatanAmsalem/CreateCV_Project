using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cvProject.Forms;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Drawing.Layout;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace cvProject
{

    public partial class cvProject : Form
    {
        private Form activeForm;

        public cvProject()
        {
            InitializeComponent();
            timer1.Start();
        }
        //create a method to open the forms in the panelDesktop
        private void OpenChildForms(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dataTime = DateTime.Now;
            this.time_lbl.Text = dataTime.ToString();
        }

        private void personal_btn_MouseClick(object sender, MouseEventArgs e)
        {
            FormPersonal formPersonal = new FormPersonal();
            OpenChildForms(formPersonal, sender);
            formPersonal.setDataTotb();
        }

        private void education_btn_Click(object sender, EventArgs e)
        {
            FormEducation education = new FormEducation();
            OpenChildForms(education, sender);
            education.SetEducationList();
        }

        private void workEx_btn_Click(object sender, EventArgs e)
        {
            FormWorkExperience workExperience = new FormWorkExperience();
            OpenChildForms(workExperience, sender);
            workExperience.SetWorkExpList();
        }

        private void skill_btn_Click(object sender, EventArgs e)
        {
            OpenChildForms(new Forms.FormLanguages(), sender);
        }
        //global variable
        double pagePosition = 30;
        static PdfDocument cv = new PdfDocument();
        static List<PdfPage> pages = new List<PdfPage>();
        static int countPages = 0;
        static XGraphics gfx;
        Color color;


        private void pdf_pb_Click(object sender, EventArgs e)
        {
            if (Program.DataEducationList.Count == 0 || Program.DataWorkExperinceList.Count == 0 || Program.langList.Count == 0 || Program.per.ID == "")
            {
                MessageBox.Show("You Are Not Finished To Fill The Sections");
            }
            else
            {
                PdfPage firstPage = cv.AddPage(); //create a page
                pages.Add(firstPage); //add the page to the list                
                gfx = XGraphics.FromPdfPage(pages[countPages]);
                color = SelectedColor();
                string selectedPdfpath = SelectedPathOfPdf();
                // Set the page size (width and height) in points
                pages[countPages].Width = XUnit.FromMillimeter(210);   // A4 width
                pages[countPages].Height = XUnit.FromMillimeter(297);  // A4 height

                //fonts:
                XFont fontHeadline = new XFont("Century Gothic", 24);
                XFont fontsubHeadline = new XFont("Century Gothic", 16, XFontStyle.Bold);
                XFont text = new XFont("Century Gothic", 12);
                XFont subTitle = new XFont("Century Gothic", 12, XFontStyle.Bold);

                string Headline = "Resume of " + Program.per.firstNAME + " " + Program.per.LastNAME;
                gfx.DrawString(Headline, fontHeadline, XBrushes.Black, new XRect(10, pagePosition, pages[countPages].Width, pages[countPages].Height), XStringFormats.TopCenter);
                pagePosition += 45;
                DrawPng(gfx);
                PesonalPdf(subTitle, fontsubHeadline, text, pages[countPages], cv);
                EducationPdf(subTitle, fontsubHeadline, text, pages[countPages], pages[countPages].Height, cv);
                WorkExpPdf(subTitle, fontsubHeadline, text, pages[countPages], pages[countPages].Height, cv);
                LanguagePdfXFont(fontsubHeadline, text, pages[countPages], pages[countPages].Height, cv);

                //"C:\\Users\\yarde\\OneDrive\\Desktop\\MyPdfDocument.pdf"
                cv.Save(selectedPdfpath + "\\" + "Resume of" + Program.per.firstNAME + " " + Program.per.LastNAME + ".pdf");
                MessageBox.Show("upload succssesfully");
            }


        }
        private string SelectedPathOfPdf()
        {
            string selectedPdfpath = "";

            FolderBrowserDialog path = new FolderBrowserDialog();
            {
                if (path.ShowDialog() == DialogResult.OK)
                {
                    selectedPdfpath = path.SelectedPath;
                }
                return selectedPdfpath;
            }
        }
        private Color SelectedColor()
        {
            Color selectedColor = new Color();
            MessageBox.Show("choose color for the Headlines");
            using (ColorDialog colorDialog = new ColorDialog())
            {

                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedColor = colorDialog.Color;
                }
            }
            return selectedColor;
        }
        public void headlineSection(XFont fontSubtitle, PdfPage page, string Title)
        {
            // Create a background rectangle for the banner
            XRect backgroundRect = new XRect(0, pagePosition, page.Width, 20);
            XBrush backgroundBrush = new XSolidBrush(XColor.FromArgb(color.R, color.G, color.B)); ;
            gfx.DrawRectangle(backgroundBrush, backgroundRect);

            // create the format position to the headline
            XStringFormat format = new XStringFormat();
            format.Alignment = XStringAlignment.Center;
            format.LineAlignment = XLineAlignment.Center;


            gfx.DrawString(Title, fontSubtitle, XBrushes.Black, backgroundRect, format);
            pagePosition += fontSubtitle.Height + 25;
        }
        public void PesonalPdf(XFont fontSubtitle, XFont fontsubHeadline, XFont text, PdfPage page, PdfDocument cv)
        {
            int index = cvComponent.cvList.FindIndex(item => item.DISPLAYTORDER == 0);
            headlineSection(fontsubHeadline, page, cvComponent.cvList[index].TITLE);
            double yFirst = 120; //position of the text 
            double xFirst = 30;  //position of the text  
            double tab = 300;// space for the second col

            string[] firstColTitle = new string[] { "Name: ", "ID: ", "Date of Birth: ", "Address: ", "Phone: ", "Email: " };
            string[] strPersonal = new string[] { Program.per.firstNAME + " " + Program.per.LastNAME, Program.per.ID, Program.per.dateofBIRTH, Program.per.ADDRESS, Program.per.PHONE, Program.per.EMAIL };

            for (int i = 0; i < firstColTitle.Length; i++)
            {
                //calculate the width of each title 
                double titleWidth = gfx.MeasureString(firstColTitle[i], fontSubtitle).Width;

                if (i < 3)
                {
                    gfx.DrawString(firstColTitle[i], fontSubtitle, XBrushes.Black, xFirst, pagePosition); //position of the first title
                    gfx.DrawString(strPersonal[i], text, XBrushes.Black, xFirst + titleWidth, pagePosition); //position of the contant for the first title
                    pagePosition += fontSubtitle.Height + text.Height; //calculate the height according to the font title and the text
                }
                else // same here with addition of the tab space
                {
                    gfx.DrawString(firstColTitle[i], fontSubtitle, XBrushes.Black, xFirst + tab, yFirst);
                    gfx.DrawString(strPersonal[i], text, XBrushes.Black, xFirst + titleWidth + tab, yFirst);
                    yFirst += fontSubtitle.Height + text.Height;
                }

            }
        }
        public void EducationPdf(XFont fontSubtitle, XFont fontsubHeadline, XFont text, PdfPage page, double pageHeight, PdfDocument cv)
        {
            double x = 30;
            double tab = 30;
            int index = cvComponent.cvList.FindIndex(item => item.DISPLAYTORDER == 1);
            headlineSection(fontsubHeadline, page, cvComponent.cvList[index].TITLE);
            CheckHeightPage(page.Height);
            foreach (Education i in Program.DataEducationList)
            {
                gfx.DrawString(i.STARTDATE + '-' + i.ENDDATE, fontSubtitle, XBrushes.Black, x, pagePosition);
                double pos = gfx.MeasureString(i.STARTDATE + '-' + i.ENDDATE, fontSubtitle).Width;
                gfx.DrawString(i.DEGREE + " major " + i.MAJOR + " in " + i.INSTITUTION, fontSubtitle, XBrushes.Black, x + pos + tab, pagePosition);
                pagePosition += fontSubtitle.Height + 5;
                double space = x + pos + tab;
                DescriptionHandled(text, page, space, i.DESCRIPTION);
                pagePosition += text.Height + 8;
                CheckHeightPage(page.Height);
            }
        }
        public void WorkExpPdf(XFont fontSubtitle, XFont fontsubHeadline, XFont text, PdfPage page, double pageHeight, PdfDocument cv)
        {
            double x = 30;
            double tab = 30;
            int index = cvComponent.cvList.FindIndex(item => item.DISPLAYTORDER == 2);
            headlineSection(fontsubHeadline, page, cvComponent.cvList[index].TITLE);

            CheckHeightPage(pageHeight);
            foreach (WorkExperience i in Program.DataWorkExperinceList)
            {
                gfx.DrawString(i.STARTDATE + '-' + i.ENDDATE, fontSubtitle, XBrushes.Black, x, pagePosition);
                double pos = gfx.MeasureString(i.STARTDATE + '-' + i.ENDDATE, fontSubtitle).Width;
                gfx.DrawString(i.POSITION + " in " + i.COMPANY, fontSubtitle, XBrushes.Black, x + pos + tab, pagePosition);
                pagePosition += fontSubtitle.Height + 0.5;
                gfx.DrawString(i.DURATION, new XFont("Century Gothic", 8, XFontStyle.Bold), XBrushes.Gray, x + pos + tab, pagePosition);
                pagePosition += fontSubtitle.Height + 3;
                double space = x + pos + tab;
                DescriptionHandled(text, page, space, i.RESPONSIBILITIES);
                pagePosition += text.Height + 8;
                CheckHeightPage(pageHeight);
            }
        }
        public void LanguagePdfXFont(XFont fontsubHeadline, XFont text, PdfPage page, double pageHeight, PdfDocument cv)
        {
            int index = cvComponent.cvList.FindIndex(item => item.DISPLAYTORDER == 3);
            headlineSection(fontsubHeadline, page, cvComponent.cvList[index].TITLE);
            XBrush backgroundBrush = new XSolidBrush(XColor.FromArgb(color.R, color.G, color.B));
            double x = 30;
            double space = 20;
            char bullet = '\u2022';// Unicode bullet character
            double squareSize = 10;
            CheckHeightPage(page.Height);
            XPen pen = new XPen(XColor.FromArgb(color.R, color.G, color.B));
            foreach (Language lang in Program.langList)
            {
                string title = bullet + "   " + lang.LANGUAGE;
                double start = x + (double)'\t' * 10 + space;
                gfx.DrawString(title, text, XBrushes.Black, x, pagePosition);
                for (int i = 0; i < 5; i++)
                {
                    if (i < lang.LEVEL)
                    {
                        XRect squareRect = new XRect(start, pagePosition - 8, squareSize, squareSize);
                        gfx.DrawRectangle(backgroundBrush, squareRect);
                    }
                    else
                    {
                        gfx.DrawRectangle(pen, start, pagePosition - 8, squareSize, squareSize);
                    }
                    start += squareSize + 10;
                }
                pagePosition += text.Height + 5;
                CheckHeightPage(page.Height);
            }
        }

        public void DescriptionHandled(XFont textfont, PdfPage page, double space, string description)
        {
            double statpos = space;
            CheckHeightPage(page.Height);
            foreach (string s in description.Split(' ', '\n', '\t', '\r'))
            {
                if (page.Width - space - 30 < gfx.MeasureString(s, textfont).Width) //Checks if we have reached the end of the line
                {
                    pagePosition += textfont.Height + 5;
                    space = statpos;
                }
                CheckHeightPage(page.Height);
                if (s != "")
                {
                    gfx.DrawString(s, textfont, XBrushes.Black, space, pagePosition);
                    space += gfx.MeasureString(s, textfont).Width + 4;
                }

            }
        }

        void DrawPng(XGraphics gfx)
        {
            if (Program.per.IMAGEPATH != "")
            {
                XImage image = XImage.FromFile(Program.per.IMAGEPATH);
                double imageWidth = 65;
                double imageHeight = 65;
                gfx.DrawImage(image, 30, 5, imageWidth, imageHeight);
            }

        }

        private void saveP_btn_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();// + "..\\myModels";
            saveFileDialog1.Filter = "model files (*.mdl)|*.mdl|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    IFormatter formatter = new BinaryFormatter();
                    using (Stream stream = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        //!!!!
                        formatter.Serialize(stream, Program.per);
                        formatter.Serialize(stream, Program.DataEducationList);
                        formatter.Serialize(stream, Program.DataWorkExperinceList);
                        formatter.Serialize(stream, Program.langList);
                        formatter.Serialize(stream, cvComponent.cvList);
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void load_btn_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();// + "..\\myModels";
            openFileDialog1.Filter = "model files (*.mdl)|*.mdl|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Stream stream = File.Open(openFileDialog1.FileName, FileMode.Open);
                    var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                    Program.per = (PersonalInfo)binaryFormatter.Deserialize(stream);
                    Program.DataEducationList = (List<Education>)binaryFormatter.Deserialize(stream);
                    Program.DataWorkExperinceList = (List<WorkExperience>)binaryFormatter.Deserialize(stream);
                    Program.langList = (List<Language>)binaryFormatter.Deserialize(stream);
                    cvComponent.cvList = (List<cvComponent>)binaryFormatter.Deserialize(stream);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CheckHeightPage(double pageHeight)
        {
            if (pageHeight - pagePosition <= 30)
            {
                PdfPage newPage = cv.AddPage();
                pages.Add(newPage);
                countPages++;
                pages[countPages].Width = XUnit.FromMillimeter(210);   // A4 width
                pages[countPages].Height = XUnit.FromMillimeter(297);  // A4 height
                gfx = XGraphics.FromPdfPage(pages[countPages]);
                pagePosition = 30;
            }

        }
    }
}


