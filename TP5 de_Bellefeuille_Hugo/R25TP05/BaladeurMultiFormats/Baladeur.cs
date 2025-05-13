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
            pListView.Items.Clear();
            foreach (Chanson uneChanson in m_colChansons)
            {
                ListViewItem objItem = new ListViewItem(uneChanson.Artiste);
                objItem.SubItems.Add(uneChanson.Titre);
                objItem.SubItems.Add(uneChanson.Annee.ToString());
                objItem.SubItems.Add(uneChanson.Format.ToUpper());
                pListView.Items.Add(objItem);
            }
        }

        /// <summary>
        /// Obtient la chanson à l'index pIndex
        /// </summary>
        /// <param name="pIndex">Index de la chanson</param>
        public Chanson ChansonAt(int pIndex)
        {
            return m_colChansons[pIndex];
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

        /// <summary>
        /// Instancie une ChansonAAC à partir de la chanson à l’index pIndex, enregistre les paroles et supprime le fichier du format précédent.
        /// </summary>
        /// <param name="pIndex">Index de la chanson</param>
        public void ConvertirVersAAC(int pIndex)
        {
            if (m_colChansons[pIndex].Format != "aac")
            {
                var chansonIndex = m_colChansons[pIndex];

                m_colChansons[pIndex] = new ChansonAAC(NOM_RÉPERTOIRE, chansonIndex.Artiste, chansonIndex.Titre, chansonIndex.Annee);
                m_colChansons[pIndex].Ecrire(chansonIndex.Paroles);

                if (File.Exists(m_colChansons[pIndex].NomFichier))
                {
                    File.Delete(chansonIndex.NomFichier);
                }
            }
            
        }

        /// <summary>
        /// Instancie une ChansonMP3 à partir de la chanson à l’index pIndex, enregistre les paroles et supprime le fichier du format précédent.
        /// </summary>
        /// <param name="pIndex">Index de la chanson</param>
        public void ConvertirVersMP3(int pIndex)
        {
            if (m_colChansons[pIndex].Format != "mp3")
            {
                var chansonIndex = m_colChansons[pIndex];

                m_colChansons[pIndex] = new ChansonMP3(NOM_RÉPERTOIRE, chansonIndex.Artiste, chansonIndex.Titre, chansonIndex.Annee);
                m_colChansons[pIndex].Ecrire(chansonIndex.Paroles);

                if (File.Exists(m_colChansons[pIndex].NomFichier))
                {
                    File.Delete(chansonIndex.NomFichier);
                }
            }
        }

        /// <summary>
        /// Instancie une ChansonWMA à partir de la chanson à l’index pIndex, enregistre les paroles et supprime le fichier du format précédent.
        /// </summary>
        /// <param name="pIndex">Index de la chanson</param>
        public void ConvertirVersWMA(int pIndex)
        {
            if (m_colChansons[pIndex].Format != "wma")
            {
                var chansonIndex = m_colChansons[pIndex];

                m_colChansons[pIndex] = new ChansonWMA(NOM_RÉPERTOIRE, chansonIndex.Artiste, chansonIndex.Titre, chansonIndex.Annee);
                m_colChansons[pIndex].Ecrire(chansonIndex.Paroles);

                if (File.Exists(m_colChansons[pIndex].NomFichier))
                {
                    File.Delete(chansonIndex.NomFichier);
                }
            }
        }

        #endregion
    }
}
