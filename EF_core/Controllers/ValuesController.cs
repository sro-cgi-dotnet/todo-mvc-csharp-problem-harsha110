using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using harsha;
using Microsoft.EntityFrameworkCore;
using data_name;
using func_op;
using Ifunc;
namespace EF_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        IFunction F=null;
        public  ValuesController(IFunction base1)
        {
          this.F=base1;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            
            List<Student> all= F.Get_all();
            //SchoolContext ob = new SchoolContext();
                           if(all.Count>0)
                           {
                           return Ok(all);
                           }
                           return BadRequest("No references in the table");
        }

        // GET api/values/5
        [HttpGet("{title}")]
        //[Route("api/values/{id}")]
        public IActionResult Get(string title, [FromQuery] string type)
        {
            //SchoolContext op = new SchoolContext();
            //List<Student> val = op.one(id);
            //SchoolContext ob = new SchoolContext();
            List<Student> all=null;
             SchoolContext ob = new SchoolContext();
            if(type=="title")
            {
                
                             all = F.Get_all_title(title);
                           if(all.Count>0)
                           {
                           return Ok(all);
                           }
                           return BadRequest("The title does not exist");
                          
            }

            else if(type=="label")
            {
                all=F.Get_all_label(title);
                if(all.Count>0)
                           {
                           return Ok(all);
                           }
                           return BadRequest("The title does not exist");

            }
            else if(type=="pinned")
            {
                if(title=="true")
                {
               List<Student> all_pin_values = F.Get_all_pinned(title);
                           if(all_pin_values.Count>0)
                           {
                           return Ok(all_pin_values);
                           }
                           return BadRequest("The title does not exist");   
                }
                else
                return Ok("Pinned value should be true only");
            }
             return BadRequest("The title or label  does not exist");
        }
  

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Student o)
        {
            SchoolContext ob = new SchoolContext();
            //SchoolContext ob = new SchoolContext();
            if(o!=null)
            {
               bool val = F.insert_in(o);
       
                return Ok("Data inserted correctly in the database");
            }
            return Ok("null values are not excepted");

        }
       

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put( [FromBody] Student up)
        {
            SchoolContext ob = new SchoolContext();
            if (up != null)
            {
                bool val = F.update_in(up);
                    // ob.Update<>
                 if(val==true)
                 {   
                   return Ok("updated correctly");
                 }  
            }
                return Ok("Empty value entered  , Please give some text to update table");
            }

        // DELETE api/values/5
        [HttpDelete("{remove_record}")]
        public IActionResult Delete(string remove_record)
        {
                SchoolContext ob = new SchoolContext();
                bool val =F.remove_in(remove_record ); 
                if(val==true)
                return Ok("Data deleted from table");
           
                return BadRequest("Could not delete as the entry does not exist");
        }
    }
}
