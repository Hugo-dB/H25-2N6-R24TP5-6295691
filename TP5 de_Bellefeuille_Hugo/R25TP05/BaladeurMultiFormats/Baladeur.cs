using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaladeurMultiFormats
{
    public class Baladeur : IBaladeur
    {
        #region CONSTANTES

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
            ConstruireLaListeDesChansons();
        }

        #endregion

        #region MÉTHODES

        public void AfficherLesChansons(ListView pListView)
        {
            throw new NotImplementedException();
        }

        public Chanson ChansonAt(int pIndex)
        {
            throw new NotImplementedException();
        }

        public void ConstruireLaListeDesChansons()
        {
            throw new NotImplementedException();
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
