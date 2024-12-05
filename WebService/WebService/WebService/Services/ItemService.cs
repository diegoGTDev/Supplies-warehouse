using Microsoft.EntityFrameworkCore;
using WebService.Data;
using WebService.Models;
using WebsServices.Requests;

namespace WebService.Services
{
    public class ItemService : iItemService
    {
        private readonly db_warehouseContext _context;
        public ItemService(db_warehouseContext context)
        {
            _context = context;
        }
        public IEnumerable<ItemResponse> GetAll()
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

        public void Add(ItemRequest item)
        {

            //get the id of the category, measure, location and material
            var category = _context.Categories.Where(o => o.Name == item.Category).Select(o => o.CategoryId).FirstOrDefault();
            var measure = _context.Measures.Where(o => o.Symbol == item.Measure).FirstOrDefault().MeasureId;
            var location = _context.Locations.Where(o => o.Name == item.Location).FirstOrDefault().LocationId;
            var material = _context.Materials.Where(o => o.Nombre == item.Material).FirstOrDefault().MaterialId;
            if (item.Code == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            var newItem = new Item
            {
                Code = item.Code,
                Name = item.Name,
                Description = item.Description,
                Measure = measure,
                Category = category,
                Location = location,
                Material = material,
                Quantity = item.Quantity
            };

            _context.Items.Add(newItem);
            _context.SaveChanges();
        }

        

        public void Update(ItemRequest item)
        {

            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            var existingItem = _context.Items.Find(item.Code);
            if (existingItem == null){
                throw new KeyNotFoundException("Item not found");
            }
            // var category = _context.Categories.Find(item.Category); 
            // var measure = _context.Measures.Find(item.Measure);
            // var location = _context.Locations.Find(item.Location);
            // var material = _context.Materials.Find(item.Material);
            // existingItem.Name = item.Name;
            // existingItem.Category = category;
            // existingItem.Description = item.Description;
            // existingItem.Measure = measure;
            // existingItem.Location = location;
            // existingItem.Material = material;
            // existingItem.Quantity = item.Quantity;
            
            try{
                _context.SaveChanges();
            }catch(Exception ex){
                throw new Exception(ex.Message);
            }

        }

        public void Delete(ItemRequest item)
        {
            if(item == null){
                throw new ArgumentNullException(nameof(item));
            }
            var existingItem = _context.Items.Find(item.Code);
            if (existingItem == null){
                throw new KeyNotFoundException("Item not found");
            }
            _context.Items.Remove(existingItem);
            try{
                _context.SaveChanges();
            }catch(Exception ex){
                throw new Exception(ex.Message);
            }
            
        }
    }
}
