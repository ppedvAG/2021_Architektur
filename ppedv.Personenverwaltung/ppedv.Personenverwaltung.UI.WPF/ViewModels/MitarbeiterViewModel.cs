using ppedv.Personenverwaltung.Data.EfCore;
using ppedv.Personenverwaltung.Logik;
using ppedv.Personenverwaltung.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace ppedv.Personenverwaltung.UI.WPF.ViewModels
{
    internal class MitarbeiterViewModel : INotifyPropertyChanged
    {
        Core core = new Core(new EfRepository());
        private Mitarbeiter selectedMitarbeiter;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<Mitarbeiter> Mitarbeiterliste { get; set; }

        public Mitarbeiter SelectedMitarbeiter
        {
            get => selectedMitarbeiter;
            set
            {
                selectedMitarbeiter = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedMitarbeiter)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AbteilungenAlsKommaText)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("klwejnwefkljnfk"));
            }
        }

        //public ICommand SaveCommand { get; set; } = new SaveCommand();
        public ICommand SaveCommand { get; set; }
        public ICommand NewCommand { get; set; }

        public string AbteilungenAlsKommaText
        {
            get
            {
                if (SelectedMitarbeiter == null)
                    return string.Empty;

                return string.Join(", ", SelectedMitarbeiter.Abteilungen.Select(x => x.Bezeichnung));
            }
        }

        public MitarbeiterViewModel()
        {
            Mitarbeiterliste = new ObservableCollection<Mitarbeiter>(core.Repository.GetAll<Mitarbeiter>());

            SaveCommand = new RelayCommand(x => core.Repository.Save());
            NewCommand = new RelayCommand(x => UserWantsToAddNewMitarbeiter());
        }

        private void UserWantsToAddNewMitarbeiter()
        {
            var m = new Mitarbeiter() { Name = "NEU NEU NUE" };

            core.Repository.Add(m);

            Mitarbeiterliste.Add(m);

        }
    }
}
