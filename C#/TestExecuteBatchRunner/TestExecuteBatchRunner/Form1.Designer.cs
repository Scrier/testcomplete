namespace TestExecuteBatchRunner
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
            this.clx_testcases = new System.Windows.Forms.CheckedListBox();
            this.lbl_testcases = new System.Windows.Forms.Label();
            this.btn_scriptfolders = new System.Windows.Forms.Button();
            this.fbd_scriptfolder = new System.Windows.Forms.FolderBrowserDialog();
            this.tbx_scriptfolder = new System.Windows.Forms.TextBox();
            this.btn_listfiles = new System.Windows.Forms.Button();
            this.tbx_filters = new System.Windows.Forms.TextBox();
            this.lbl_filter = new System.Windows.Forms.Label();
            this.btn_testeexecute = new System.Windows.Forms.Button();
            this.btn_projectsuite = new System.Windows.Forms.Button();
            this.tbx_testexecute = new System.Windows.Forms.TextBox();
            this.tbx_projectsuite = new System.Windows.Forms.TextBox();
            this.ofd_testexecute = new System.Windows.Forms.OpenFileDialog();
            this.ofd_projectsuite = new System.Windows.Forms.OpenFileDialog();
            this.tbx_project = new System.Windows.Forms.TextBox();
            this.lbl_project = new System.Windows.Forms.Label();
            this.btn_checkall = new System.Windows.Forms.Button();
            this.btn_uncheckall = new System.Windows.Forms.Button();
            this.btn_match = new System.Windows.Forms.Button();
            this.tbx_matchfrom = new System.Windows.Forms.TextBox();
            this.tbx_matchto = new System.Windows.Forms.TextBox();
            this.lbl_matchfrom = new System.Windows.Forms.Label();
            this.lbl_matchto = new System.Windows.Forms.Label();
            this.rtb_logger = new System.Windows.Forms.RichTextBox();
            this.tbx_runmethod = new System.Windows.Forms.TextBox();
            this.lbl_function = new System.Windows.Forms.Label();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_execute = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clx_testcases
            // 
            this.clx_testcases.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.clx_testcases.CheckOnClick = true;
            this.clx_testcases.FormattingEnabled = true;
            this.clx_testcases.Location = new System.Drawing.Point(12, 33);
            this.clx_testcases.Name = "clx_testcases";
            this.clx_testcases.Size = new System.Drawing.Size(186, 304);
            this.clx_testcases.TabIndex = 0;
            // 
            // lbl_testcases
            // 
            this.lbl_testcases.AutoSize = true;
            this.lbl_testcases.Location = new System.Drawing.Point(12, 17);
            this.lbl_testcases.Name = "lbl_testcases";
            this.lbl_testcases.Size = new System.Drawing.Size(60, 13);
            this.lbl_testcases.TabIndex = 1;
            this.lbl_testcases.Text = "Test Cases";
            // 
            // btn_scriptfolders
            // 
            this.btn_scriptfolders.Location = new System.Drawing.Point(204, 12);
            this.btn_scriptfolders.Name = "btn_scriptfolders";
            this.btn_scriptfolders.Size = new System.Drawing.Size(80, 23);
            this.btn_scriptfolders.TabIndex = 2;
            this.btn_scriptfolders.Text = "Script Folder";
            this.btn_scriptfolders.UseVisualStyleBackColor = true;
            this.btn_scriptfolders.Click += new System.EventHandler(this.btn_scriptfolders_Click);
            // 
            // tbx_scriptfolder
            // 
            this.tbx_scriptfolder.Location = new System.Drawing.Point(290, 14);
            this.tbx_scriptfolder.Name = "tbx_scriptfolder";
            this.tbx_scriptfolder.Size = new System.Drawing.Size(233, 20);
            this.tbx_scriptfolder.TabIndex = 3;
            // 
            // btn_listfiles
            // 
            this.btn_listfiles.Location = new System.Drawing.Point(204, 41);
            this.btn_listfiles.Name = "btn_listfiles";
            this.btn_listfiles.Size = new System.Drawing.Size(80, 23);
            this.btn_listfiles.TabIndex = 4;
            this.btn_listfiles.Text = "List Files";
            this.btn_listfiles.UseVisualStyleBackColor = true;
            this.btn_listfiles.Click += new System.EventHandler(this.btn_listfiles_Click);
            // 
            // tbx_filters
            // 
            this.tbx_filters.Location = new System.Drawing.Point(328, 43);
            this.tbx_filters.Name = "tbx_filters";
            this.tbx_filters.Size = new System.Drawing.Size(195, 20);
            this.tbx_filters.TabIndex = 5;
            this.tbx_filters.Text = "*.sj|*.js";
            // 
            // lbl_filter
            // 
            this.lbl_filter.AutoSize = true;
            this.lbl_filter.Location = new System.Drawing.Point(290, 46);
            this.lbl_filter.Name = "lbl_filter";
            this.lbl_filter.Size = new System.Drawing.Size(32, 13);
            this.lbl_filter.TabIndex = 6;
            this.lbl_filter.Text = "Filter:";
            // 
            // btn_testeexecute
            // 
            this.btn_testeexecute.Location = new System.Drawing.Point(204, 70);
            this.btn_testeexecute.Name = "btn_testeexecute";
            this.btn_testeexecute.Size = new System.Drawing.Size(80, 23);
            this.btn_testeexecute.TabIndex = 7;
            this.btn_testeexecute.Text = "TestExecute";
            this.btn_testeexecute.UseVisualStyleBackColor = true;
            this.btn_testeexecute.Click += new System.EventHandler(this.btn_testeexecute_Click);
            // 
            // btn_projectsuite
            // 
            this.btn_projectsuite.Location = new System.Drawing.Point(204, 99);
            this.btn_projectsuite.Name = "btn_projectsuite";
            this.btn_projectsuite.Size = new System.Drawing.Size(80, 23);
            this.btn_projectsuite.TabIndex = 8;
            this.btn_projectsuite.Text = "Project Suite";
            this.btn_projectsuite.UseVisualStyleBackColor = true;
            this.btn_projectsuite.Click += new System.EventHandler(this.btn_projectsuite_Click);
            // 
            // tbx_testexecute
            // 
            this.tbx_testexecute.Location = new System.Drawing.Point(290, 70);
            this.tbx_testexecute.Name = "tbx_testexecute";
            this.tbx_testexecute.Size = new System.Drawing.Size(233, 20);
            this.tbx_testexecute.TabIndex = 9;
            // 
            // tbx_projectsuite
            // 
            this.tbx_projectsuite.Location = new System.Drawing.Point(290, 101);
            this.tbx_projectsuite.Name = "tbx_projectsuite";
            this.tbx_projectsuite.Size = new System.Drawing.Size(233, 20);
            this.tbx_projectsuite.TabIndex = 10;
            // 
            // ofd_testexecute
            // 
            this.ofd_testexecute.FileName = "TestExecute";
            this.ofd_testexecute.Filter = "Executable (*.exe)|*.exe";
            this.ofd_testexecute.InitialDirectory = "C:\\Program Files\\SmartBear\\TestExecute 9\\Bin";
            // 
            // ofd_projectsuite
            // 
            this.ofd_projectsuite.FileName = "TCProjectSuite";
            this.ofd_projectsuite.Filter = "Project Suite (*.pjs)|*.pjs";
            this.ofd_projectsuite.InitialDirectory = "S:\\TCProjectSuite";
            // 
            // tbx_project
            // 
            this.tbx_project.Location = new System.Drawing.Point(290, 130);
            this.tbx_project.Name = "tbx_project";
            this.tbx_project.Size = new System.Drawing.Size(233, 20);
            this.tbx_project.TabIndex = 11;
            this.tbx_project.Text = "Main";
            this.tbx_project.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbx_project_KeyPress);
            // 
            // lbl_project
            // 
            this.lbl_project.AutoSize = true;
            this.lbl_project.Location = new System.Drawing.Point(204, 133);
            this.lbl_project.Name = "lbl_project";
            this.lbl_project.Size = new System.Drawing.Size(74, 13);
            this.lbl_project.TabIndex = 12;
            this.lbl_project.Text = "Project Name:";
            // 
            // btn_checkall
            // 
            this.btn_checkall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_checkall.Location = new System.Drawing.Point(12, 343);
            this.btn_checkall.Name = "btn_checkall";
            this.btn_checkall.Size = new System.Drawing.Size(75, 23);
            this.btn_checkall.TabIndex = 13;
            this.btn_checkall.Text = "Check All";
            this.btn_checkall.UseVisualStyleBackColor = true;
            this.btn_checkall.Click += new System.EventHandler(this.btn_checkall_Click);
            // 
            // btn_uncheckall
            // 
            this.btn_uncheckall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_uncheckall.Location = new System.Drawing.Point(93, 343);
            this.btn_uncheckall.Name = "btn_uncheckall";
            this.btn_uncheckall.Size = new System.Drawing.Size(75, 23);
            this.btn_uncheckall.TabIndex = 14;
            this.btn_uncheckall.Text = "Uncheck All";
            this.btn_uncheckall.UseVisualStyleBackColor = true;
            this.btn_uncheckall.Click += new System.EventHandler(this.btn_uncheckall_Click);
            // 
            // btn_match
            // 
            this.btn_match.Location = new System.Drawing.Point(203, 186);
            this.btn_match.Name = "btn_match";
            this.btn_match.Size = new System.Drawing.Size(81, 23);
            this.btn_match.TabIndex = 16;
            this.btn_match.Text = "Select Match";
            this.btn_match.UseVisualStyleBackColor = true;
            this.btn_match.Click += new System.EventHandler(this.btn_match_Click);
            // 
            // tbx_matchfrom
            // 
            this.tbx_matchfrom.Location = new System.Drawing.Point(328, 188);
            this.tbx_matchfrom.Name = "tbx_matchfrom";
            this.tbx_matchfrom.Size = new System.Drawing.Size(80, 20);
            this.tbx_matchfrom.TabIndex = 17;
            this.tbx_matchfrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbx_matchfrom_KeyPress);
            this.tbx_matchfrom.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbx_matchfrom_KeyUp);
            // 
            // tbx_matchto
            // 
            this.tbx_matchto.Location = new System.Drawing.Point(443, 188);
            this.tbx_matchto.Name = "tbx_matchto";
            this.tbx_matchto.Size = new System.Drawing.Size(80, 20);
            this.tbx_matchto.TabIndex = 18;
            this.tbx_matchto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbx_matchto_KeyPress);
            this.tbx_matchto.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbx_matchto_KeyUp);
            // 
            // lbl_matchfrom
            // 
            this.lbl_matchfrom.AutoSize = true;
            this.lbl_matchfrom.Location = new System.Drawing.Point(290, 191);
            this.lbl_matchfrom.Name = "lbl_matchfrom";
            this.lbl_matchfrom.Size = new System.Drawing.Size(33, 13);
            this.lbl_matchfrom.TabIndex = 19;
            this.lbl_matchfrom.Text = "From:";
            // 
            // lbl_matchto
            // 
            this.lbl_matchto.AutoSize = true;
            this.lbl_matchto.Location = new System.Drawing.Point(414, 191);
            this.lbl_matchto.Name = "lbl_matchto";
            this.lbl_matchto.Size = new System.Drawing.Size(23, 13);
            this.lbl_matchto.TabIndex = 20;
            this.lbl_matchto.Text = "To:";
            // 
            // rtb_logger
            // 
            this.rtb_logger.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtb_logger.Location = new System.Drawing.Point(203, 214);
            this.rtb_logger.Name = "rtb_logger";
            this.rtb_logger.Size = new System.Drawing.Size(320, 123);
            this.rtb_logger.TabIndex = 21;
            this.rtb_logger.Text = "";
            // 
            // tbx_runmethod
            // 
            this.tbx_runmethod.Location = new System.Drawing.Point(290, 159);
            this.tbx_runmethod.Name = "tbx_runmethod";
            this.tbx_runmethod.Size = new System.Drawing.Size(233, 20);
            this.tbx_runmethod.TabIndex = 22;
            this.tbx_runmethod.Text = "Run";
            this.tbx_runmethod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbx_runmethod_KeyPress);
            // 
            // lbl_function
            // 
            this.lbl_function.AutoSize = true;
            this.lbl_function.Location = new System.Drawing.Point(204, 162);
            this.lbl_function.Name = "lbl_function";
            this.lbl_function.Size = new System.Drawing.Size(71, 13);
            this.lbl_function.TabIndex = 23;
            this.lbl_function.Text = "Function Call:";
            // 
            // btn_clear
            // 
            this.btn_clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_clear.Location = new System.Drawing.Point(203, 343);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(75, 23);
            this.btn_clear.TabIndex = 24;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_execute
            // 
            this.btn_execute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_execute.Location = new System.Drawing.Point(367, 343);
            this.btn_execute.Name = "btn_execute";
            this.btn_execute.Size = new System.Drawing.Size(75, 23);
            this.btn_execute.TabIndex = 25;
            this.btn_execute.Text = "Execute";
            this.btn_execute.UseVisualStyleBackColor = true;
            this.btn_execute.Click += new System.EventHandler(this.btn_execute_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_exit.Location = new System.Drawing.Point(448, 343);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(75, 23);
            this.btn_exit.TabIndex = 26;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // frm_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 375);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_execute);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.lbl_function);
            this.Controls.Add(this.tbx_runmethod);
            this.Controls.Add(this.rtb_logger);
            this.Controls.Add(this.lbl_matchto);
            this.Controls.Add(this.lbl_matchfrom);
            this.Controls.Add(this.tbx_matchto);
            this.Controls.Add(this.tbx_matchfrom);
            this.Controls.Add(this.btn_match);
            this.Controls.Add(this.btn_uncheckall);
            this.Controls.Add(this.btn_checkall);
            this.Controls.Add(this.lbl_project);
            this.Controls.Add(this.tbx_project);
            this.Controls.Add(this.tbx_projectsuite);
            this.Controls.Add(this.tbx_testexecute);
            this.Controls.Add(this.btn_projectsuite);
            this.Controls.Add(this.btn_testeexecute);
            this.Controls.Add(this.lbl_filter);
            this.Controls.Add(this.tbx_filters);
            this.Controls.Add(this.btn_listfiles);
            this.Controls.Add(this.tbx_scriptfolder);
            this.Controls.Add(this.btn_scriptfolders);
            this.Controls.Add(this.lbl_testcases);
            this.Controls.Add(this.clx_testcases);
            this.Name = "frm_main";
            this.Text = "TestExecute Batch Runner";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_main_FormClosing);
            this.Load += new System.EventHandler(this.frm_main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clx_testcases;
        private System.Windows.Forms.Label lbl_testcases;
        private System.Windows.Forms.Button btn_scriptfolders;
        private System.Windows.Forms.FolderBrowserDialog fbd_scriptfolder;
        private System.Windows.Forms.TextBox tbx_scriptfolder;
        private System.Windows.Forms.Button btn_listfiles;
        private System.Windows.Forms.TextBox tbx_filters;
        private System.Windows.Forms.Label lbl_filter;
        private System.Windows.Forms.Button btn_testeexecute;
        private System.Windows.Forms.Button btn_projectsuite;
        private System.Windows.Forms.TextBox tbx_testexecute;
        private System.Windows.Forms.TextBox tbx_projectsuite;
        private System.Windows.Forms.OpenFileDialog ofd_testexecute;
        private System.Windows.Forms.OpenFileDialog ofd_projectsuite;
        private System.Windows.Forms.TextBox tbx_project;
        private System.Windows.Forms.Label lbl_project;
        private System.Windows.Forms.Button btn_checkall;
        private System.Windows.Forms.Button btn_uncheckall;
        private System.Windows.Forms.Button btn_match;
        private System.Windows.Forms.TextBox tbx_matchfrom;
        private System.Windows.Forms.TextBox tbx_matchto;
        private System.Windows.Forms.Label lbl_matchfrom;
        private System.Windows.Forms.Label lbl_matchto;
        private System.Windows.Forms.RichTextBox rtb_logger;
        private System.Windows.Forms.TextBox tbx_runmethod;
        private System.Windows.Forms.Label lbl_function;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_execute;
        private System.Windows.Forms.Button btn_exit;
    }
}

