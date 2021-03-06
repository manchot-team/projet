﻿namespace Manchot
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
            this.waveformGraph1 = new NationalInstruments.UI.WindowsForms.WaveformGraph();
            this.waveformPlot1 = new NationalInstruments.UI.WaveformPlot();
            this.xAxis1 = new NationalInstruments.UI.XAxis();
            this.yAxis1 = new NationalInstruments.UI.YAxis();
            this.waveformPlot2 = new NationalInstruments.UI.WaveformPlot();
            this.waveformPlot3 = new NationalInstruments.UI.WaveformPlot();
            this.waveformPlot4 = new NationalInstruments.UI.WaveformPlot();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fichiersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ouvrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.affichageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.touteLesCourbesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.balanceCourbe1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.balanceCourbe2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.balanceCourbe3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sommeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analyseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lancerLanalyseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exporterLesRésultatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.waveformGraph1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // waveformGraph1
            // 
            this.waveformGraph1.ImmediateUpdates = true;
            this.waveformGraph1.InteractionModeDefault = NationalInstruments.UI.GraphDefaultInteractionMode.PanX;
            this.waveformGraph1.Location = new System.Drawing.Point(12, 43);
            this.waveformGraph1.Name = "waveformGraph1";
            this.waveformGraph1.Plots.AddRange(new NationalInstruments.UI.WaveformPlot[] {
            this.waveformPlot1,
            this.waveformPlot2,
            this.waveformPlot3,
            this.waveformPlot4});
            this.waveformGraph1.Size = new System.Drawing.Size(833, 336);
            this.waveformGraph1.TabIndex = 0;
            this.waveformGraph1.UseColorGenerator = true;
            this.waveformGraph1.XAxes.AddRange(new NationalInstruments.UI.XAxis[] {
            this.xAxis1});
            this.waveformGraph1.YAxes.AddRange(new NationalInstruments.UI.YAxis[] {
            this.yAxis1});
            // 
            // waveformPlot1
            // 
            this.waveformPlot1.XAxis = this.xAxis1;
            this.waveformPlot1.YAxis = this.yAxis1;
            // 
            // waveformPlot2
            // 
            this.waveformPlot2.XAxis = this.xAxis1;
            this.waveformPlot2.YAxis = this.yAxis1;
            // 
            // waveformPlot3
            // 
            this.waveformPlot3.XAxis = this.xAxis1;
            this.waveformPlot3.YAxis = this.yAxis1;
            // 
            // waveformPlot4
            // 
            this.waveformPlot4.XAxis = this.xAxis1;
            this.waveformPlot4.YAxis = this.yAxis1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichiersToolStripMenuItem,
            this.affichageToolStripMenuItem,
            this.analyseToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1058, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fichiersToolStripMenuItem
            // 
            this.fichiersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ouvrirToolStripMenuItem});
            this.fichiersToolStripMenuItem.Name = "fichiersToolStripMenuItem";
            this.fichiersToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.fichiersToolStripMenuItem.Text = "Fichiers";
            // 
            // ouvrirToolStripMenuItem
            // 
            this.ouvrirToolStripMenuItem.Name = "ouvrirToolStripMenuItem";
            this.ouvrirToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.ouvrirToolStripMenuItem.Text = "Ouvrir";
            this.ouvrirToolStripMenuItem.Click += new System.EventHandler(this.ouvrirToolStripMenuItem_Click);
            // 
            // affichageToolStripMenuItem
            // 
            this.affichageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.touteLesCourbesToolStripMenuItem,
            this.balanceCourbe1ToolStripMenuItem,
            this.balanceCourbe2ToolStripMenuItem,
            this.balanceCourbe3ToolStripMenuItem,
            this.sommeToolStripMenuItem});
            this.affichageToolStripMenuItem.Enabled = false;
            this.affichageToolStripMenuItem.Name = "affichageToolStripMenuItem";
            this.affichageToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.affichageToolStripMenuItem.Text = "Affichage";
            // 
            // touteLesCourbesToolStripMenuItem
            // 
            this.touteLesCourbesToolStripMenuItem.AccessibleName = "0";
            this.touteLesCourbesToolStripMenuItem.Name = "touteLesCourbesToolStripMenuItem";
            this.touteLesCourbesToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.touteLesCourbesToolStripMenuItem.Text = "Toute les courbes";
            this.touteLesCourbesToolStripMenuItem.Click += new System.EventHandler(this.balanceCourbeToolStripMenuItem_Click);
            // 
            // balanceCourbe1ToolStripMenuItem
            // 
            this.balanceCourbe1ToolStripMenuItem.AccessibleName = "1";
            this.balanceCourbe1ToolStripMenuItem.Name = "balanceCourbe1ToolStripMenuItem";
            this.balanceCourbe1ToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.balanceCourbe1ToolStripMenuItem.Text = "Balance/Courbe 1";
            this.balanceCourbe1ToolStripMenuItem.Click += new System.EventHandler(this.balanceCourbeToolStripMenuItem_Click);
            // 
            // balanceCourbe2ToolStripMenuItem
            // 
            this.balanceCourbe2ToolStripMenuItem.AccessibleName = "2";
            this.balanceCourbe2ToolStripMenuItem.Name = "balanceCourbe2ToolStripMenuItem";
            this.balanceCourbe2ToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.balanceCourbe2ToolStripMenuItem.Text = "Balance/Courbe 2";
            this.balanceCourbe2ToolStripMenuItem.Click += new System.EventHandler(this.balanceCourbeToolStripMenuItem_Click);
            // 
            // balanceCourbe3ToolStripMenuItem
            // 
            this.balanceCourbe3ToolStripMenuItem.AccessibleName = "3";
            this.balanceCourbe3ToolStripMenuItem.Name = "balanceCourbe3ToolStripMenuItem";
            this.balanceCourbe3ToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.balanceCourbe3ToolStripMenuItem.Text = "Balance/Courbe 3";
            this.balanceCourbe3ToolStripMenuItem.Click += new System.EventHandler(this.balanceCourbeToolStripMenuItem_Click);
            // 
            // sommeToolStripMenuItem
            // 
            this.sommeToolStripMenuItem.CheckOnClick = true;
            this.sommeToolStripMenuItem.Name = "sommeToolStripMenuItem";
            this.sommeToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.sommeToolStripMenuItem.Text = "Somme";
            this.sommeToolStripMenuItem.Click += new System.EventHandler(this.sommeToolStripMenuItem_Click);
            // 
            // analyseToolStripMenuItem
            // 
            this.analyseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lancerLanalyseToolStripMenuItem,
            this.exporterLesRésultatsToolStripMenuItem});
            this.analyseToolStripMenuItem.Enabled = false;
            this.analyseToolStripMenuItem.Name = "analyseToolStripMenuItem";
            this.analyseToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.analyseToolStripMenuItem.Text = "Analyse";
            // 
            // lancerLanalyseToolStripMenuItem
            // 
            this.lancerLanalyseToolStripMenuItem.Name = "lancerLanalyseToolStripMenuItem";
            this.lancerLanalyseToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.lancerLanalyseToolStripMenuItem.Text = "Lancer l\'analyse";
            this.lancerLanalyseToolStripMenuItem.Click += new System.EventHandler(this.lancerLanalyseToolStripMenuItem_Click);
            // 
            // exporterLesRésultatsToolStripMenuItem
            // 
            this.exporterLesRésultatsToolStripMenuItem.Name = "exporterLesRésultatsToolStripMenuItem";
            this.exporterLesRésultatsToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.exporterLesRésultatsToolStripMenuItem.Text = "Exporter les résultats";
            this.exporterLesRésultatsToolStripMenuItem.Click += new System.EventHandler(this.exporterLesRésultatsToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLbl});
            this.statusStrip1.Location = new System.Drawing.Point(0, 413);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1058, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLbl
            // 
            this.toolStripStatusLbl.Name = "toolStripStatusLbl";
            this.toolStripStatusLbl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripStatusLbl.Size = new System.Drawing.Size(0, 17);
            this.toolStripStatusLbl.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(894, 43);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 435);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.waveformGraph1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "SupraPingu";
            ((System.ComponentModel.ISupportInitialize)(this.waveformGraph1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NationalInstruments.UI.WindowsForms.WaveformGraph waveformGraph1;
        private NationalInstruments.UI.WaveformPlot waveformPlot1;
        private NationalInstruments.UI.XAxis xAxis1;
        private NationalInstruments.UI.YAxis yAxis1;
        private NationalInstruments.UI.WaveformPlot waveformPlot2;
        private NationalInstruments.UI.WaveformPlot waveformPlot3;
        private NationalInstruments.UI.WaveformPlot waveformPlot4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fichiersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ouvrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem affichageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem balanceCourbe1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem balanceCourbe2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem balanceCourbe3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sommeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analyseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lancerLanalyseToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLbl;
        private System.Windows.Forms.ToolStripMenuItem touteLesCourbesToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ToolStripMenuItem exporterLesRésultatsToolStripMenuItem;
    }
}

