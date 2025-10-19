namespace Infrastructure.Models
{
    public interface ILibraryEntity // a contract for all different objects in the library
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateLastModified { get; set; }

        public DateTime DateDeleted { get; set; }

        public bool IsDeleted { get; set; }
    }
}
