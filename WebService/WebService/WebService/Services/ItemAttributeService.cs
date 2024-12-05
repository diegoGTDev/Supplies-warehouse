using WebService.Data;
using Microsoft.AspNetCore.Mvc;
using WebService.Models.Response;
using WebService.Services;

namespace WebService.Services{
    public class ItemAttributeService : iItemAttributeService{
        private db_warehouseContext _context;

        public ItemAttributeService(db_warehouseContext context){
            _context = context;
        }

        public ItemAttributeResponse GetAll(){
            var response = new ItemAttributeResponse();
            response.location = _context.Locations.Select(o => o.Name).ToArray();
            response.material = _context.Materials.Select(o => o.Nombre).ToArray();
            response.category = _context.Categories.Select(o => o.Name).ToArray();
            response.measure = _context.Measures.Select(o => o.Symbol).ToArray();
        
            return response;
        }
    }
}