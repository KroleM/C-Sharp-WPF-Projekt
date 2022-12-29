using Firma.Models.Entities;
using Firma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.ViewModels
{
    public class NowaGrupaRabatowaViewModel : JedenViewModel<GrupaRabatowa>
    {
        #region Konstruktor
        public NowaGrupaRabatowaViewModel()
            : base("Grupa rabatowa")
        {
            Item = new GrupaRabatowa();
        }
        #endregion
        #region Properties
        public string Nazwa
        {
            get
            {
                return Item.Nazwa;
            }
            set
            {
                if (value != Item.Nazwa)
                {
                    Item.Nazwa = value;
                    base.OnPropertyChanged(() => Nazwa);
                }
            }
        }
        public decimal Rabat
        {
            get
            {
                return Item.Rabat;
            }
            set
            {
                if (value != Item.Rabat)
                {
                    Item.Rabat = value;
                    base.OnPropertyChanged(() => Rabat);
                }
            }
        }
        #endregion

        #region Save
        public override void Save()
        {
            Item.CzyAktywny = true;
            Db.GrupaRabatowa.AddObject(Item);
            Db.SaveChanges();
        }
        #endregion
    }
}
