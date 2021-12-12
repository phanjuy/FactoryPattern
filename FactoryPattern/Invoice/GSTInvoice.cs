using System.Text;

namespace FactoryPattern.Invoice
{
    public class GSTInvoice : IInvoice
    {
        public byte[] GenerateInvoice()
        {
            return Encoding.Default.GetBytes("Hello world from a GST Invoice");
        }
    }
}
