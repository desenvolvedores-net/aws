namespace ReadCloudWatch.Forms
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Regions");
            this.tbMain = new System.Windows.Forms.TableLayoutPanel();
            this.tvMain = new System.Windows.Forms.TreeView();
            this.rtbMain = new System.Windows.Forms.RichTextBox();
            this.tbMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbMain
            // 
            this.tbMain.ColumnCount = 2;
            this.tbMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tbMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tbMain.Controls.Add(this.tvMain, 0, 0);
            this.tbMain.Controls.Add(this.rtbMain, 1, 0);
            this.tbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMain.Location = new System.Drawing.Point(0, 0);
            this.tbMain.Name = "tbMain";
            this.tbMain.RowCount = 1;
            this.tbMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbMain.Size = new System.Drawing.Size(969, 690);
            this.tbMain.TabIndex = 0;
            // 
            // tvMain
            // 
            this.tvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvMain.Location = new System.Drawing.Point(3, 3);
            this.tvMain.Name = "tvMain";
            treeNode1.Name = "nodeRegions";
            treeNode1.Text = "Regions";
            this.tvMain.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.tvMain.Size = new System.Drawing.Size(284, 684);
            this.tvMain.TabIndex = 0;
            this.tvMain.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TvMain_AfterSelect);
            // 
            // rtbMain
            // 
            this.rtbMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbMain.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rtbMain.Location = new System.Drawing.Point(293, 3);
            this.rtbMain.Name = "rtbMain";
            this.rtbMain.Size = new System.Drawing.Size(673, 684);
            this.rtbMain.TabIndex = 1;
            this.rtbMain.Text = "";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 690);
            this.Controls.Add(this.tbMain);
            this.Name = "Main";
            this.Text = "Cloudwatch Logs";
            this.Shown += new System.EventHandler(this.Main_Shown);
            this.tbMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tbMain;
        private System.Windows.Forms.TreeView tvMain;
        private System.Windows.Forms.RichTextBox rtbMain;
    }
}
