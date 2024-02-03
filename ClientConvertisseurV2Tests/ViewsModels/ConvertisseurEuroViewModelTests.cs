using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientConvertisseurV2.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientConvertisseurV2.Models;
using System.Collections.ObjectModel;

namespace ClientConvertisseurV2.ViewsModels.Tests
{
    [TestClass()]
    public class ConvertisseurEuroViewModelTests
    {

        [TestMethod()]
        public void ConvertisseurEuroViewModelTest()
        {
            ConvertisseurEuroViewModel convertisseurEuro = new ConvertisseurEuroViewModel();
            Assert.IsNotNull(convertisseurEuro);
        }
       


        [TestMethod()]
        public void GetDataOnLoadAsyncTest_OK()
        {
            //Arrange
            ConvertisseurEuroViewModel convertisseurEuro = new ConvertisseurEuroViewModel();
            //Act
            convertisseurEuro.GetDataOnLoadAsync();
            Thread.Sleep(1000);
            Devise euro = new Devise(1, "Dollar", 1.08);
            Devise dollar = new Devise(2, "Franc Suisse", 1.07);
            Devise livreSterling = new Devise(3,"Yen", 120);

            List<Devise> devisesAttendues = new List<Devise> { euro, dollar, livreSterling };

            CollectionAssert.AreEqual(devisesAttendues, convertisseurEuro.Devises); 
            Assert.IsNotNull(convertisseurEuro.Devises);


        }

        /// <summary>
        /// Test conversion OK
        /// </summary>
        [TestMethod()]
        public void ActionSetConversionTest()
        {
            //Arrange
            //Création d'un objet de type ConvertisseurEuroViewModel 

            ConvertisseurEuroViewModel Convert =new ConvertisseurEuroViewModel();
            //Property MontantEuro = 100 (par exemple)
            Convert.Montant = 100;
            //Création d'un objet Devise, dont Taux=1.07
            Convert.Devises = new ObservableCollection<Devise> { new Devise(1, "Salut", 1.07) };
            //Property DeviseSelectionnee = objet Devise instancié
            Convert.DeviseSelectionnee=Convert.Devises[0];
            //Act
            //Appel de la méthode ActionSetConversion
            Convert.ActionSetConversion();
            //Assert
            //Assertion : MontantDevise est égal à la valeur espérée 107
            Assert.AreEqual(107, Convert.Res);
        }

    }
}