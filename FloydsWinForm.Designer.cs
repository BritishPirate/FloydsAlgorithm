using System.IO;

namespace Floyds
{
    partial class FloydsWinForm
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
            System.Windows.Forms.Button FindFile;
            this.MatrixTable = new System.Windows.Forms.DataGridView();
            this.IncludeTitles = new System.Windows.Forms.CheckBox();
            this.FromBox = new System.Windows.Forms.TextBox();
            this.ToBox = new System.Windows.Forms.TextBox();
            this.FromTitle = new System.Windows.Forms.Label();
            this.ToTitle = new System.Windows.Forms.Label();
            this.FileAddressBox = new System.Windows.Forms.TextBox();
            this.FileAddressTitle = new System.Windows.Forms.Label();
            this.RunFloyds = new System.Windows.Forms.Button();
            this.FindRoute = new System.Windows.Forms.Button();
            this.RouteTitle = new System.Windows.Forms.Label();
            this.CostTitle = new System.Windows.Forms.Label();
            this.StepNumberBox = new System.Windows.Forms.TextBox();
            this.GoToMatrix = new System.Windows.Forms.Button();
            this.RouteOrDistance = new System.Windows.Forms.ComboBox();
            this.Steps = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            FindFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MatrixTable)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FindFile
            // 
            FindFile.Location = new System.Drawing.Point(11, 113);
            FindFile.Name = "FindFile";
            FindFile.Size = new System.Drawing.Size(169, 31);
            FindFile.TabIndex = 18;
            FindFile.Text = "Find File";
            FindFile.UseVisualStyleBackColor = true;
            FindFile.Click += new System.EventHandler(this.FindFile_Click);
            // 
            // MatrixTable
            // 
            this.MatrixTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.MatrixTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.MatrixTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MatrixTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MatrixTable.Location = new System.Drawing.Point(0, 0);
            this.MatrixTable.Name = "MatrixTable";
            this.MatrixTable.RowHeadersWidth = 62;
            this.MatrixTable.RowTemplate.Height = 28;
            this.MatrixTable.Size = new System.Drawing.Size(1121, 573);
            this.MatrixTable.TabIndex = 1;
            this.MatrixTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MatrixTable_CellContentClick);
            // 
            // IncludeTitles
            // 
            this.IncludeTitles.AutoSize = true;
            this.IncludeTitles.Location = new System.Drawing.Point(15, 83);
            this.IncludeTitles.Name = "IncludeTitles";
            this.IncludeTitles.Size = new System.Drawing.Size(128, 24);
            this.IncludeTitles.TabIndex = 0;
            this.IncludeTitles.Text = "Include Titles";
            this.IncludeTitles.UseVisualStyleBackColor = true;
            this.IncludeTitles.CheckedChanged += new System.EventHandler(this.IncludeTitles_CheckedChanged);
            // 
            // FromBox
            // 
            this.FromBox.Location = new System.Drawing.Point(11, 343);
            this.FromBox.MaximumSize = new System.Drawing.Size(100, 26);
            this.FromBox.Name = "FromBox";
            this.FromBox.Size = new System.Drawing.Size(100, 26);
            this.FromBox.TabIndex = 2;
            // 
            // ToBox
            // 
            this.ToBox.Location = new System.Drawing.Point(11, 411);
            this.ToBox.Name = "ToBox";
            this.ToBox.Size = new System.Drawing.Size(100, 26);
            this.ToBox.TabIndex = 3;
            // 
            // FromTitle
            // 
            this.FromTitle.AutoSize = true;
            this.FromTitle.Location = new System.Drawing.Point(7, 320);
            this.FromTitle.MaximumSize = new System.Drawing.Size(46, 20);
            this.FromTitle.Name = "FromTitle";
            this.FromTitle.Size = new System.Drawing.Size(46, 20);
            this.FromTitle.TabIndex = 4;
            this.FromTitle.Text = "From";
            // 
            // ToTitle
            // 
            this.ToTitle.AutoSize = true;
            this.ToTitle.Location = new System.Drawing.Point(11, 382);
            this.ToTitle.Name = "ToTitle";
            this.ToTitle.Size = new System.Drawing.Size(27, 20);
            this.ToTitle.TabIndex = 5;
            this.ToTitle.Text = "To";
            // 
            // FileAddressBox
            // 
            this.FileAddressBox.Location = new System.Drawing.Point(11, 48);
            this.FileAddressBox.MaximumSize = new System.Drawing.Size(169, 26);
            this.FileAddressBox.Name = "FileAddressBox";
            this.FileAddressBox.Size = new System.Drawing.Size(169, 26);
            this.FileAddressBox.TabIndex = 6;
            // 
            // FileAddressTitle
            // 
            this.FileAddressTitle.AutoSize = true;
            this.FileAddressTitle.Location = new System.Drawing.Point(7, 25);
            this.FileAddressTitle.MaximumSize = new System.Drawing.Size(97, 20);
            this.FileAddressTitle.Name = "FileAddressTitle";
            this.FileAddressTitle.Size = new System.Drawing.Size(97, 20);
            this.FileAddressTitle.TabIndex = 7;
            this.FileAddressTitle.Text = "File Address";
            // 
            // RunFloyds
            // 
            this.RunFloyds.AutoSize = true;
            this.RunFloyds.Location = new System.Drawing.Point(11, 150);
            this.RunFloyds.MaximumSize = new System.Drawing.Size(168, 37);
            this.RunFloyds.Name = "RunFloyds";
            this.RunFloyds.Size = new System.Drawing.Size(168, 37);
            this.RunFloyds.TabIndex = 8;
            this.RunFloyds.Text = "Run Floyd\'s";
            this.RunFloyds.UseVisualStyleBackColor = true;
            this.RunFloyds.Click += new System.EventHandler(this.RunFloyds_Click);
            // 
            // FindRoute
            // 
            this.FindRoute.AutoSize = true;
            this.FindRoute.Location = new System.Drawing.Point(11, 443);
            this.FindRoute.Name = "FindRoute";
            this.FindRoute.Size = new System.Drawing.Size(100, 37);
            this.FindRoute.TabIndex = 9;
            this.FindRoute.Text = "Find Route";
            this.FindRoute.UseVisualStyleBackColor = true;
            this.FindRoute.Click += new System.EventHandler(this.FindRoute_Click);
            // 
            // RouteTitle
            // 
            this.RouteTitle.AutoSize = true;
            this.RouteTitle.Location = new System.Drawing.Point(7, 483);
            this.RouteTitle.MaximumSize = new System.Drawing.Size(200, 0);
            this.RouteTitle.Name = "RouteTitle";
            this.RouteTitle.Size = new System.Drawing.Size(53, 20);
            this.RouteTitle.TabIndex = 12;
            this.RouteTitle.Text = "Route";
            // 
            // CostTitle
            // 
            this.CostTitle.AutoSize = true;
            this.CostTitle.Location = new System.Drawing.Point(117, 443);
            this.CostTitle.Name = "CostTitle";
            this.CostTitle.Size = new System.Drawing.Size(42, 20);
            this.CostTitle.TabIndex = 13;
            this.CostTitle.Text = "Cost";
            // 
            // StepNumberBox
            // 
            this.StepNumberBox.Location = new System.Drawing.Point(11, 217);
            this.StepNumberBox.MaximumSize = new System.Drawing.Size(30, 26);
            this.StepNumberBox.Name = "StepNumberBox";
            this.StepNumberBox.Size = new System.Drawing.Size(30, 26);
            this.StepNumberBox.TabIndex = 14;
            // 
            // GoToMatrix
            // 
            this.GoToMatrix.AutoSize = true;
            this.GoToMatrix.Location = new System.Drawing.Point(11, 283);
            this.GoToMatrix.MaximumSize = new System.Drawing.Size(158, 34);
            this.GoToMatrix.Name = "GoToMatrix";
            this.GoToMatrix.Size = new System.Drawing.Size(158, 34);
            this.GoToMatrix.TabIndex = 15;
            this.GoToMatrix.Text = "Go To Matrix";
            this.GoToMatrix.UseVisualStyleBackColor = true;
            this.GoToMatrix.Click += new System.EventHandler(this.GoToMatrix_Click);
            // 
            // RouteOrDistance
            // 
            this.RouteOrDistance.FormattingEnabled = true;
            this.RouteOrDistance.Items.AddRange(new object[] {
            "Distance Matrices",
            "Route Matrices"});
            this.RouteOrDistance.Location = new System.Drawing.Point(11, 249);
            this.RouteOrDistance.MaximumSize = new System.Drawing.Size(121, 0);
            this.RouteOrDistance.Name = "RouteOrDistance";
            this.RouteOrDistance.Size = new System.Drawing.Size(121, 28);
            this.RouteOrDistance.TabIndex = 16;
            this.RouteOrDistance.SelectedIndexChanged += new System.EventHandler(this.RouteOrDistance_SelectedIndexChanged);
            // 
            // Steps
            // 
            this.Steps.AutoSize = true;
            this.Steps.Location = new System.Drawing.Point(7, 194);
            this.Steps.Name = "Steps";
            this.Steps.Size = new System.Drawing.Size(59, 20);
            this.Steps.TabIndex = 17;
            this.Steps.Text = "Steps: ";
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(FindFile);
            this.groupBox1.Controls.Add(this.Steps);
            this.groupBox1.Controls.Add(this.RouteOrDistance);
            this.groupBox1.Controls.Add(this.GoToMatrix);
            this.groupBox1.Controls.Add(this.StepNumberBox);
            this.groupBox1.Controls.Add(this.CostTitle);
            this.groupBox1.Controls.Add(this.RouteTitle);
            this.groupBox1.Controls.Add(this.FindRoute);
            this.groupBox1.Controls.Add(this.RunFloyds);
            this.groupBox1.Controls.Add(this.FileAddressTitle);
            this.groupBox1.Controls.Add(this.FileAddressBox);
            this.groupBox1.Controls.Add(this.ToTitle);
            this.groupBox1.Controls.Add(this.FromTitle);
            this.groupBox1.Controls.Add(this.ToBox);
            this.groupBox1.Controls.Add(this.FromBox);
            this.groupBox1.Controls.Add(this.IncludeTitles);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(1121, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(186, 573);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controls";
            // 
            // FloydsWinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1307, 573);
            this.Controls.Add(this.MatrixTable);
            this.Controls.Add(this.groupBox1);
            this.Name = "FloydsWinForm";
            this.Text = "Floyds";
            this.Load += new System.EventHandler(this.FloydsWinForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MatrixTable)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView MatrixTable;
        private System.Windows.Forms.CheckBox IncludeTitles;
        private System.Windows.Forms.TextBox FromBox;
        private System.Windows.Forms.TextBox ToBox;
        private System.Windows.Forms.Label FromTitle;
        private System.Windows.Forms.Label ToTitle;
        private System.Windows.Forms.TextBox FileAddressBox;
        private System.Windows.Forms.Label FileAddressTitle;
        private System.Windows.Forms.Button RunFloyds;
        private System.Windows.Forms.Button FindRoute;
        private System.Windows.Forms.Label RouteTitle;
        private System.Windows.Forms.Label CostTitle;
        private System.Windows.Forms.TextBox StepNumberBox;
        private System.Windows.Forms.Button GoToMatrix;
        private System.Windows.Forms.ComboBox RouteOrDistance;
        private System.Windows.Forms.Label Steps;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

