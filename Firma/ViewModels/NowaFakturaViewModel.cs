﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.ViewModels
{
    public class NowaFakturaViewModel: WorkspaceViewModel //bo wszystkie zakładki dziedziczą po WorkspaceViewModel
    {
        #region Konstruktor
        public NowaFakturaViewModel()
        {
            base.DisplayName = "Faktura";
        }
        #endregion
    }
}
