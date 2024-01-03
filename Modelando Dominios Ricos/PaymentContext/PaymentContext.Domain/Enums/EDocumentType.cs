using System.ComponentModel;

namespace PaymentContext.Domain.Enums
{
    public enum EDocumentType
    {
        [Description("Pessoa Fisica - CPF")]
        CPF = 1,
        
        [Description("Pessoa Juridica - CNPJ")]
        CNPJ = 2
    }
}