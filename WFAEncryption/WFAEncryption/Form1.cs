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
        private const int RUS = 32;

        private static int offset;          // сдвиг
        private static char[] alphabet;     // алфавит
        private static float[] freq;        // относительная частота
        private static int N;               // мощность алфавита
        private static int i = 0, j = 0;    // переменные цикла
        private static string method = null;
        private static float constMI;


        public MainForm()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            tBCounter.Maximum = RUS;
            constMI = RUS_MI;
            alphabet = new char[] {
                ' ', 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ж', 'З', 'И', 'Й',
                'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф',
                'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ы', 'Ь', 'Э', 'Ю', 'Я' };
            N = alphabet.Length;
            freq = new float[N];
            for (int i = 0; i < N; freq[i++] = 0) { }
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
            if (originalText.Text.Equals("")) MessageBox.Show("Текстовое поле пустое!");
            else
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
        }

        private void btnDecode_Click(object sender, EventArgs e)
        {
            if (originalText.Text.Equals("")) MessageBox.Show("Текстовое поле пустое!");
            else
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
                    case "Substitution":
                        {   // расшифровать текст метода подстановки
                            string text = originalText.Text.ToString().ToUpper();
                            cipherText.Text = Decode_Substitution(text).ToLower();
                            break;
                        }
                }
            }
        }

        private string radioBtn_Checked()
        {
            if (radioBtnVigenere.Checked)
            {
                tBCounter.Visible = false; numLatters.Visible = false;
                textKey.Visible = true; keyword.Visible = true;
                labelKeyLength.Visible = true; keyLength.Visible = true;
                labelHitIndex.Visible = true; hitIndex.Visible = true;
                btnEncode.Enabled = true; btnDecode.Enabled = true;
                return "Vigenere";
            }
            if (radioBtnCaesar.Checked)
            {
                tBCounter.Visible = true; numLatters.Visible = true;
                textKey.Visible = false; keyword.Visible = false;
                labelKeyLength.Visible = false; keyLength.Visible = false;
                labelHitIndex.Visible = false; hitIndex.Visible = false;
                btnEncode.Enabled = true; btnDecode.Enabled = true;
                return "Caesar";
            }
            if (radioBtnMonoAlphabet.Checked)
            {
                tBCounter.Visible = false; numLatters.Visible = false;
                textKey.Visible = false; keyword.Visible = false;
                labelKeyLength.Visible = false; keyLength.Visible = false;
                labelHitIndex.Visible = false; hitIndex.Visible = false;
                btnEncode.Enabled = false; btnDecode.Enabled = true;
                return "Substitution";
            }
            return null;
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            method = radioBtn_Checked();
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
            radioBtnVigenere.Enabled = true;
            radioBtnCaesar.Enabled = true;
            radioBtnMonoAlphabet.Enabled = true;
            method = radioBtn_Checked();
            MessageBox.Show("Файл открыт");
        }

        private string Decode_Substitution(string input)
        {
            string result = "";             // выходная строка
            int n = input.Length;           // длина исходного текста
            int[] count = new int[n];       // кол-во i-ой буквы в тексте
            //float maxFreq = 0f;
            DataTable freqTable;
            String[] freqColumns = { "№ п/п", "Буква шифротекста",
                "Кол-во", "Относ. частота", "Буква исходного текста" };
            char[] alphabetFreq = new char[] {
                ' ', 'С', 'О', 'Т', 'Е', 'А', 'И', 'Р', 'Н', 'Л', 'У',
                'В', 'К', 'Д', 'Я', 'П', 'Х', 'Ы', 'Г', 'Ю', 'Ч', 'Ь',
                'М', 'Ж', 'Б', 'Ф', 'Э', 'Щ', 'Й', 'З', 'Ц', 'Ш' };

            // Создаем таблицу индекса совпадений для длин ключа
            freqTable = creatTable(freqColumns);

            count = matchSearch(input);
            for (i = 0; i < N; i++)
                freq[i] = (float)count[i] / n;

            char[] copyAlphabet = alphabet;
            for (i = 0; i < N - 1; i++)
            {
                for (j = i + 1; j < N; j++)
                {
                    if (freq[i] <= freq[j])
                    {
                        float tempFreq = freq[i];
                        freq[i] = freq[j];
                        freq[j] = tempFreq;
                        char tempLetter = copyAlphabet[i];
                        copyAlphabet[i] = copyAlphabet[j];
                        copyAlphabet[j] = tempLetter;
                        int tempCount = count[i];
                        count[i] = count[j];
                        count[j] = tempCount;
                    }
                }
            }

            for (i = 0; i < N; i++)
            {
                for (j = 0; j < N - 1; j++)
                {
                    if (freq[j] == freq[j + 1])
                    {
                        if (copyAlphabet[j] > copyAlphabet[j + 1])
                        {
                            char tempLetter = copyAlphabet[j];
                            copyAlphabet[j] = copyAlphabet[j + 1];
                            copyAlphabet[j + 1] = tempLetter;
                        }
                    }
                }
            }

            for (i = 0; i < N; i++)
                freqTable.Rows.Add(i + 1, copyAlphabet[i], count[i], Math.Round(freq[i], 3), alphabetFreq[i]);
            dataGridView2.DataSource = freqTable;

            char[] charInput = input.ToCharArray();
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < N; j++)
                {
                    if (charInput[i] == copyAlphabet[j])
                    {
                        charInput[i] = alphabetFreq[j];
                        break;
                    }
                }
            }

            string text = new string(charInput);
            List<string> l1Char = new List<string>();
            for (int i = 1; i < text.Length - 1; i++)
            {
                if (text[i - 1] == ' ' && text[i + 1] == ' ')
                    l1Char.Add(text[i].ToString());
            }
            Console.WriteLine("Предлоги 1: " + String.Join("; ", l1Char));
            List<string> l2Char = new List<string>();
            for (int i = 1; i < text.Length - 2; i++)
            {
                if (text[i - 1] == ' ' && text[i + 2] == ' ')
                    l2Char.Add(String.Concat(text[i], text[i + 1]));
            }
            Console.WriteLine("Предлоги 2: " + String.Join("; ", l2Char));
            List<string> l3Char = new List<string>();
            for (int i = 1; i < text.Length - 3; i++)
            {
                if (text[i - 1] == ' ' && text[i + 3] == ' ')
                    l3Char.Add(String.Concat(text[i], text[i + 1], text[i + 2]));
            }
            Console.WriteLine("Предлоги 3: " + String.Join("; ", l3Char));

            for (i = 0; i < n; i++)
                result += charInput[i];
            return result;
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
                ind = matchSearch(splitText[j]);
                len = splitText[j].Length;
                for (i = 0; i < N; i++)
                {
                    freq[i] = (float)ind[i] / len;
                    freqTable.Rows.Add(j + 1, i, alphabet[i], freq[i]);
                    if (saveFreq <= freq[i])
                    {
                        saveFreq = freq[i];
                        if (Math.Round(freq[i], 3) >= 0.090)
                        {
                            key[j] = ' ';
                            int c = Array.IndexOf(alphabet, alphabet[i]);
                            key[j] = alphabet[c];
                            //break;
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