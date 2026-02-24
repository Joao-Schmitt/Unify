namespace Unify.UI.WinForms.Forms.Cadastros.Unidades
{
    partial class frmUnidade
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
            this.unifyFrame1 = new Unify.UI.Controls.Controls.UnifyFrame();
            this.txtSigla = new Unify.UI.Controls.Controls.UnifyTextBox();
            this.txtDescricao = new Unify.UI.Controls.Controls.UnifyTextBox();
            this.SuspendLayout();
            // 
            // unifyFrame1
            // 
            this.unifyFrame1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.unifyFrame1.ConfirmarButtonVisible = true;
            this.unifyFrame1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.unifyFrame1.InfoText = "Descrição da Rotina";
            this.unifyFrame1.InfoVisible = false;
            this.unifyFrame1.Location = new System.Drawing.Point(0, 0);
            this.unifyFrame1.Name = "unifyFrame1";
            this.unifyFrame1.SairButtonVisible = true;
            this.unifyFrame1.Size = new System.Drawing.Size(496, 104);
            this.unifyFrame1.TabIndex = 0;
            this.unifyFrame1.ConfirmarButtonClick += new System.EventHandler(this.unifyFrame1_ConfirmarButtonClick);
            // 
            // txtSigla
            // 
            this.txtSigla.Caption = "Sigla";
            this.txtSigla.Location = new System.Drawing.Point(12, 12);
            this.txtSigla.Mascara = Unify.UI.Controls.Enums.TipoMascara.Texto;
            this.txtSigla.MascaraCustomizada = "";
            this.txtSigla.MaxLength = 3;
            this.txtSigla.Name = "txtSigla";
            this.txtSigla.ReadOnly = false;
            this.txtSigla.Size = new System.Drawing.Size(72, 40);
            this.txtSigla.TabIndex = 0;
            this.txtSigla.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSigla.ValorSemMascara = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtDescricao
            // 
            this.txtDescricao.Caption = "Descrição";
            this.txtDescricao.Location = new System.Drawing.Point(90, 12);
            this.txtDescricao.Mascara = Unify.UI.Controls.Enums.TipoMascara.Texto;
            this.txtDescricao.MascaraCustomizada = "";
            this.txtDescricao.MaxLength = 200;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.ReadOnly = false;
            this.txtDescricao.Size = new System.Drawing.Size(393, 40);
            this.txtDescricao.TabIndex = 1;
            this.txtDescricao.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDescricao.ValorSemMascara = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // frmUnidade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 104);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.txtSigla);
            this.Controls.Add(this.unifyFrame1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUnidade";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Unidade";
            this.Shown += new System.EventHandler(this.frmUnidade_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private Unify.UI.Controls.Controls.UnifyFrame unifyFrame1;
        private Unify.UI.Controls.Controls.UnifyTextBox txtSigla;
        private Unify.UI.Controls.Controls.UnifyTextBox txtDescricao;
    }
}