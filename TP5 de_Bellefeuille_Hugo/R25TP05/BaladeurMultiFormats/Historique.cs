using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BaladeurMultiFormats
{

    public class Historique
    {
        #region Propriétés
        /// <summary>
        /// Liste de consultations
        /// </summary>
        public List<Consultation> ColConsultations { get; private set; }
        #endregion

        #region Constructeurs
        public Historique()
        {
            ColConsultations = new List<Consultation>();
        }
        public Historique(List<Consultation> pConsultations)
        {
            if (pConsultations == null)
            {
                throw new ArgumentNullException();
            }
            ColConsultations = pConsultations;
        }
        #endregion

        #region Méthodes
        /// <summary>
        /// Ajouter une nouvelle consultation à l'historique
        /// </summary>
        /// <param name="pConsultation">La nouvelle consultation</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Ajouter(Consultation pConsultation)
        {
            if (pConsultation == null)
            {
                throw new ArgumentNullException();
            }

            ColConsultations.Add(pConsultation);
        }
        /// <summary>
        /// Créer et ajouter une consultation à l'historique
        /// </summary>
        /// <param name="pChanson">Chanson consultée</param>
        /// <param name="pDate">Date de consultation</param>
        /// <returns>La nouvelle consultation</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Consultation Ajouter(object pChanson, DateTime pDate)
        {
            if (pChanson == null)
            {
                throw new ArgumentNullException();
            }
            Consultation nouvelleConsultation = new Consultation(pDate, pChanson);
            ColConsultations.Add(nouvelleConsultation);

            return nouvelleConsultation;
        }

        /// <summary>
        /// Obtenir une consultation à une position donnée de l'historique
        /// </summary>
        /// <param name="index">position de la consultation</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Consultation ConsultationAt(int index)
        {
            if (index < 0 || index >= ColConsultations.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            return ColConsultations[index];

        }
        /// <summary>
        /// Supprimer tout l'historique
        /// </summary>
        public void Vider()
        {

            ColConsultations.Clear();

        }
        #region NbConsultationsPourUneChanson
        /// <summary>
        /// Parcourt les consultations afin de compter le nombre de fois qu'une certaine
        /// chanson a été consultée.
        /// </summary>
        /// <param name="pIndexChanson"></param>
        /// <returns>Nombre de consultations pour une certaine chanson</returns>
        public int NbConsultationsPourUneChanson(object pChanson)
        {

            if (pChanson == null)
                throw new ArgumentNullException();

            int cptOccurences = 0;
            foreach (Consultation uneConsultation in ColConsultations)
            {
                if (uneConsultation.LaChanson == pChanson)
                {
                    cptOccurences++;
                }
            }
            return cptOccurences;
        }
        #endregion

        #region HistoriqueEntreDeuxDates
        /// <summary>
        /// Obtenir la liste des consultations effectées entre deux dates
        /// </summary>
        /// <param name="pDateInf">date de début</param>
        /// <param name="pDateSup">date de fin</param>
        /// <returns>liste de consultation</returns>
        public List<Consultation> HistoriqueEntreDeuxDates(DateTime pDateInf, DateTime pDateSup)
        {

            List<Consultation> colConsultations = new List<Consultation>();

            foreach (Consultation consultation in ColConsultations)
            {

                if (consultation.Date >= pDateInf && consultation.Date <= pDateSup)
                {

                    colConsultations.Add(consultation);

                }


            }


            return colConsultations;
        }

        #endregion
        #region NbConsultationsDepuisXSecondes
        /// <summary>
        /// Parcourt les consultations afin de compter le nombre de chansons 
        /// consultées depuis un certains nombre de secondes.
        /// </summary>
        /// <param name="pDelai"></param>
        /// <returns>Nombre de chansons consultées depuis pDelai secondes</returns>
        public int NbConsultationsDepuisXSecondes(int pDelai)
        {

            if (pDelai < 0)
                throw new IndexOutOfRangeException();

            int cptChansons = 0;
            foreach (Consultation uneConsultation in ColConsultations)
            {
                if (uneConsultation.Délai <= pDelai)
                {
                    cptChansons++;
                }
            }

            return cptChansons;
        }
        #endregion

        #endregion

    }
}
