using Firma.Models.Entities;
using Firma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.ViewModels
{
    public class NowyRynekViewModel : JedenViewModel<Rynek>
    {
        #region Konstruktor
        public NowyRynekViewModel()
            : base("Nowy rynek")
        {
            Item = new Rynek();
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
        public string Skrot
        {
            get
            {
                return Item.Skrot;
            }
            set
            {
                if (value != Item.Skrot)
                {
                    Item.Skrot = value;
                    base.OnPropertyChanged(() => Skrot);
                }
            }
        }
        #endregion

        #region Save
        public override void Save()
        {
            Item.CzyAktywny = true;
            Db.Rynek.AddObject(Item);
            Db.SaveChanges();
        }
        #endregion
    }
}
