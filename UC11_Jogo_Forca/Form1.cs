using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UC11_Jogo_Forca
{
    public partial class Form1 : Form
    {
        string palavraSECRETA = string.Empty;
        string[] vetorpalavraSECRETA = new string[10];
        string letraTESTAR = "";
        int erro = 1;
        int acerto = 0;
        int tentativas = 0;
        int pontos = 0;

        public Form1()
        {
            InitializeComponent();

            panelCONFIG.Visible = false;
            labelNOMEJOGADOR.Text = string.Empty;
            labelpalavraSECRETA.Text = string.Empty;
            labelPONTOS.Text = string.Empty;

            for (int i = 0; i < 10; i++)
            {
                vetorpalavraSECRETA[i] = "_";
            }
        }

        private void buttonINICIA_Click(object sender, EventArgs e)
        {
            labelNOMEJOGADOR.Text = textBoxNOMEJOGADOR.Text;
            textBoxNOMEJOGADOR.Text = string.Empty;
            palavraSECRETA = textBoxPALAVRASECRETA.Text.ToUpper();
            textBoxPALAVRASECRETA.Text = string.Empty;
            labelPONTOS.Text = "0";
            pictureBoxFORCA.Image = Properties.Resources.vazia;
            panelCONFIG.Visible = false;
            labelpalavraSECRETA.Text = string.Empty;
            for (int i = 0; i < palavraSECRETA.Length; i++)
            {
                labelpalavraSECRETA.Text = labelpalavraSECRETA.Text + vetorpalavraSECRETA[i] + " ";
            }
        }

        private void labelCONFIG_Click(object sender, EventArgs e)
        {
            panelCONFIG.Visible = true;
        }

        private void buttonTESTAR_Click(object sender, EventArgs e)
        {
            if (textBoxLETRA.Text != string.Empty)
            {
                letraTESTAR = textBoxLETRA.Text.ToUpper();
                for (int i = 0; i < palavraSECRETA.Length; i++)
                {
                    if (letraTESTAR == palavraSECRETA.Substring(i, 1))
                    {
                        vetorpalavraSECRETA[i] = letraTESTAR;
                        erro = 0;
                    }
                    else
                    {
                        // ...
                    }
                }
                if (erro == 1)
                {
                    MessageBox.Show("Letra Incorreta!");
                    pontos = pontos - 5;
                    tentativas++;
                    if (tentativas == 1)
                    {
                        pictureBoxFORCA.Image = Properties.Resources.cabeca;
                    }
                    if (tentativas == 2)
                    {
                        pictureBoxFORCA.Image = Properties.Resources.corpo;
                    }
                    if (tentativas == 3)
                    {
                        pictureBoxFORCA.Image = Properties.Resources.braco1;
                    }
                    if (tentativas == 4)
                    {
                        pictureBoxFORCA.Image = Properties.Resources.braco2;
                    }
                    if (tentativas == 5)
                    {
                        pictureBoxFORCA.Image = Properties.Resources.perna1;
                    }
                    if (tentativas == 6)
                    {
                        pictureBoxFORCA.Image = Properties.Resources.perna2;
                    }
                }
                else
                {
                    pontos = pontos + 20;
                }
                erro = 1;
                textBoxLETRA.Text = string.Empty;
                labelpalavraSECRETA.Text = string.Empty;
                for (int i = 0; i < palavraSECRETA.Length; i++)
                {
                    labelpalavraSECRETA.Text = labelpalavraSECRETA.Text + vetorpalavraSECRETA[i] + " ";
                    if (vetorpalavraSECRETA[i] == palavraSECRETA.Substring(i, 1))
                    {
                        acerto++;
                    }
                }
                if (tentativas == 6)
                {
                    MessageBox.Show("ACABOU O JOGO!");
                }
                if (acerto == palavraSECRETA.Length)
                {
                    MessageBox.Show("VOCÊ VENCEU!");
                }
                acerto = 0;
                labelPONTOS.Text = pontos.ToString();
                textBoxLETRA.Focus();
            }
            else
            {
                MessageBox.Show("Informe UMA LETRA!");
            }
        }

        private void labelX_Click(object sender, EventArgs e)
        {
            panelCONFIG.Visible = false;
        }
    }
}
