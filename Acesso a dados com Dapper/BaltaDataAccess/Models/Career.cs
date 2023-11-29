using BaltaDataAccess.Models;

namespace BaltaDataAccess
{
    class Career
    {
        public Career()
        {
            Items = new List<CarrerItem>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public IList<CarrerItem> Items { get; set; }
    }
}