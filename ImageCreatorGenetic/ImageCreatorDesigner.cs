using System;
using System.Windows.Forms;


namespace ImageCreatorGenetic
{
	partial class ImageCreator
	{
		private System.ComponentModel.IContainer components = null;
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}
		private void InitializeComponent()
		{
			this.imageOriginale = new System.Windows.Forms.PictureBox();
			this.imageCalculee = new System.Windows.Forms.PictureBox();
			this.boutonStart = new System.Windows.Forms.Button();
			this.updownNbChar = new System.Windows.Forms.NumericUpDown();
			this.updownNbGenerations = new System.Windows.Forms.NumericUpDown();
			this.updownNbPopulation = new System.Windows.Forms.NumericUpDown();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.progressBarFitness = new System.Windows.Forms.ProgressBar();
			this.groupBox = new System.Windows.Forms.GroupBox();
			this.tablePanel = new System.Windows.Forms.TableLayoutPanel();
			this.labelFitness = new Label();

			((System.ComponentModel.ISupportInitialize)(this.updownNbChar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.updownNbGenerations)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.updownNbPopulation)).BeginInit();
			this.SuspendLayout();
			//
			// tablePanel
			//
			this.tablePanel.RowCount = 1;
			this.tablePanel.ColumnCount = 2;
			for (int i = 0; i < tablePanel.ColumnCount; i++)
			{
				tablePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,50));
			}

			this.tablePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom  
				| System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Left))));

			this.tablePanel.Controls.Add(imageCalculee, 0, 0);
			this.tablePanel.Controls.Add(imageOriginale, 1,0);
			this.tablePanel.Location = new System.Drawing.Point(13, 13);
			this.tablePanel.Name = "tablePanel";
			this.tablePanel.Size = new System.Drawing.Size(815, 766);
			this.tablePanel.Text = "Images";
			// 
			// groupBox1
			// 
			this.groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox.Controls.Add(this.boutonStart);
			this.groupBox.Controls.Add(this.updownNbChar);
			this.groupBox.Controls.Add(this.labelFitness);
			this.groupBox.Controls.Add(this.updownNbGenerations);
			this.groupBox.Controls.Add(this.updownNbPopulation);
			this.groupBox.Controls.Add(this.progressBar);
			this.groupBox.Controls.Add(this.progressBarFitness);
			this.groupBox.Location = new System.Drawing.Point(828, 13);
			this.groupBox.Name = "groupBox";
			this.groupBox.Size = new System.Drawing.Size(183, 766);
			this.groupBox.TabIndex = 1;
			this.groupBox.TabStop = false;
			this.groupBox.Text = "Contrôles";
			//
			// imageOriginale
			//
			this.imageOriginale.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.imageOriginale.Dock = System.Windows.Forms.DockStyle.Fill;
			this.imageOriginale.BackColor = System.Drawing.Color.WhiteSmoke;
			this.imageOriginale.DoubleClick += new System.EventHandler(this.loadImageOriginale);
			//
			// imageCalculee
			//
			this.imageCalculee.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.imageCalculee.Dock = System.Windows.Forms.DockStyle.Fill;
			this.imageCalculee.BackColor = System.Drawing.Color.WhiteSmoke;
			//
			// boutonStart
			//
			this.boutonStart.Location = new System.Drawing.Point(5, 126);
			this.boutonStart.Name = "button1";
			this.boutonStart.Size = new System.Drawing.Size(167, 23);
			this.boutonStart.TabIndex = 5;
			this.boutonStart.Text = "Create 1 generation";
			this.boutonStart.UseVisualStyleBackColor = true;
			this.boutonStart.Click += new System.EventHandler(this.startGeneration);
			//
			// updownNbChar
			//
			this.updownNbChar.Location = new System.Drawing.Point(69, 20);
			this.updownNbChar.Maximum = new decimal(new int[] {
				50000,
				0,
				0,
				0});
			this.updownNbChar.Minimum = new decimal(new int[] {
				10,
				0,
				0,
				0});
			this.updownNbChar.Name = "updownNbChar";
			this.updownNbChar.Size = new System.Drawing.Size(103, 20);
			this.updownNbChar.TabIndex = 7;
			this.updownNbChar.Value = new decimal(new int[] {
				1500,
				0,
				0,
				0});
			//
			// updownNbGenerations
			//
			this.updownNbGenerations.Location = new System.Drawing.Point(69, 90);
			this.updownNbGenerations.Maximum = new decimal(new int[] {
				5000000,
				0,
				0,
				0});
			this.updownNbGenerations.Minimum = new decimal(new int[] {
				5,
				0,
				0,
				0});
			this.updownNbGenerations.Name = "updownNbGenerations";
			this.updownNbGenerations.Size = new System.Drawing.Size(103, 20);
			this.updownNbGenerations.TabIndex = 7;
			this.updownNbGenerations.Value = new decimal(new int[] {
				2000,
				0,
				0,
				0});
			//
			// updownNbPopulation
			//
			this.updownNbPopulation.Location = new System.Drawing.Point(69, 50);
			this.updownNbPopulation.Maximum = new decimal(new int[] {
				5000000,
				0,
				0,
				0});
			this.updownNbPopulation.Minimum = new decimal(new int[] {
				5,
				0,
				0,
				0});
			this.updownNbPopulation.Name = "updownNbPopulation";
			this.updownNbPopulation.Size = new System.Drawing.Size(103, 20);
			this.updownNbPopulation.TabIndex = 7;
			this.updownNbPopulation.Value = new decimal(new int[] {
				50,
				0,
				0,
				0});
			//
			// progressBarFitness
			//
			this.progressBarFitness.Location = new System.Drawing.Point(5, 150);
			this.progressBarFitness.Name = "progressBarFitness";
			this.progressBarFitness.Size = new System.Drawing.Size(167, 23);
			this.progressBarFitness.TabIndex = 15;
			//
			// progressBar
			//
			this.progressBar.Location = new System.Drawing.Point(5, 180);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(167, 23);
			this.progressBar.TabIndex = 15;
			//
			// labelFitness
			//
			this.labelFitness.Location = new System.Drawing.Point(5, 210);
			this.labelFitness.Name = "labelFitness";
			this.labelFitness.Size = new System.Drawing.Size(167, 43);
			this.labelFitness.Text = "Fitness : 00.00%";


			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1023, 791);
			this.Controls.Add(this.tablePanel);
			this.Controls.Add(this.groupBox);
			//this.Controls.Add(this.boutonStart);
			this.Name = "ImageCreator";
			this.Text = "ImageCreator";
			this.groupBox.ResumeLayout(false);
			this.groupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.updownNbChar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.updownNbGenerations)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.updownNbPopulation)).EndInit();
			//this.tabControl1.ResumeLayout(false);
			//this.tabPage1.ResumeLayout(false);
			//this.tabPage2.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.TableLayoutPanel tablePanel;
		private System.Windows.Forms.PictureBox imageOriginale;
		private System.Windows.Forms.PictureBox imageCalculee;
		private System.Windows.Forms.GroupBox groupBox;
		private System.Windows.Forms.Button boutonStart;
		private System.Windows.Forms.NumericUpDown updownNbChar;
		private System.Windows.Forms.NumericUpDown updownNbGenerations;
		private System.Windows.Forms.NumericUpDown updownNbPopulation;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.ProgressBar progressBarFitness;
		private System.Windows.Forms.Label labelFitness;
	}
}

