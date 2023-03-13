namespace _2kL_2023_02_09_AnimDblBfr
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
            mainPanel = new Panel();
            btnStart = new Button();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mainPanel.BackColor = Color.White;
            mainPanel.Location = new Point(22, 26);
            mainPanel.Margin = new Padding(6, 6, 6, 6);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1036, 864);
            mainPanel.TabIndex = 0;
            mainPanel.Resize += mainPanel_Resize;
            // 
            // btnStart
            // 
            btnStart.Anchor = AnchorStyles.Bottom;
            btnStart.Location = new Point(472, 917);
            btnStart.Margin = new Padding(6, 6, 6, 6);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(139, 49);
            btnStart.TabIndex = 1;
            btnStart.Text = "Старт";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1081, 992);
            Controls.Add(btnStart);
            Controls.Add(mainPanel);
            Margin = new Padding(6, 6, 6, 6);
            MinimumSize = new Size(721, 666);
            Name = "Form1";
            Text = "Анимация";
            ResumeLayout(false);
        }

        #endregion

        private Panel mainPanel;
        private Button btnStart;
    }
}