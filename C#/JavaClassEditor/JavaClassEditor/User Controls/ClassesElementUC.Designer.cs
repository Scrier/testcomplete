namespace JavaClassEditor.User_Controls
{
    partial class ClassesElementUC
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
            this.btn_new_class = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_new_class
            // 
            this.btn_new_class.Location = new System.Drawing.Point(12, 12);
            this.btn_new_class.Name = "btn_new_class";
            this.btn_new_class.Size = new System.Drawing.Size(97, 23);
            this.btn_new_class.TabIndex = 0;
            this.btn_new_class.Text = "Add New Class";
            this.btn_new_class.UseVisualStyleBackColor = true;
            this.btn_new_class.Click += new System.EventHandler(this.btn_new_class_Click);
            // 
            // ClassesElementUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_new_class);
            this.Name = "ClassesElementUC";
            this.Size = new System.Drawing.Size(306, 249);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_new_class;
    }
}
