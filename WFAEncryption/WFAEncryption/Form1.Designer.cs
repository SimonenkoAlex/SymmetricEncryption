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
            this.radioBtnMonoAlphabet = new System.Windows.Forms.RadioButton();
            this.radioBtnCaesar = new System.Windows.Forms.RadioButton();
            this.tBCounter = new System.Windows.Forms.TrackBar();
            this.numLatters = new System.Windows.Forms.Label();
            this.textKey = new System.Windows.Forms.TextBox();
            this.btnDecode = new System.Windows.Forms.Button();
            this.btnEncode = new System.Windows.Forms.Button();
            this.keyword = new System.Windows.Forms.Label();
            this.originalText = new System.Windows.Forms.RichTextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.labelOriginalText = new System.Windows.Forms.Label();
            this.labelCipherText = new System.Windows.Forms.Label();
            this.cipherText = new System.Windows.Forms.RichTextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labelHitIndex = new System.Windows.Forms.Label();
            this.hitIndex = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.keyLength = new System.Windows.Forms.TextBox();
            this.labelKeyLength = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioBtnVigenere);
            this.groupBox1.Controls.Add(this.radioBtnMonoAlphabet);
            this.groupBox1.Controls.Add(this.radioBtnCaesar);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(550, 60);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Метод шифрования";
            // 
            // radioBtnVigenere
            // 
            this.radioBtnVigenere.AutoSize = true;
            this.radioBtnVigenere.Checked = true;
            this.radioBtnVigenere.Enabled = false;
            this.radioBtnVigenere.Location = new System.Drawing.Point(128, 24);
            this.radioBtnVigenere.Name = "radioBtnVigenere";
            this.radioBtnVigenere.Size = new System.Drawing.Size(139, 23);
            this.radioBtnVigenere.TabIndex = 0;
            this.radioBtnVigenere.TabStop = true;
            this.radioBtnVigenere.Text = "метод Виженера";
            this.radioBtnVigenere.UseVisualStyleBackColor = true;
            this.radioBtnVigenere.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioBtnMonoAlphabet
            // 
            this.radioBtnMonoAlphabet.AutoSize = true;
            this.radioBtnMonoAlphabet.Enabled = false;
            this.radioBtnMonoAlphabet.Location = new System.Drawing.Point(273, 25);
            this.radioBtnMonoAlphabet.Name = "radioBtnMonoAlphabet";
            this.radioBtnMonoAlphabet.Size = new System.Drawing.Size(273, 23);
            this.radioBtnMonoAlphabet.TabIndex = 0;
            this.radioBtnMonoAlphabet.Text = "шифр одноалфавитной подстановки";
            this.radioBtnMonoAlphabet.UseVisualStyleBackColor = true;
            this.radioBtnMonoAlphabet.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioBtnCaesar
            // 
            this.radioBtnCaesar.AutoSize = true;
            this.radioBtnCaesar.Enabled = false;
            this.radioBtnCaesar.Location = new System.Drawing.Point(8, 25);
            this.radioBtnCaesar.Name = "radioBtnCaesar";
            this.radioBtnCaesar.Size = new System.Drawing.Size(114, 23);
            this.radioBtnCaesar.TabIndex = 0;
            this.radioBtnCaesar.Text = "шифр Цезаря";
            this.radioBtnCaesar.UseVisualStyleBackColor = true;
            this.radioBtnCaesar.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // tBCounter
            // 
            this.tBCounter.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.tBCounter.Location = new System.Drawing.Point(12, 80);
            this.tBCounter.Maximum = 32;
            this.tBCounter.Name = "tBCounter";
            this.tBCounter.Size = new System.Drawing.Size(520, 45);
            this.tBCounter.TabIndex = 2;
            this.tBCounter.Visible = false;
            this.tBCounter.ValueChanged += new System.EventHandler(this.tBCounter_ValueChanged);
            // 
            // numLatters
            // 
            this.numLatters.AutoSize = true;
            this.numLatters.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numLatters.Location = new System.Drawing.Point(538, 80);
            this.numLatters.Name = "numLatters";
            this.numLatters.Size = new System.Drawing.Size(21, 23);
            this.numLatters.TabIndex = 3;
            this.numLatters.Text = "0";
            this.numLatters.Visible = false;
            // 
            // textKey
            // 
            this.textKey.Location = new System.Drawing.Point(12, 137);
            this.textKey.Name = "textKey";
            this.textKey.Size = new System.Drawing.Size(160, 20);
            this.textKey.TabIndex = 4;
            // 
            // btnDecode
            // 
            this.btnDecode.Enabled = false;
            this.btnDecode.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDecode.Location = new System.Drawing.Point(445, 128);
            this.btnDecode.Name = "btnDecode";
            this.btnDecode.Size = new System.Drawing.Size(125, 35);
            this.btnDecode.TabIndex = 5;
            this.btnDecode.Text = "Расшифровать";
            this.btnDecode.UseVisualStyleBackColor = true;
            this.btnDecode.Click += new System.EventHandler(this.btnDecode_Click);
            // 
            // btnEncode
            // 
            this.btnEncode.Enabled = false;
            this.btnEncode.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEncode.Location = new System.Drawing.Point(314, 128);
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
            this.keyword.Location = new System.Drawing.Point(12, 115);
            this.keyword.Name = "keyword";
            this.keyword.Size = new System.Drawing.Size(123, 19);
            this.keyword.TabIndex = 3;
            this.keyword.Text = "Ключевое слово:";
            // 
            // originalText
            // 
            this.originalText.Location = new System.Drawing.Point(13, 186);
            this.originalText.Name = "originalText";
            this.originalText.Size = new System.Drawing.Size(550, 100);
            this.originalText.TabIndex = 6;
            this.originalText.Text = "";
            // 
            // btnLoad
            // 
            this.btnLoad.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnLoad.Location = new System.Drawing.Point(183, 128);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(125, 35);
            this.btnLoad.TabIndex = 5;
            this.btnLoad.Text = "Загрузка";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // labelOriginalText
            // 
            this.labelOriginalText.AutoSize = true;
            this.labelOriginalText.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelOriginalText.Location = new System.Drawing.Point(12, 160);
            this.labelOriginalText.Name = "labelOriginalText";
            this.labelOriginalText.Size = new System.Drawing.Size(168, 23);
            this.labelOriginalText.TabIndex = 7;
            this.labelOriginalText.Text = "Исходный текст:";
            // 
            // labelCipherText
            // 
            this.labelCipherText.AutoSize = true;
            this.labelCipherText.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCipherText.Location = new System.Drawing.Point(12, 324);
            this.labelCipherText.Name = "labelCipherText";
            this.labelCipherText.Size = new System.Drawing.Size(281, 23);
            this.labelCipherText.TabIndex = 7;
            this.labelCipherText.Text = "(За/Рас)шифрованный текст:";
            // 
            // cipherText
            // 
            this.cipherText.Location = new System.Drawing.Point(13, 350);
            this.cipherText.Name = "cipherText";
            this.cipherText.Size = new System.Drawing.Size(550, 100);
            this.cipherText.TabIndex = 6;
            this.cipherText.Text = "";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(582, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(220, 440);
            this.dataGridView1.TabIndex = 8;
            // 
            // labelHitIndex
            // 
            this.labelHitIndex.AutoSize = true;
            this.labelHitIndex.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHitIndex.ForeColor = System.Drawing.Color.Maroon;
            this.labelHitIndex.Location = new System.Drawing.Point(253, 293);
            this.labelHitIndex.Name = "labelHitIndex";
            this.labelHitIndex.Size = new System.Drawing.Size(144, 19);
            this.labelHitIndex.TabIndex = 3;
            this.labelHitIndex.Text = "Индекс совпадения:";
            // 
            // hitIndex
            // 
            this.hitIndex.BackColor = System.Drawing.Color.MistyRose;
            this.hitIndex.Enabled = false;
            this.hitIndex.Location = new System.Drawing.Point(403, 292);
            this.hitIndex.Name = "hitIndex";
            this.hitIndex.Size = new System.Drawing.Size(160, 20);
            this.hitIndex.TabIndex = 4;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(822, 12);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(550, 440);
            this.dataGridView2.TabIndex = 9;
            // 
            // keyLength
            // 
            this.keyLength.BackColor = System.Drawing.Color.MistyRose;
            this.keyLength.Enabled = false;
            this.keyLength.Location = new System.Drawing.Point(119, 292);
            this.keyLength.Name = "keyLength";
            this.keyLength.Size = new System.Drawing.Size(100, 20);
            this.keyLength.TabIndex = 4;
            // 
            // labelKeyLength
            // 
            this.labelKeyLength.AutoSize = true;
            this.labelKeyLength.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelKeyLength.ForeColor = System.Drawing.Color.Maroon;
            this.labelKeyLength.Location = new System.Drawing.Point(12, 293);
            this.labelKeyLength.Name = "labelKeyLength";
            this.labelKeyLength.Size = new System.Drawing.Size(101, 19);
            this.labelKeyLength.TabIndex = 3;
            this.labelKeyLength.Text = "Длина ключа:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1384, 462);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.labelCipherText);
            this.Controls.Add(this.labelOriginalText);
            this.Controls.Add(this.cipherText);
            this.Controls.Add(this.originalText);
            this.Controls.Add(this.btnEncode);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnDecode);
            this.Controls.Add(this.keyLength);
            this.Controls.Add(this.hitIndex);
            this.Controls.Add(this.textKey);
            this.Controls.Add(this.labelKeyLength);
            this.Controls.Add(this.labelHitIndex);
            this.Controls.Add(this.keyword);
            this.Controls.Add(this.numLatters);
            this.Controls.Add(this.tBCounter);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Симметрическое шифрование";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioBtnVigenere;
        private System.Windows.Forms.RadioButton radioBtnCaesar;
        private System.Windows.Forms.TrackBar tBCounter;
        private System.Windows.Forms.Label numLatters;
        private System.Windows.Forms.TextBox textKey;
        private System.Windows.Forms.Button btnDecode;
        private System.Windows.Forms.Button btnEncode;
        private System.Windows.Forms.Label keyword;
        private System.Windows.Forms.RichTextBox originalText;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label labelOriginalText;
        private System.Windows.Forms.Label labelCipherText;
        private System.Windows.Forms.RichTextBox cipherText;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelHitIndex;
        private System.Windows.Forms.TextBox hitIndex;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox keyLength;
        private System.Windows.Forms.Label labelKeyLength;
        private System.Windows.Forms.RadioButton radioBtnMonoAlphabet;
    }
}

