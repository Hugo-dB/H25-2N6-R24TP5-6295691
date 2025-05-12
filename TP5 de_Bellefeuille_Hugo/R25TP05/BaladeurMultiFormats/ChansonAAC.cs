using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaladeurMultiFormats
{
    /// <summary>
    /// Une ChansonAAC utilise un codage au format AAC
    /// </summary>
    public class ChansonAAC : Chanson
    {
        

        #region PROPRIÉTÉS

        /// <summary>
        /// Obtient le format du fichier (AAC)
        /// </summary>
        public override string Format { get { return "AAC"; } }

        #endregion

        #region CONSTRUCTEURS

        /// <summary>
        /// Initialise une instance avec les données passées en paramètres en appelant le constructeur de la classe de base.
        /// </summary>
        /// <param name="pNomFichier">Nom du fichier de la chanson</param>
        public ChansonAAC(string pNomFichier) 
                        : base(pNomFichier)
        {
        }

        /// <summary>
        /// Initialise une instance avec les données passées en paramètres en appelant le constructeur de la classe de base.
        /// </summary>
        /// <param name="pRepertoire">Nom du répertoire où est situé le fichier de la chanson</param>
        /// <param name="pArtiste">Nom de l'artiste de la chanson</param>
        /// <param name="pTitre">Titre de la chanson</param>
        /// <param name="pAnnee">Année de création de la chanson</param>
        public ChansonAAC(string pRepertoire, string pArtiste, string pTitre, int pAnnee) 
                        : base(pRepertoire, pArtiste, pTitre, pAnnee)
        {
        }

        #endregion

        #region MÉTHODES

        /// <summary>
        /// Écrit une ligne dans le fichier passé en paramètre. Cette ligne correspond à l’entête du fichier et contient les informations sur la chanson 
        /// </summary>
        /// <param name="pobjFichier">Nom du fichier de la chanson</param>
        public override void EcrireEntete(StreamWriter pobjFichier)
        {
            pobjFichier.WriteLine("TITRE = " + m_titre
                             + " : ARTISTE = " + m_artiste
                             + " : ANNÉE = " + m_annee);
        }

        /// <summary>
        /// Encode les paroles reçues en paramètre au format AAC, ensuite écrit ses paroles encodées dans le fichier passé en paramètre.
        /// </summary>
        /// <param name="pobjFichier">Nom du fichier de la chanson</param>
        /// <param name="pParoles">Paroles à écrire</param>
        public override void EcrireParoles(StreamWriter pobjFichier, string pParoles)
        {
            string m_paroles = OutilsFormats.EncoderAAC(pParoles);
            pobjFichier.Write(m_paroles);
        }

        /// <summary>
        /// Lit la premiere ligne du fichier de la chanson et initialise les champs de la chanson (titre, artiste et année de création de la chanson)
        /// </summary>
        public override void LireEntete()
        {
            StreamReader objFichier = new StreamReader(m_nomFichier);
            string ligneLue = objFichier.ReadLine();
            objFichier.Close();
            string[] tabLue = ligneLue.Split(':');

            m_titre = tabLue[0].Split('=')[1].Trim();
            m_artiste = tabLue[1].Split('=')[1].Trim();
            m_annee = int.Parse(tabLue[2].Split('=')[1]);
        }

        /// <summary>
        /// Récupère les paroles de la chanson à partir du fichier passé en paramètre, les décode selon le format AAC et les retourne.
        /// </summary>
        /// <param name="pobjFichier">Nom du fichier de la chanson</param>
        /// <returns></returns>
        public override string LireParoles(StreamReader pobjFichier)
        {
            string m_paroles = pobjFichier.ReadToEnd();
            m_paroles = OutilsFormats.DecoderAAC(m_paroles);
            return m_paroles;
        }

        #endregion
    }
}
