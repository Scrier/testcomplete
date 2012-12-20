namespace JavaClassEditor.User_Controls
{
    partial class ClassElementUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbx_id = new System.Windows.Forms.TextBox();
            this.tbx_namespace = new System.Windows.Forms.TextBox();
            this.tbx_class = new System.Windows.Forms.TextBox();
            this.lbl_id = new System.Windows.Forms.Label();
            this.lbl_namespace = new System.Windows.Forms.Label();
            this.lbl_classname = new System.Windows.Forms.Label();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_add_objectname = new System.Windows.Forms.Button();
            this.btn_add_constructor = new System.Windows.Forms.Button();
            this.btn_add_init = new System.Windows.Forms.Button();
            this.btn_add_params = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbx_id
            // 
            this.tbx_id.Location = new System.Drawing.Point(75, 3);
            this.tbx_id.Name = "tbx_id";
            this.tbx_id.Size = new System.Drawing.Size(100, 20);
            this.tbx_id.TabIndex = 0;
            // 
            // tbx_namespace
            // 
            this.tbx_namespace.Location = new System.Drawing.Point(75, 29);
            this.tbx_namespace.Name = "tbx_namespace";
            this.tbx_namespace.Size = new System.Drawing.Size(100, 20);
            this.tbx_namespace.TabIndex = 1;
            // 
            // tbx_class
            // 
            this.tbx_class.Location = new System.Drawing.Point(75, 55);
            this.tbx_class.Name = "tbx_class";
            this.tbx_class.Size = new System.Drawing.Size(100, 20);
            this.tbx_class.TabIndex = 2;
            // 
            // lbl_id
            // 
            this.lbl_id.AutoSize = true;
            this.lbl_id.Location = new System.Drawing.Point(3, 6);
            this.lbl_id.Name = "lbl_id";
            this.lbl_id.Size = new System.Drawing.Size(21, 13);
            this.lbl_id.TabIndex = 3;
            this.lbl_id.Text = "ID:";
            // 
            // lbl_namespace
            // 
            this.lbl_namespace.AutoSize = true;
            this.lbl_namespace.Location = new System.Drawing.Point(3, 32);
            this.lbl_namespace.Name = "lbl_namespace";
            this.lbl_namespace.Size = new System.Drawing.Size(67, 13);
            this.lbl_namespace.TabIndex = 4;
            this.lbl_namespace.Text = "Namespace:";
            // 
            // lbl_classname
            // 
            this.lbl_classname.AutoSize = true;
            this.lbl_classname.Location = new System.Drawing.Point(3, 58);
            this.lbl_classname.Name = "lbl_classname";
            this.lbl_classname.Size = new System.Drawing.Size(61, 13);
            this.lbl_classname.TabIndex = 5;
            this.lbl_classname.Text = "Classname:";
            // 
            // btn_edit
            // 
            this.btn_edit.Location = new System.Drawing.Point(6, 81);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(75, 23);
            this.btn_edit.TabIndex = 6;
            this.btn_edit.Text = "Edit";
            this.btn_edit.UseVisualStyleBackColor = true;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(87, 81);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 7;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_add_objectname
            // 
            this.btn_add_objectname.Location = new System.Drawing.Point(6, 110);
            this.btn_add_objectname.Name = "btn_add_objectname";
            this.btn_add_objectname.Size = new System.Drawing.Size(107, 23);
            this.btn_add_objectname.TabIndex = 8;
            this.btn_add_objectname.Text = "Add Object Name";
            this.btn_add_objectname.UseVisualStyleBackColor = true;
            this.btn_add_objectname.Click += new System.EventHandler(this.btn_add_objectname_Click);
            // 
            // btn_add_constructor
            // 
            this.btn_add_constructor.Location = new System.Drawing.Point(6, 139);
            this.btn_add_constructor.Name = "btn_add_constructor";
            this.btn_add_constructor.Size = new System.Drawing.Size(107, 23);
            this.btn_add_constructor.TabIndex = 9;
            this.btn_add_constructor.Text = "Add Constructor";
            this.btn_add_constructor.UseVisualStyleBackColor = true;
            this.btn_add_constructor.Click += new System.EventHandler(this.btn_add_constructor_Click);
            // 
            // btn_add_init
            // 
            this.btn_add_init.Location = new System.Drawing.Point(6, 168);
            this.btn_add_init.Name = "btn_add_init";
            this.btn_add_init.Size = new System.Drawing.Size(107, 23);
            this.btn_add_init.TabIndex = 10;
            this.btn_add_init.Text = "Add Init";
            this.btn_add_init.UseVisualStyleBackColor = true;
            this.btn_add_init.Click += new System.EventHandler(this.btn_add_init_Click);
            // 
            // btn_add_params
            // 
            this.btn_add_params.Location = new System.Drawing.Point(6, 197);
            this.btn_add_params.Name = "btn_add_params";
            this.btn_add_params.Size = new System.Drawing.Size(107, 23);
            this.btn_add_params.TabIndex = 11;
            this.btn_add_params.Text = "Add Parameters";
            this.btn_add_params.UseVisualStyleBackColor = true;
            this.btn_add_params.Click += new System.EventHandler(this.btn_add_params_Click);
            // 
            // ClassElementUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_add_params);
            this.Controls.Add(this.btn_add_init);
            this.Controls.Add(this.btn_add_constructor);
            this.Controls.Add(this.btn_add_objectname);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_edit);
            this.Controls.Add(this.lbl_classname);
            this.Controls.Add(this.lbl_namespace);
            this.Controls.Add(this.lbl_id);
            this.Controls.Add(this.tbx_class);
            this.Controls.Add(this.tbx_namespace);
            this.Controls.Add(this.tbx_id);
            this.Name = "ClassElementUC";
            this.Size = new System.Drawing.Size(471, 372);
            this.Load += new System.EventHandler(this.ClassElementUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbx_id;
        private System.Windows.Forms.TextBox tbx_namespace;
        private System.Windows.Forms.TextBox tbx_class;
        private System.Windows.Forms.Label lbl_id;
        private System.Windows.Forms.Label lbl_namespace;
        private System.Windows.Forms.Label lbl_classname;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_add_objectname;
        private System.Windows.Forms.Button btn_add_constructor;
        private System.Windows.Forms.Button btn_add_init;
        private System.Windows.Forms.Button btn_add_params;
    }
}
