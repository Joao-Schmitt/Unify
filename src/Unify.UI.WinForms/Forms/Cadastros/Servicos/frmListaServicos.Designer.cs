namespace Unify.UI.WinForms.Forms.Cadastros.Servicos
{
    partial class frmListaServicos
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
            this.gridServicos = new System.Windows.Forms.DataGridView();
            this.btnAdd = new Unify.UI.Controls.Controls.UnifyButton();
            this.unifyFrame1 = new Unify.UI.Controls.Controls.UnifyFrame();
            this.txtFiltro = new Unify.UI.Controls.Controls.UnifyTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridServicos)).BeginInit();
            this.SuspendLayout();
            // 
            // gridServicos
            // 
            this.gridServicos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridServicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridServicos.Location = new System.Drawing.Point(12, 91);
            this.gridServicos.Name = "gridServicos";
            this.gridServicos.Size = new System.Drawing.Size(882, 389);
            this.gridServicos.TabIndex = 3;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAdd.Location = new System.Drawing.Point(791, 56);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(103, 29);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Adicionar";
            this.btnAdd.Theme = Unify.UI.Controls.Enums.ButtonTheme.ThemePrimary;
            this.btnAdd.UseAutomaticForeColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // unifyFrame1
            // 
            this.unifyFrame1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.unifyFrame1.ConfirmarButtonVisible = false;
            this.unifyFrame1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.unifyFrame1.InfoText = "Lista de Cadastros de Servicos";
            this.unifyFrame1.InfoVisible = true;
            this.unifyFrame1.Location = new System.Drawing.Point(0, 0);
            this.unifyFrame1.Name = "unifyFrame1";
            this.unifyFrame1.SairButtonVisible = true;
            this.unifyFrame1.Size = new System.Drawing.Size(902, 526);
            this.unifyFrame1.TabIndex = 0;
            // 
            // txtFiltro
            // 
            this.txtFiltro.Caption = "Filtro";
            this.txtFiltro.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtFiltro.Location = new System.Drawing.Point(12, 45);
            this.txtFiltro.Mascara = Unify.UI.Controls.Enums.TipoMascara.Texto;
            this.txtFiltro.MascaraCustomizada = "";
            this.txtFiltro.MaxLength = 32767;
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.ReadOnly = false;
            this.txtFiltro.Size = new System.Drawing.Size(411, 40);
            this.txtFiltro.TabIndex = 5;
            this.txtFiltro.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtFiltro.ValorSemMascara = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtFiltro.InputTextChanged += new System.EventHandler(this.txtFiltro_InputTextChanged);
            // 
            // frmListaServicos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 526);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.gridServicos);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.unifyFrame1);
            this.MinimumSize = new System.Drawing.Size(902, 526);
            this.Name = "frmListaServicos";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Shown += new System.EventHandler(this.frmListaServicos_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gridServicos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Unify.UI.Controls.Controls.UnifyFrame unifyFrame1;
        private Unify.UI.Controls.Controls.UnifyButton btnAdd;
        private System.Windows.Forms.DataGridView gridServicos;
        private Unify.UI.Controls.Controls.UnifyTextBox txtFiltro;
    }
}