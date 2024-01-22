using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MiCalculadora_MCLG
{
    public partial class MainPage : ContentPage
    {
        private string operacion = string.Empty;
        private double numeroUno, numeroDos;
        private string numeroActual = string.Empty;
        

        
        public MainPage()
        {
            InitializeComponent();
        }

        private void Btn_NoSirve(object sender, EventArgs e)
        {
            resultadoPantalla.Text = "Este boton no sirve \n（；´д｀）ゞ \n ಥ_ಥ";
            numeroActual = "0";
            operacion = "0";
            numeroUno = 0;
            numeroDos = 0;
        }
        private void Btn_EliminarNumero(object sender, EventArgs e)
        {
            numeroActual = "0";
            resultadoPantalla.Text = "0";
            numeroActual = string.Empty;
        }

        private void Btn_Limpiar(object sender, EventArgs e)
        {
            numeroActual = string.Empty;
            operacion = string.Empty;
            resultadoPantalla.Text = "0";
        }
        private void Btn_Operacion(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operacion = button.Text;

            // Asigna el valor de resultado a numeroUno
            if (!string.IsNullOrEmpty(resultadoPantalla.Text))
            {
                numeroUno = Convert.ToDouble(resultadoPantalla.Text);
            }

            numeroActual = string.Empty;
        }


        private void Btn_Numero(object sender, EventArgs e)
        { 
                Button button = (Button)sender;
                numeroActual += button.Text;
                resultadoPantalla.Text = numeroActual;
           
       
        }
        private void Btn_Punto(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string buttonPunto= button.Text;
            if(buttonPunto == ".")
            { 
                if (!numeroActual.Contains("."))
                {
                    numeroActual += buttonPunto;
                }

            }
            else
            {
                numeroActual += buttonPunto;
            }
            resultadoPantalla.Text = numeroActual;
        }  
        private void Btn_Calcular(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(operacion) && !string.IsNullOrEmpty(numeroActual))
            {
             
                numeroDos = Convert.ToDouble(numeroActual);
                double resultado = 0;
                
                    switch (operacion)
                    {
                        case "+":
                            resultado = numeroUno + numeroDos;
                            break;
                        case "-":
                            resultado = numeroUno - numeroDos;
                            break;
                        case "×":
                            resultado = numeroUno * numeroDos;
                            break;
                        case "÷":
                            resultado = numeroUno / numeroDos;
                            break;
                    }

                
                
                resultadoPantalla.Text = Convert.ToString(resultado);

                numeroUno = resultado;

                // Limpia numeroActual para la siguiente entrada
                numeroActual = string.Empty;
            }
            else
            {
                resultadoPantalla.Text = "Error (no hay numeros)";
            }

            
        }
    }

}
