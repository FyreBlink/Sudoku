
namespace Sudoku
{
    partial class Form1
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
            if (disposing && (components != null))
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.StartGameMenu1Item = new System.Windows.Forms.ToolStripMenuItem();
            this.RestartMenu1Item = new System.Windows.Forms.ToolStripMenuItem();
            this.DifficultyMenu1Item = new System.Windows.Forms.ToolStripMenuItem();
            this.EasyDiffSubMenu1Item = new System.Windows.Forms.ToolStripMenuItem();
            this.MediumDiffSubMenu1Item = new System.Windows.Forms.ToolStripMenuItem();
            this.HardDiffSubMenu1Item = new System.Windows.Forms.ToolStripMenuItem();
            this.SetupDiffSubMenu1Item = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutMenu1Item = new System.Windows.Forms.ToolStripMenuItem();
            this.DebugMenu1Item = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StartGameMenu1Item,
            this.RestartMenu1Item,
            this.DifficultyMenu1Item,
            this.AboutMenu1Item,
            this.DebugMenu1Item});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // StartGameMenu1Item
            // 
            this.StartGameMenu1Item.Name = "StartGameMenu1Item";
            this.StartGameMenu1Item.Size = new System.Drawing.Size(81, 20);
            this.StartGameMenu1Item.Text = "Новая игра";
            // 
            // RestartMenu1Item
            // 
            this.RestartMenu1Item.Name = "RestartMenu1Item";
            this.RestartMenu1Item.Size = new System.Drawing.Size(61, 20);
            this.RestartMenu1Item.Text = "Рестарт";
            // 
            // DifficultyMenu1Item
            // 
            this.DifficultyMenu1Item.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EasyDiffSubMenu1Item,
            this.MediumDiffSubMenu1Item,
            this.HardDiffSubMenu1Item,
            this.SetupDiffSubMenu1Item});
            this.DifficultyMenu1Item.Name = "DifficultyMenu1Item";
            this.DifficultyMenu1Item.Size = new System.Drawing.Size(81, 20);
            this.DifficultyMenu1Item.Text = "Сложность";
            // 
            // EasyDiffSubMenu1Item
            // 
            this.EasyDiffSubMenu1Item.Name = "EasyDiffSubMenu1Item";
            this.EasyDiffSubMenu1Item.Size = new System.Drawing.Size(159, 22);
            this.EasyDiffSubMenu1Item.Text = "Легко";
            // 
            // MediumDiffSubMenu1Item
            // 
            this.MediumDiffSubMenu1Item.Name = "MediumDiffSubMenu1Item";
            this.MediumDiffSubMenu1Item.Size = new System.Drawing.Size(159, 22);
            this.MediumDiffSubMenu1Item.Text = "Средне";
            // 
            // HardDiffSubMenu1Item
            // 
            this.HardDiffSubMenu1Item.Name = "HardDiffSubMenu1Item";
            this.HardDiffSubMenu1Item.Size = new System.Drawing.Size(159, 22);
            this.HardDiffSubMenu1Item.Text = "Сложно";
            // 
            // SetupDiffSubMenu1Item
            // 
            this.SetupDiffSubMenu1Item.Name = "SetupDiffSubMenu1Item";
            this.SetupDiffSubMenu1Item.Size = new System.Drawing.Size(159, 22);
            this.SetupDiffSubMenu1Item.Text = "Настраиваемая";
            // 
            // AboutMenu1Item
            // 
            this.AboutMenu1Item.Name = "AboutMenu1Item";
            this.AboutMenu1Item.Size = new System.Drawing.Size(94, 20);
            this.AboutMenu1Item.Text = "О программе";
            // 
            // DebugMenu1Item
            // 
            this.DebugMenu1Item.Name = "DebugMenu1Item";
            this.DebugMenu1Item.Size = new System.Drawing.Size(54, 20);
            this.DebugMenu1Item.Text = "Debug";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(332, 189);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(627, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(627, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(627, 335);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Проверка решения";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem AboutMenu1Item;
        private System.Windows.Forms.ToolStripMenuItem StartGameMenu1Item;
        private System.Windows.Forms.ToolStripMenuItem DifficultyMenu1Item;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem RestartMenu1Item;
        private System.Windows.Forms.ToolStripMenuItem DebugMenu1Item;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem EasyDiffSubMenu1Item;
        private System.Windows.Forms.ToolStripMenuItem MediumDiffSubMenu1Item;
        private System.Windows.Forms.ToolStripMenuItem HardDiffSubMenu1Item;
        private System.Windows.Forms.ToolStripMenuItem SetupDiffSubMenu1Item;
        private System.Windows.Forms.Button button1;
    }

    class Grid
    {
        public int[,] NumbGridSolution = new int[9, 9];
        public int[,] NumbGridStart = new int[9, 9];
        public int[,] NumbGridCurrent = new int[9, 9];
        public int ClickedCellX = new();
        public int ClickedCellY = new();
        public bool IsStarted = false;
        public bool NeedCleanUp = false;
        public bool IsClicked = false;
        public bool NonNumberEntered = false;
    }
}

