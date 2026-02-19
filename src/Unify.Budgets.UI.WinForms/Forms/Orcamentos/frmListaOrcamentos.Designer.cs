namespace Unify.Budgets.UI.WinForms.Forms.Cadastros.Orcamentos
{
    partial class frmListaOrcamentos
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
            this.gridOrcamentos = new System.Windows.Forms.DataGridView();
            this.unifyFrame1 = new Unify.Budgets.UI.Controls.Controls.UnifyFrame();
            this.txtFiltro = new Unify.Budgets.UI.Controls.Controls.UnifyTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridOrcamentos)).BeginInit();
            this.SuspendLayout();
            // 
            // gridOrcamentos
            // 
            this.gridOrcamentos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridOrcamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridOrcamentos.Location = new System.Drawing.Point(12, 91);
            this.gridOrcamentos.Name = "gridOrcamentos";
            this.gridOrcamentos.Size = new System.Drawing.Size(882, 389);
            this.gridOrcamentos.TabIndex = 3;
            // 
            // unifyFrame1
            // 
            this.unifyFrame1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.unifyFrame1.ConfirmarButtonVisible = true;
            this.unifyFrame1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.unifyFrame1.InfoText = "Lista de Cadastros de Orcamentos";
            this.unifyFrame1.InfoVisible = true;
            this.unifyFrame1.Location = new System.Drawing.Point(0, 0);
            this.unifyFrame1.Name = "unifyFrame1";
            this.unifyFrame1.SairButtonVisible = true;
            this.unifyFrame1.Size = new System.Drawing.Size(902, 526);
            this.unifyFrame1.TabIndex = 0;
            this.unifyFrame1.ConfirmarButtonClick += new System.EventHandler(this.unifyFrame1_ConfirmarButtonClick);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Caption = "Filtro";
            this.txtFiltro.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtFiltro.Location = new System.Drawing.Point(12, 45);
            this.txtFiltro.Mascara = Unify.Budgets.UI.Controls.Enums.TipoMascara.Texto;
            this.txtFiltro.MascaraCustomizada = "";
            this.txtFiltro.MaxLength = 32767;
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.ReadOnly = false;
            this.txtFiltro.Size = new System.Drawing.Size(411, 40);
            this.txtFiltro.TabIndex = 5;
            this.txtFiltro.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtFiltro.UsarFonteCustomizada = false;
            this.txtFiltro.ValorSemMascara = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtFiltro.InputTextChanged += new System.EventHandler(this.txtFiltro_InputTextChanged);
            // 
            // frmListaOrcamentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 526);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.gridOrcamentos);
            this.Controls.Add(this.unifyFrame1);
            this.MinimumSize = new System.Drawing.Size(902, 526);
            this.Name = "frmListaOrcamentos";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Shown += new System.EventHandler(this.frmListaOrcamentos_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gridOrcamentos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Unify.Budgets.UI.Controls.Controls.UnifyFrame unifyFrame1;
        private System.Windows.Forms.DataGridView gridOrcamentos;
        private Unify.Budgets.UI.Controls.Controls.UnifyTextBox txtFiltro;
    }
}