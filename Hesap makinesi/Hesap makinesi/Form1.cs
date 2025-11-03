using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hesap_makinesi
{
    public partial class Form1 : Form
    {
        public Form1() { InitializeComponent(); }

        double a, b, sonuc;
        char islem;

        private void SayıEkle(string s)
        {
            if (label1.Text == "0")
                label1.Text = s;
            else
                label1.Text += s;
        }

        private void button1_Click(object sender, EventArgs e) => SayıEkle("1");
        private void button8_Click(object sender, EventArgs e) => SayıEkle("2");
        private void button12_Click(object sender, EventArgs e) => SayıEkle("3");
        private void button2_Click(object sender, EventArgs e) => SayıEkle("4");
        private void button7_Click(object sender, EventArgs e) => SayıEkle("5");
        private void button11_Click(object sender, EventArgs e) => SayıEkle("6");
        private void button3_Click(object sender, EventArgs e) => SayıEkle("7");
        private void button5_Click(object sender, EventArgs e) => SayıEkle("8");
        private void button9_Click(object sender, EventArgs e) => SayıEkle("9");
        private void button6_Click(object sender, EventArgs e) => SayıEkle("0");

        private void button18_Click(object sender, EventArgs e)
        {
            string[] parts = label1.Text.Split(new char[] { '+', '-', 'x', '/' });
            string lastPart = parts[parts.Length - 1];
            if (!lastPart.Contains(","))
                label1.Text += ",";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (label1.Text.Length > 0)
                label1.Text = label1.Text.Substring(0, label1.Text.Length - 1);
            if (label1.Text == "") label1.Text = "0";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label1.Text = "0";
            a = b = sonuc = 0;
            islem = '\0';
        }

        private void IslemSec(char op)
        {
            try
            {
                // Türkçe virgül destekli
                a = double.Parse(label1.Text, new CultureInfo("tr-TR"));
                islem = op;
                label1.Text += op == '*' ? "x" : op.ToString();
            }
            catch
            {
                MessageBox.Show("Geçersiz sayı formatı!");
            }
        }

        private void button16_Click(object sender, EventArgs e) => IslemSec('+');
        private void button15_Click(object sender, EventArgs e) => IslemSec('-');
        private void button14_Click(object sender, EventArgs e) => IslemSec('/');

        private void button19_Click(object sender, EventArgs e)
        {
            try
            {
                
                string text = label1.Text.Replace('.', ',');
                double sayi = double.Parse(text, System.Globalization.CultureInfo.GetCultureInfo("tr-TR"));

                if (sayi < 0)
                {
                    MessageBox.Show("Negatif sayıların karekökü alınamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                double sonuc = Math.Sqrt(sayi);
                label1.Text = sonuc.ToString("G", System.Globalization.CultureInfo.GetCultureInfo("tr-TR"));
            }
            catch
            {
                MessageBox.Show("Geçersiz sayı formatı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            islem = '^';
            label1.Text += "^";

            string text = label1.Text;
            text = text.Substring(0, text.Length - 1);
            text = text.Replace(',', '.');
            a = double.Parse(text, System.Globalization.CultureInfo.InvariantCulture);
        }

        private void button13_Click(object sender, EventArgs e) => IslemSec('*');

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                string labelText = label1.Text;
                string[] parts = labelText.Split(new char[] { '+', '-', 'x', '/', '^' });

                if (parts.Length != 2)
                    return;

                b = double.Parse(parts[1], new CultureInfo("tr-TR"));

                switch (islem)
                {
                    case '+': sonuc = a + b; break;
                    case '-': sonuc = a - b; break;
                    case '*': sonuc = a * b; break;
                    case '/':
                        if (b == 0)
                        {
                            MessageBox.Show("SIFIRA BÖLÜNME HATASI!");
                            label1.Text = "0";
                            return;
                        }
                        sonuc = a / b;
                        break;
                    case '^': sonuc = Math.Pow(a, b); break;
                }

                label1.Text = sonuc.ToString("G", new CultureInfo("tr-TR"));
            }
            catch
            {
                MessageBox.Show("Hesaplama hatası! Sayı formatını kontrol et.");
            }
        }
    }
}















