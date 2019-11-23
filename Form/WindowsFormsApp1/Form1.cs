using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        static byte[] bytes = ASCIIEncoding.ASCII.GetBytes("ZeroCool");

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Close_MouseEnter(object sender, EventArgs e)
        {
            Close.ForeColor = Color.Green;
        }

        private void Close_MouseLeave(object sender, EventArgs e)
        {
            Close.ForeColor = Color.Black;
        }
        Point LastPoint;
        private void Close_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                this.Left += e.X - LastPoint.X;
                this.Left += e.Y - LastPoint.Y;
            }
        }

        private void Close_MouseDown(object sender, MouseEventArgs e)
        {
            LastPoint = new Point(e.X, e.Y);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            LastPoint = new Point(e.X, e.Y);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - LastPoint.X;
                this.Top += e.Y - LastPoint.Y;
            }
        }

        private void input_TextChanged(object sender, EventArgs e)
        {
            
          
        }

        private void encrypted_output_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void encrypt_button_Click(object sender, EventArgs e)
        {
            string ourText = input.Text; // Переменная для нашей строки
            string textFromForm = encrypted_output.Text; // Переменная для вывода зашифрованной строки
            if (String.IsNullOrEmpty(ourText)) // Проверяем пустая ли строка или нет
            {
                throw new ArgumentNullException
                       ("The string which needs to be encrypted can not be null.");
            }
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider(); // Cоздаем объект класса  DESCryptoServiceProvider для DES шифрования
            MemoryStream memoryStream = new MemoryStream(); // Создаем объект класса  MemoryStream для хранения данных в памяти
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                cryptoProvider.CreateEncryptor(bytes, bytes), CryptoStreamMode.Write); // связываем потоки с криптографическими преобразованиями
            StreamWriter writer = new StreamWriter(cryptoStream); // Создаем объект класса StreamWriter, запись данных в символьный поток 
            writer.Write(ourText); // пишем наш текст 
            writer.Flush(); // очищаем буфер для нашей записи, запись данных в основной поток 
            cryptoStream.FlushFinalBlock();
            writer.Flush();
            encrypted_output.Text =  Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length).ToString(); // выводим зашифрованную строку 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(encrypted_output.Text)) // Проверяем путсая ли строка или нет
            {
                throw new ArgumentNullException
                   ("The string which needs to be decrypted can not be null.");
            }
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider(); // объект для шифрования 
            MemoryStream memoryStream = new MemoryStream
                    (Convert.FromBase64String(encrypted_output.Text));
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                cryptoProvider.CreateDecryptor(bytes, bytes), CryptoStreamMode.Read);
            StreamReader reader = new StreamReader(cryptoStream); // чтение данных из потока
            Decrypted_output.Text = reader.ReadToEnd(); // расшифрованная строка 
        }

        private void Decrypted_output_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
