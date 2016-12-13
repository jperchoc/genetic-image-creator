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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelFitness = new System.Windows.Forms.Label();
            this.tablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imageOriginale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCalculee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updownNbChar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updownNbGenerations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updownNbPopulation)).BeginInit();
            this.groupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tablePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageOriginale
            // 
            this.imageOriginale.BackColor = System.Drawing.Color.WhiteSmoke;
            this.imageOriginale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageOriginale.Location = new System.Drawing.Point(410, 3);
            this.imageOriginale.Name = "imageOriginale";
            this.imageOriginale.Size = new System.Drawing.Size(402, 760);
            this.imageOriginale.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageOriginale.TabIndex = 1;
            this.imageOriginale.TabStop = false;
            this.imageOriginale.DoubleClick += new System.EventHandler(this.loadImageOriginale);
            // 
            // imageCalculee
            // 
            this.imageCalculee.BackColor = System.Drawing.Color.WhiteSmoke;
            this.imageCalculee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageCalculee.Location = new System.Drawing.Point(3, 3);
            this.imageCalculee.Name = "imageCalculee";
            this.imageCalculee.Size = new System.Drawing.Size(401, 760);
            this.imageCalculee.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageCalculee.TabIndex = 0;
            this.imageCalculee.TabStop = false;
            // 
            // boutonStart
            // 
            this.boutonStart.Enabled = false;
            this.boutonStart.Location = new System.Drawing.Point(8, 246);
            this.boutonStart.Name = "boutonStart";
            this.boutonStart.Size = new System.Drawing.Size(162, 23);
            this.boutonStart.TabIndex = 5;
            this.boutonStart.Text = "Start";
            this.boutonStart.UseVisualStyleBackColor = true;
            this.boutonStart.Click += new System.EventHandler(this.btn_startClick);
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
            this.updownNbGenerations.Location = new System.Drawing.Point(69, 72);
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
            this.updownNbPopulation.Location = new System.Drawing.Point(69, 46);
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
            10,
            0,
            0,
            0});
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(9, 305);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(162, 23);
            this.progressBar.TabIndex = 15;
            // 
            // progressBarFitness
            // 
            this.progressBarFitness.Location = new System.Drawing.Point(9, 330);
            this.progressBarFitness.Name = "progressBarFitness";
            this.progressBarFitness.Size = new System.Drawing.Size(162, 23);
            this.progressBarFitness.TabIndex = 15;
            // 
            // groupBox
            // 
            this.groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox.Controls.Add(this.button2);
            this.groupBox.Controls.Add(this.button1);
            this.groupBox.Controls.Add(this.groupBox1);
            this.groupBox.Controls.Add(this.label3);
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Controls.Add(this.label1);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Location = new System.Drawing.Point(8, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(164, 111);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Drawing";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(56, 17);
            this.radioButton1.TabIndex = 21;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Circles";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 42);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(76, 17);
            this.radioButton2.TabIndex = 22;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Characters";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(6, 65);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(58, 17);
            this.radioButton3.TabIndex = 23;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Elipses";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(6, 88);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(68, 17);
            this.radioButton4.TabIndex = 22;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Triangles";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Iterations";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Population";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Items";
            // 
            // labelFitness
            // 
            this.labelFitness.Location = new System.Drawing.Point(9, 360);
            this.labelFitness.Name = "labelFitness";
            this.labelFitness.Size = new System.Drawing.Size(162, 60);
            this.labelFitness.TabIndex = 8;
            this.labelFitness.Text = "Fitness : 00.00%";
            // 
            // tablePanel
            // 
            this.tablePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tablePanel.ColumnCount = 2;
            this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePanel.Controls.Add(this.imageCalculee, 0, 0);
            this.tablePanel.Controls.Add(this.imageOriginale, 1, 0);
            this.tablePanel.Location = new System.Drawing.Point(13, 13);
            this.tablePanel.Name = "tablePanel";
            this.tablePanel.RowCount = 1;
            this.tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tablePanel.Size = new System.Drawing.Size(815, 766);
            this.tablePanel.TabIndex = 0;
            this.tablePanel.Text = "Images";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(8, 275);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 23);
            this.button1.TabIndex = 22;
            this.button1.Text = "Clean";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(8, 215);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(162, 25);
            this.button2.TabIndex = 23;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ImageCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 791);
            this.Controls.Add(this.tablePanel);
            this.Controls.Add(this.groupBox);
            this.Name = "ImageCreator";
            this.Text = "ImageCreator";
            ((System.ComponentModel.ISupportInitialize)(this.imageOriginale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCalculee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updownNbChar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updownNbGenerations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updownNbPopulation)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tablePanel.ResumeLayout(false);
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
        private GroupBox groupBox1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
		private RadioButton radioButton3;
		private RadioButton radioButton4;
        private Label label3;
        private Label label2;
        private Label label1;
        private System.Windows.Forms.Label labelFitness;
        private Button button1;
        private Button button2;
    }
}

