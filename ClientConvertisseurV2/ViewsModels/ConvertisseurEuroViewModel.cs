using ClientConvertisseurV2.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientConvertisseurV2.Models;
using Microsoft.UI.Xaml.Controls;
using System.Runtime.CompilerServices;
using Microsoft.UI.Xaml;
using CommunityToolkit.Mvvm.Input;

namespace ClientConvertisseurV2.ViewsModels
{
    public class ConvertisseurEuroViewModel:ObservableObject
    {
        public IRelayCommand BtnSetConversion { get; }

        public ConvertisseurEuroViewModel()
        {
            this.GetDataOnLoadAsync();
            BtnSetConversion = new RelayCommand(ActionSetConversion);
        }



        private ObservableCollection<Devise> devises;

        public ObservableCollection<Devise> Devises
        {
            get { return devises; }
            set
            {
                devises = value;
                OnPropertyChanged();
            }
        }


        private Devise deviseSelectionnee;


        public Devise DeviseSelectionnee

        {
            get { return deviseSelectionnee; }
            set
            {
                deviseSelectionnee = value;
                OnPropertyChanged();
            }
        }



        private double montant;


        public double Montant

        {
            get { return montant; }
            set
            {
                montant = value;
                OnPropertyChanged();
            }
        }
        private double res;


        public double Res

        {
            get { return res; }
            set
            {
                res = value;
                OnPropertyChanged();
            }
        }



        private async void GetDataOnLoadAsync()
        {
            WSService service = new WSService("http://localhost:7211/");
            List<Devise> result = await service.GetDevisesAsync("devises");
            if (result == null)
            {
                MessageAsync("API non disponible", "Erreur");
            }
            else
            {
                Devises = new ObservableCollection<Devise>(result);
            }


        }


        public async void MessageAsync(string content, string title)
        {
            ContentDialog noApi = new ContentDialog
            {
                Title = title,
                Content = content,
                CloseButtonText = "OK"

            };
            noApi.XamlRoot = App.MainRoot.XamlRoot;

            ContentDialogResult result = await noApi.ShowAsync();

        }
        private async void ActionSetConversion()
        {
            if (this.DeviseSelectionnee == null)
            {
                ContentDialog noDevise = new ContentDialog
                {
                    Title = "Erreur",
                    Content = "Vous devez selectionner une devise !!!!",
                    CloseButtonText = "OK"
                };
                noDevise.XamlRoot = App.MainRoot.XamlRoot;

                ContentDialogResult result = await noDevise.ShowAsync();
            }
            else
            {
                Res = this.DeviseSelectionnee.Taux*this.Montant;

            }
        }







    }
}
