using ClientConvertisseurV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvertisseurV2
{
    public class ServicesDevise
    {
        public double Convertisseur(Devise undevise,double montant)
        {
            return montant * undevise.Taux;
        }
    }
}
