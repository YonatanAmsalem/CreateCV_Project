
namespace cvProject.Forms
{
    partial class FormLanguages
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.language_lb = new System.Windows.Forms.Label();
            this.level_lb = new System.Windows.Forms.Label();
            this.new_btn = new System.Windows.Forms.Button();
            this.lang_tb = new System.Windows.Forms.TextBox();
            this.levelLang_cb = new System.Windows.Forms.ComboBox();
            this.save_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // language_lb
            // 
            this.language_lb.AutoSize = true;
            this.language_lb.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.language_lb.ForeColor = System.Drawing.Color.Gray;
            this.language_lb.Location = new System.Drawing.Point(44, 48);
            this.language_lb.Name = "language_lb";
            this.language_lb.Size = new System.Drawing.Size(108, 23);
            this.language_lb.TabIndex = 3;
            this.language_lb.Text = "Language";
            // 
            // level_lb
            // 
            this.level_lb.AutoSize = true;
            this.level_lb.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.level_lb.ForeColor = System.Drawing.Color.Gray;
            this.level_lb.Location = new System.Drawing.Point(361, 48);
            this.level_lb.Name = "level_lb";
            this.level_lb.Size = new System.Drawing.Size(298, 23);
            this.level_lb.TabIndex = 5;
            this.level_lb.Text = "level of language knowledge";
            // 
            // new_btn
            // 
            this.new_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(185)))), ((int)(((byte)(223)))));
            this.new_btn.FlatAppearance.BorderSize = 0;
            this.new_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.new_btn.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.new_btn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.new_btn.Location = new System.Drawing.Point(740, 114);
            this.new_btn.Name = "new_btn";
            this.new_btn.Size = new System.Drawing.Size(104, 36);
            this.new_btn.TabIndex = 14;
            this.new_btn.Text = "New";
            this.new_btn.UseVisualStyleBackColor = false;
            this.new_btn.Click += new System.EventHandler(this.new_btn_Click);
            // 
            // lang_tb
            // 
            this.lang_tb.BackColor = System.Drawing.Color.LightGray;
            this.lang_tb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lang_tb.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lang_tb.Location = new System.Drawing.Point(48, 110);
            this.lang_tb.Name = "lang_tb";
            this.lang_tb.Size = new System.Drawing.Size(216, 35);
            this.lang_tb.TabIndex = 16;
            // 
            // levelLang_cb
            // 
            this.levelLang_cb.BackColor = System.Drawing.Color.White;
            this.levelLang_cb.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.levelLang_cb.ForeColor = System.Drawing.Color.Black;
            this.levelLang_cb.FormattingEnabled = true;
            this.levelLang_cb.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.levelLang_cb.Location = new System.Drawing.Point(450, 110);
            this.levelLang_cb.Name = "levelLang_cb";
            this.levelLang_cb.Size = new System.Drawing.Size(120, 33);
            this.levelLang_cb.TabIndex = 17;
            // 
            // save_btn
            // 
            this.save_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(185)))), ((int)(((byte)(223)))));
            this.save_btn.FlatAppearance.BorderSize = 0;
            this.save_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save_btn.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save_btn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.save_btn.Location = new System.Drawing.Point(740, 193);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(104, 36);
            this.save_btn.TabIndex = 18;
            this.save_btn.Text = "Save";
            this.save_btn.UseVisualStyleBackColor = false;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(59, 522);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(711, 22);
            this.label1.TabIndex = 19;
            this.label1.Text = "Add language by clicking on New button and when you finish press Save button";
            // 
            // FormLanguages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 567);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.levelLang_cb);
            this.Controls.Add(this.lang_tb);
            this.Controls.Add(this.new_btn);
            this.Controls.Add(this.level_lb);
            this.Controls.Add(this.language_lb);
            this.Name = "FormLanguages";
            this.Text = "FormLanguage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label language_lb;
        private System.Windows.Forms.Label level_lb;
        private System.Windows.Forms.Button new_btn;
        private System.Windows.Forms.TextBox lang_tb;
        private System.Windows.Forms.ComboBox levelLang_cb;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.Label label1;
    }
}