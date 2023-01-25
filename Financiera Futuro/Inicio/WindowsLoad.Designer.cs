
namespace Financiera_Futuro
{
    partial class WindowsLoad
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
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.gunaDragControl1 = new Guna.UI.WinForms.GunaDragControl(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblentr = new Guna.UI.WinForms.GunaLabel();
            this.Cir = new Guna.UI.WinForms.GunaCircleProgressBar();
            this.lblBienve = new Guna.UI.WinForms.GunaLabel();
            this.ImgUsu = new Guna.UI.WinForms.GunaCirclePictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ImgUsu)).BeginInit();
            this.SuspendLayout();
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.Radius = 24;
            this.gunaElipse1.TargetControl = this;
            // 
            // gunaDragControl1
            // 
            this.gunaDragControl1.TargetControl = this;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblentr
            // 
            this.lblentr.AutoSize = true;
            this.lblentr.BackColor = System.Drawing.Color.Transparent;
            this.lblentr.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblentr.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblentr.Location = new System.Drawing.Point(52, 370);
            this.lblentr.Name = "lblentr";
            this.lblentr.Size = new System.Drawing.Size(29, 22);
            this.lblentr.TabIndex = 2;
            this.lblentr.Text = ":D";
            // 
            // Cir
            // 
            this.Cir.Animated = true;
            this.Cir.AnimationSpeed = 0.7F;
            this.Cir.BackColor = System.Drawing.Color.Transparent;
            this.Cir.BaseColor = System.Drawing.Color.Transparent;
            this.Cir.Font = new System.Drawing.Font("Century Gothic", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cir.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Cir.IdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(48)))), ((int)(((byte)(80)))));
            this.Cir.IdleOffset = 15;
            this.Cir.IdleThickness = 10;
            this.Cir.Image = null;
            this.Cir.ImageSize = new System.Drawing.Size(52, 52);
            this.Cir.LineEndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            this.Cir.LineStartCap = System.Drawing.Drawing2D.LineCap.SquareAnchor;
            this.Cir.Location = new System.Drawing.Point(668, 315);
            this.Cir.Margin = new System.Windows.Forms.Padding(0);
            this.Cir.Name = "Cir";
            this.Cir.ProgressMaxColor = System.Drawing.Color.DarkSlateBlue;
            this.Cir.ProgressMinColor = System.Drawing.Color.CornflowerBlue;
            this.Cir.ProgressOffset = 25;
            this.Cir.ProgressThickness = 10;
            this.Cir.Size = new System.Drawing.Size(200, 200);
            this.Cir.TabIndex = 9;
            this.Cir.UseProgressPercentText = true;
            // 
            // lblBienve
            // 
            this.lblBienve.AutoSize = true;
            this.lblBienve.BackColor = System.Drawing.Color.Transparent;
            this.lblBienve.Font = new System.Drawing.Font("Gabriola", 21F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienve.ForeColor = System.Drawing.Color.White;
            this.lblBienve.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBienve.Location = new System.Drawing.Point(231, 127);
            this.lblBienve.Name = "lblBienve";
            this.lblBienve.Size = new System.Drawing.Size(51, 51);
            this.lblBienve.TabIndex = 10;
            this.lblBienve.Text = " :\'D";
            this.lblBienve.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ImgUsu
            // 
            this.ImgUsu.BackColor = System.Drawing.Color.Transparent;
            this.ImgUsu.BaseColor = System.Drawing.Color.White;
            this.ImgUsu.ErrorImage = global::Financiera_Futuro.Properties.Resources.Close;
            this.ImgUsu.Image = global::Financiera_Futuro.Properties.Resources.LogUser;
            this.ImgUsu.InitialImage = global::Financiera_Futuro.Properties.Resources.LogUser;
            this.ImgUsu.Location = new System.Drawing.Point(25, 49);
            this.ImgUsu.Name = "ImgUsu";
            this.ImgUsu.Size = new System.Drawing.Size(200, 200);
            this.ImgUsu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImgUsu.TabIndex = 12;
            this.ImgUsu.TabStop = false;
            this.ImgUsu.UseTransfarantBackground = false;
            // 
            // WindowsLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(22)))));
            this.BackgroundImage = global::Financiera_Futuro.Properties.Resources._17044_4k;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(877, 524);
            this.Controls.Add(this.ImgUsu);
            this.Controls.Add(this.lblBienve);
            this.Controls.Add(this.Cir);
            this.Controls.Add(this.lblentr);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WindowsLoad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WindowsLoad";
            ((System.ComponentModel.ISupportInitialize)(this.ImgUsu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaElipse gunaElipse1;
        private Guna.UI.WinForms.GunaDragControl gunaDragControl1;
        private System.Windows.Forms.Timer timer1;
        private Guna.UI.WinForms.GunaLabel lblentr;
        private Guna.UI.WinForms.GunaCircleProgressBar Cir;
        private Guna.UI.WinForms.GunaLabel lblBienve;
        private Guna.UI.WinForms.GunaCirclePictureBox ImgUsu;
    }
}