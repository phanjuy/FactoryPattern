using System.Text;

namespace FactoryPattern.Invoice
{
    public class VATInvoice : IInvoice
    {
        public byte[] GenerateInvoice()
        {
            return Encoding.Default.GetBytes("Hello world from a VAT Invoice");
        }
    }
}
