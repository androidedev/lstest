using System.ComponentModel.DataAnnotations;

namespace ncorerazor.models
{
    public class Languajes
    {
        public int Id { get; set; }
        public string Languaje { get; set; }
        public string? Official { get; set; }
        //[DataType(DataType.Date)]
        //public DateTime ReleaseDate { get; set; }
        //public string? Genre { get; set; }
        //public decimal Price { get; set; }
    }
}
