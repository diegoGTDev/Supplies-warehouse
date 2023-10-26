using System.Collections;
using WebService.Models;

namespace WebService.Services
{
    public interface iItemService
    {
        IEnumerable<ItemResponse> Get();
        void Add();
        void Update();
        void Delete();
    }
}
