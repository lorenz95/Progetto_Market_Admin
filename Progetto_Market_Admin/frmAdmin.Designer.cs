
namespace Progetto_Market_Admin
{
    partial class frmAdmin
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
            this.flpButton = new System.Windows.Forms.FlowLayoutPanel();
            this.btnProfili = new System.Windows.Forms.Button();
            this.btnUtenti = new System.Windows.Forms.Button();
            this.btnFornitori = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.flpButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpButton
            // 
            this.flpButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpButton.Controls.Add(this.btnProfili);
            this.flpButton.Controls.Add(this.btnUtenti);
            this.flpButton.Controls.Add(this.btnFornitori);
            this.flpButton.Location = new System.Drawing.Point(12, 12);
            this.flpButton.Name = "flpButton";
            this.flpButton.Size = new System.Drawing.Size(977, 50);
            this.flpButton.TabIndex = 0;
            // 
            // btnProfili
            // 
            this.btnProfili.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProfili.FlatAppearance.BorderSize = 0;
            this.btnProfili.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfili.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProfili.Image = global::Progetto_Market_Admin.Properties.Resources.icons8_group_50;
            this.btnProfili.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProfili.Location = new System.Drawing.Point(3, 3);
            this.btnProfili.Name = "btnProfili";
            this.btnProfili.Size = new System.Drawing.Size(155, 44);
            this.btnProfili.TabIndex = 0;
            this.btnProfili.Text = "           Profilo";
            this.btnProfili.UseVisualStyleBackColor = true;
            this.btnProfili.Click += new System.EventHandler(this.btnProfili_Click);
            // 
            // btnUtenti
            // 
            this.btnUtenti.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUtenti.FlatAppearance.BorderSize = 0;
            this.btnUtenti.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUtenti.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUtenti.Image = global::Progetto_Market_Admin.Properties.Resources.icons8_user_50;
            this.btnUtenti.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUtenti.Location = new System.Drawing.Point(164, 3);
            this.btnUtenti.Name = "btnUtenti";
            this.btnUtenti.Size = new System.Drawing.Size(155, 44);
            this.btnUtenti.TabIndex = 1;
            this.btnUtenti.Text = "     Utenti";
            this.btnUtenti.UseVisualStyleBackColor = true;
            this.btnUtenti.Click += new System.EventHandler(this.btnUtenti_Click);
            // 
            // btnFornitori
            // 
            this.btnFornitori.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFornitori.FlatAppearance.BorderSize = 0;
            this.btnFornitori.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFornitori.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFornitori.Image = global::Progetto_Market_Admin.Properties.Resources.icons8_supplier_50;
            this.btnFornitori.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFornitori.Location = new System.Drawing.Point(325, 3);
            this.btnFornitori.Name = "btnFornitori";
            this.btnFornitori.Size = new System.Drawing.Size(155, 44);
            this.btnFornitori.TabIndex = 2;
            this.btnFornitori.Text = "         Fornitore";
            this.btnFornitori.UseVisualStyleBackColor = true;
            this.btnFornitori.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(12, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(977, 5);
            this.label1.TabIndex = 1;
            // 
            // pnlForm
            // 
            this.pnlForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlForm.Location = new System.Drawing.Point(12, 73);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(977, 570);
            this.pnlForm.TabIndex = 2;
            // 
            // frmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1001, 655);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flpButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAdmin";
            this.Load += new System.EventHandler(this.frmAdmin_Load);
            this.flpButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnProfili;
        private System.Windows.Forms.Button btnUtenti;
        private System.Windows.Forms.Button btnFornitori;
        private System.Windows.Forms.Panel pnlForm;
    }
}