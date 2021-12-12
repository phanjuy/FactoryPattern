using System.Text;

namespace FactoryPattern.Invoice
{
    public class NoVATInvoice : IInvoice
    {
        public byte[] GenerateInvoice()
        {
            return Encoding.Default.GetBytes("Hello world from a NO VAT invoice");
        }
    }
}
