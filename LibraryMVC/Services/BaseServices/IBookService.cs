using Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BaseServices
{
    public interface IBookService : IBaseService<Book>
    {
        public Task Add(string name, int genreID, int authorID, int publisherID, int yearPublished, IFormFile imageFile);
        public Task Update(int id, string name, int genreID, int authorID, int publisherID, int yearPublished, IFormFile imageFile);
        public Task<Book> GetByID(int id);
        public Task<List<Book>> GetList();
    }
}
