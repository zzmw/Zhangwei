using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly OrderDbContext orderDbCtx;
        

        public ValuesController(OrderDbContext context){
            this.orderDbCtx=context;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Item>> GetAllRecords()
        {
            return orderDbCtx.Items.ToList();
            
        }

        // GET api/values/1
        [HttpGet("{id}")]
        public ActionResult<Item> GetRecord(long id)
        {
            var item=orderDbCtx.Items.Find(id);
            if(item==null){
                return NotFound();
            }
            return item;
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Item> PostNewRecord(Item item) 
        {
            orderDbCtx.Items.Add(item);
            orderDbCtx.SaveChanges();
            return item;
            
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Item> PutUpdatedRecord(long id, Item item)
        {
            if(id!=item.Id){
                return BadRequest();
            }
            orderDbCtx.Entry(item).State=EntityState.Modified;
            orderDbCtx.SaveChanges();
            return NoContent();

        }

        // DELETE api/values/1
        [HttpDelete("{id}")]
        public ActionResult<Item> DeleteRecord(long id)
        {
            var item=orderDbCtx.Items.Find(id);

            if(item==null){
                return NotFound();
            }

            orderDbCtx.Items.Remove(item);
            orderDbCtx.SaveChanges();
            return NoContent();
        }
    }
}
