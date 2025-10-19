namespace Infrastructure.Models
{
    public abstract class BasePerson: BaseEntity, IPerson //base class for all people objects (authors,workers,etc.)
    {
        public int Age { get; set; }

        public DateOnly BirthDate { get; set; }

        public string Nationality { get; set; }
    }
}
