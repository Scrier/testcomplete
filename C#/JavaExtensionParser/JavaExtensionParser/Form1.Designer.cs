namespace JavaExtensionParser
{
    partial class frm_main
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
            this.rtb_information = new System.Windows.Forms.RichTextBox();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_parse = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.cbx_doBackup = new System.Windows.Forms.CheckBox();
            this.cbx_parseXml = new System.Windows.Forms.CheckBox();
            this.tbx_parseFile = new System.Windows.Forms.TextBox();
            this.btn_parse_doxygen = new System.Windows.Forms.Button();
            this.cbx_savelog = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // rtb_information
            // 
            this.rtb_information.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtb_information.Location = new System.Drawing.Point(12, 12);
            this.rtb_information.Name = "rtb_information";
            this.rtb_information.Size = new System.Drawing.Size(810, 527);
            this.rtb_information.TabIndex = 0;
            this.rtb_information.Text = "";
            // 
            // btn_exit
            // 
            this.btn_exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_exit.Location = new System.Drawing.Point(747, 545);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(75, 23);
            this.btn_exit.TabIndex = 1;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_parse
            // 
            this.btn_parse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_parse.Location = new System.Drawing.Point(666, 545);
            this.btn_parse.Name = "btn_parse";
            this.btn_parse.Size = new System.Drawing.Size(75, 23);
            this.btn_parse.TabIndex = 2;
            this.btn_parse.Text = "Parse";
            this.btn_parse.UseVisualStyleBackColor = true;
            this.btn_parse.Click += new System.EventHandler(this.btn_parse_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_clear.Location = new System.Drawing.Point(453, 545);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(97, 23);
            this.btn_clear.TabIndex = 3;
            this.btn_clear.Text = "Remove Backup";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // cbx_doBackup
            // 
            this.cbx_doBackup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbx_doBackup.AutoSize = true;
            this.cbx_doBackup.Location = new System.Drawing.Point(12, 549);
            this.cbx_doBackup.Name = "cbx_doBackup";
            this.cbx_doBackup.Size = new System.Drawing.Size(97, 17);
            this.cbx_doBackup.TabIndex = 4;
            this.cbx_doBackup.Text = "Create Backup";
            this.cbx_doBackup.UseVisualStyleBackColor = true;
            // 
            // cbx_parseXml
            // 
            this.cbx_parseXml.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbx_parseXml.AutoSize = true;
            this.cbx_parseXml.Location = new System.Drawing.Point(193, 549);
            this.cbx_parseXml.Name = "cbx_parseXml";
            this.cbx_parseXml.Size = new System.Drawing.Size(73, 17);
            this.cbx_parseXml.TabIndex = 5;
            this.cbx_parseXml.Text = "Parse Xml";
            this.cbx_parseXml.UseVisualStyleBackColor = true;
            this.cbx_parseXml.CheckStateChanged += new System.EventHandler(this.cbx_parseXml_CheckStateChanged);
            // 
            // tbx_parseFile
            // 
            this.tbx_parseFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbx_parseFile.Location = new System.Drawing.Point(272, 546);
            this.tbx_parseFile.Name = "tbx_parseFile";
            this.tbx_parseFile.Size = new System.Drawing.Size(153, 20);
            this.tbx_parseFile.TabIndex = 6;
            // 
            // btn_parse_doxygen
            // 
            this.btn_parse_doxygen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_parse_doxygen.Location = new System.Drawing.Point(556, 545);
            this.btn_parse_doxygen.Name = "btn_parse_doxygen";
            this.btn_parse_doxygen.Size = new System.Drawing.Size(104, 23);
            this.btn_parse_doxygen.TabIndex = 7;
            this.btn_parse_doxygen.Text = "Generate Doxygen";
            this.btn_parse_doxygen.UseVisualStyleBackColor = true;
            this.btn_parse_doxygen.Click += new System.EventHandler(this.btn_parse_doxygen_Click);
            // 
            // cbx_savelog
            // 
            this.cbx_savelog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbx_savelog.AutoSize = true;
            this.cbx_savelog.Location = new System.Drawing.Point(115, 549);
            this.cbx_savelog.Name = "cbx_savelog";
            this.cbx_savelog.Size = new System.Drawing.Size(72, 17);
            this.cbx_savelog.TabIndex = 8;
            this.cbx_savelog.Text = "Save Log";
            this.cbx_savelog.UseVisualStyleBackColor = true;
            // 
            // frm_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 580);
            this.Controls.Add(this.cbx_savelog);
            this.Controls.Add(this.btn_parse_doxygen);
            this.Controls.Add(this.tbx_parseFile);
            this.Controls.Add(this.cbx_parseXml);
            this.Controls.Add(this.cbx_doBackup);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_parse);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.rtb_information);
            this.Name = "frm_main";
            this.Text = "Java Extension Parser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtb_information;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_parse;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.CheckBox cbx_doBackup;
        private System.Windows.Forms.CheckBox cbx_parseXml;
        private System.Windows.Forms.TextBox tbx_parseFile;
        private System.Windows.Forms.Button btn_parse_doxygen;
        private System.Windows.Forms.CheckBox cbx_savelog;
    }
}

