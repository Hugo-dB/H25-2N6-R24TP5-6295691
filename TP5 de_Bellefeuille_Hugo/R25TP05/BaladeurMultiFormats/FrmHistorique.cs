﻿using System.Windows.Forms;

namespace BaladeurMultiFormats
{
    /// <summary>
    /// Présente l'historique des consultations des chansons
    /// </summary>
    public partial class FrmHistorique : Form
    {
        private readonly Historique m_historique; // historique courant
        /// <summary>
        /// Initilise le formulaire, affiche l'historique des consultations
        /// </summary>
        /// <param name="pHistorique">Historique à afficher</param>
        public FrmHistorique(Historique pHistorique)
        {
            InitializeComponent();
            tmrRaffraîchir.Start();
            m_historique = pHistorique;
            AfficherHistorique();
            lblNbChansons.Text = m_historique.ColConsultations.ToString();
            numSecondes.Value = 5;
        }

        #region AfficherHistorique
        /// <summary>
        /// Affiche l'historique des consultations des chansons dans un ListView
        /// </summary>
        /// <param name="pHistorique">Historique à afficher</param>
        public void AfficherHistorique()
        {
            lsvChansons.Items.Clear();
            lsvChansons.BeginUpdate();
            for (int index = m_historique.ColConsultations.Count - 1; index >= 0; index--)
            {
                Consultation objConsultation = m_historique.ColConsultations[index];
                Chanson objChanson = (Chanson)objConsultation.LaChanson;
                ListViewItem objItem = new ListViewItem(objChanson.Artiste);
                objItem.SubItems.Add(objChanson.Titre);
                objItem.SubItems.Add(objChanson.Annee.ToString());
                objItem.SubItems.Add(objConsultation.Délai + "s");
                objItem.SubItems.Add(m_historique.NbConsultationsPourUneChanson(objChanson).ToString());
                lsvChansons.Items.Add(objItem);
            }
            lsvChansons.EndUpdate();
        }
        #endregion

        private void RaffraîchirNbConsultationsDepuis()
        {
            int nombre = m_historique.NbConsultationsDepuisXSecondes((int)numSecondes.Value);
            lblNbChansonsDepuis.Text = nombre.ToString();
        }
        private void NumSecondes_ValueChanged(object sender, System.EventArgs e)
        {
            RaffraîchirNbConsultationsDepuis();
        }

        private void FrmHistorique_FormClosing(object sender, FormClosingEventArgs e)
        {
            tmrRaffraîchir.Stop();
        }

        private void TmrRaffraîchir_Tick(object sender, System.EventArgs e)
        {
            RaffraîchirNbConsultationsDepuis();
            for (int index = m_historique.ColConsultations.Count - 1; index >= 0; index--)
            {
                Consultation objConsultation = m_historique.ColConsultations[m_historique.ColConsultations.Count - index - 1]; // BUFFIX : 12/05/2022 
                Chanson objChanson = (Chanson)objConsultation.LaChanson;
                lsvChansons.Items[index].SubItems[3].Text = objConsultation.Délai + "s";
            }
        }

        private void lsvChansons_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void lblNbChansons_Click(object sender, System.EventArgs e)
        {

        }

        private void lblNbChansonsDepuis_Click(object sender, System.EventArgs e)
        {

        }
    }
}
