using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using tuto1.model;

namespace tuto1.ViewModel
{
    class ClientViewModel : INotifyPropertyChanged
    {
        Model1 db = new Model1();
        private produits _Model;
        private List<produits> lesProduits;
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
            //MessageBox.Show(db.produits.ToString());
        }
        public ClientViewModel()
        {
            GetlesProduits();
        }
        public produits getLeProduit(int i)
        {
            var cli = from cat in db.produits
                      where cat.id == i
                      select cat;
            this._Model = cli.ToList()[0];
            return this._Model;
        }
        public produits getLeProduit()
        {
            return this._Model;
        }
        public void setLeProduit(produits leprod)
        {
            this._Model = leprod;
            OnPropertyChanged();
        }
        public List<produits> GetlesProduits()
        {
            var cli = from cat in db.produits
                      select cat;
            this.lesProduits = cli.ToList();
            return this.lesProduits;
        }
        public void SetlesProduits(List<produits> lesProds)
        {
            lesProduits = lesProds;
            OnPropertyChanged();
        }
        public void Update(produits leProduit)
        {
            MessageBox.Show(leProduit.id + " " + leProduit.nom);
            for (int i = 0; i < db.produits.ToList().Count; i++)
            {
                if (db.produits.ToList()[i].id == leProduit.id)
                {
                    db.produits.ToList()[i] = leProduit;
                }
            }
            SetlesProduits(GetlesProduits());
            db.SaveChanges();
        }
        public bool Delete(produits leProduit)
        {
            bool test = false;
            int nbre = db.produits.ToList().Count;
            foreach (produits a in db.produits.ToList())
            {
                if (a.id == leProduit.id)
                {
                    db.produits.Remove(leProduit);
                    GetlesProduits().Remove(leProduit);
                    break;
                }
            }
            db.SaveChanges();
            SetlesProduits(GetlesProduits());
            if (db.produits.ToList().Count < nbre)
            {
                MessageBox.Show($"Le produit {leProduit.nom} a bien été effacé!");
                test = true;
            }
            return test;
        }
        public bool Insert(produits leProduit)
        {
            bool test = false;
            int nbre = db.produits.ToList().Count;
            //MessageBox.Show("avant : " + nbre);
            db.produits.Add(leProduit);
            GetlesProduits().Add(leProduit);
            db.SaveChanges();
            //db.SaveChangesAsync();
            //MessageBox.Show("apres : " + db.produits.ToList().Count);
            SetlesProduits(GetlesProduits());
            if (db.produits.ToList().Count > nbre)
            {
                MessageBox.Show($"Le produit {leProduit.nom} a bien été enregistré!");
                test = true;
            }
            return test;
        }
    }
}

