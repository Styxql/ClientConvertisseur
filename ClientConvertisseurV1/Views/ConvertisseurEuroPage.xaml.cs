using ClientConvertisseurV1.Models;
using ClientConvertisseurV1.Services;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Services.Store;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ClientConvertisseurV1.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ConvertisseurEuroPage : Page,INotifyPropertyChanged
    {
        private ServicesDevise serviceDevise;
        public ConvertisseurEuroPage()
        {
            this.InitializeComponent();
            this.DataContext = this;
            GetDataOnLoadAsync();
            serviceDevise = new ServicesDevise();
            
            
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Devise> devises;

        public ObservableCollection<Devise> Devises
        {
            get { return devises; }
            set
            {
                devises = value;
                OnPropertyChanged("Devises");
            }
        }


        private Devise deviseSelectionnee;


        public Devise DeviseSelectionnee

        {
            get { return deviseSelectionnee; }
            set
            {
                deviseSelectionnee = value;
                OnPropertyChanged("DeviseSelectionnee");
            }
        }



        private double montant;


        public double Montant

        {
            get { return montant; }
            set
            {
                montant = value;
                OnPropertyChanged("Montant");
            }
        }
        private double res;


        public double Res

        {
            get { return res; }
            set
            {
                res = value;
                OnPropertyChanged("Res");
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


        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private async void btMontantDevise_Click(object sender, RoutedEventArgs e)
        {
            if (this.DeviseSelectionnee == null)
            {
                ContentDialog noDevise = new ContentDialog
                {
                    Title = "Erreur",
                    Content = "Vous devez selectionner une devise !!!!",
                    CloseButtonText = "OK"
                };
                noDevise.XamlRoot = this.Content.XamlRoot;

                ContentDialogResult result = await noDevise.ShowAsync();
            }
            else
            {
                Res = serviceDevise.Convertisseur(this.DeviseSelectionnee, this.Montant);

            }
        }

        public async void MessageAsync(string content,string title)
        {
            ContentDialog noApi = new ContentDialog
            {
                Title = title,
                Content = content,
                CloseButtonText = "OK"

            };
            noApi.XamlRoot = this.Content.XamlRoot;

            ContentDialogResult result = await noApi.ShowAsync();

        }


    }
}
