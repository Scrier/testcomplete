namespace JavaClassEditor
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.rtb_debug = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tvw_treeview = new System.Windows.Forms.TreeView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pnl_main = new System.Windows.Forms.Panel();
            this.uc_constructor = new JavaClassEditor.ConstructorElementUC();
            this.uc_class = new JavaClassEditor.User_Controls.ClassElementUC();
            this.uc_classes = new JavaClassEditor.User_Controls.ClassesElementUC();
            this.uc_default = new JavaClassEditor.DefaultElementUC();
            this.uc_param = new JavaClassEditor.ParamElementUC();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnl_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(3, 660);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rtb_debug
            // 
            this.rtb_debug.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtb_debug.Location = new System.Drawing.Point(3, 486);
            this.rtb_debug.Name = "rtb_debug";
            this.rtb_debug.Size = new System.Drawing.Size(656, 197);
            this.rtb_debug.TabIndex = 1;
            this.rtb_debug.Text = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Xml File|*.xml";
            // 
            // tvw_treeview
            // 
            this.tvw_treeview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tvw_treeview.Location = new System.Drawing.Point(3, 6);
            this.tvw_treeview.Name = "tvw_treeview";
            this.tvw_treeview.Size = new System.Drawing.Size(324, 648);
            this.tvw_treeview.TabIndex = 2;
            this.tvw_treeview.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvw_treeview_AfterSelect);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvw_treeview);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnl_main);
            this.splitContainer1.Panel2.Controls.Add(this.rtb_debug);
            this.splitContainer1.Size = new System.Drawing.Size(997, 686);
            this.splitContainer1.SplitterDistance = 331;
            this.splitContainer1.TabIndex = 3;
            // 
            // pnl_main
            // 
            this.pnl_main.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_main.Controls.Add(this.uc_param);
            this.pnl_main.Controls.Add(this.uc_constructor);
            this.pnl_main.Controls.Add(this.uc_class);
            this.pnl_main.Controls.Add(this.uc_classes);
            this.pnl_main.Controls.Add(this.uc_default);
            this.pnl_main.Location = new System.Drawing.Point(3, 3);
            this.pnl_main.Name = "pnl_main";
            this.pnl_main.Size = new System.Drawing.Size(656, 480);
            this.pnl_main.TabIndex = 2;
            // 
            // uc_constructor
            // 
            this.uc_constructor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uc_constructor.Location = new System.Drawing.Point(0, 0);
            this.uc_constructor.Name = "uc_constructor";
            this.uc_constructor.Size = new System.Drawing.Size(656, 480);
            this.uc_constructor.TabIndex = 3;
            this.uc_constructor.Visible = false;
            // 
            // uc_class
            // 
            this.uc_class.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uc_class.Location = new System.Drawing.Point(0, 0);
            this.uc_class.Name = "uc_class";
            this.uc_class.Size = new System.Drawing.Size(656, 480);
            this.uc_class.TabIndex = 2;
            this.uc_class.Visible = false;
            // 
            // uc_classes
            // 
            this.uc_classes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uc_classes.Location = new System.Drawing.Point(0, 0);
            this.uc_classes.Name = "uc_classes";
            this.uc_classes.Size = new System.Drawing.Size(656, 480);
            this.uc_classes.TabIndex = 1;
            this.uc_classes.Visible = false;
            // 
            // uc_default
            // 
            this.uc_default.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uc_default.Location = new System.Drawing.Point(0, 0);
            this.uc_default.Name = "uc_default";
            this.uc_default.Size = new System.Drawing.Size(656, 480);
            this.uc_default.TabIndex = 0;
            this.uc_default.Visible = false;
            // 
            // uc_param
            // 
            this.uc_param.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uc_param.Location = new System.Drawing.Point(0, 0);
            this.uc_param.Name = "uc_param";
            this.uc_param.Size = new System.Drawing.Size(656, 480);
            this.uc_param.TabIndex = 4;
            this.uc_param.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 710);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnl_main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox rtb_debug;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TreeView tvw_treeview;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel pnl_main;
        private DefaultElementUC uc_default;
        private User_Controls.ClassesElementUC uc_classes;
        private User_Controls.ClassElementUC uc_class;
        private ConstructorElementUC uc_constructor;
        private ParamElementUC uc_param;
    }
}

