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
            ChansonAAC testAAC = new ChansonAAC("Chansons\\Blame It On Me.aac");
            ChansonMP3 testMP3 = new ChansonMP3("Chansons\\Billie Jean.mp3");
            ChansonWMA testWMA = new ChansonWMA("Chansons\\Hotel California.wma");
            Baladeur testBaladeur = new Baladeur();
            testBaladeur.ConstruireLaListeDesChansons();
            testBaladeur.AfficherLesChansons(lsvChansons);
        }
        #endregion
        //---------------------------------------------------------------------------------
        #region Méthode : MettreAJourSelonContexte
        private void MettreAJourSelonContexte()
        {
            // À COMPLÉTER...
        }
        #endregion
        //---------------------------------------------------------------------------------
        #region Événement : LsvChansons_SelectedIndexChanged
        private void LsvChansons_SelectedIndexChanged(object sender, EventArgs e)
        {
            // À COMPLÉTER...
        }
        #endregion

        //---------------------------------------------------------------------------------
        #region Méthodes : Convertir vers les formats AAC, MP3 ou WMA
        private void MnuFormatConvertirVersAAC_Click(object sender, EventArgs e)
        {
            // Vider l'historique car les références ne sont plus bonnes
            // À COMPLÉTER...
        }
        private void MnuFormatConvertirVersMP3_Click(object sender, EventArgs e)
        {
            // Vider l'historique car les références ne sont plus bonnes
            // À COMPLÉTER...
        }
        private void MnuFormatConvertirVersWMA_Click(object sender, EventArgs e)
        {
            // Vider l'historique car les références ne sont plus bonnes
            // À COMPLÉTER...
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
