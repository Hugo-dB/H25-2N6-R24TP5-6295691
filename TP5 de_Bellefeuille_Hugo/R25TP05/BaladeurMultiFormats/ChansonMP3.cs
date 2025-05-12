using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaladeurMultiFormats
{
    public class ChansonMP3 : Chanson
    {

        #region PROPRIÉTÉES

        /// <summary>
        /// Obtient le format du fichier (MP3)
        /// </summary>
        public override string Format { get { return "MP3"; } }

        #endregion

        #region CONSTRUCTEURS

        /// <summary>
        /// Initialise une instance avec les données passées en paramètres en appelant le constructeur de la classe de base.
        /// </summary>
        /// <param name="pNomFichier">Nom du fichier de la chanson</param>
        public ChansonMP3(string pNomFichier) 
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
        public ChansonMP3(string pRepertoire, string pArtiste, string pTitre, int pAnnee) 
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
            pobjFichier.WriteLine(m_artiste 
                                + " | " + m_annee 
                                + " | " + m_titre);
            pobjFichier.Close();
        }

        /// <summary>
        /// Encode les paroles recue en paramètre au format MP3, ensuite écrit ses paraoles encodées dans le fichier passé en paramètre.
        /// </summary>
        /// <param name="pobjFichier">Nom du fichier de la chanson</param>
        /// <param name="pParoles">Paroles à écrire</param>
        public override void EcrireParoles(StreamWriter pobjFichier, string pParoles)
        {
            string m_paroles = OutilsFormats.EncoderMP3(pParoles);
            pobjFichier.Write(m_paroles);
            pobjFichier.Close();
        }

        /// <summary>
        /// Lit la premiere ligne du fichier de la chanson et initialise les champs de la chanson (artiste, année de création et titre)
        /// </summary>
        public override void LireEntete()
        {
            StreamReader objFichier = new StreamReader(m_nomFichier);
            string ligneLue = objFichier.ReadLine();
            string[] tabLue = ligneLue.Split('|');
            m_artiste = tabLue[0].Trim();
            m_annee = int.Parse(tabLue[1]);
            m_titre = tabLue[2].Trim();
        }

        /// <summary>
        /// Récupèere les paroles de la chanson à partir du fichier passé en paramètre, les décode en format MP3 et les retourne.
        /// </summary>
        /// <param name="pobjFichier">Nom du fichier de la chanson</param>
        /// <returns></returns>
        public override string LireParoles(StreamReader pobjFichier)
        {
            string m_paroles = pobjFichier.ReadToEnd();
            m_paroles = OutilsFormats.DecoderMP3(m_paroles);
            return m_paroles;
        }

        #endregion


    }
}
