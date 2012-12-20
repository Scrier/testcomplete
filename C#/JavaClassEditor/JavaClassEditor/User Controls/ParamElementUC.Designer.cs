namespace JavaClassEditor
{
    partial class ParamElementUC
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
            this.lbl_type = new System.Windows.Forms.Label();
            this.lbl_element = new System.Windows.Forms.Label();
            this.tbx_element = new System.Windows.Forms.TextBox();
            this.cbx_type = new System.Windows.Forms.ComboBox();
            this.tbx_name = new System.Windows.Forms.TextBox();
            this.lbl_name = new System.Windows.Forms.Label();
            this.cbx_init = new System.Windows.Forms.CheckBox();
            this.tbx_init = new System.Windows.Forms.TextBox();
            this.tbx_description = new System.Windows.Forms.TextBox();
            this.cbx_description = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lbl_type
            // 
            this.lbl_type.AutoSize = true;
            this.lbl_type.Location = new System.Drawing.Point(3, 32);
            this.lbl_type.Name = "lbl_type";
            this.lbl_type.Size = new System.Drawing.Size(34, 13);
            this.lbl_type.TabIndex = 1;
            this.lbl_type.Text = "Type:";
            // 
            // lbl_element
            // 
            this.lbl_element.AutoSize = true;
            this.lbl_element.Location = new System.Drawing.Point(3, 6);
            this.lbl_element.Name = "lbl_element";
            this.lbl_element.Size = new System.Drawing.Size(48, 13);
            this.lbl_element.TabIndex = 2;
            this.lbl_element.Text = "Element:";
            // 
            // tbx_element
            // 
            this.tbx_element.Location = new System.Drawing.Point(106, 3);
            this.tbx_element.Name = "tbx_element";
            this.tbx_element.Size = new System.Drawing.Size(199, 20);
            this.tbx_element.TabIndex = 3;
            // 
            // cbx_type
            // 
            this.cbx_type.FormattingEnabled = true;
            this.cbx_type.Location = new System.Drawing.Point(106, 29);
            this.cbx_type.Name = "cbx_type";
            this.cbx_type.Size = new System.Drawing.Size(199, 21);
            this.cbx_type.TabIndex = 4;
            this.cbx_type.SelectedIndexChanged += new System.EventHandler(this.cbx_type_SelectedIndexChanged);
            // 
            // tbx_name
            // 
            this.tbx_name.Location = new System.Drawing.Point(106, 56);
            this.tbx_name.Name = "tbx_name";
            this.tbx_name.Size = new System.Drawing.Size(199, 20);
            this.tbx_name.TabIndex = 5;
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(3, 59);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(38, 13);
            this.lbl_name.TabIndex = 6;
            this.lbl_name.Text = "Name:";
            // 
            // cbx_init
            // 
            this.cbx_init.AutoSize = true;
            this.cbx_init.Location = new System.Drawing.Point(6, 84);
            this.cbx_init.Name = "cbx_init";
            this.cbx_init.Size = new System.Drawing.Size(43, 17);
            this.cbx_init.TabIndex = 7;
            this.cbx_init.Text = "Init:";
            this.cbx_init.UseVisualStyleBackColor = true;
            this.cbx_init.CheckedChanged += new System.EventHandler(this.cbx_init_CheckedChanged);
            // 
            // tbx_init
            // 
            this.tbx_init.Location = new System.Drawing.Point(106, 82);
            this.tbx_init.Name = "tbx_init";
            this.tbx_init.Size = new System.Drawing.Size(199, 20);
            this.tbx_init.TabIndex = 8;
            // 
            // tbx_description
            // 
            this.tbx_description.Location = new System.Drawing.Point(106, 108);
            this.tbx_description.Name = "tbx_description";
            this.tbx_description.Size = new System.Drawing.Size(199, 20);
            this.tbx_description.TabIndex = 9;
            // 
            // cbx_description
            // 
            this.cbx_description.AutoSize = true;
            this.cbx_description.Location = new System.Drawing.Point(6, 110);
            this.cbx_description.Name = "cbx_description";
            this.cbx_description.Size = new System.Drawing.Size(82, 17);
            this.cbx_description.TabIndex = 10;
            this.cbx_description.Text = "Description:";
            this.cbx_description.UseVisualStyleBackColor = true;
            this.cbx_description.CheckedChanged += new System.EventHandler(this.cbx_description_CheckedChanged);
            // 
            // ParamElementUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbx_description);
            this.Controls.Add(this.tbx_description);
            this.Controls.Add(this.tbx_init);
            this.Controls.Add(this.cbx_init);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.tbx_name);
            this.Controls.Add(this.cbx_type);
            this.Controls.Add(this.tbx_element);
            this.Controls.Add(this.lbl_element);
            this.Controls.Add(this.lbl_type);
            this.Name = "ParamElementUC";
            this.Size = new System.Drawing.Size(470, 370);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_type;
        private System.Windows.Forms.Label lbl_element;
        private System.Windows.Forms.TextBox tbx_element;
        private System.Windows.Forms.ComboBox cbx_type;
        private System.Windows.Forms.TextBox tbx_name;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.CheckBox cbx_init;
        private System.Windows.Forms.TextBox tbx_init;
        private System.Windows.Forms.TextBox tbx_description;
        private System.Windows.Forms.CheckBox cbx_description;
    }
}
