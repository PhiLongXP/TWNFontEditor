
using System.Windows.Forms;

namespace TWNFont
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlEditor = new System.Windows.Forms.Panel();
            this.btnUpdateCharacter = new System.Windows.Forms.Button();
            this.lblPosition = new System.Windows.Forms.Label();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnPaste = new System.Windows.Forms.Button();
            this.txtConvert = new System.Windows.Forms.TextBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnlEditor
            // 
            this.pnlEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlEditor.Location = new System.Drawing.Point(240, 4);
            this.pnlEditor.Name = "pnlEditor";
            this.pnlEditor.Size = new System.Drawing.Size(275, 590);
            this.pnlEditor.TabIndex = 0;
            // 
            // btnUpdateCharacter
            // 
            this.btnUpdateCharacter.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.btnUpdateCharacter.Location = new System.Drawing.Point(240, 599);
            this.btnUpdateCharacter.Name = "btnUpdateCharacter";
            this.btnUpdateCharacter.Size = new System.Drawing.Size(122, 33);
            this.btnUpdateCharacter.TabIndex = 1;
            this.btnUpdateCharacter.Text = "Update Character";
            this.btnUpdateCharacter.UseVisualStyleBackColor = true;
            this.btnUpdateCharacter.Click += new System.EventHandler(this.btnUpdateCharacter_Click);
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(479, 596);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(32, 13);
            this.lblPosition.TabIndex = 2;
            this.lblPosition.Text = "NUM";
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(368, 605);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(47, 20);
            this.btnCopy.TabIndex = 3;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnPaste
            // 
            this.btnPaste.Location = new System.Drawing.Point(420, 605);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(47, 20);
            this.btnPaste.TabIndex = 4;
            this.btnPaste.Text = "Paste";
            this.btnPaste.UseVisualStyleBackColor = true;
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // txtConvert
            // 
            this.txtConvert.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConvert.Location = new System.Drawing.Point(4, 294);
            this.txtConvert.Multiline = true;
            this.txtConvert.Name = "txtConvert";
            this.txtConvert.Size = new System.Drawing.Size(231, 148);
            this.txtConvert.TabIndex = 5;
            this.txtConvert.Text = "Dấu Chấm Hỏi";
            // 
            // btnConvert
            // 
            this.btnConvert.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConvert.Location = new System.Drawing.Point(22, 452);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(195, 40);
            this.btnConvert.TabIndex = 6;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 635);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.txtConvert);
            this.Controls.Add(this.btnPaste);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.btnUpdateCharacter);
            this.Controls.Add(this.pnlEditor);
            this.Name = "frmMain";
            this.Text = "TWN Font Editor";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel pnlEditor;
        private Button btnUpdateCharacter;
        private Label lblPosition;
        private Button btnCopy;
        private Button btnPaste;
        private TextBox txtConvert;
        private Button btnConvert;
    }
}

