using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Test
{
    [TestClass]
    public class DocumentTest
    {
        [TestMethod]
        public void Deve_retorna_Erro_Quando_CNPJ_Invalido()
        {   
            var doc = new Document("123", EDocumentType.CNPJ);
            Assert.AreEqual(false, doc.Validate());
        }

        [TestMethod]
        public void Deve_retorna_Sucesso_Quando_CNPJ_Valido()
        {   
            var doc = new Document("12345678911111", EDocumentType.CNPJ);
             Assert.AreEqual(true, doc.Validate());
        }

         [TestMethod]
        public void Deve_retorna_Erro_Quando_CPF_Invalido()
        {   
             var doc = new Document("85254", EDocumentType.CPF);
             Assert.AreEqual(false, doc.Validate());
        }

        [TestMethod]
        public void Deve_retorna_Sucesso_Quando_CPF_Valido()
        {   
            var doc = new Document("99999999999", EDocumentType.CPF);
             Assert.AreEqual(true, doc.Validate());
        }

    }
}