namespace Unify.UI.WinForms.Forms.Cadastros.Servicos
{
    partial class frmOrcamentoDescontos
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
            this.txtPreco = new Unify.UI.Controls.Controls.UnifyTextBox();
            this.txtNome = new Unify.UI.Controls.Controls.UnifyTextBox();
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
            this.unifyFrame1.Size = new System.Drawing.Size(456, 154);
            this.unifyFrame1.TabIndex = 5;
            this.unifyFrame1.ConfirmarButtonClick += new System.EventHandler(this.unifyFrame1_ConfirmarButtonClick);
            // 
            // txtPreco
            // 
            this.txtPreco.Caption = "Preço";
            this.txtPreco.Location = new System.Drawing.Point(12, 58);
            this.txtPreco.Mascara = Unify.UI.Controls.Enums.TipoMascara.Moeda;
            this.txtPreco.MascaraCustomizada = "";
            this.txtPreco.MaxLength = 32767;
            this.txtPreco.Name = "txtPreco";
            this.txtPreco.ReadOnly = false;
            this.txtPreco.Size = new System.Drawing.Size(171, 40);
            this.txtPreco.TabIndex = 1;
            this.txtPreco.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPreco.UsarFonteCustomizada = false;
            this.txtPreco.ValorSemMascara = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtNome
            // 
            this.txtNome.Caption = "Descrição do Desconto";
            this.txtNome.Location = new System.Drawing.Point(12, 12);
            this.txtNome.Mascara = Unify.UI.Controls.Enums.TipoMascara.Texto;
            this.txtNome.MascaraCustomizada = "";
            this.txtNome.MaxLength = 200;
            this.txtNome.Name = "txtNome";
            this.txtNome.ReadOnly = false;
            this.txtNome.Size = new System.Drawing.Size(437, 40);
            this.txtNome.TabIndex = 0;
            this.txtNome.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtNome.UsarFonteCustomizada = false;
            this.txtNome.ValorSemMascara = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // frmOrcamentoDescontos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 154);
            this.Controls.Add(this.txtPreco);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.unifyFrame1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOrcamentoDescontos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Servico";
            this.Shown += new System.EventHandler(this.frmServico_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private Unify.UI.Controls.Controls.UnifyFrame unifyFrame1;
        private Unify.UI.Controls.Controls.UnifyTextBox txtPreco;
        private UI.Controls.Controls.UnifyTextBox txtNome;
    }
}