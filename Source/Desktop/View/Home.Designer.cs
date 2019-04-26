namespace Desktop.View
{
    partial class Home
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabFrete = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.txtTamanho = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPeso = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCep = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabFinanceiro = new System.Windows.Forms.TabPage();
            this.lblResultadoFinanceiro = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.txtCpf = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblResultadoFrete = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabFrete.SuspendLayout();
            this.tabFinanceiro.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabFrete);
            this.tabControl.Controls.Add(this.tabFinanceiro);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(327, 500);
            this.tabControl.TabIndex = 0;
            // 
            // tabFrete
            // 
            this.tabFrete.Controls.Add(this.lblResultadoFrete);
            this.tabFrete.Controls.Add(this.button1);
            this.tabFrete.Controls.Add(this.txtTamanho);
            this.tabFrete.Controls.Add(this.label3);
            this.tabFrete.Controls.Add(this.txtPeso);
            this.tabFrete.Controls.Add(this.label2);
            this.tabFrete.Controls.Add(this.txtCep);
            this.tabFrete.Controls.Add(this.label1);
            this.tabFrete.Location = new System.Drawing.Point(4, 22);
            this.tabFrete.Name = "tabFrete";
            this.tabFrete.Padding = new System.Windows.Forms.Padding(3);
            this.tabFrete.Size = new System.Drawing.Size(319, 474);
            this.tabFrete.TabIndex = 0;
            this.tabFrete.Text = "Frete";
            this.tabFrete.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(82, 181);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Calcular Frete";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // txtTamanho
            // 
            this.txtTamanho.Location = new System.Drawing.Point(19, 145);
            this.txtTamanho.Name = "txtTamanho";
            this.txtTamanho.Size = new System.Drawing.Size(279, 20);
            this.txtTamanho.TabIndex = 5;
            this.txtTamanho.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTamanho_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tamanho";
            // 
            // txtPeso
            // 
            this.txtPeso.Location = new System.Drawing.Point(19, 93);
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.Size = new System.Drawing.Size(279, 20);
            this.txtPeso.TabIndex = 3;
            this.txtPeso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPeso_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Peso";
            // 
            // txtCep
            // 
            this.txtCep.Location = new System.Drawing.Point(19, 41);
            this.txtCep.Name = "txtCep";
            this.txtCep.Size = new System.Drawing.Size(279, 20);
            this.txtCep.TabIndex = 1;
            this.txtCep.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCep_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "CEP";
            // 
            // tabFinanceiro
            // 
            this.tabFinanceiro.Controls.Add(this.lblResultadoFinanceiro);
            this.tabFinanceiro.Controls.Add(this.button2);
            this.tabFinanceiro.Controls.Add(this.txtCpf);
            this.tabFinanceiro.Controls.Add(this.label5);
            this.tabFinanceiro.Location = new System.Drawing.Point(4, 22);
            this.tabFinanceiro.Name = "tabFinanceiro";
            this.tabFinanceiro.Padding = new System.Windows.Forms.Padding(3);
            this.tabFinanceiro.Size = new System.Drawing.Size(319, 474);
            this.tabFinanceiro.TabIndex = 1;
            this.tabFinanceiro.Text = "Financeiro";
            this.tabFinanceiro.UseVisualStyleBackColor = true;
            // 
            // lblResultadoFinanceiro
            // 
            this.lblResultadoFinanceiro.Location = new System.Drawing.Point(27, 133);
            this.lblResultadoFinanceiro.Name = "lblResultadoFinanceiro";
            this.lblResultadoFinanceiro.Size = new System.Drawing.Size(258, 302);
            this.lblResultadoFinanceiro.TabIndex = 11;
            this.lblResultadoFinanceiro.Text = "Informe o CPF do comprador\r\n";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(30, 93);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(255, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Verificar Situação Financeira";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // txtCpf
            // 
            this.txtCpf.Location = new System.Drawing.Point(21, 55);
            this.txtCpf.Name = "txtCpf";
            this.txtCpf.Size = new System.Drawing.Size(279, 20);
            this.txtCpf.TabIndex = 9;
            this.txtCpf.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCpf_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "CPF do comprador";
            // 
            // lblResultadoFrete
            // 
            this.lblResultadoFrete.Location = new System.Drawing.Point(25, 218);
            this.lblResultadoFrete.Name = "lblResultadoFrete";
            this.lblResultadoFrete.Size = new System.Drawing.Size(258, 203);
            this.lblResultadoFrete.TabIndex = 7;
            this.lblResultadoFrete.Text = "Informe o CEP de destino e dados do produto";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 524);
            this.Controls.Add(this.tabControl);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.tabControl.ResumeLayout(false);
            this.tabFrete.ResumeLayout(false);
            this.tabFrete.PerformLayout();
            this.tabFinanceiro.ResumeLayout(false);
            this.tabFinanceiro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabFrete;
        private System.Windows.Forms.TextBox txtTamanho;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPeso;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCep;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabFinanceiro;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblResultadoFinanceiro;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtCpf;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblResultadoFrete;
    }
}