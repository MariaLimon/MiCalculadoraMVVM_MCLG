using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVM_Implementacion_MCLG;
using MvvmGuia.VistaModelo;
using Xamarin.Forms;
using MiCalculadora_MCLG.Modelo;

namespace MiCalculadora_MCLG.VistaModelo
{
    public class VMcalculadora : BaseViewModel
    {
        #region VARIABLES
        string _pantallaResultado;
        double _numero1;
        double _numero2;
        string _operador;
		string _punto;
		bool _multiActivado;
        Mcalculadora _Mcalculadora;
        #endregion
        #region CONSTRUCTOR
        public VMcalculadora(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion
        #region OBJETOS
        public string pantallaResultado
        {
            get { return _pantallaResultado; }
            set { SetValue(ref _pantallaResultado, value); }
        }
        public double numero1
        {
            get { return _numero1; }
            set { SetValue(ref _numero1, value); }
        }
        public double  numero2
		{
			get { return _numero2; }
			set { SetValue(ref _numero2, value); }
		}
		public string operador
		{
			get { return _operador; }
			set { SetValue(ref _operador, value); }
		}
		public string punto
		{
			get { return _punto; }
			set { SetValue(ref _punto, value); }
		}
		public bool multiActivado
		{
			get { return _multiActivado; }
			set { SetValue(ref _multiActivado, value); }
		}
		#endregion
		#region PROCESOS
		
		public async Task ProcesoAsyncrono()
        {
            await DisplayAlert("Titulo", "Mensaje", "Ok");
        }
        public void ProcesoSimple()
        {

        }

	
		private void AgregarNumero(string numero)
		{
			pantallaResultado += numero;
		}
		
		private void AgregarOperador(string operador)
		{
			_numero1 = double.Parse(pantallaResultado);
			_operador = operador;
			pantallaResultado = "";
		}

		private void Btn_Operacion(object sender, EventArgs e)
		{
			
			// Asigna el valor de resultado a numero1
			if (!string.IsNullOrEmpty(pantallaResultado))
			{
				numero1 = Convert.ToDouble(pantallaResultado);
			}

			pantallaResultado = string.Empty;
		}
		private void RealizarCalculo()
		{
			double resultado = 0;
			numero2 = double.Parse(pantallaResultado);
			switch (operador)
			{
				case "+":
					resultado =numero1 + numero2;
					break;
				case "-":
					resultado = numero1 - numero2;
					break;
				case "*":
					resultado= numero1 * numero2;
					break;
				case "/":
					if (numero2 != 0)
						resultado = numero1 / numero2;
					else
						pantallaResultado = ("No se puede dividir por cero");
					break;
				
			}
			pantallaResultado = resultado.ToString();
		}
		private void Btn_Limpiar()
		{
			pantallaResultado = string.Empty;
			pantallaResultado = "";
		}

		private void Btn_Punto(string puntoe)
		{
			if (puntoe == ".")
			{
				if (!pantallaResultado.Contains("."))
				{
					pantallaResultado += puntoe;
				}

			}
			else
			{
				pantallaResultado += puntoe;
			}
			_ = pantallaResultado;
		}
		public bool MultiOperador(bool multi)
		{
			multi = multiActivado = !multiActivado;
			return multiActivado;
		}
		#endregion
		#region COMANDOS
		public ICommand ProcesoAsyncommand => new Command(async () => await ProcesoAsyncrono());
        public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
		public ICommand NumeroSimpcommand => new Command<string>((p) => AgregarNumero(p));
		public ICommand OperadorSimpcommand => new Command<string>((p) => AgregarOperador(p));
		public ICommand EliminarSimpcommand => new Command(Btn_Limpiar);
		public ICommand IgualSimpcommand => new Command(RealizarCalculo);
		public ICommand MultiSimpcommand => new Command<bool>((p) => MultiOperador(p));

		public ICommand PuntoSimpcommand => new Command<string>((p) => Btn_Punto(p));




		#endregion
	}
}
