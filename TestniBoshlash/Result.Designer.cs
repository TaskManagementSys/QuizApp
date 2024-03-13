namespace QuizApp.TestniBoshlash
{
    partial class Result
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnInCorrect = new Guna.UI2.WinForms.Guna2Button();
            btnCorrect = new Guna.UI2.WinForms.Guna2Button();
            lbUserLevel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            SuspendLayout();
            // 
            // btnInCorrect
            // 
            btnInCorrect.Anchor = AnchorStyles.None;
            btnInCorrect.BorderRadius = 15;
            btnInCorrect.CustomizableEdges = customizableEdges5;
            btnInCorrect.DisabledState.BorderColor = Color.DarkGray;
            btnInCorrect.DisabledState.CustomBorderColor = Color.DarkGray;
            btnInCorrect.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnInCorrect.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnInCorrect.Font = new Font("Showcard Gothic", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnInCorrect.ForeColor = Color.White;
            btnInCorrect.Location = new Point(21, 232);
            btnInCorrect.Name = "btnInCorrect";
            btnInCorrect.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnInCorrect.Size = new Size(758, 54);
            btnInCorrect.TabIndex = 9;
            btnInCorrect.Click += btnInCorrect_Click;
            // 
            // btnCorrect
            // 
            btnCorrect.Anchor = AnchorStyles.None;
            btnCorrect.BorderRadius = 15;
            btnCorrect.CustomizableEdges = customizableEdges7;
            btnCorrect.DisabledState.BorderColor = Color.DarkGray;
            btnCorrect.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCorrect.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCorrect.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCorrect.Font = new Font("Showcard Gothic", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCorrect.ForeColor = Color.White;
            btnCorrect.Location = new Point(21, 164);
            btnCorrect.Name = "btnCorrect";
            btnCorrect.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnCorrect.Size = new Size(758, 50);
            btnCorrect.TabIndex = 8;
            btnCorrect.Click += btnCorrect_Click;
            // 
            // lbUserLevel
            // 
            lbUserLevel.BackColor = Color.Transparent;
            lbUserLevel.Font = new Font("Showcard Gothic", 20F, FontStyle.Bold);
            lbUserLevel.ForeColor = Color.White;
            lbUserLevel.Location = new Point(185, 50);
            lbUserLevel.Name = "lbUserLevel";
            lbUserLevel.Size = new Size(328, 44);
            lbUserLevel.TabIndex = 10;
            lbUserLevel.Text = "You are the level";
            // 
            // Result
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(77, 24, 160);
            ClientSize = new Size(800, 450);
            Controls.Add(lbUserLevel);
            Controls.Add(btnInCorrect);
            Controls.Add(btnCorrect);
            Name = "Result";
            Text = "Result";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnInCorrect;
        private Guna.UI2.WinForms.Guna2Button btnCorrect;
        private Guna.UI2.WinForms.Guna2HtmlLabel lbUserLevel;
    }
}