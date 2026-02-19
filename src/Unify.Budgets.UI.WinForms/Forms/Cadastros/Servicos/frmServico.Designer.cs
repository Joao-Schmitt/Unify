namespace Unify.Budgets.UI.WinForms.Forms.Cadastros.Servicos
{
    partial class frmServico
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
            this.txtPreco = new Unify.Budgets.UI.Controls.Controls.UnifyTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // chkAtivo
            // 
            this.chkAtivo.AutoSize = true;
            this.chkAtivo.Checked = true;
            this.chkAtivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAtivo.Location = new System.Drawing.Point(15, 261);
            this.chkAtivo.Name = "chkAtivo";
            this.chkAtivo.Size = new System.Drawing.Size(89, 17);
            this.chkAtivo.TabIndex = 4;
            this.chkAtivo.Text = "Servico Ativo";
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
            this.unifyFrame1.Size = new System.Drawing.Size(494, 331);
            this.unifyFrame1.TabIndex = 5;
            this.unifyFrame1.ConfirmarButtonClick += new System.EventHandler(this.unifyFrame1_ConfirmarButtonClick);
            // 
            // txtNome
            // 
            this.txtNome.Caption = "Nome do Serviço";
            this.txtNome.Location = new System.Drawing.Point(12, 12);
            this.txtNome.Mascara = Unify.Budgets.UI.Controls.Enums.TipoMascara.Texto;
            this.txtNome.MascaraCustomizada = "";
            this.txtNome.MaxLength = 200;
            this.txtNome.Name = "txtNome";
            this.txtNome.ReadOnly = false;
            this.txtNome.Size = new System.Drawing.Size(471, 40);
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
            this.txtPreco.Mascara = Unify.Budgets.UI.Controls.Enums.TipoMascara.Moeda;
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
            this.label1.Location = new System.Drawing.Point(12, 103);
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
            this.richTextBox1.Location = new System.Drawing.Point(12, 121);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(471, 134);
            this.richTextBox1.TabIndex = 16;
            this.richTextBox1.Text = "";
            // 
            // frmServico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 331);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.txtPreco);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.chkAtivo);
            this.Controls.Add(this.unifyFrame1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmServico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Servico";
            this.Shown += new System.EventHandler(this.frmServico_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Unify.Budgets.UI.Controls.Controls.UnifyFrame unifyFrame1;
        private System.Windows.Forms.CheckBox chkAtivo;
        private Unify.Budgets.UI.Controls.Controls.UnifyTextBox txtNome;
        private Unify.Budgets.UI.Controls.Controls.UnifyTextBox txtPreco;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}