using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BaladeurMultiFormats
{
    /// <summary>
    /// Une ChansonWMA est caractérisée par l’utilisation d’un numéro de codage, il s’agit d’un nombre de 3 à 15 inclusivement qui est utilisé pour encoder le texte des paroles.
    /// </summary>
    public class ChansonWMA : Chanson
    {

        #region CHAMPS ET PROPRIÉTÉS

        /// <summary>
        /// Numéro de codage de la chanson
        /// </summary>
        private int m_codage;

        /// <summary>
        /// Obtient le format du fichier (WMA)
        /// </summary>
        public override string Format { get { return "WMA"; } }

        #endregion

        #region CONSTRUCTEURS

        /// <summary>
        /// Initialise une instance avec les données passées en paramètres en appelant le constructeur de la classe de base.
        /// </summary>
        /// <param name="pNomFichier">Nom du fichier de la chanson</param>
        public ChansonWMA(string pNomFichier) 
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
        public ChansonWMA(string pRepertoire, string pArtiste, string pTitre, int pAnnee) 
                        : base(pRepertoire, pArtiste, pTitre, pAnnee)
        {
        }

        #endregion

        #region MÉTHODES 

        /// <summary>
        /// Génère un numéro de codage entre 3 et 15 et écrit une ligne dans le fichier passé en paramètre. Cette ligne correspond à l’entête du fichier et contient les informations sur la chanson  
        /// </summary>
        /// <param name="pobjFichier">Nom du fichier de la chanson</param>
        public override void EcrireEntete(StreamWriter pobjFichier)
        {
            Random encodage = new Random();
            pobjFichier.WriteLine(encodage.Next(3, 15)
                                + " / " + m_annee
                                + " / " + m_titre
                                + " / " + m_artiste);
        }

        /// <summary>
        /// Encode les paroles recue en paramètre au format WMA, ensuite écrit ses paraoles encodées dans le fichier passé en paramètre.
        /// </summary>
        /// <param name="pobjFichier">Nom du fichier de la chanson</param>
        /// <param name="pParoles">Paroles à écrire</param>
        public override void EcrireParoles(StreamWriter pobjFichier, string pParoles)
        {
            string m_paroles = OutilsFormats.EncoderWMA(pParoles, m_codage);
            pobjFichier.Write(m_paroles);
            pobjFichier.Close();
        }

        /// <summary>
        /// Lit la premiere ligne du fichier de la chanson et initialise les champs de la chanson (codage, artiste, année de création et titre)
        /// </summary>
        public override void LireEntete()
        {
            StreamReader objFichier = new StreamReader(m_nomFichier);
            string ligneLue = objFichier.ReadLine();
            objFichier.Close();
            string[] tabLue = ligneLue.Split('/');
            m_codage = int.Parse(tabLue[0]);
            m_annee = int.Parse(tabLue[1]);
            m_titre = tabLue[2].Trim();
            m_artiste = tabLue[3].Trim();
        }

        /// <summary>
        /// Récupèere les paroles de la chanson à partir du fichier passé en paramètre, les décode en format WMA et les retourne.
        /// </summary>
        /// <param name="pobjFichier">Nom du fichier de la chanson</param>
        /// <returns></returns>
        public override string LireParoles(StreamReader pobjFichier)
        {
            string m_paroles = pobjFichier.ReadToEnd();
            m_paroles = OutilsFormats.DecoderWMA(m_paroles, m_codage);
            return m_paroles;
        }

        #endregion


    }
}
