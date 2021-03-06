﻿namespace MinecraftWinForms
{
    partial class MineCraftView
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
            this.components = new System.ComponentModel.Container();
            this.ViewTimer = new System.Windows.Forms.Timer(this.components);
            this.Invalidater = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // ViewTimer
            // 
            this.ViewTimer.Enabled = true;
            this.ViewTimer.Interval = 42;
            this.ViewTimer.Tick += new System.EventHandler(this.ViewTimer_Tick);
            // 
            // Invalidater
            // 
            this.Invalidater.Enabled = true;
            this.Invalidater.Interval = 1000;
            this.Invalidater.Tick += new System.EventHandler(this.Invalidater_Tick);
            // 
            // MineCraftView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "MineCraftView";
            this.Text = "MineCraftWinForms";
            this.Load += new System.EventHandler(this.MineCraftView_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MineCraftView_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MineCraftView_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MineCraftView_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer ViewTimer;
        private System.Windows.Forms.Timer Invalidater;
    }
}

