using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace INotifySuma.ViewModel
{
    public class MainPageViewModel
    {
        

        public int Numero1 { get; set; }
        public int Numero2 { get; set; }
        public int Numero3 { get; set; }
        public int Numero4 { get; set; }
        public int Numero5 { get; set; }
        public int Numero6 { get; set; }
        public int Numero7 { get; set; }
        public int Numero8 { get; set; }
        public int Numero9 { get; set; }
        public int Numero10 { get; set; }
        
        private int resultado;
        public int Resultado { get => resultado; set { resultado = value; OnPropertyChanged(); } }

        public MainPageViewModel()
        {
            Numero1 = 1;
            Numero2 = 2;
            Numero3 = 3;
            Numero4 = 4;
            Numero5 = 5;
            Numero6 = 6;
            Numero7 = 7;
            Numero8 = 8;
            Numero9 = 9;
            Numero10 = 10;

            SumCommand = new Command(async () =>
            Resultado = Numero1 + Numero2 + Numero3 + Numero4 + Numero5 + Numero6 + Numero7 + Numero8 + Numero9 + Numero10
            );
        }

        public ICommand SumCommand { get; set; }



    }
}
