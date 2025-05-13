//using BaladeurMultiFormats;
using BaladeurMultiFormats;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BaladeurMultiFormats_Tests
{
    
        [TestClass]
        public class Consultation_Tests
        {
            [TestMethod]
            public void ConstrConsultation()
            {
                // Instancier la classe Consultation avec un Datetime.Now et la chanson objChanson
                DateTime objDateTime = DateTime.Now;
                ChansonAAC objChanson = new ChansonAAC("Chansons", "Test", "Test", 2000);
                Consultation objConsultation = new Consultation(objDateTime, objChanson);
                // Vérifier la valeur des propriétés Date et LaChanson
                Assert.AreEqual(objDateTime, objConsultation.Date);
                Assert.AreEqual(objChanson, objConsultation.LaChanson);
            }
        }
    
}
