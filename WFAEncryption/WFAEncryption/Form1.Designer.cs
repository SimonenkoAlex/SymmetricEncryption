namespace WFAEncryption
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioBtnVigenere = new System.Windows.Forms.RadioButton();
            this.radioBtnCaesar = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tBCounter = new System.Windows.Forms.TrackBar();
            this.numLatters = new System.Windows.Forms.Label();
            this.textKey = new System.Windows.Forms.TextBox();
            this.btnDecode = new System.Windows.Forms.Button();
            this.btnEncode = new System.Windows.Forms.Button();
            this.keyword = new System.Windows.Forms.Label();
            this.radioBtnEng = new System.Windows.Forms.RadioButton();
            this.radioBtnRus = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBCounter)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioBtnVigenere);
            this.groupBox1.Controls.Add(this.radioBtnCaesar);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 60);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Метод шифрования";
            // 
            // radioBtnVigenere
            // 
            this.radioBtnVigenere.AutoSize = true;
            this.radioBtnVigenere.Checked = true;
            this.radioBtnVigenere.Location = new System.Drawing.Point(135, 26);
            this.radioBtnVigenere.Name = "radioBtnVigenere";
            this.radioBtnVigenere.Size = new System.Drawing.Size(139, 23);
            this.radioBtnVigenere.TabIndex = 0;
            this.radioBtnVigenere.TabStop = true;
            this.radioBtnVigenere.Text = "метод Виженера";
            this.radioBtnVigenere.UseVisualStyleBackColor = true;
            this.radioBtnVigenere.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioBtnCaesar
            // 
            this.radioBtnCaesar.AutoSize = true;
            this.radioBtnCaesar.Location = new System.Drawing.Point(7, 26);
            this.radioBtnCaesar.Name = "radioBtnCaesar";
            this.radioBtnCaesar.Size = new System.Drawing.Size(114, 23);
            this.radioBtnCaesar.TabIndex = 0;
            this.radioBtnCaesar.Text = "шифр Цезаря";
            this.radioBtnCaesar.UseVisualStyleBackColor = true;
            this.radioBtnCaesar.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioBtnRus);
            this.groupBox2.Controls.Add(this.radioBtnEng);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(299, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(273, 61);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Язык";
            // 
            // tBCounter
            // 
            this.tBCounter.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.tBCounter.Location = new System.Drawing.Point(12, 79);
            this.tBCounter.Maximum = 32;
            this.tBCounter.Name = "tBCounter";
            this.tBCounter.Size = new System.Drawing.Size(517, 45);
            this.tBCounter.TabIndex = 2;
            this.tBCounter.Visible = false;
            this.tBCounter.ValueChanged += new System.EventHandler(this.tBCounter_ValueChanged);
            // 
            // numLatters
            // 
            this.numLatters.AutoSize = true;
            this.numLatters.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numLatters.Location = new System.Drawing.Point(535, 79);
            this.numLatters.Name = "numLatters";
            this.numLatters.Size = new System.Drawing.Size(21, 23);
            this.numLatters.TabIndex = 3;
            this.numLatters.Text = "0";
            this.numLatters.Visible = false;
            // 
            // textKey
            // 
            this.textKey.Location = new System.Drawing.Point(141, 124);
            this.textKey.Name = "textKey";
            this.textKey.Size = new System.Drawing.Size(169, 20);
            this.textKey.TabIndex = 4;
            // 
            // btnDecode
            // 
            this.btnDecode.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDecode.Location = new System.Drawing.Point(447, 115);
            this.btnDecode.Name = "btnDecode";
            this.btnDecode.Size = new System.Drawing.Size(125, 35);
            this.btnDecode.TabIndex = 5;
            this.btnDecode.Text = "Расшифровать";
            this.btnDecode.UseVisualStyleBackColor = true;
            this.btnDecode.Click += new System.EventHandler(this.btnDecode_Click);
            // 
            // btnEncode
            // 
            this.btnEncode.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEncode.Location = new System.Drawing.Point(316, 115);
            this.btnEncode.Name = "btnEncode";
            this.btnEncode.Size = new System.Drawing.Size(125, 35);
            this.btnEncode.TabIndex = 5;
            this.btnEncode.Text = "Зашифровать";
            this.btnEncode.UseVisualStyleBackColor = true;
            this.btnEncode.Click += new System.EventHandler(this.btnEncode_Click);
            // 
            // keyword
            // 
            this.keyword.AutoSize = true;
            this.keyword.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.keyword.Location = new System.Drawing.Point(12, 123);
            this.keyword.Name = "keyword";
            this.keyword.Size = new System.Drawing.Size(123, 19);
            this.keyword.TabIndex = 3;
            this.keyword.Text = "Ключевое слово:";
            // 
            // radioBtnEng
            // 
            this.radioBtnEng.AutoSize = true;
            this.radioBtnEng.Location = new System.Drawing.Point(6, 27);
            this.radioBtnEng.Name = "radioBtnEng";
            this.radioBtnEng.Size = new System.Drawing.Size(106, 23);
            this.radioBtnEng.TabIndex = 0;
            this.radioBtnEng.Text = "английский";
            this.radioBtnEng.UseVisualStyleBackColor = true;
            this.radioBtnEng.CheckedChanged += new System.EventHandler(this.radioBtnLanguage_CheckedChanged);
            // 
            // radioBtnRus
            // 
            this.radioBtnRus.AutoSize = true;
            this.radioBtnRus.Checked = true;
            this.radioBtnRus.Location = new System.Drawing.Point(161, 27);
            this.radioBtnRus.Name = "radioBtnRus";
            this.radioBtnRus.Size = new System.Drawing.Size(81, 23);
            this.radioBtnRus.TabIndex = 0;
            this.radioBtnRus.TabStop = true;
            this.radioBtnRus.Text = "русский";
            this.radioBtnRus.UseVisualStyleBackColor = true;
            this.radioBtnRus.CheckedChanged += new System.EventHandler(this.radioBtnLanguage_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(584, 161);
            this.Controls.Add(this.btnEncode);
            this.Controls.Add(this.btnDecode);
            this.Controls.Add(this.textKey);
            this.Controls.Add(this.keyword);
            this.Controls.Add(this.numLatters);
            this.Controls.Add(this.tBCounter);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Симметрическое шифрование";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBCounter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioBtnVigenere;
        private System.Windows.Forms.RadioButton radioBtnCaesar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TrackBar tBCounter;
        private System.Windows.Forms.Label numLatters;
        private System.Windows.Forms.TextBox textKey;
        private System.Windows.Forms.Button btnDecode;
        private System.Windows.Forms.Button btnEncode;
        private System.Windows.Forms.Label keyword;
        private System.Windows.Forms.RadioButton radioBtnRus;
        private System.Windows.Forms.RadioButton radioBtnEng;
    }
}

