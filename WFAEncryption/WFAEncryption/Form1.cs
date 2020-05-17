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
        private static int offset; // сдвиг
        private static char[] alphabet; // алфавит заданный в виде массива символов
        private static int N; // мощность алфавита
        private static int ENG = 26, RUS = 32;
        private static string method = "Vigenere";

        public MainForm()
        {
            InitializeComponent();
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

        // реализация метода, расшифровывающего строку методом Виженера
        private string Decode_Vigenere(string input, string keyword)
        {
            input = input.ToUpper();
            keyword = keyword.ToUpper();

            string result = "";
            int keyword_index = 0;

            foreach (char symbol in input)
            {
                int p = (Array.IndexOf(alphabet, symbol) + N -
                    Array.IndexOf(alphabet, keyword[keyword_index])) % N;
                result += alphabet[p];
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
            char latter;
            bool flag;

            foreach (char symbol in input)
            {
                flag = false; //обработан ли текущий символ
                if (symbol >= 'A' && symbol <= 'Z')
                {
                    latter = Convert.ToChar(symbol + (offset % ENG));
                    if (latter > 'Z') latter = Convert.ToChar('A' + (latter - 'Z') - 1);
                    result += latter;
                    flag = true;
                }
                if (symbol >= 'a' && symbol <= 'z')
                {
                    latter = Convert.ToChar(symbol + (offset % ENG));
                    if (latter > 'z') latter = Convert.ToChar('a' + (latter - 'z') - 1);
                    result += latter;
                    flag = true;
                }
                if (symbol >= 'А' && symbol <= 'Я')
                {
                    latter = Convert.ToChar(symbol + (offset % RUS));
                    if (latter > 'Я') latter = Convert.ToChar('А' + (latter - 'Я') - 1);
                    result += latter;
                    flag = true;
                }
                if (symbol >= 'а' && symbol <= 'я')
                {
                    latter = Convert.ToChar(symbol + (offset % RUS));
                    if (latter > 'я') latter = Convert.ToChar('а' + (latter - 'я') - 1);
                    result += latter;
                    flag = true;
                }
                if (!flag) result += symbol;
                
            }
            return result;
        }

        private void btnEncode_Click(object sender, EventArgs e)
        {
            switch (method)
            {
                case "Caesar":
                    {
                        string s;

                        StreamReader sr = new StreamReader(@"Text\input.txt", Encoding.GetEncoding(1251));
                        StreamWriter sw = new StreamWriter(@"Text\output.txt");

                        while (!sr.EndOfStream)
                        {
                            s = sr.ReadLine();
                            sw.WriteLine(Encode_Caesar(s));
                        }

                        sr.Close();
                        sw.Close();
                        break;
                    }
                case "Vigenere":
                    {
                        if (textKey.Text.Length > 0)
                        {
                            string s;

                            StreamReader sr = new StreamReader(@"Text\input.txt");
                            StreamWriter sw = new StreamWriter(@"Text\output.txt");

                            while (!sr.EndOfStream)
                            {
                                s = sr.ReadLine();
                                sw.WriteLine(Encode_Vigenere(s, textKey.Text));
                            }

                            sr.Close();
                            sw.Close();
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
                    {
                        string s;

                        StreamReader sr = new StreamReader(@"Text\input.txt", Encoding.GetEncoding(1251));
                        StreamWriter sw = new StreamWriter(@"Text\output.txt");

                        while (!sr.EndOfStream)
                        {
                            s = sr.ReadLine();
                            sw.WriteLine(Decode_Caesar(s));
                        }

                        sr.Close();
                        sw.Close();
                        break;
                    }
                case "Vigenere":
                    {
                        if (textKey.Text.Length > 0)
                        {
                            string s;

                            StreamReader sr = new StreamReader(@"Text\input.txt");
                            StreamWriter sw = new StreamWriter(@"Text\output.txt");

                            while (!sr.EndOfStream)
                            {
                                s = sr.ReadLine();
                                sw.WriteLine(Decode_Vigenere(s, textKey.Text));
                            }

                            sr.Close();
                            sw.Close();
                        }
                        else MessageBox.Show("Введите ключевое слово!");
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
                    method = "Vigenere";
                }
                if (radioButton.Text == "шифр Цезаря")
                {
                    tBCounter.Visible = true; numLatters.Visible = true;
                    textKey.Visible = false; keyword.Visible = false;
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
                    alphabet = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
                                            'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
                                            'U', 'V', 'W', 'X', 'Y', 'Z', ' ', '1', '2', '3',
                                            '4', '5', '6', '7', '8', '9', '0' };
                    N = alphabet.Length;
                }
                if (radioButton.Text == "русский")
                {
                    tBCounter.Maximum = RUS;
                    alphabet = new char[] { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И',
                                            'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т',
                                            'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь', 'Ы', 'Ъ',
                                            'Э', 'Ю', 'Я', ' ', '1', '2', '3', '4', '5', '6',
                                            '7', '8', '9', '0' };
                    N = alphabet.Length;
                }
            }
        }

        // реализация метода, расшифрующего строку методом Цезаря
        private string Decode_Caesar(string input)
        {
            string result = "";
            char latter;
            bool flag;

            foreach (char symbol in input)
            {
                flag = false; //обработан ли текущий символ
                if (symbol >= 'A' && symbol <= 'Z')
                {
                    latter = Convert.ToChar(symbol - (offset % ENG));
                    if (latter < 'A') latter = Convert.ToChar('A' - (latter - 'Z') - 1);
                    result += latter;
                    flag = true;
                }
                if (symbol >= 'a' && symbol <= 'z')
                {
                    latter = Convert.ToChar(symbol - (offset % ENG));
                    if (latter < 'a') latter = Convert.ToChar('a' - (latter - 'z') - 1);
                    result += latter;
                    flag = true;
                }
                if (symbol >= 'А' && symbol <= 'Я')
                {
                    latter = Convert.ToChar(symbol - (offset % RUS));
                    if (latter < 'А') latter = Convert.ToChar('А' - (latter - 'Я') - 1);
                    result += latter;
                    flag = true;
                }
                if (symbol >= 'а' && symbol <= 'я')
                {
                    latter = Convert.ToChar(symbol - (offset % RUS));
                    if (latter < 'а') latter = Convert.ToChar('а' - (latter - 'я') - 1);
                    result += latter;
                    flag = true;
                }
                if (!flag) result += symbol;

            }
            return result;
        }
    }
}
