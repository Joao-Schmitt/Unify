namespace Unify.UI.Controls.Forms
{
    partial class frmMap
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
            this.webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.unifyFrame1 = new Unify.UI.Controls.Controls.UnifyFrame();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).BeginInit();
            this.SuspendLayout();
            // 
            // webView21
            // 
            this.webView21.AllowExternalDrop = true;
            this.webView21.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webView21.CreationProperties = null;
            this.webView21.Cursor = System.Windows.Forms.Cursors.Hand;
            this.webView21.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView21.Location = new System.Drawing.Point(0, 30);
            this.webView21.Name = "webView21";
            this.webView21.Size = new System.Drawing.Size(833, 430);
            this.webView21.TabIndex = 1;
            this.webView21.ZoomFactor = 1D;
            // 
            // unifyFrame1
            // 
            this.unifyFrame1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.unifyFrame1.ConfirmarButtonVisible = true;
            this.unifyFrame1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.unifyFrame1.InfoText = "";
            this.unifyFrame1.InfoVisible = true;
            this.unifyFrame1.Location = new System.Drawing.Point(0, 0);
            this.unifyFrame1.Name = "unifyFrame1";
            this.unifyFrame1.SairButtonVisible = true;
            this.unifyFrame1.Size = new System.Drawing.Size(833, 501);
            this.unifyFrame1.TabIndex = 0;
            this.unifyFrame1.ConfirmarButtonClick += new System.EventHandler(this.unifyFrame1_ConfirmarButtonClick);
            // 
            // frmMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 501);
            this.Controls.Add(this.webView21);
            this.Controls.Add(this.unifyFrame1);
            this.Name = "frmMap";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.UnifyFrame unifyFrame1;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
    }
}