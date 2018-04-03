using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BRUTUS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string[] pass;
        string[] pass1;
        string[] pass2;
        string[] pass3;
        private void Form1_Load(object sender, EventArgs e)
        {
            pass = File.ReadAllLines(@"C:\Users\Leonardo\Documents\10_million_password_list_top_1000000.txt");
            pass2 = File.ReadAllLines(@"C:\Users\Leonardo\Documents\10_million_password_list_top_1000000.txt");
            pass3 = File.ReadAllLines(@"C:\Users\Leonardo\Documents\10_million_password_list_top_1000000.txt");

        }

        string senha = null;

        Stopwatch stopwatch = new Stopwatch();

        private void button1_Click(object sender, EventArgs e)
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();

            label2.Text = "Status: Processando...";
            label2.ForeColor = Color.Red;
            senha = textBox2.Text;
            textBox1.Clear();
            backgroundWorker1.RunWorkerAsync(1000);
            backgroundWorker2.RunWorkerAsync(1000);
            textBox1.Focus();
        }

        int x = 0;
        private object tbPositionCursor;

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                x = 0;
                string guarda = "";
                int k = 0;
                foreach (string TENTAR in pass)
                {
                    if (k == 15)
                    {
                        log(guarda);
                        guarda = "";
                        k = 0;
                    }
                    if (TENTAR == senha)
                    {
                        log(guarda);
                        log("\r\n\r\nPassword Encontrado: " + TENTAR + "\r\nApós " + x + " Tentativas");
                        End("Status: Encontrado após " + x + " Tentativas");
                        return;
                    }
                    else
                        guarda += "False <= "+ TENTAR +"\r\n";
                    x++;
                    k++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
        }
        private void End(string x)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(End), new object[] { x });
                return;
            }
            label2.Text = x;

            label2.ForeColor = Color.Green;
            textBox1.SelectionStart = textBox1.TextLength;
            textBox1.ScrollToCaret();
        }

        private void log(string xz)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(log), new object[] { xz });
                return;
            }
            textBox1.Text += xz; textBox1.SelectionStart = textBox1.TextLength;
            textBox1.ScrollToCaret();
            label3.Text = x + "/" + pass.Length.ToString();
            if (stopwatch.IsRunning)
                label4.Text = stopwatch.Elapsed.ToString();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            textBox1.SelectionStart = textBox1.TextLength;
            textBox1.ScrollToCaret();
            stopwatch.Stop();
            label4.Text = stopwatch.Elapsed.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var target = textBox2.Text;
            var results = Array.FindAll(pass, s => s.Equals(target));
            if (results.Length > 0)
                MessageBox.Show("Encontrado no dicionario");
            else
                MessageBox.Show("Não existe no dicionario");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(stopwatch.IsRunning)
            label4.Text = stopwatch.Elapsed.ToString();
        }

        int t = 0;
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                t = 0;
                string guarda = "";
                int k = 0;
                foreach (string TENTAR in pass2)
                {
                    if (k == 15)
                    {
                        log2(guarda);
                        guarda = "";
                        k = 0;
                    }
                    if (TENTAR == senha)
                    {
                        log2(guarda);
                        log2("\r\n\r\nPassword Encontrado: " + TENTAR + "\r\nApós " + t + " Tentativas");
                        End("Status: Encontrado após " + t + " Tentativas");
                        return;
                    }
                    else
                        guarda += "False <= " + TENTAR + "\r\n";
                    t++;
                    k++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
        }

        private void End2(string x)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(End2), new object[] { x });
                return;
            }
            
            textBox3.SelectionStart = textBox3.TextLength;
            textBox3.ScrollToCaret();
        }

        private void log2(string xz)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(log2), new object[] { xz });
                return;
            }
            textBox3.Text += xz; textBox3.SelectionStart = textBox3.TextLength;
            textBox3.ScrollToCaret();
           
        }

    }
}
