namespace Unify.Budgets.UI.WinForms.Forms.Cadastros.Produtos
{
    partial class frmProduto
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
            this.chkAtivo = new System.Windows.Forms.CheckBox();
            this.unifyFrame1 = new Unify.Budgets.UI.Controls.Controls.UnifyFrame();
            this.txtNome = new Unify.Budgets.UI.Controls.Controls.UnifyTextBox();
            this.txtUnidade = new Unify.Budgets.UI.Controls.Controls.UnifyTextBox();
            this.txtUnidadeDescricao = new Unify.Budgets.UI.Controls.Controls.UnifyTextBox();
            this.txtVlrUnidade = new Unify.Budgets.UI.Controls.Controls.UnifyTextBox();
            this.SuspendLayout();
            // 
            // chkAtivo
            // 
            this.chkAtivo.AutoSize = true;
            this.chkAtivo.Checked = true;
            this.chkAtivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAtivo.Location = new System.Drawing.Point(12, 150);
            this.chkAtivo.Name = "chkAtivo";
            this.chkAtivo.Size = new System.Drawing.Size(90, 17);
            this.chkAtivo.TabIndex = 4;
            this.chkAtivo.Text = "Produto Ativo";
            this.chkAtivo.UseVisualStyleBackColor = true;
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
            this.unifyFrame1.Size = new System.Drawing.Size(495, 212);
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
            this.txtNome.ReadOnly = false;
            this.txtNome.Size = new System.Drawing.Size(471, 40);
            this.txtNome.TabIndex = 0;
            this.txtNome.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
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
            this.txtUnidade.ReadOnly = false;
            this.txtUnidade.Size = new System.Drawing.Size(65, 40);
            this.txtUnidade.TabIndex = 1;
            this.txtUnidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtUnidade.ValorSemMascara = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtUnidade.Leave += new System.EventHandler(this.txtUnidade_Leave);
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
            this.txtUnidadeDescricao.ValorSemMascara = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtVlrUnidade
            // 
            this.txtVlrUnidade.Caption = "Valor da Unidade";
            this.txtVlrUnidade.Location = new System.Drawing.Point(12, 104);
            this.txtVlrUnidade.Mascara = Unify.Budgets.UI.Controls.Enums.TipoMascara.Moeda;
            this.txtVlrUnidade.MascaraCustomizada = "";
            this.txtVlrUnidade.MaxLength = 32767;
            this.txtVlrUnidade.Name = "txtVlrUnidade";
            this.txtVlrUnidade.ReadOnly = false;
            this.txtVlrUnidade.Size = new System.Drawing.Size(125, 40);
            this.txtVlrUnidade.TabIndex = 3;
            this.txtVlrUnidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtVlrUnidade.ValorSemMascara = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // frmProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 212);
            this.Controls.Add(this.txtVlrUnidade);
            this.Controls.Add(this.txtUnidadeDescricao);
            this.Controls.Add(this.txtUnidade);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.chkAtivo);
            this.Controls.Add(this.unifyFrame1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProduto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Produto";
            this.Shown += new System.EventHandler(this.frmProduto_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Unify.Budgets.UI.Controls.Controls.UnifyFrame unifyFrame1;
        private System.Windows.Forms.CheckBox chkAtivo;
        private Unify.Budgets.UI.Controls.Controls.UnifyTextBox txtNome;
        private Unify.Budgets.UI.Controls.Controls.UnifyTextBox txtUnidade;
        private Unify.Budgets.UI.Controls.Controls.UnifyTextBox txtUnidadeDescricao;
        private Unify.Budgets.UI.Controls.Controls.UnifyTextBox txtVlrUnidade;
    }
}