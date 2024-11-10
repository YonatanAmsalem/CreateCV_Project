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
    public partial class FormLanguages : Form
    {
        public FormLanguages()
        {        
            InitializeComponent();          
            RestoreForm();
            //Polymorphism
            cvComponent cvObj = new Language();
            if (!cvObj.checkIfObjectInTheList())
                cvObj.addTocvCompList();
        }
        
        int Count = 1;
        int spacing = 20;
        List<TextBox> tbList = new List<TextBox>();
        List<ComboBox> cbList = new List<ComboBox>();

        private void new_btn_Click(object sender, EventArgs e)
        {
            if(tbList.Count == 0 && cbList.Count == 0)
            {
                tbList.Add(lang_tb);
                cbList.Add(levelLang_cb);
            }
            //                                         check if an item is selected
            if (!string.IsNullOrEmpty(lang_tb.Text) && levelLang_cb.SelectedIndex != -1)
            {
                TextBox newTextBox = new TextBox();
                addNewTextBox(ref newTextBox);
                ComboBox comboBox = new ComboBox();
                addNewComboBox(ref comboBox);
                Count++;
            }
            else
            {
                MessageBox.Show("Invalid Input");
            }
            
        }

        private void addNewTextBox(ref TextBox newTextBox)
        {            
            Controls.Add(newTextBox);
            newTextBox.Location = new System.Drawing.Point(lang_tb.Location.X, lang_tb.Location.Y + Count * (newTextBox.Height + spacing));
            newTextBox.Size = new Size(lang_tb.Width, lang_tb.Height);
            newTextBox.Font = lang_tb.Font;
            newTextBox.BorderStyle = lang_tb.BorderStyle;
            newTextBox.BackColor = Color.LightGray;
            newTextBox.Name = lang_tb.Name + Count.ToString();
            tbList.Add(newTextBox);//add to list 
        }
        private void addNewComboBox(ref ComboBox comboBox)
        {            
            Controls.Add(comboBox);
            comboBox.Location = new System.Drawing.Point(levelLang_cb.Location.X, levelLang_cb.Location.Y + Count * (comboBox.Height + spacing));
            comboBox.Size = new Size(levelLang_cb.Width, levelLang_cb.Height);
            comboBox.Font = levelLang_cb.Font;
            comboBox.BackColor = Color.White;
            comboBox.Name = levelLang_cb.Name + Count.ToString();
            foreach (var item in levelLang_cb.Items)
                comboBox.Items.Add(item);
            cbList.Add(comboBox); //add to list 
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            if(Program.checkValidInputName(lang_tb.Text) && levelLang_cb.SelectedIndex != -1 && Program.langList.Count == 0)
            {
                Language language = new Language(lang_tb.Text, int.Parse(levelLang_cb.SelectedItem.ToString()), "Language", 4);
                Program.langList.Add(language);
            }
            if (Program.langList.Count == 0)
            {
                MessageBox.Show("Invalid Input");
            }
            else
            {
                for (int i = 1; i < Count; i++)
                {
                    if (Program.checkValidInputName(tbList[i].Text) && cbList[i].SelectedIndex != -1)
                    {
                        Language language = new Language(tbList[i].Text, int.Parse(cbList[i].SelectedItem.ToString()), "Language", 4);
                        //check if the object is allready in the list
                        if(Program.langList.FindIndex(item => item.LANGUAGE == language.LANGUAGE) == -1)
                            Program.langList.Add(language);
                    }
                }
                MessageBox.Show("Succsess");
            }
            
        }

        private void RestoreForm()
        {
            if(Program.langList.Count > 0)
            {
                lang_tb.Text = Program.langList[0].LANGUAGE;
                levelLang_cb.Text = Program.langList[0].LEVEL.ToString();
            }            
            for (int i = 1; i < Program.langList.Count; i++)
            {
                TextBox newTextBox = new TextBox();
                ComboBox comboBox = new ComboBox();
                newTextBox.Text = Program.langList[i].LANGUAGE;
                comboBox.Text = Program.langList[i].LEVEL.ToString();
                addNewTextBox(ref newTextBox);
                addNewComboBox(ref comboBox);
            }
        }
    }
}
