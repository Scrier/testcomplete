namespace JavaClassEditor
{
    partial class ConstructorElementUC
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
            this.btn_add_param = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_add_param
            // 
            this.btn_add_param.Location = new System.Drawing.Point(3, 3);
            this.btn_add_param.Name = "btn_add_param";
            this.btn_add_param.Size = new System.Drawing.Size(97, 23);
            this.btn_add_param.TabIndex = 0;
            this.btn_add_param.Text = "Add Parameter";
            this.btn_add_param.UseVisualStyleBackColor = true;
            this.btn_add_param.Click += new System.EventHandler(this.btn_add_param_Click);
            // 
            // ConstructorElementUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_add_param);
            this.Name = "ConstructorElementUC";
            this.Size = new System.Drawing.Size(370, 318);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_add_param;
    }
}
