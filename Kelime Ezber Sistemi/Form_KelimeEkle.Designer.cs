
namespace Kelime_Ezber_Sistemi
{
    partial class Form_KelimeEkle
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
            this.gridControl_kelimeEkle = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btn_gözat = new DevExpress.XtraEditors.SimpleButton();
            this.lbl_dosyaİsmi = new DevExpress.XtraEditors.LabelControl();
            this.btn_yükle = new DevExpress.XtraEditors.SimpleButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lbl_yüzde = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_kelimeEkle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl_kelimeEkle
            // 
            this.gridControl_kelimeEkle.Location = new System.Drawing.Point(12, 56);
            this.gridControl_kelimeEkle.MainView = this.gridView1;
            this.gridControl_kelimeEkle.Name = "gridControl_kelimeEkle";
            this.gridControl_kelimeEkle.Size = new System.Drawing.Size(669, 578);
            this.gridControl_kelimeEkle.TabIndex = 0;
            this.gridControl_kelimeEkle.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.gridView1.GridControl = this.gridControl_kelimeEkle;
            this.gridView1.Name = "gridView1";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "TR";
            this.gridColumn1.FieldName = "TR";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "EN";
            this.gridColumn2.FieldName = "EN";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "TÜR";
            this.gridColumn3.FieldName = "tür";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Alan";
            this.gridColumn4.FieldName = "alan";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // btn_gözat
            // 
            this.btn_gözat.Location = new System.Drawing.Point(13, 13);
            this.btn_gözat.Name = "btn_gözat";
            this.btn_gözat.Size = new System.Drawing.Size(44, 23);
            this.btn_gözat.TabIndex = 1;
            this.btn_gözat.Text = "Gözat";
            this.btn_gözat.Click += new System.EventHandler(this.btn_gözat_Click);
            // 
            // lbl_dosyaİsmi
            // 
            this.lbl_dosyaİsmi.Location = new System.Drawing.Point(65, 18);
            this.lbl_dosyaİsmi.Name = "lbl_dosyaİsmi";
            this.lbl_dosyaİsmi.Size = new System.Drawing.Size(52, 13);
            this.lbl_dosyaİsmi.TabIndex = 2;
            this.lbl_dosyaİsmi.Text = "Dosya İsmi";
            // 
            // btn_yükle
            // 
            this.btn_yükle.Location = new System.Drawing.Point(637, 8);
            this.btn_yükle.Name = "btn_yükle";
            this.btn_yükle.Size = new System.Drawing.Size(44, 23);
            this.btn_yükle.TabIndex = 1;
            this.btn_yükle.Text = "Yükle";
            this.btn_yükle.Click += new System.EventHandler(this.btn_yükle_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lbl_yüzde
            // 
            this.lbl_yüzde.Appearance.Font = new System.Drawing.Font("Tahoma", 7F);
            this.lbl_yüzde.Appearance.Options.UseFont = true;
            this.lbl_yüzde.Location = new System.Drawing.Point(637, 37);
            this.lbl_yüzde.Name = "lbl_yüzde";
            this.lbl_yüzde.Size = new System.Drawing.Size(5, 11);
            this.lbl_yüzde.TabIndex = 3;
            this.lbl_yüzde.Text = "0";
            // 
            // Form_KelimeEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 646);
            this.Controls.Add(this.lbl_yüzde);
            this.Controls.Add(this.lbl_dosyaİsmi);
            this.Controls.Add(this.btn_yükle);
            this.Controls.Add(this.btn_gözat);
            this.Controls.Add(this.gridControl_kelimeEkle);
            this.Name = "Form_KelimeEkle";
            this.Text = "Form_KelimeEkle";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_kelimeEkle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_kelimeEkle;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton btn_gözat;
        private DevExpress.XtraEditors.LabelControl lbl_dosyaİsmi;
        private DevExpress.XtraEditors.SimpleButton btn_yükle;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private DevExpress.XtraEditors.LabelControl lbl_yüzde;
    }
}