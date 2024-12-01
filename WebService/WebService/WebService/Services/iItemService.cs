using System.Collections;
using WebService.Models;
using WebsServices.Requests;

namespace WebService.Services
{
    public interface iItemService
    {
        IEnumerable<ItemResponse> GetAll();
        void Add(ItemRequest item);
        void Update(ItemRequest item);
        void Delete(ItemRequest item);
    }
}
