using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaladeurMultiFormats
{
    public abstract class Chanson : IChanson
    {
        #region CHAMPS ET PROPRIÉTÉS
        /// <summary>
        /// Année de création de la chanson
        /// </summary>
        protected int m_annee;

        /// <summary>
        /// Nom de l'artiste de la chanson
        /// </summary>
        protected string m_artiste;

        /// <summary>
        /// Nom du fichier de la chanson
        /// </summary>
        protected string m_nomFichier;

        /// <summary>
        /// Titre de la chanson
        /// </summary>
        protected string m_titre;



        /// <summary>
        /// Obtient l’année de création de la chanson 
        /// </summary>
        public int Annee { get { return m_annee; } }

        /// <summary>
        /// Obtient le nom de l’artiste
        /// </summary>
        public string Artiste { get { return m_artiste; } }

        /// <summary>
        /// Obtient le titre de la chanson
        /// </summary>
        public string Titre { get { return m_titre; } }

        /// <summary>
        /// Obtient le format du fichier de la chanson
        /// </summary>
        public abstract string Format { get; }

        /// <summary>
        /// Obtient le nom de fichier de la chanson
        /// </summary>
        public string NomFichier { get { return m_nomFichier; } }

        /// <summary>
        /// Cette propriété calculée va vérifier si le fichier de la chanson existe, afin de l'ouvrir pour ensuite sauter l'en-tête pour lire les paroles les traiter et les retourner.
        /// </summary>
        public string Paroles
        {
            get
            {
                if (File.Exists(m_nomFichier))
                {
                    StreamReader objFichier = new StreamReader(m_nomFichier);
                    SauterEntete(objFichier);

                    string m_paroles = "";
                    while(!objFichier.EndOfStream)
                    {
                        m_paroles += objFichier.ReadLine();
                    }
                    objFichier.Close();
                    return m_paroles;
                }
                else
                {
                    throw new ArgumentNullException();
                }
                
            }
        }

        #endregion

        #region CONSTRUCTEURS

        /// <summary>
        /// Initialise une instance avec les données passées en paramètres en appelant le constructeur de la classe de base.
        /// </summary>
        /// <param name="pNomFichier">Nom du fichier de la chanson</param>
        public Chanson(string pNomFichier)
        {
            m_nomFichier = pNomFichier;
            LireEntete();
        }

        /// <summary>
        /// Initialise une instance avec les données passées en paramètres en appelant le constructeur de la classe de base.
        /// </summary>
        /// <param name="pRepertoire">Nom du répertoire où se situe la chanson</param>
        /// <param name="pArtiste">Nom de l'artiste de la chanson</param>
        /// <param name="pTitre">Titre de la chanson</param>
        /// <param name="pAnnee">Année de créationde la chanson</param>
        public Chanson(string pRepertoire, string pArtiste, string pTitre, int pAnnee)
        {
            m_nomFichier = pRepertoire + "/" + pTitre + "." + Format;
            LireEntete();
        }

        #endregion

        #region MÉTHODES

        /// <summary>
        /// Écrit les paroles passées en paramètre dans le fichier de la chanson. Elle doit d’abord écrire l’en-tête ensuite écrire les paroles.
        /// </summary>
        /// <param name="pParoles">Paroles à écrire</param>
        public void Ecrire(string pParoles)
        {
            StreamWriter objFichier = new StreamWriter(m_nomFichier);
            EcrireEntete(objFichier);
            EcrireParoles(objFichier, pParoles);
            objFichier.Close();
        }

        /// <summary>
        /// Une méthode qui permet d’écrire l’entête de la chanson
        /// </summary>
        /// <param name="pobjFichier">Nom du fichier de la chanson</param>
        public abstract void EcrireEntete(StreamWriter pobjFichier);

        /// <summary>
        /// Une méthode qui permet d’écrire les paroles de la chanson
        /// </summary>
        /// <param name="pobjFichier">Nom du fichier de la chanson</param>
        /// <param name="pParoles">Paroles à écrire</param>
        public abstract void EcrireParoles(StreamWriter pobjFichier, string pParoles);

        /// <summary>
        /// Méthode abstraite à redéfénir dans les classes dérivées
        /// </summary>
        public abstract void LireEntete();

        /// <summary>
        /// Méthode abstraite à redéfinir dans les classe dérivées
        /// </summary>
        /// <param name="pobjFichier">Nom du fichier de la chanson</param>
        /// <returns></returns>
        public abstract string LireParoles(StreamReader pobjFichier);

        /// <summary>
        /// Lit une ligne à partir du fichier passé en paramètre.
        /// </summary>
        /// <param name="pobjFichier">Nom du fichier de la chanson</param>
        public void SauterEntete(StreamReader pobjFichier)
        {
            pobjFichier.ReadLine();
            pobjFichier.Close();
        }

        #endregion
    }
}
