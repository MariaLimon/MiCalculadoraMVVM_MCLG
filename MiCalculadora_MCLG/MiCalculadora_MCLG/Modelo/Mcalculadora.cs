using System;
using System.Collections.Generic;
using System.Text;

namespace MiCalculadora_MCLG.Modelo
{
    public class Mcalculadora
    {
		public double RealizarOperacion(double numero1, double numero2, string operador)
		{
			switch (operador)
			{
				case "+":
					return numero1 + numero2;
				case "-":
					return numero1 - numero2;
				case "*":
					return numero1 * numero2;
				case "/":
					if (numero2 != 0)
						return numero1 / numero2;
					else
						throw new ArgumentException("No se puede dividir por cero");
				default:
					throw new ArgumentException("Operador no válido");
			}
		}
	}
}
