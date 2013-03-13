namespace TestExecuteBatchRunner
{
    partial class ProgressForm
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
            this.components = new System.ComponentModel.Container();
            this.prb_progress = new System.Windows.Forms.ProgressBar();
            this.btn_play = new System.Windows.Forms.Button();
            this.btn_pause = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.bgw_execute = new System.ComponentModel.BackgroundWorker();
            this.tmr_timeout = new System.Windows.Forms.Timer(this.components);
            this.lbl_information = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // prb_progress
            // 
            this.prb_progress.Location = new System.Drawing.Point(12, 12);
            this.prb_progress.Name = "prb_progress";
            this.prb_progress.Size = new System.Drawing.Size(609, 23);
            this.prb_progress.TabIndex = 0;
            // 
            // btn_play
            // 
            this.btn_play.Location = new System.Drawing.Point(385, 41);
            this.btn_play.Name = "btn_play";
            this.btn_play.Size = new System.Drawing.Size(75, 23);
            this.btn_play.TabIndex = 1;
            this.btn_play.Text = "Play";
            this.btn_play.UseVisualStyleBackColor = true;
            this.btn_play.Click += new System.EventHandler(this.btn_play_Click);
            // 
            // btn_pause
            // 
            this.btn_pause.Location = new System.Drawing.Point(466, 41);
            this.btn_pause.Name = "btn_pause";
            this.btn_pause.Size = new System.Drawing.Size(75, 23);
            this.btn_pause.TabIndex = 2;
            this.btn_pause.Text = "Pause";
            this.btn_pause.UseVisualStyleBackColor = true;
            this.btn_pause.Click += new System.EventHandler(this.btn_pause_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.Location = new System.Drawing.Point(546, 41);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(75, 23);
            this.btn_stop.TabIndex = 3;
            this.btn_stop.Text = "Stop";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // bgw_execute
            // 
            this.bgw_execute.WorkerReportsProgress = true;
            this.bgw_execute.WorkerSupportsCancellation = true;
            this.bgw_execute.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_execute_DoWork);
            this.bgw_execute.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgw_execute_ProgressChanged);
            // 
            // tmr_timeout
            // 
            this.tmr_timeout.Interval = 1000;
            this.tmr_timeout.Tick += new System.EventHandler(this.tmr_timeout_Tick);
            // 
            // lbl_information
            // 
            this.lbl_information.AutoSize = true;
            this.lbl_information.Location = new System.Drawing.Point(12, 46);
            this.lbl_information.Name = "lbl_information";
            this.lbl_information.Size = new System.Drawing.Size(0, 13);
            this.lbl_information.TabIndex = 4;
            // 
            // ProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 76);
            this.Controls.Add(this.lbl_information);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.btn_pause);
            this.Controls.Add(this.btn_play);
            this.Controls.Add(this.prb_progress);
            this.Name = "ProgressForm";
            this.Text = "ProgressForm";
            this.Load += new System.EventHandler(this.ProgressForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar prb_progress;
        private System.Windows.Forms.Button btn_play;
        private System.Windows.Forms.Button btn_pause;
        private System.Windows.Forms.Button btn_stop;
        private System.ComponentModel.BackgroundWorker bgw_execute;
        private System.Windows.Forms.Timer tmr_timeout;
        private System.Windows.Forms.Label lbl_information;
    }
}