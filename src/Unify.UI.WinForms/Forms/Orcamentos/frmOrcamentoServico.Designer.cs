namespace Unify.UI.WinForms.Forms.Cadastros.Servicos
{
    partial class frmOrcamentoServico
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
            this.txtNome = new Unify.UI.Controls.Controls.UnifyTextBox();
            this.txtPreco = new Unify.UI.Controls.Controls.UnifyTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnSelecaoProduto = new Unify.UI.Controls.Controls.UnifyButton();
            this.unifyTextBox1 = new Unify.UI.Controls.Controls.UnifyTextBox();
            this.txtVlrTotal = new Unify.UI.Controls.Controls.UnifyTextBox();
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
            this.unifyFrame1.Size = new System.Drawing.Size(494, 364);
            this.unifyFrame1.TabIndex = 5;
            this.unifyFrame1.ConfirmarButtonClick += new System.EventHandler(this.unifyFrame1_ConfirmarButtonClick);
            // 
            // txtNome
            // 
            this.txtNome.Caption = "Nome do Serviço";
            this.txtNome.Location = new System.Drawing.Point(12, 12);
            this.txtNome.Mascara = Unify.UI.Controls.Enums.TipoMascara.Texto;
            this.txtNome.MascaraCustomizada = "";
            this.txtNome.MaxLength = 200;
            this.txtNome.Name = "txtNome";
            this.txtNome.ReadOnly = true;
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
            // txtPreco
            // 
            this.txtPreco.Caption = "Preço";
            this.txtPreco.Location = new System.Drawing.Point(12, 58);
            this.txtPreco.Mascara = Unify.UI.Controls.Enums.TipoMascara.Moeda;
            this.txtPreco.MascaraCustomizada = "";
            this.txtPreco.MaxLength = 32767;
            this.txtPreco.Name = "txtPreco";
            this.txtPreco.ReadOnly = false;
            this.txtPreco.Size = new System.Drawing.Size(141, 40);
            this.txtPreco.TabIndex = 1;
            this.txtPreco.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPreco.UsarFonteCustomizada = false;
            this.txtPreco.ValorSemMascara = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.Location = new System.Drawing.Point(12, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 15);
            this.label1.TabIndex = 17;
            this.label1.Text = "Observações";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.Location = new System.Drawing.Point(12, 181);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(471, 140);
            this.richTextBox1.TabIndex = 16;
            this.richTextBox1.Text = "";
            // 
            // btnSelecaoProduto
            // 
            this.btnSelecaoProduto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelecaoProduto.Font = new System.Drawing.Font("Segoe UI", 9.4F);
            this.btnSelecaoProduto.Location = new System.Drawing.Point(455, 25);
            this.btnSelecaoProduto.Name = "btnSelecaoProduto";
            this.btnSelecaoProduto.Size = new System.Drawing.Size(27, 27);
            this.btnSelecaoProduto.TabIndex = 18;
            this.btnSelecaoProduto.Text = "🔎";
            this.btnSelecaoProduto.Theme = Unify.UI.Controls.Enums.ButtonTheme.ThemePrimary;
            this.btnSelecaoProduto.UseAutomaticForeColor = true;
            // 
            // unifyTextBox1
            // 
            this.unifyTextBox1.Caption = "Quantidade";
            this.unifyTextBox1.Location = new System.Drawing.Point(159, 58);
            this.unifyTextBox1.Mascara = Unify.UI.Controls.Enums.TipoMascara.Moeda;
            this.unifyTextBox1.MascaraCustomizada = "";
            this.unifyTextBox1.MaxLength = 32767;
            this.unifyTextBox1.Name = "unifyTextBox1";
            this.unifyTextBox1.ReadOnly = false;
            this.unifyTextBox1.Size = new System.Drawing.Size(93, 40);
            this.unifyTextBox1.TabIndex = 19;
            this.unifyTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.unifyTextBox1.UsarFonteCustomizada = false;
            this.unifyTextBox1.ValorSemMascara = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtVlrTotal
            // 
            this.txtVlrTotal.Caption = "Valor Total";
            this.txtVlrTotal.Location = new System.Drawing.Point(12, 104);
            this.txtVlrTotal.Mascara = Unify.UI.Controls.Enums.TipoMascara.Moeda;
            this.txtVlrTotal.MascaraCustomizada = "";
            this.txtVlrTotal.MaxLength = 32767;
            this.txtVlrTotal.Name = "txtVlrTotal";
            this.txtVlrTotal.ReadOnly = true;
            this.txtVlrTotal.Size = new System.Drawing.Size(240, 53);
            this.txtVlrTotal.TabIndex = 20;
            this.txtVlrTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtVlrTotal.UsarFonteCustomizada = true;
            this.txtVlrTotal.ValorSemMascara = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // frmOrcamentoServico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 364);
            this.Controls.Add(this.txtVlrTotal);
            this.Controls.Add(this.unifyTextBox1);
            this.Controls.Add(this.btnSelecaoProduto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.txtPreco);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.unifyFrame1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOrcamentoServico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Servico";
            this.Shown += new System.EventHandler(this.frmServico_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Unify.UI.Controls.Controls.UnifyFrame unifyFrame1;
        private Unify.UI.Controls.Controls.UnifyTextBox txtNome;
        private Unify.UI.Controls.Controls.UnifyTextBox txtPreco;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private UI.Controls.Controls.UnifyButton btnSelecaoProduto;
        private UI.Controls.Controls.UnifyTextBox unifyTextBox1;
        private UI.Controls.Controls.UnifyTextBox txtVlrTotal;
    }
}