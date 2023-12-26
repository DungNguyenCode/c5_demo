using AppData.Context;
using AppData.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppdbContext _dbContext;
        public ProductController()
        {
            _dbContext= new AppdbContext();
        }
        // GET: api/<ProductController>
        [HttpGet("GetAll")]
        public IEnumerable<Product> GetAll()
        {
            return _dbContext.products.ToList();
        }

        // GET api/<ProductController>/5
        [HttpGet("GetByMa/{ma}")]
        public Product GetByMa(string ma)
        { 
            return _dbContext.products.FirstOrDefault(c=>c.Ma == ma);
        }

        // POST api/<ProductController>
        [HttpPost("Post")]
        public bool Post(Product pro)
        {
            _dbContext.products.Add(pro);
            _dbContext.SaveChanges();
            return true;
        }

        // PUT api/<ProductController>/5
        [HttpPut("Put/{ma}")]
        public bool Put(string ma, Product pro)
        {
            var item = _dbContext.products.FirstOrDefault(c=>c.Ma==ma);
            item.NhaSanXuat = pro.NhaSanXuat;
            item.Name  = pro.Name;
            item.Price = pro.Price;
            item.SoTonKho = pro.SoTonKho;
            item.Price = pro.Price;
            _dbContext.products.Update(item);
            _dbContext.SaveChanges();
            return true;
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("Delete/{ma}")]
        public bool Delete(string ma)
        {
            var item = _dbContext.products.FirstOrDefault(c => c.Ma == ma);
           
            _dbContext.products.Remove(item);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
