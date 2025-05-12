using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaladeurMultiFormats
{
    public class Baladeur : IBaladeur
    {
        #region CONSTANTE

        /// <summary>
        /// Nom du répertoire des chansons
        /// </summary>
        private const string NOM_RÉPERTOIRE = "Chansons";

        #endregion

        #region CHAMPS ET PROPRIÉTÉS

        /// <summary>
        /// Liste des chansons
        /// </summary>
        private List<Chanson> m_colChansons;

        /// <summary>
        /// Obtient le nombre de chansons.
        /// </summary>
        public int NbChansons { get { return m_colChansons.Count; } }

        #endregion

        #region CONSTRUCTEUR

        public Baladeur()
        {
            m_colChansons = new List<Chanson>();
        }

        #endregion

        #region MÉTHODES

        /// <summary>
        /// Affiche la liste des chansons dans la pListView passée en paramètre.
        /// </summary>
        /// <param name="pListView">Nom du ListView</param>
        public void AfficherLesChansons(ListView pListView)
        {
            foreach (Chanson uneChanson in m_colChansons)
            {
                ListViewItem objItem = new ListViewItem(uneChanson.Artiste);
                objItem.SubItems.Add(uneChanson.Titre);
                objItem.SubItems.Add(uneChanson.Annee.ToString());
                objItem.SubItems.Add(uneChanson.Format);
                pListView.Items.Add(objItem);
            }
        }

        public Chanson ChansonAt(int pIndex)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Charge la liste des chansons dans m_colChansons. Elle doit vérifier l’existence du répertoire des chansons, ensuite lit chaque fichier et instancie une classe de chanson selon le format et l’ajoute dans la collection des chansons m_colChansons 
        /// </summary>
        public void ConstruireLaListeDesChansons()
        {
            if (Directory.Exists(NOM_RÉPERTOIRE))
            { 
                foreach (string unFichier in Directory.GetFiles(NOM_RÉPERTOIRE))
                {
                    if (unFichier.Contains(".aac"))
                    {
                        m_colChansons.Add(new ChansonAAC(unFichier));
                    }
                    if (unFichier.Contains(".mp3"))
                    {
                        m_colChansons.Add(new ChansonMP3(unFichier));
                    }
                    if (unFichier.Contains(".wma"))
                    {
                        m_colChansons.Add(new ChansonWMA(unFichier));
                    }
                }
            }
            else
            {
                throw new FileNotFoundException();
            }
        }

        public void ConvertirVersAAC(int pIndex)
        {
            throw new NotImplementedException();
        }

        public void ConvertirVersMP3(int pIndex)
        {
            throw new NotImplementedException();
        }

        public void ConvertirVersWMA(int pIndex)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
