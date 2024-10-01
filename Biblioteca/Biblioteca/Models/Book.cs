
namespace Biblioteca.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string Denumire { get; set; }
        public string Autor { get; set; }
        public int NrPagini { get; set; }
        public int AnEditare { get; set; }

        internal static Book Find(int? Id)
        {
            throw new NotImplementedException();
        }
    }
}
