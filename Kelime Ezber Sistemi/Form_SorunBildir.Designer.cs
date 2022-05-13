
namespace Kelime_Ezber_Sistemi
{
    partial class Form_SorunBildir
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.rtb_sorun = new System.Windows.Forms.RichTextBox();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lbl_kelime = new DevExpress.XtraEditors.LabelControl();
            this.lbl_cevap = new DevExpress.XtraEditors.LabelControl();
            this.btn_gönder = new DevExpress.XtraEditors.SimpleButton();
            this.btn_vazgeç = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(45, 36);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(41, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Kelime:";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(24, 67);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(62, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Tercümesi:";
            // 
            // rtb_sorun
            // 
            this.rtb_sorun.Location = new System.Drawing.Point(92, 117);
            this.rtb_sorun.Name = "rtb_sorun";
            this.rtb_sorun.Size = new System.Drawing.Size(199, 96);
            this.rtb_sorun.TabIndex = 1;
            this.rtb_sorun.Text = "";
            this.rtb_sorun.TextChanged += new System.EventHandler(this.rtb_sorun_TextChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(92, 98);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(159, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Sorunuzu kısaca özetleyiniz:";
            // 
            // lbl_kelime
            // 
            this.lbl_kelime.Location = new System.Drawing.Point(92, 36);
            this.lbl_kelime.Name = "lbl_kelime";
            this.lbl_kelime.Size = new System.Drawing.Size(30, 13);
            this.lbl_kelime.TabIndex = 0;
            this.lbl_kelime.Text = "Kelime";
            // 
            // lbl_cevap
            // 
            this.lbl_cevap.Location = new System.Drawing.Point(92, 67);
            this.lbl_cevap.Name = "lbl_cevap";
            this.lbl_cevap.Size = new System.Drawing.Size(29, 13);
            this.lbl_cevap.TabIndex = 0;
            this.lbl_cevap.Text = "cevap";
            // 
            // btn_gönder
            // 
            this.btn_gönder.Location = new System.Drawing.Point(156, 229);
            this.btn_gönder.Name = "btn_gönder";
            this.btn_gönder.Size = new System.Drawing.Size(75, 23);
            this.btn_gönder.TabIndex = 2;
            this.btn_gönder.Text = "GÖNDER";
            this.btn_gönder.Click += new System.EventHandler(this.btn_gönder_Click);
            // 
            // btn_vazgeç
            // 
            this.btn_vazgeç.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_vazgeç.Location = new System.Drawing.Point(237, 229);
            this.btn_vazgeç.Name = "btn_vazgeç";
            this.btn_vazgeç.Size = new System.Drawing.Size(54, 23);
            this.btn_vazgeç.TabIndex = 2;
            this.btn_vazgeç.Text = "VAZGEÇ";
            this.btn_vazgeç.Click += new System.EventHandler(this.btn_vazgeç_Click);
            // 
            // Form_SorunBildir
            // 
            this.AcceptButton = this.btn_gönder;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_vazgeç;
            this.ClientSize = new System.Drawing.Size(317, 279);
            this.ControlBox = false;
            this.Controls.Add(this.btn_vazgeç);
            this.Controls.Add(this.btn_gönder);
            this.Controls.Add(this.rtb_sorun);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.lbl_cevap);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.lbl_kelime);
            this.Controls.Add(this.labelControl1);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "Form_SorunBildir";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SORUN BİLDİR";
            this.Load += new System.EventHandler(this.Form_SorunBildir_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.RichTextBox rtb_sorun;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl lbl_kelime;
        private DevExpress.XtraEditors.LabelControl lbl_cevap;
        private DevExpress.XtraEditors.SimpleButton btn_gönder;
        private DevExpress.XtraEditors.SimpleButton btn_vazgeç;
    }
}