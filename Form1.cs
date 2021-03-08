using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculo_IMC
{
    public partial class Calculo_De_IMC : Form
    {
        public Calculo_De_IMC()
        {
            InitializeComponent();
        }

        private void lbl_texto_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Calculadora de IMC, Saiba como está indo sua saúde de forma rápida e prática apenas informando os dados pedidos abaixo e clicando no botão Calcular!!!", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Calculo_De_IMC_Load(object sender, EventArgs e)
        {

        }

        private void txt_Peso_TextChanged(object sender, EventArgs e)
        {

            txt_Peso.MaxLength = 5;          

             
        }

        private void txt_Peso_KeyPress(object sender, KeyPressEventArgs e)
        {
            // permite apenas numeros e numeros com virugula


            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
                MessageBox.Show("Este campo aceita somente números e vírgulas!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
                MessageBox.Show("Este campo aceita somente uma virgula!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void txt_Altura_TextChanged(object sender, EventArgs e)
        {

            txt_Altura.MaxLength = 5;

          

        }

        private void txt_Altura_KeyPress(object sender, KeyPressEventArgs e)
        {

            // permite apenas numeros e numeros com virugula
           

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
                MessageBox.Show("Este campo aceita somente números e vírgulas!!", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
                MessageBox.Show("Este campo aceita somente uma virgula!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void btn_Calc_Click(object sender, EventArgs e)
        {
            if(txt_Altura.Text != "" && txt_Peso.Text != "")
            {
                double imc = Convert.ToDouble(txt_Peso.Text) / (Convert.ToDouble(txt_Altura.Text) * (Convert.ToDouble(txt_Altura.Text)));

                MessageBox.Show("O seu Cálculo de IMC é : " + imc.ToString("N2") + ", fique atento a tabela ao lado para saber ao estado da sua saúde", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                DialogResult confirmar = MessageBox.Show("Deseja Passar o seu resultado para um TXT?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmar.ToString().ToUpper() == "YES")
                {

                    StreamWriter Salvar_Dados;

                    string user = System.Windows.Forms.SystemInformation.UserName; // pega o nome do usuario

                    var desktop = @"C:\\Users\\"+ user + "\\Desktop\\IMC.txt"; ;//pega o desktop do usuário

              

                    Salvar_Dados = File.CreateText(desktop);


                    Salvar_Dados.WriteLine("Peso: " + txt_Peso.Text);
                    Salvar_Dados.WriteLine("Altura: " + txt_Altura.Text);
                    Salvar_Dados.WriteLine("IMC : " + imc.ToString("N2"));
                    Salvar_Dados.WriteLine("Considere uma mudança e habitos alimentares e uma rotina de exercícios se o seu IMC deu acima de saudável");

                    Salvar_Dados.Close();

                    MessageBox.Show("Arquivo salvo no seu Desktop com sucesso!!!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }


                
            }
            else
            {
                MessageBox.Show("Dados em branco ou escritos de forma errada, Tente Novamente!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

            


        }

        private void LinkGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/ViniciusLimaSilva");
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }
    }
}
