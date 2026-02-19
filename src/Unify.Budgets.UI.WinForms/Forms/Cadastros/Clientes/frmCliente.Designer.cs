namespace Unify.Budgets.UI.WinForms.Forms.Cadastros.Clientes
{
    partial class frmCliente
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtEstado = new Unify.Budgets.UI.Controls.Controls.UnifyTextBox();
            this.txtCidade = new Unify.Budgets.UI.Controls.Controls.UnifyTextBox();
            this.txtBairro = new Unify.Budgets.UI.Controls.Controls.UnifyTextBox();
            this.txtNr = new Unify.Budgets.UI.Controls.Controls.UnifyTextBox();
            this.txtRua = new Unify.Budgets.UI.Controls.Controls.UnifyTextBox();
            this.txtCep = new Unify.Budgets.UI.Controls.Controls.UnifyTextBox();
            this.txtNome = new Unify.Budgets.UI.Controls.Controls.UnifyTextBox();
            this.txtDocum = new Unify.Budgets.UI.Controls.Controls.UnifyTextBox();
            this.txtFone = new Unify.Budgets.UI.Controls.Controls.UnifyTextBox();
            this.txtEmail = new Unify.Budgets.UI.Controls.Controls.UnifyTextBox();
            this.txtComplemento = new Unify.Budgets.UI.Controls.Controls.UnifyTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkAtivo
            // 
            this.chkAtivo.AutoSize = true;
            this.chkAtivo.Checked = true;
            this.chkAtivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAtivo.Location = new System.Drawing.Point(12, 362);
            this.chkAtivo.Name = "chkAtivo";
            this.chkAtivo.Size = new System.Drawing.Size(85, 17);
            this.chkAtivo.TabIndex = 10;
            this.chkAtivo.Text = "Cliente Ativo";
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
            this.unifyFrame1.Size = new System.Drawing.Size(463, 424);
            this.unifyFrame1.TabIndex = 11;
            this.unifyFrame1.ConfirmarButtonClick += new System.EventHandler(this.unifyFrame1_ConfirmarButtonClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtComplemento);
            this.groupBox1.Controls.Add(this.txtEstado);
            this.groupBox1.Controls.Add(this.txtCidade);
            this.groupBox1.Controls.Add(this.txtBairro);
            this.groupBox1.Controls.Add(this.txtNr);
            this.groupBox1.Controls.Add(this.txtRua);
            this.groupBox1.Controls.Add(this.txtCep);
            this.groupBox1.Location = new System.Drawing.Point(12, 150);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(436, 206);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Endereço";
            // 
            // txtEstado
            // 
            this.txtEstado.BackColorInput = System.Drawing.Color.White;
            this.txtEstado.Caption = "Estado";
            this.txtEstado.ForeColorInput = System.Drawing.SystemColors.WindowText;
            this.txtEstado.Location = new System.Drawing.Point(143, 109);
            this.txtEstado.Mascara = Unify.Budgets.UI.Controls.Enums.TipoMascara.Texto;
            this.txtEstado.MascaraCustomizada = "";
            this.txtEstado.MaxLength = 2;
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = false;
            this.txtEstado.Size = new System.Drawing.Size(81, 40);
            this.txtEstado.TabIndex = 9;
            this.txtEstado.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtEstado.UsarFonteCustomizada = false;
            this.txtEstado.ValorSemMascara = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtCidade
            // 
            this.txtCidade.BackColorInput = System.Drawing.Color.White;
            this.txtCidade.Caption = "Cidade";
            this.txtCidade.ForeColorInput = System.Drawing.SystemColors.WindowText;
            this.txtCidade.Location = new System.Drawing.Point(230, 63);
            this.txtCidade.Mascara = Unify.Budgets.UI.Controls.Enums.TipoMascara.Texto;
            this.txtCidade.MascaraCustomizada = "";
            this.txtCidade.MaxLength = 200;
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.ReadOnly = false;
            this.txtCidade.Size = new System.Drawing.Size(197, 40);
            this.txtCidade.TabIndex = 7;
            this.txtCidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtCidade.UsarFonteCustomizada = false;
            this.txtCidade.ValorSemMascara = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtBairro
            // 
            this.txtBairro.BackColorInput = System.Drawing.Color.White;
            this.txtBairro.Caption = "Bairro";
            this.txtBairro.ForeColorInput = System.Drawing.SystemColors.WindowText;
            this.txtBairro.Location = new System.Drawing.Point(10, 63);
            this.txtBairro.Mascara = Unify.Budgets.UI.Controls.Enums.TipoMascara.Texto;
            this.txtBairro.MascaraCustomizada = "";
            this.txtBairro.MaxLength = 200;
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.ReadOnly = false;
            this.txtBairro.Size = new System.Drawing.Size(214, 40);
            this.txtBairro.TabIndex = 6;
            this.txtBairro.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtBairro.UsarFonteCustomizada = false;
            this.txtBairro.ValorSemMascara = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtNr
            // 
            this.txtNr.BackColorInput = System.Drawing.Color.White;
            this.txtNr.Caption = "Número";
            this.txtNr.ForeColorInput = System.Drawing.SystemColors.WindowText;
            this.txtNr.Location = new System.Drawing.Point(10, 109);
            this.txtNr.Mascara = Unify.Budgets.UI.Controls.Enums.TipoMascara.Texto;
            this.txtNr.MascaraCustomizada = "";
            this.txtNr.MaxLength = 15;
            this.txtNr.Name = "txtNr";
            this.txtNr.ReadOnly = false;
            this.txtNr.Size = new System.Drawing.Size(122, 40);
            this.txtNr.TabIndex = 8;
            this.txtNr.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtNr.UsarFonteCustomizada = false;
            this.txtNr.ValorSemMascara = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtRua
            // 
            this.txtRua.BackColorInput = System.Drawing.Color.White;
            this.txtRua.Caption = "Rua";
            this.txtRua.ForeColorInput = System.Drawing.SystemColors.WindowText;
            this.txtRua.Location = new System.Drawing.Point(138, 19);
            this.txtRua.Mascara = Unify.Budgets.UI.Controls.Enums.TipoMascara.Texto;
            this.txtRua.MascaraCustomizada = "";
            this.txtRua.MaxLength = 400;
            this.txtRua.Name = "txtRua";
            this.txtRua.ReadOnly = false;
            this.txtRua.Size = new System.Drawing.Size(289, 40);
            this.txtRua.TabIndex = 5;
            this.txtRua.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtRua.UsarFonteCustomizada = false;
            this.txtRua.ValorSemMascara = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtCep
            // 
            this.txtCep.BackColorInput = System.Drawing.Color.White;
            this.txtCep.Caption = "Cep";
            this.txtCep.ForeColorInput = System.Drawing.SystemColors.WindowText;
            this.txtCep.Location = new System.Drawing.Point(10, 19);
            this.txtCep.Mascara = Unify.Budgets.UI.Controls.Enums.TipoMascara.Texto;
            this.txtCep.MascaraCustomizada = "";
            this.txtCep.MaxLength = 15;
            this.txtCep.Name = "txtCep";
            this.txtCep.ReadOnly = false;
            this.txtCep.Size = new System.Drawing.Size(122, 40);
            this.txtCep.TabIndex = 4;
            this.txtCep.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtCep.UsarFonteCustomizada = false;
            this.txtCep.ValorSemMascara = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtNome
            // 
            this.txtNome.BackColorInput = System.Drawing.Color.White;
            this.txtNome.Caption = "Nome do Cliente";
            this.txtNome.ForeColorInput = System.Drawing.SystemColors.WindowText;
            this.txtNome.Location = new System.Drawing.Point(12, 12);
            this.txtNome.Mascara = Unify.Budgets.UI.Controls.Enums.TipoMascara.Texto;
            this.txtNome.MascaraCustomizada = "";
            this.txtNome.MaxLength = 400;
            this.txtNome.Name = "txtNome";
            this.txtNome.ReadOnly = false;
            this.txtNome.Size = new System.Drawing.Size(439, 40);
            this.txtNome.TabIndex = 0;
            this.txtNome.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtNome.UsarFonteCustomizada = false;
            this.txtNome.ValorSemMascara = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtDocum
            // 
            this.txtDocum.BackColorInput = System.Drawing.Color.White;
            this.txtDocum.Caption = "CPF/CNPJ";
            this.txtDocum.ForeColorInput = System.Drawing.SystemColors.WindowText;
            this.txtDocum.Location = new System.Drawing.Point(12, 58);
            this.txtDocum.Mascara = Unify.Budgets.UI.Controls.Enums.TipoMascara.Texto;
            this.txtDocum.MascaraCustomizada = "";
            this.txtDocum.MaxLength = 14;
            this.txtDocum.Name = "txtDocum";
            this.txtDocum.ReadOnly = false;
            this.txtDocum.Size = new System.Drawing.Size(114, 40);
            this.txtDocum.TabIndex = 1;
            this.txtDocum.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDocum.UsarFonteCustomizada = false;
            this.txtDocum.ValorSemMascara = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtFone
            // 
            this.txtFone.BackColorInput = System.Drawing.Color.White;
            this.txtFone.Caption = "Fone";
            this.txtFone.ForeColorInput = System.Drawing.SystemColors.WindowText;
            this.txtFone.Location = new System.Drawing.Point(132, 58);
            this.txtFone.Mascara = Unify.Budgets.UI.Controls.Enums.TipoMascara.Texto;
            this.txtFone.MascaraCustomizada = "";
            this.txtFone.MaxLength = 20;
            this.txtFone.Name = "txtFone";
            this.txtFone.ReadOnly = false;
            this.txtFone.Size = new System.Drawing.Size(154, 40);
            this.txtFone.TabIndex = 2;
            this.txtFone.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtFone.UsarFonteCustomizada = false;
            this.txtFone.ValorSemMascara = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtEmail
            // 
            this.txtEmail.BackColorInput = System.Drawing.Color.White;
            this.txtEmail.Caption = "Email";
            this.txtEmail.ForeColorInput = System.Drawing.SystemColors.WindowText;
            this.txtEmail.Location = new System.Drawing.Point(12, 104);
            this.txtEmail.Mascara = Unify.Budgets.UI.Controls.Enums.TipoMascara.Texto;
            this.txtEmail.MascaraCustomizada = "";
            this.txtEmail.MaxLength = 400;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = false;
            this.txtEmail.Size = new System.Drawing.Size(439, 40);
            this.txtEmail.TabIndex = 3;
            this.txtEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtEmail.UsarFonteCustomizada = false;
            this.txtEmail.ValorSemMascara = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtComplemento
            // 
            this.txtComplemento.BackColorInput = System.Drawing.Color.White;
            this.txtComplemento.Caption = "Complemento";
            this.txtComplemento.ForeColorInput = System.Drawing.SystemColors.WindowText;
            this.txtComplemento.Location = new System.Drawing.Point(10, 155);
            this.txtComplemento.Mascara = Unify.Budgets.UI.Controls.Enums.TipoMascara.Texto;
            this.txtComplemento.MascaraCustomizada = "";
            this.txtComplemento.MaxLength = 15;
            this.txtComplemento.Name = "txtComplemento";
            this.txtComplemento.ReadOnly = false;
            this.txtComplemento.Size = new System.Drawing.Size(341, 40);
            this.txtComplemento.TabIndex = 17;
            this.txtComplemento.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtComplemento.UsarFonteCustomizada = false;
            this.txtComplemento.ValorSemMascara = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // frmCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 424);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtFone);
            this.Controls.Add(this.txtDocum);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkAtivo);
            this.Controls.Add(this.unifyFrame1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Cliente";
            this.Shown += new System.EventHandler(this.frmCliente_Shown);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Unify.Budgets.UI.Controls.Controls.UnifyFrame unifyFrame1;
        private System.Windows.Forms.CheckBox chkAtivo;
        private System.Windows.Forms.GroupBox groupBox1;
        private Unify.Budgets.UI.Controls.Controls.UnifyTextBox txtNome;
        private Unify.Budgets.UI.Controls.Controls.UnifyTextBox txtDocum;
        private Unify.Budgets.UI.Controls.Controls.UnifyTextBox txtFone;
        private Unify.Budgets.UI.Controls.Controls.UnifyTextBox txtEmail;
        private Unify.Budgets.UI.Controls.Controls.UnifyTextBox txtCep;
        private Unify.Budgets.UI.Controls.Controls.UnifyTextBox txtRua;
        private Unify.Budgets.UI.Controls.Controls.UnifyTextBox txtNr;
        private Unify.Budgets.UI.Controls.Controls.UnifyTextBox txtCidade;
        private Unify.Budgets.UI.Controls.Controls.UnifyTextBox txtBairro;
        private Unify.Budgets.UI.Controls.Controls.UnifyTextBox txtEstado;
        private UI.Controls.Controls.UnifyTextBox txtComplemento;
    }
}