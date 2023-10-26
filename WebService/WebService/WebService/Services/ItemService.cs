using Microsoft.EntityFrameworkCore;
using WebService.Data;
using WebService.Models;

namespace WebService.Services
{
    public class ItemService : iItemService
    {
        private readonly db_warehouseContext _context;
        public ItemService(db_warehouseContext context)
        {
            _context = context;
        }
        public IEnumerable<ItemResponse> Get()
        {
            var items = _context.Items.Include(o => o.MaterialNavigation).Include(o => o.CategoryNavigation).Include(o => o.LocationNavigation).Include(o => o.MeasureNavigation);

            var result = items.Select(o => new ItemResponse{
                Code = o.Code,
                Name = o.Name,
                Description = o.Description,
                Measure = o.MeasureNavigation.Symbol,
                Category = o.CategoryNavigation.Name,
                Location = o.LocationNavigation.Name,
                Material = o.MaterialNavigation.Nombre,
                Quantity = o.Quantity

            });
            return result.ToList();
        }

        public void Add()
        {

        }

        public void Update()
        {

        }

        public void Delete()
        {

        }
    }
}
