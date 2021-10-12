using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFAEncryption
{
    public partial class MainForm : Form
    {
        private const float RUS_MI = 0.0553f;
        private const float ENG_MI = 0.0644f;
        private const int ENG = 26, RUS = 32;

        private static int offset;          // сдвиг
        private static char[] alphabet;     // алфавит
        private static float[] freq;        // относительная частота
        private static int N;               // мощность алфавита
        private static int i = 0, j = 0;    // переменные цикла
        private static string method = "Vigenere";
        private static float constMI;


        public MainForm()
        {
            InitializeComponent();
            btnDecode.Enabled = false;
            btnEncode.Enabled = false;
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (radioBtnEng.Checked)
            {
                tBCounter.Maximum = ENG;
                constMI = ENG_MI;
                alphabet = new char[] { ' ', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I',
                                        'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S',
                                        'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
                N = alphabet.Length;
                freq = new float[N];
                for (int i = 0; i < N; freq[i++] = 0) { }
            }
            if (radioBtnRus.Checked)
            {
                tBCounter.Maximum = RUS;
                constMI = RUS_MI;
                alphabet = new char[] { ' ', 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ж', 'З', 'И',
                                        'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т',
                                        'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ы', 'Ь',
                                        'Э', 'Ю', 'Я' };
                N = alphabet.Length;
                freq = new float[N];
                for (int i = 0; i < N; freq[i++] = 0) { }
            }
        }

        private void tBCounter_ValueChanged(object sender, EventArgs e)
        {
            numLatters.Text = tBCounter.Value.ToString();
            offset = Convert.ToInt32(numLatters.Text);
        }

        // реализация метода, шифрующего строку методом Виженера
        private string Encode_Vigenere(string input, string keyword)
        {
            input = input.ToUpper();
            keyword = keyword.ToUpper();

            string result = "";
            int keyword_index = 0;

            foreach (char symbol in input)
            {
                int c = (Array.IndexOf(alphabet, symbol) +
                    Array.IndexOf(alphabet, keyword[keyword_index])) % N;
                result += alphabet[c];
                keyword_index++;
                if ((keyword_index + 1) == keyword.Length)
                    keyword_index = 0;
            }
            return result;
        }

        // реализация метода, шифрующего строку методом Цезаря
        private string Encode_Caesar(string input)
        {
            string result = "";
            int keyNumber = Convert.ToInt32(numLatters.Text);

            foreach (char symbol in input)
            {
                int c = (Array.IndexOf(alphabet, symbol) + keyNumber) % N;
                result += alphabet[c];
            }
            return result;
        }

        private void btnEncode_Click(object sender, EventArgs e)
        {
            switch (method)
            {
                case "Caesar":
                    {
                        string text = originalText.Text.ToString().ToUpper();
                        cipherText.Text = Encode_Caesar(text).ToLower();
                        break;
                    }
                case "Vigenere":
                    {
                        string keyword = textKey.Text;
                        if (keyword.Length > 0)
                        {
                            string text = originalText.Text.ToString().ToUpper();
                            cipherText.Text = Encode_Vigenere(text, keyword).ToLower();
                        }
                        else MessageBox.Show("Введите ключевое слово!");
                        break;
                    }
            }
        }

        private void btnDecode_Click(object sender, EventArgs e)
        {
            switch (method)
            {
                case "Caesar":
                    {   // расшифровать текст метода Цезаря
                        string text = originalText.Text.ToString().ToUpper();
                        cipherText.Text = Decode_Caesar(text).ToLower();
                        break;
                    }
                case "Vigenere":
                    {   // расшифровать текст метода Виженера
                        string text = originalText.Text.ToString().ToUpper();
                        cipherText.Text = Decode_Vigenere(text).ToLower();
                        break;
                    }
            }
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                if (radioButton.Text == "метод Виженера")
                {
                    tBCounter.Visible = false; numLatters.Visible = false;
                    textKey.Visible = true; keyword.Visible = true;
                    labelKeyLength.Visible = true; keyLength.Visible = true;
                    labelHitIndex.Visible = true; hitIndex.Visible = true;
                    method = "Vigenere";
                }
                if (radioButton.Text == "шифр Цезаря")
                {
                    tBCounter.Visible = true; numLatters.Visible = true;
                    textKey.Visible = false; keyword.Visible = false;
                    labelKeyLength.Visible = false; keyLength.Visible = false;
                    labelHitIndex.Visible = false; hitIndex.Visible = false;
                    method = "Caesar";
                }
            }
        }

        private void radioBtnLanguage_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                if (radioButton.Text == "английский")
                {
                    tBCounter.Maximum = ENG;
                    alphabet = new char[] { ' ', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I',
                                            'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S',
                                            'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
                    N = alphabet.Length;
                }
                if (radioButton.Text == "русский")
                {
                    tBCounter.Maximum = RUS;
                    alphabet = new char[] { ' ', 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ж', 'З', 'И',
                                            'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т',
                                            'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ы', 'Ь',
                                            'Э', 'Ю', 'Я' };
                    N = alphabet.Length;
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            // читаем файл в строку
            string fileText = System.IO.File.ReadAllText(filename);
            originalText.Text = fileText;
            btnDecode.Enabled = true;
            btnEncode.Enabled = true;
            MessageBox.Show("Файл открыт");
        }

        // реализация метода расшифровки строки 
        // зашифрованной методом Цезаря
        private string Decode_Caesar(string input)
        {
            string result = "";             // выходная строка
            int keyNumber = 0;              // предполагаемая длина ключа
            int n = input.Length;           // длина исходного текста
            float saveFreq = 0f;
            int[] count = new int[n];       // кол-во i-ой буквы в тексте
            DataTable freqTable;
            String[] freqColumns = { "№ буквы", "Буква", "Кол-во", "Относ. частота" };

            // Создаем таблицу индекса совпадений для длин ключа
            freqTable = creatTable(freqColumns);

            char[] charInput = input.ToCharArray();
            count = matchSearch(input);
            for (i = 0; i < N; i++)
            {
                freq[i] = (float)count[i] / n;
                freqTable.Rows.Add(i, alphabet[i], count[i], freq[i]);
                if (saveFreq <= freq[i])
                {
                    saveFreq = freq[i];
                    if (Math.Round(freq[i], 3) >= 0.1)
                    {
                        keyNumber = Array.IndexOf(alphabet, alphabet[i]);
                    }
                }
            }
            dataGridView2.DataSource = freqTable;
            numLatters.Text = keyNumber.ToString();

            int firstSymbol = 0, subSumbol = 0;
            for (i = 0; i < n; i++)
            {
                firstSymbol = Array.IndexOf(alphabet, charInput[i]);
                subSumbol = (firstSymbol - keyNumber) % N;
                if (subSumbol < 0) result += alphabet[N + subSumbol];
                else result += alphabet[subSumbol];
            }
            return result;
        }

        DataTable creatTable(String[] nameColumns)
        {
            DataTable table = new DataTable();
            for (i = 0; i < nameColumns.Length; i++)
                table.Columns.Add(nameColumns[i]);
            return table;
        }

        // реализация метода расшифровки строки 
        // зашифрованной методом Виженера
        private string Decode_Vigenere(string input)
        {
            string result = "";             // выходная строка
            int len, keyLeng;               // предполагаемая длина ключа
            int n = input.Length;           // длина исходного текста
            int n0 = 0;                     // длина временного текста
            float ind1 = 0f;                // индекс совпадений
            int[] ind = new int[n];         // кол-во i-ой буквы в тексте
            string teststr = "";            // временная строка
            DataTable freqTable, indexTable;
            String[] freqColumns = { "№ слова", "№ буквы", "Буква", "Относ. частота" };
            String[] indexColumns = { "Длина ключа", "Индекс совпадений" };

            // Создаем таблицу относительных частот букв в тексте
            freqTable = creatTable(freqColumns);

            // Создаем таблицу индекса совпадений для длин ключа
            indexTable = creatTable(indexColumns);

            char[] charInput = input.ToCharArray();
            for (keyLeng = 2; keyLeng < 40; keyLeng++)
            {   // цикл поиска ключа
                teststr = ""; ind1 = 0f;
                for (i = 0; i < n; i += keyLeng)
                    teststr += charInput[i];
                ind = matchSearch(teststr);
                n0 = teststr.Length;
                for (j = 0; j < N; j++)
                    ind1 += (float)(ind[j] * (ind[j] - 1)) / (n0 * (n0 - 1));
                indexTable.Rows.Add(keyLeng, ind1);
                if (Math.Round(ind1, 4) >= constMI) break;
            }
            dataGridView1.DataSource = indexTable;

            keyLength.Text = keyLeng.ToString();
            hitIndex.Text = ind1.ToString();
            //originalText.Text = "";
            string[] splitText = new string[keyLeng];
            char[] key = new char[keyLeng];
            char[] resultText = new char[n];
            string keyWord = "";
            float saveFreq = 0f;
            for (j = 0; j < keyLeng; j++)
            {
                for (i = j; i < n; i += keyLeng)
                {
                    splitText[j] += charInput[i];
                }
                //originalText.Text += String.Format("{0} >- {1}\n", j, splitText[j]).ToLower();
                ind = matchSearch(splitText[j]);
                len = splitText[j].Length;
                for (i = 0; i < N; i++)
                {
                    freq[i] = (float)ind[i] / len;
                    freqTable.Rows.Add(j + 1, i, alphabet[i], freq[i]);
                    if (saveFreq <= freq[i])
                    {
                        saveFreq = freq[i];
                        if (Math.Round(freq[i], 3) >= 0.1)
                        {
                            key[j] = ' ';
                            int c = Array.IndexOf(alphabet, alphabet[i]);
                            key[j] = alphabet[c];
                        }
                    }
                }
                keyWord += key[j];
                saveFreq = 0f;
            }
            dataGridView2.DataSource = freqTable;

            int firstSymbol = 0, secondSymbol = 0, subSumbol = 0;
            for (j = 0; j < keyLeng; j++)
            {
                for (i = j; i < n; i += keyLeng)
                {
                    firstSymbol = Array.IndexOf(alphabet, charInput[i]);
                    secondSymbol = Array.IndexOf(alphabet, key[j]);
                    subSumbol = (firstSymbol - secondSymbol) % N;
                    if (subSumbol < 0) resultText[i] = alphabet[N + subSumbol];
                    else resultText[i] = alphabet[subSumbol];
                }
            }
            for (i = 0; i < n; i++)
            {
                result += resultText[i];
            }
            textKey.Text = keyWord.ToLower();
            return result;
        }

        private int[] matchSearch(string text)
        {
            int[] index = new int[text.Length];
            i = 0; // обнулить индекс
            foreach (char symbolABC in alphabet)
            {   // перебор символов алфавита и исходного текста
                foreach (char symbolText in text)
                {   // и подсчёт количества совпадений
                    if (symbolABC == symbolText) index[i]++;
                }
                i++;
            }
            return index;
        }
    }
}
