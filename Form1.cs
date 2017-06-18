/*
 * This program is created to calculate every thing what is related to matrix 3x3
 * (determinant of matrix, inverse matrix,transponing)
 * Created by: Cezary Łysoń wwww.Lomaz.pl
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Globalization;


namespace macierzekalk
{
    public partial class Kalkulator_Macierzy : Form
    {
        float wyznacznik = 0;
        float d11, d12, d13, d21, d22, d23, d31, d32, d33, //it`s loading values from user matrix   
            w11, w12, w13, w21, w22, w23, w31, w32, w33, //it`s for calculate determinant 
            o11, o12, o13, o21, o22, o23, o31, o32, o33, //this for calculate inverse matrix 
            t11, t12, t13, t21, t22, t23, t31, t32, t33; //and this for transpon matrix
        string s11, s12, s13, s21, s22, s23, s31, s32, s33;

        private void W11_TextChanged(object sender, EventArgs e)
        {

        }
        
        public Kalkulator_Macierzy()
        {
            InitializeComponent();
        }

        private void D11M1(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        #region przyciski //this is button

        private void Obliczwyznacznik_btt_Click(object sender, EventArgs e)
        {
            obliczanie_wyznaczniku(); //determinant
        }

        private void modwrotna_btt_Click(object sender, EventArgs e)
        {
            obliczanie_modwrotna(); //inverse
        }

        private void mtransponowana_btt_Click(object sender, EventArgs e)
        {
            transponowanie(); //transpon
        }

        #endregion

        #region wynikowe okna 
        //boxes with resoult
        private void wyznacznikwynik_TextChanged()
        {
            wyznacznikwynik.Text = Convert.ToString(Math.Round(wyznacznik,2));
        }

        private void wyznacznikwynik_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            //textbox wynik:
        }
        #region macierz wynikowa

        private void W11_TextChanged()
        {

        }

        private void W12_TextChanged()
        {

        }

        private void W13_TextChanged()
        {

        }

        private void W21_TextChanged()
        {

        }

        private void W22_TextChanged()
        {

        }

        private void W23_TextChanged()
        {

        }

        private void W31_TextChanged()
        {

        }

        private void W32_TextChanged()
        {

        }

        private void W33_TextChanged()
        {

        }
        #endregion

        #endregion

        #region obliczenia 
        //calculating

        private void obliczanie_modwrotna()//this is creating inverse matrix
        {
            obliczanie_wyznaczniku();
            if(wyznacznik != 0)
            {
                o11 = (d22 * d33 - d32 * d23); o12 = (-(d12 * d33 - d31 * d23)); o13 = (d21 * d32 - d31 * d22);
                o21 = (-(d12 * d33 - d32 * d13)); o22 = (d11 * d33 - d31 * d13); o23 = (-(d11 * d32 - d31 * d12));
                o31 = (d12 * d23 - d22 * d13); o32 = (-(d11 * d23 - d21 * d13)); o33 = (d11 * d22 - d21 * d12);

                t11 = o11 / wyznacznik; t12 = o21 / wyznacznik; t13 = o31 / wyznacznik;
                t21 = o12 / wyznacznik; t22 = o22 / wyznacznik; t23 = o32 / wyznacznik;
                t31 = o13 / wyznacznik; t32 = o23 / wyznacznik; t33 = o33 / wyznacznik;
                
                W11.Text = Convert.ToString(Math.Round(t11, 3)); W12.Text = Convert.ToString(Math.Round(t12, 3)); W13.Text = Convert.ToString(Math.Round(t13, 3));
                W21.Text = Convert.ToString(Math.Round(t21, 3)); W22.Text = Convert.ToString(Math.Round(t22, 3)); W23.Text = Convert.ToString(Math.Round(t23, 3));
                W31.Text = Convert.ToString(Math.Round(t31, 3)); W32.Text = Convert.ToString(Math.Round(t32, 3)); W33.Text = Convert.ToString(Math.Round(t33, 3));
                           
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Wyznacznik musi być różny od zera."); 
            }
        }


        private void obliczanie_wyznaczniku() //calc. determinant
        {
            kon();
            wyznacznik = (d11 * d22 * d33) + (d12 * d23 * d31) + (d13 * d21 * d32) - (d31 * d22 * d13) - (d32 * d23 * d11) - (d33 * d21 * d12);
            wyznacznikwynik_TextChanged();
        }

        private void transponowanie()
        { 
            w11 = d11; w12 = d21; w13 = d31;
            w21 = d12; w22 = d22; w23 = d32;    
            w31 = d13; w32 = d23; w33 = d33;
            //  W11_TextChanged();W12_TextChanged();W13_TextChanged();W21_TextChanged();W22_TextChanged();W23_TextChanged();W31_TextChanged();W32_TextChanged();W33_TextChanged();
            W11.Text = Convert.ToString(w11); W21.Text = Convert.ToString(w21); W31.Text = Convert.ToString(w31);
            W12.Text = Convert.ToString(w12); W22.Text = Convert.ToString(w22); W32.Text = Convert.ToString(w32);
            W13.Text = Convert.ToString(w13); W23.Text = Convert.ToString(w23); W33.Text = Convert.ToString(w33);
        }

        private void kon() //it`s checking introduced values by user; is it some null boxes
        {
            if (string.IsNullOrWhiteSpace(s11) || string.IsNullOrWhiteSpace(s12) || string.IsNullOrWhiteSpace(s13)
             || string.IsNullOrWhiteSpace(s21) || string.IsNullOrWhiteSpace(s22) || string.IsNullOrWhiteSpace(s23)
             || string.IsNullOrWhiteSpace(s31) || string.IsNullOrWhiteSpace(s32) || string.IsNullOrWhiteSpace(s33))
            {
                System.Windows.Forms.MessageBox.Show("Uzupełnij wszystkie pola macierzy!");
            }
            else
            {             
                d11 = float.Parse(s11);
                d12 = float.Parse(s12);
                d13 = float.Parse(s13);
                d21 = float.Parse(s21);
                d22 = float.Parse(s22);
                d23 = float.Parse(s23);
                d31 = float.Parse(s31);
                d32 = float.Parse(s32);
                d33 = float.Parse(s33);
                //            System.Windows.Forms.MessageBox.Show("kon done");                
            }
        }
        #endregion

        #region macierz 1 

        #region keypressy
        //it`s checking introduced values by user; is it number etc
        private void D11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsNumber(e.KeyChar) || e.KeyChar=='.' || e.KeyChar == '-')
            {
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void D12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == '-')
            {
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void D13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == '-')
            {
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void D21_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == '-')
            {
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void D22_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == '-')
            {
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void D23_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == '-')
            {
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void D31_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == '-')
            {
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void D32_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == '-')
            {
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void D33_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == '-')
            {
            }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        #endregion
        public void D11_TextChanged(object sender, EventArgs e)
        {
            TextBox objTextBox11 = (TextBox)sender;
            s11 = objTextBox11.Text;
     //     d11 = float.Parse(s11);
        }

        private void D12_TextChanged(object sender, EventArgs e)
        {
            TextBox objTextBox12 = (TextBox)sender;
            s12 = objTextBox12.Text;
       //     d12 = float.Parse(s12);
        }

        private void D13_TextChanged(object sender, EventArgs e)
        {
            TextBox objTextBox13 = (TextBox)sender;
            s13 = objTextBox13.Text;
       //     d13 = float.Parse(s13);
        }

        private void D21_TextChanged(object sender, EventArgs e)
        {
            TextBox objTextBox21 = (TextBox)sender;
            s21 = objTextBox21.Text;
         //   d21 = float.Parse(s21);
        }

        private void D22_TextChanged(object sender, EventArgs e)
        {
            TextBox objTextBox22 = (TextBox)sender;
            s22 = objTextBox22.Text;
       //     d22 = float.Parse(s22);
        }

        private void D23_TextChanged(object sender, EventArgs e)
        {
            TextBox objTextBox23 = (TextBox)sender;
            s23 = objTextBox23.Text;
      //      d23 = float.Parse(s23);
        }

        private void D31_TextChanged(object sender, EventArgs e)
        {
            TextBox objTextBox31 = (TextBox)sender;
            s31 = objTextBox31.Text;
       //     d31 = float.Parse(s31);
        }

        private void D32_TextChanged(object sender, EventArgs e)
        {
            TextBox objTextBox32 = (TextBox)sender;
            s32 = objTextBox32.Text;
        //    d32 = float.Parse(s32);
        }

        private void D33_TextChanged(object sender, EventArgs e)
        {
            TextBox objTextBox33 = (TextBox)sender;
            s33 = objTextBox33.Text;
        //    d33 = float.Parse(s33);
        }
        #endregion

    }
}
