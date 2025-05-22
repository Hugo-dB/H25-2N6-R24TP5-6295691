using System;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;


namespace BaladeurMultiFormats
{
    // Étapes de  réalisation :
    // TODO 01 (Étape #1) : Définir les interfaces et les classes du projet
    // TODO 02 (Étape #2) : Compléter le formulaire FrmPrincipal
    // TODO 03 (Étape #3) : Définir les tests unitaires de la classe Consultation et Historique
    //  Vous devez définir les tests pour tous les éléments d'une classe (Propriétés, constructeurs et méthodes)
    //  Vous devez identifier les différents cas de tests possibles (couverture des tests)


    public partial class FrmPrincipal : Form
    {
        Baladeur LeBaladeur;
        public const string APP_INFO = "6295691";

        #region Propriété : MonHistorique
        public Historique MonHistorique { get; }
        #endregion
        //---------------------------------------------------------------------------------
        #region FrmPrincipal
        public FrmPrincipal()
        {
            InitializeComponent();
            Text += APP_INFO;
            MonHistorique = new Historique();
            // À COMPLÉTER...
            LeBaladeur = new Baladeur();
            LeBaladeur.ConstruireLaListeDesChansons();
            MettreAJourSelonContexte();



        }
        #endregion
        //---------------------------------------------------------------------------------
        #region Méthode : MettreAJourSelonContexte
        private void MettreAJourSelonContexte()
        {
            LeBaladeur.AfficherLesChansons(lsvChansons);
            lblNbChansons.Text = LeBaladeur.NbChansons.ToString();
        }
        #endregion
        //---------------------------------------------------------------------------------
        #region Événement : LsvChansons_SelectedIndexChanged
        private void LsvChansons_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtParoles.Text = "";
            if (lsvChansons.SelectedIndices.Count > 0)
            {  
                int index = lsvChansons.SelectedIndices[0];
                Consultation NouvelleConsultation = new Consultation(DateTime.Now, LeBaladeur.ChansonAt(index));
                MonHistorique.Ajouter(NouvelleConsultation);
                txtParoles.Text = LeBaladeur.ChansonAt(index).Paroles;
                
                MnuFormatConvertirVersAAC.Enabled = true;
                MnuFormatConvertirVersMP3.Enabled = true;
                MnuFormatConvertirVersWMA.Enabled = true;
                switch (LeBaladeur.ChansonAt(index).Format)
                {
                    case "aac":
                        MnuFormatConvertirVersAAC.Enabled = false;
                        break;
                    case "mp3":
                        MnuFormatConvertirVersMP3.Enabled = false;
                        break;
                    case "wma":
                        MnuFormatConvertirVersWMA.Enabled = false;
                        break;
                }

            }
        }
        #endregion

        //---------------------------------------------------------------------------------
        #region Méthodes : Convertir vers les formats AAC, MP3 ou WMA
        private void MnuFormatConvertirVersAAC_Click(object sender, EventArgs e)
        {
            // Vider l'historique car les références ne sont plus bonnes
            MonHistorique.Vider();
            // À COMPLÉTER...
            if (lsvChansons.SelectedIndices.Count > 0)
            {
                int index = lsvChansons.SelectedIndices[0];
                LeBaladeur.ConvertirVersAAC(index);
            }
            MettreAJourSelonContexte();
            
        }
        private void MnuFormatConvertirVersMP3_Click(object sender, EventArgs e)
        {
            // Vider l'historique car les références ne sont plus bonnes
            MonHistorique.Vider();
            // À COMPLÉTER...
            if (lsvChansons.SelectedIndices.Count > 0)
            {
                int index = lsvChansons.SelectedIndices[0];
                LeBaladeur.ConvertirVersMP3(index);
            }
            MettreAJourSelonContexte();
        }
        private void MnuFormatConvertirVersWMA_Click(object sender, EventArgs e)
        {
            // Vider l'historique car les références ne sont plus bonnes
            MonHistorique.Vider();
            // À COMPLÉTER...
            if (lsvChansons.SelectedIndices.Count > 0)
            {
                int index = lsvChansons.SelectedIndices[0];
                LeBaladeur.ConvertirVersWMA(index);
            }
            MettreAJourSelonContexte();
        }
        #endregion
        //---------------------------------------------------------------------------------
        #region Historique
        private void MnuSpécialHistorique_Click(object sender, EventArgs e)
        {
            FrmHistorique objFormulaire = new FrmHistorique(MonHistorique);
            objFormulaire.ShowDialog();
        }
        #endregion
        //---------------------------------------------------------------------------------
        #region Méthodes : MnuFichierQuitter_Click
        //---------------------------------------------------------------------------------
        private void MnuFichierQuitter_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

       
    }
}
