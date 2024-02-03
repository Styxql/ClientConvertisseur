using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientConvertisseurV2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientConvertisseurV2.Models;

namespace ClientConvertisseurV2.Services.Tests
{
    [TestClass()]
    public class WSServiceTests
    {
        [TestMethod()]
        public void WSServiceTest()
        {
            WSService ws = new WSService("http://localhost:7211/");
            Assert.IsNotNull(ws);
        }

        [TestMethod()]
        public void GetDevisesAsync()
        {
            WSService ws = new WSService("http://localhost:7211/");
            var result = ws.GetDevisesAsync("devises").Result;
            Thread.Sleep(1000);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(List<Devise>));

            Devise euro = new Devise(1, "Dollar", 1.08);
            Devise dollar = new Devise(2, "Franc Suisse", 1.07);
            Devise livreSterling = new Devise(3, "Yen", 120);

            List<Devise> devisesAttendues = new List<Devise> { euro, dollar, livreSterling };

            CollectionAssert.AreEqual(devisesAttendues,result);
        }
    }
}