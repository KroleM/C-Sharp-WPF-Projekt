using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Firma.ViewModels
{
    internal class OperacjeMagazynoweViewModel : WorkspaceViewModel //wszystkie zakładki dziedziczą po WorkspaceViewModel
    {
		#region Konstruktor
		public OperacjeMagazynoweViewModel()
        {
            base.DisplayName = "Operacje magazynowe";
        }
        #endregion
    }
}
