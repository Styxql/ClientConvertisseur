using System.ComponentModel.DataAnnotations;

namespace WPSConvertisseur.Models
{
    public class Devise
    {
        public Devise(int id, string nomDevise, double taux)
        {
            this.Id = id;
            this.NomDevise = nomDevise;
            this.Taux = taux;
        }
        public Devise()
        {
            
        }

        public int Id { get; set; }
        private string? nomDevise;
        [Required]
        public string? NomDevise
        {
            get { return nomDevise; }
            set { nomDevise = value; }
        }
        public double Taux { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Devise devise &&
                   this.Id == devise.Id &&
                   this.nomDevise == devise.nomDevise &&
                   this.NomDevise == devise.NomDevise &&
                   this.Taux == devise.Taux;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Id, this.nomDevise, this.NomDevise, this.Taux);
        }
    }
}
