using System;
using System.Collections;
using System.Windows.Forms;

namespace BaladeurMultiFormats
{
    public class ListViewComparer : IComparer
    {
        private int m_colIndex;
        // ===================================================================
        public ListViewComparer(int pColIndex)
        {
            m_colIndex = pColIndex;
        }
        // ===================================================================
        public int Compare(object pobjX, object pobjY)
        {
            // Get the objects as ListViewItems.
            ListViewItem itemX = pobjX as ListViewItem;
            ListViewItem itemY = pobjY as ListViewItem;

            // Obtient le sous-item pour l'itemX
            string chaineX;
            if (itemX.SubItems.Count <= m_colIndex)
                chaineX = "";
            else
                chaineX = itemX.SubItems[m_colIndex].Text;

            // Obtient le sous-item pour l'itemY
            string chaineY;
            if (itemY.SubItems.Count <= m_colIndex)
                chaineY = "";
            else
                chaineY = itemY.SubItems[m_colIndex].Text;
 
            // On va comparer les deux items
            // On va supposer qu'il s'agit de nombres
            int result;
            int nombreX, nombreY;
            if (int.TryParse(chaineX, out nombreX) && int.TryParse(chaineY, out nombreY))
            {   // On va comparer des nombres
                result = -nombreX.CompareTo(nombreY);
            }
            else
            {
                // Traite comme du texte
                result = chaineX.CompareTo(chaineY);
            }

            return result;
        }
    }
}
