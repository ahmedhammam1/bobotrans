﻿namespace DesktopAplikacija.Menadzer
{
    partial class DodajRasporedVoznje
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DodajRasporedVoznje));
            this.btnBrisi = new System.Windows.Forms.Button();
            this.btnSpasi = new System.Windows.Forms.Button();
            this.btnIzadji = new System.Windows.Forms.Button();
            this.gbRasporedi = new System.Windows.Forms.GroupBox();
            this.dgvRasporediVoznji = new System.Windows.Forms.DataGridView();
            this.colSifra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDanUSedmici = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVrijemePolaskaRasporeda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPotrebnaSjedista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdAutobusa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbRasporedi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRasporediVoznji)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBrisi
            // 
            this.btnBrisi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrisi.Location = new System.Drawing.Point(366, 268);
            this.btnBrisi.Name = "btnBrisi";
            this.btnBrisi.Size = new System.Drawing.Size(75, 23);
            this.btnBrisi.TabIndex = 11;
            this.btnBrisi.Text = "Briši red";
            this.btnBrisi.UseVisualStyleBackColor = true;
            this.btnBrisi.Click += new System.EventHandler(this.btnBrisi_Click);
            // 
            // btnSpasi
            // 
            this.btnSpasi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSpasi.Location = new System.Drawing.Point(285, 268);
            this.btnSpasi.Name = "btnSpasi";
            this.btnSpasi.Size = new System.Drawing.Size(75, 23);
            this.btnSpasi.TabIndex = 10;
            this.btnSpasi.Text = "Spremi";
            this.btnSpasi.UseVisualStyleBackColor = true;
            this.btnSpasi.Click += new System.EventHandler(this.btnSpasi_Click);
            // 
            // btnIzadji
            // 
            this.btnIzadji.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIzadji.Location = new System.Drawing.Point(447, 268);
            this.btnIzadji.Name = "btnIzadji";
            this.btnIzadji.Size = new System.Drawing.Size(75, 23);
            this.btnIzadji.TabIndex = 9;
            this.btnIzadji.Text = "Izađi";
            this.btnIzadji.UseVisualStyleBackColor = true;
            this.btnIzadji.Click += new System.EventHandler(this.btnIzadji_Click);
            // 
            // gbRasporedi
            // 
            this.gbRasporedi.Controls.Add(this.dgvRasporediVoznji);
            this.gbRasporedi.Location = new System.Drawing.Point(12, 12);
            this.gbRasporedi.Name = "gbRasporedi";
            this.gbRasporedi.Size = new System.Drawing.Size(510, 250);
            this.gbRasporedi.TabIndex = 8;
            this.gbRasporedi.TabStop = false;
            this.gbRasporedi.Text = "Rasporedi vožnji";
            // 
            // dgvRasporediVoznji
            // 
            this.dgvRasporediVoznji.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvRasporediVoznji.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRasporediVoznji.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSifra,
            this.colDanUSedmici,
            this.colVrijemePolaskaRasporeda,
            this.colPotrebnaSjedista,
            this.colIdAutobusa});
            this.dgvRasporediVoznji.Location = new System.Drawing.Point(16, 19);
            this.dgvRasporediVoznji.Name = "dgvRasporediVoznji";
            this.dgvRasporediVoznji.Size = new System.Drawing.Size(484, 225);
            this.dgvRasporediVoznji.TabIndex = 5;
            // 
            // colSifra
            // 
            this.colSifra.HeaderText = "Šifra";
            this.colSifra.Name = "colSifra";
            this.colSifra.ReadOnly = true;
            this.colSifra.Width = 40;
            // 
            // colDanUSedmici
            // 
            this.colDanUSedmici.HeaderText = "Dan u sedmici";
            this.colDanUSedmici.Name = "colDanUSedmici";
            // 
            // colVrijemePolaskaRasporeda
            // 
            this.colVrijemePolaskaRasporeda.HeaderText = "Vrijeme polaska";
            this.colVrijemePolaskaRasporeda.Name = "colVrijemePolaskaRasporeda";
            this.colVrijemePolaskaRasporeda.Width = 110;
            // 
            // colPotrebnaSjedista
            // 
            this.colPotrebnaSjedista.HeaderText = "Potreban broj sjedišta";
            this.colPotrebnaSjedista.Name = "colPotrebnaSjedista";
            this.colPotrebnaSjedista.Width = 90;
            // 
            // colIdAutobusa
            // 
            this.colIdAutobusa.HeaderText = "Šifra autobusa";
            this.colIdAutobusa.Name = "colIdAutobusa";
            // 
            // DodajRasporedVoznje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 306);
            this.Controls.Add(this.btnBrisi);
            this.Controls.Add(this.btnSpasi);
            this.Controls.Add(this.btnIzadji);
            this.Controls.Add(this.gbRasporedi);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(548, 99999);
            this.MinimumSize = new System.Drawing.Size(548, 344);
            this.Name = "DodajRasporedVoznje";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dodavanje rasporeda vožnje";
            this.Load += new System.EventHandler(this.DodajRasporedVoznje_Load);
            this.gbRasporedi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRasporediVoznji)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBrisi;
        private System.Windows.Forms.Button btnSpasi;
        private System.Windows.Forms.Button btnIzadji;
        private System.Windows.Forms.GroupBox gbRasporedi;
        private System.Windows.Forms.DataGridView dgvRasporediVoznji;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSifra;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDanUSedmici;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVrijemePolaskaRasporeda;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPotrebnaSjedista;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdAutobusa;
    }
}