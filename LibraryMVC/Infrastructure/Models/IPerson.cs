namespace Infrastructure.Models
{
    public interface IPerson // contract for all people in the library (authors,workers,etc.)
    {
        public int Age { get; set; }

        public DateOnly BirthDate { get; set; }

        public string Nationality { get; set; }
    }
}
