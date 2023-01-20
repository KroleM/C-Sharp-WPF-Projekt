using CommunityToolkit.Mvvm.Messaging;
using Firma.Helpers;
using Firma.Models.Entities;
using Firma.Models.Validators;
using Firma.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Firma.ViewModels
{
    public class NowaPozycjaZamowieniaViewModel : JedenViewModel<PozycjaZamowienia>, IDataErrorInfo
    {
        #region Pola i Właściwości
        private string _DaneTowaru;
        public string DaneTowaru
        {
            get
            {
                return _DaneTowaru;
            }
            set
            {
                if (value != _DaneTowaru)
                {
                    _DaneTowaru = value;
                    base.OnPropertyChanged(() => DaneTowaru);
                }
            }
        }
        public int ZamowienieId
        {
            get => Item.ZamowienieId;
            set
            {
                if (value != Item.ZamowienieId)
                {
                    Item.ZamowienieId = value;
                    base.OnPropertyChanged(() => ZamowienieId);
                }
            }
        }
        public int TowarId
        {
            get => Item.TowarId;
            set
            {
                if (value != Item.TowarId)
                {
                    Item.TowarId = value;
                    base.OnPropertyChanged(() => TowarId);
                }
            }
        }
        public int Sztuki
        {
            get => Item.Sztuki;
            set
            {
                if (value != Item.Sztuki)
                {
                    Item.Sztuki = value;
                    base.OnPropertyChanged(() => Sztuki);
                }
            }
        }
        #endregion
        #region Konstruktor
        public NowaPozycjaZamowieniaViewModel() : base("Pozycja zamówienia") 
        { 
            Item = new PozycjaZamowienia()
            {
                CzyAktywny = true
            };
            WeakReferenceMessenger.Default.Register<Towar>(this, (r, m) => przypiszTowar(m));
            WeakReferenceMessenger.Default.Register<MessengerNumberMessage<int>>(this, (r, m) => przypiszTowar(m));
        }
        #endregion
        #region Komendy
        private ICommand _WybierzTowarCommand;
        public ICommand WybierzTowarCommand
        {
            get
            {
                if (_WybierzTowarCommand == null)
                {
                    _WybierzTowarCommand = new BaseCommand(() => wybierzTowar());
                }
                return _WybierzTowarCommand;
            }
        }
        #endregion
        #region Metody
        private void przypiszTowar(Towar towar)
        {
            DaneTowaru = towar.Nazwa;

            Item.TowarId = towar.Id;
        }
        private void przypiszTowar(MessengerNumberMessage<int> towarId)
        {
            Item.TowarId = towarId.Number;
            DaneTowaru = Db.Towar.First(arg => arg.Id == towarId.Number).Nazwa;
        }
        private void wybierzTowar()
        {
            WeakReferenceMessenger.Default.Send("Towary Show");
        }
        public override void Save()
        {
            Item.DataUtworzenia = DateTime.Now;
            Item.DataModyfikacji = DateTime.Now;

            WeakReferenceMessenger.Default.Send(Item);
        }
        public string Error => string.Empty;
        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(Sztuki):
                        return DecimalValidator.CzyWiekszeOdZera(Sztuki);
                    case nameof(DaneTowaru):
                        return StringValidator.CannotBeNull(DaneTowaru);
                    default:
                        return string.Empty;
                }
            }
        }
        protected override bool IsValid()
        {
            return this[nameof(Sztuki)] == string.Empty
                && this[nameof(DaneTowaru)] == string.Empty;
        }
        #endregion
    }
}
