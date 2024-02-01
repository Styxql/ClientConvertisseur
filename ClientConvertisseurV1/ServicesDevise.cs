using ClientConvertisseurV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvertisseurV1
{
    public class ServicesDevise
    {
        public double Convertisseur(Devise undevise,double montant)
        {
            return montant * undevise.Taux;
        }
    }
}
