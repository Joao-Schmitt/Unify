namespace Unify.Budgets.UI.WinForms.Forms.Cadastros.Produtos
{
    partial class frmOrcamentoProduto
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
            this.unifyFrame1 = new Unify.Budgets.UI.Controls.Controls.UnifyFrame();
            this.txtNome = new Unify.Budgets.UI.Controls.Controls.UnifyTextBox();
            this.txtUnidade = new Unify.Budgets.UI.Controls.Controls.UnifyTextBox();
            this.txtUnidadeDescricao = new Unify.Budgets.UI.Controls.Controls.UnifyTextBox();
            this.txtVlrUnidade = new Unify.Budgets.UI.Controls.Controls.UnifyTextBox();
            this.txtQuantidade = new Unify.Budgets.UI.Controls.Controls.UnifyTextBox();
            this.txtVlrTotal = new Unify.Budgets.UI.Controls.Controls.UnifyTextBox();
            this.btnSelecaoProduto = new Unify.Budgets.UI.Controls.Controls.UnifyButton();
            this.unifyTextBox1 = new Unify.Budgets.UI.Controls.Controls.UnifyTextBox();
            this.unifyTextBox2 = new Unify.Budgets.UI.Controls.Controls.UnifyTextBox();
            this.unifyTextBox3 = new Unify.Budgets.UI.Controls.Controls.UnifyTextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.unifyFrame1.Size = new System.Drawing.Size(500, 458);
            this.unifyFrame1.TabIndex = 5;
            this.unifyFrame1.ConfirmarButtonClick += new System.EventHandler(this.unifyFrame1_ConfirmarButtonClick);
            // 
            // txtNome
            // 
            this.txtNome.Caption = "Nome do Produto";
            this.txtNome.Location = new System.Drawing.Point(12, 12);
            this.txtNome.Mascara = Unify.Budgets.UI.Controls.Enums.TipoMascara.Texto;
            this.txtNome.MascaraCustomizada = "";
            this.txtNome.MaxLength = 200;
            this.txtNome.Name = "txtNome";
            this.txtNome.ReadOnly = true;
            this.txtNome.Size = new System.Drawing.Size(438, 40);
            this.txtNome.TabIndex = 0;
            this.txtNome.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtNome.UsarFonteCustomizada = false;
            this.txtNome.ValorSemMascara = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtUnidade
            // 
            this.txtUnidade.Caption = "Unidade";
            this.txtUnidade.Location = new System.Drawing.Point(12, 58);
            this.txtUnidade.Mascara = Unify.Budgets.UI.Controls.Enums.TipoMascara.Texto;
            this.txtUnidade.MascaraCustomizada = "";
            this.txtUnidade.MaxLength = 3;
            this.txtUnidade.Name = "txtUnidade";
            this.txtUnidade.ReadOnly = true;
            this.txtUnidade.Size = new System.Drawing.Size(65, 40);
            this.txtUnidade.TabIndex = 1;
            this.txtUnidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtUnidade.UsarFonteCustomizada = false;
            this.txtUnidade.ValorSemMascara = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtUnidadeDescricao
            // 
            this.txtUnidadeDescricao.Caption = "Descrição da Unidade";
            this.txtUnidadeDescricao.Location = new System.Drawing.Point(83, 58);
            this.txtUnidadeDescricao.Mascara = Unify.Budgets.UI.Controls.Enums.TipoMascara.Texto;
            this.txtUnidadeDescricao.MascaraCustomizada = "";
            this.txtUnidadeDescricao.MaxLength = 32767;
            this.txtUnidadeDescricao.Name = "txtUnidadeDescricao";
            this.txtUnidadeDescricao.ReadOnly = true;
            this.txtUnidadeDescricao.Size = new System.Drawing.Size(400, 40);
            this.txtUnidadeDescricao.TabIndex = 2;
            this.txtUnidadeDescricao.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtUnidadeDescricao.UsarFonteCustomizada = false;
            this.txtUnidadeDescricao.ValorSemMascara = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtVlrUnidade
            // 
            this.txtVlrUnidade.Caption = "Valor da Unidade";
            this.txtVlrUnidade.Location = new System.Drawing.Point(12, 150);
            this.txtVlrUnidade.Mascara = Unify.Budgets.UI.Controls.Enums.TipoMascara.Moeda;
            this.txtVlrUnidade.MascaraCustomizada = "";
            this.txtVlrUnidade.MaxLength = 32767;
            this.txtVlrUnidade.Name = "txtVlrUnidade";
            this.txtVlrUnidade.ReadOnly = false;
            this.txtVlrUnidade.Size = new System.Drawing.Size(216, 40);
            this.txtVlrUnidade.TabIndex = 3;
            this.txtVlrUnidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtVlrUnidade.UsarFonteCustomizada = false;
            this.txtVlrUnidade.ValorSemMascara = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtVlrUnidade.Leave += new System.EventHandler(this.txtVlrUnidade_Leave);
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Caption = "Comprimento";
            this.txtQuantidade.Location = new System.Drawing.Point(12, 104);
            this.txtQuantidade.Mascara = Unify.Budgets.UI.Controls.Enums.TipoMascara.Moeda;
            this.txtQuantidade.MascaraCustomizada = "";
            this.txtQuantidade.MaxLength = 32767;
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.ReadOnly = false;
            this.txtQuantidade.Size = new System.Drawing.Size(105, 40);
            this.txtQuantidade.TabIndex = 6;
            this.txtQuantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtQuantidade.UsarFonteCustomizada = false;
            this.txtQuantidade.ValorSemMascara = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtQuantidade.Leave += new System.EventHandler(this.txtQuantidade_Leave);
            // 
            // txtVlrTotal
            // 
            this.txtVlrTotal.Caption = "Valor Total";
            this.txtVlrTotal.Location = new System.Drawing.Point(12, 196);
            this.txtVlrTotal.Mascara = Unify.Budgets.UI.Controls.Enums.TipoMascara.Moeda;
            this.txtVlrTotal.MascaraCustomizada = "";
            this.txtVlrTotal.MaxLength = 32767;
            this.txtVlrTotal.Name = "txtVlrTotal";
            this.txtVlrTotal.ReadOnly = true;
            this.txtVlrTotal.Size = new System.Drawing.Size(216, 53);
            this.txtVlrTotal.TabIndex = 7;
            this.txtVlrTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtVlrTotal.UsarFonteCustomizada = true;
            this.txtVlrTotal.ValorSemMascara = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // btnSelecaoProduto
            // 
            this.btnSelecaoProduto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelecaoProduto.Font = new System.Drawing.Font("Segoe UI", 9.4F);
            this.btnSelecaoProduto.Location = new System.Drawing.Point(456, 25);
            this.btnSelecaoProduto.Name = "btnSelecaoProduto";
            this.btnSelecaoProduto.Size = new System.Drawing.Size(27, 27);
            this.btnSelecaoProduto.TabIndex = 10;
            this.btnSelecaoProduto.Text = "🔎";
            this.btnSelecaoProduto.Theme = Unify.Budgets.UI.Controls.Enums.ButtonTheme.ThemePrimary;
            this.btnSelecaoProduto.UseAutomaticForeColor = true;
            this.btnSelecaoProduto.Click += new System.EventHandler(this.btnSelecaoProduto_Click);
            // 
            // unifyTextBox1
            // 
            this.unifyTextBox1.Caption = "Largura";
            this.unifyTextBox1.Location = new System.Drawing.Point(123, 104);
            this.unifyTextBox1.Mascara = Unify.Budgets.UI.Controls.Enums.TipoMascara.Moeda;
            this.unifyTextBox1.MascaraCustomizada = "";
            this.unifyTextBox1.MaxLength = 32767;
            this.unifyTextBox1.Name = "unifyTextBox1";
            this.unifyTextBox1.ReadOnly = false;
            this.unifyTextBox1.Size = new System.Drawing.Size(105, 40);
            this.unifyTextBox1.TabIndex = 11;
            this.unifyTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.unifyTextBox1.UsarFonteCustomizada = false;
            this.unifyTextBox1.ValorSemMascara = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // unifyTextBox2
            // 
            this.unifyTextBox2.Caption = "Área Total";
            this.unifyTextBox2.Location = new System.Drawing.Point(234, 104);
            this.unifyTextBox2.Mascara = Unify.Budgets.UI.Controls.Enums.TipoMascara.Moeda;
            this.unifyTextBox2.MascaraCustomizada = "";
            this.unifyTextBox2.MaxLength = 32767;
            this.unifyTextBox2.Name = "unifyTextBox2";
            this.unifyTextBox2.ReadOnly = true;
            this.unifyTextBox2.Size = new System.Drawing.Size(105, 40);
            this.unifyTextBox2.TabIndex = 12;
            this.unifyTextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.unifyTextBox2.UsarFonteCustomizada = false;
            this.unifyTextBox2.ValorSemMascara = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // unifyTextBox3
            // 
            this.unifyTextBox3.Caption = "Quantidade";
            this.unifyTextBox3.Location = new System.Drawing.Point(234, 150);
            this.unifyTextBox3.Mascara = Unify.Budgets.UI.Controls.Enums.TipoMascara.Moeda;
            this.unifyTextBox3.MascaraCustomizada = "";
            this.unifyTextBox3.MaxLength = 32767;
            this.unifyTextBox3.Name = "unifyTextBox3";
            this.unifyTextBox3.ReadOnly = false;
            this.unifyTextBox3.Size = new System.Drawing.Size(105, 40);
            this.unifyTextBox3.TabIndex = 13;
            this.unifyTextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.unifyTextBox3.UsarFonteCustomizada = false;
            this.unifyTextBox3.ValorSemMascara = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.Location = new System.Drawing.Point(15, 275);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(476, 141);
            this.richTextBox1.TabIndex = 14;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.Location = new System.Drawing.Point(12, 257);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "Observações";
            // 
            // frmOrcamentoProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 458);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.unifyTextBox3);
            this.Controls.Add(this.unifyTextBox2);
            this.Controls.Add(this.unifyTextBox1);
            this.Controls.Add(this.btnSelecaoProduto);
            this.Controls.Add(this.txtVlrTotal);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.txtVlrUnidade);
            this.Controls.Add(this.txtUnidadeDescricao);
            this.Controls.Add(this.txtUnidade);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.unifyFrame1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOrcamentoProduto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Produto";
            this.Shown += new System.EventHandler(this.frmProduto_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Unify.Budgets.UI.Controls.Controls.UnifyFrame unifyFrame1;
        private Unify.Budgets.UI.Controls.Controls.UnifyTextBox txtNome;
        private Unify.Budgets.UI.Controls.Controls.UnifyTextBox txtUnidade;
        private Unify.Budgets.UI.Controls.Controls.UnifyTextBox txtUnidadeDescricao;
        private Unify.Budgets.UI.Controls.Controls.UnifyTextBox txtVlrUnidade;
        private UI.Controls.Controls.UnifyTextBox txtQuantidade;
        private UI.Controls.Controls.UnifyTextBox txtVlrTotal;
        private UI.Controls.Controls.UnifyButton btnSelecaoProduto;
        private UI.Controls.Controls.UnifyTextBox unifyTextBox1;
        private UI.Controls.Controls.UnifyTextBox unifyTextBox2;
        private UI.Controls.Controls.UnifyTextBox unifyTextBox3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
    }
}