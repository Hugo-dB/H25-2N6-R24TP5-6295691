using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaladeurMultiFormats
{
    public interface IChanson
    {
        #region PROPRIÉTÉS

        /// <summary>
        /// Obtient l'année de création de la chanson
        /// </summary>
        int Annee { get; }

        /// <summary>
        /// Obtient le nom de l'artiste ou du groupe ayant créé la chanson
        /// </summary>
        string Artiste { get; }

        /// <summary>
        /// Obtient le titre de la chanson
        /// </summary>
        string Titre { get; }

        /// <summary>
        /// Obtient le format audio de la chanson par exemple "AAC", "MP3" ou "WMA"
        /// </summary>
        string Format { get; }

        /// <summary>
        /// Obtient le nom du fichier de la chanson
        /// </summary>
        string NomFichier { get; }

        /// <summary>
        /// Cette propriété calculée va obtenir les paroles de la chanson à partir d’un fichier texte
        /// </summary>
        string Paroles { get; }



        #endregion

        #region MÉTHODES

        /// <summary>
        /// Lecture de l’en-tête du fichier soit uniquement la première ligne
        /// </summary>
        void LireEntete();

        /// <summary>
        /// Obtient les paroles à partir d'un fichier binaire déjà ouvert.
        /// </summary>
        /// <param name="pobjFichier">Nom du fichier</param>
        /// <returns></returns>
        string LireParoles(StreamReader pobjFichier);

        /// <summary>
        /// Lit une ligne à partir du fichier passé en paramètre.
        /// </summary>
        /// <param name="pobjFichier">Nom du fichier</param>
        void SauterEntete(StreamReader pobjFichier);

        /// <summary>
        /// Écrit uniquement l'entête de la chanson.
        /// </summary>
        /// <param name="pobjFichier">Nom du fichier</param>
        void EcrireEntete(StreamWriter pobjFichier);

        /// <summary>
        /// Écrit uniquement les paroles de la chanson
        /// </summary>
        /// <param name="pobjFichier">Nom du fichier</param>
        /// <param name="pParoles">Paroles à écrire</param>
        void EcrireParoles(StreamWriter pobjFichier, string pParoles);

        /// <summary>
        /// Écrit les paroles passées en paramètre dans le fichier de la chanson. 
        /// </summary>
        /// <param name="pParoles">Paroles à écrire</param>
        void Ecrire(string pParoles);
        #endregion
    }
}
