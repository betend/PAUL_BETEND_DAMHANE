using PAUL_DAMHANE_BETEND;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAUL_BETEND_DAMHANE
{
    public class GestionPAUL
    {
        private ObservableCollection<Produit> lesProduits;
        private ObservableCollection<Recette> lesRecettes;
        private ObservableCollection<Commande> lesCommandes;
        private ObservableCollection<Client> lesClients;
        private ObservableCollection<CategorieEvenement> lesCategorieEvenement;
        private ObservableCollection<LigneCommande> lesLignesCommande;


        private string nom;

        //public GestionPAUL()
        //{
        //    LesProduits = new ObservableCollection<Produit>(new Produit().FindAll());
        //    LesRecettes = new ObservableCollection<Recette>(new Recette().FindAll());
        //    LesCommandes = new ObservableCollection<Commande>(new Commande().FindAll());
        //    LesClients = new ObservableCollection<Client>(new Client().FindAll());
        //    foreach (Produit p in LesProduits)
        //    {
        //        p.UneRecette = LesRecettes.SingleOrDefault(r => r.Recette_id == p.Recette_id);
        //    }

        //    foreach (Commande co in LesCommandes)
        //    {
        //        co.UnClient = LesClients.SingleOrDefault(client => client.Client_id == co.Client_id);
        //    }

        //}
        public GestionPAUL(string nom)
        {

            this.Nom = nom;
            LesProduits = new ObservableCollection<Produit>(new Produit().FindAll());
            LesRecettes = new ObservableCollection<Recette>(new Recette().FindAll());
            LesCommandes = new ObservableCollection<Commande>(new Commande().FindAll());
            LesClients = new ObservableCollection<Client>(new Client().FindAll());
            LesCategorieEvenement = new ObservableCollection<CategorieEvenement>(new CategorieEvenement().FindAll());

            foreach (Produit p in LesProduits)
            {
                p.UneRecette = LesRecettes.SingleOrDefault(r => r.Recette_id == p.Recette_id);

            }

            foreach (Commande co in LesCommandes)
            {
                co.UnClient = LesClients.SingleOrDefault(client => client.Client_id == co.Client_id);
                co.UneCategorie_evenement = LesCategorieEvenement.SingleOrDefault(categorieEvenement => categorieEvenement.Categorie_evenement_id == co.Categorie_evenement_id);

            }


        }

        public ObservableCollection<Produit> LesProduits
        {
            get
            {
                return this.lesProduits;
            }

            set
            {
                this.lesProduits = value;
            }
        }

        public String Nom
        {
            get
            {
                return this.nom;
            }

            set
            {
                this.nom = value;
            }
        }

        public ObservableCollection<Recette> LesRecettes
        {
            get
            {
                return this.lesRecettes;
            }

            set
            {
                this.lesRecettes = value;
            }
        }

        public ObservableCollection<Commande> LesCommandes
        {
            get
            {
                return this.lesCommandes;
            }

            set
            {
                this.lesCommandes = value;
            }
        }

        public ObservableCollection<Client> LesClients
        {
            get
            {
                return this.lesClients;
            }

            set
            {
                this.lesClients = value;
            }
        }

        public ObservableCollection<CategorieEvenement> LesCategorieEvenement
        {
            get
            {
                return this.lesCategorieEvenement;
            }

            set
            {
                this.lesCategorieEvenement = value;
            }
        }


        public ObservableCollection<LigneCommande> LesLignesCommande
        {
            get
            {
                return this.lesLignesCommande;
            }

            set
            {
                this.lesLignesCommande = value;
            }
        }
    }
}
