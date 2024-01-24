using MiCalculadora_MCLG.VistaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MiCalculadora_MCLG.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class calculadora : ContentPage
    {
        public calculadora()
        {
            InitializeComponent();
            BindingContext = new VMcalculadora(Navigation);
        }
    }
}