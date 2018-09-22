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
        SchoolContext ob=null;
        public  ValuesController(SchoolContext base1)
        {
          this.ob=base1;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            private IFunction prvGetMockExchangeRateFeed()
        {
            MFunct Other = new MFunct();
            Mock<IFunction> mockObject = new Mock<IFunction>();
            mockObject.Setup(m => m.Get_all(SchoolContext)).Returns(Other.Get_all());
            return mockObject.Object;
        }
        IFunction feed =prvGetMockExchangeRateFeed();
            List<Student> expectedResult= feed.Get_all();
            Function_op F = new Function_op();
            List<Student> all= F.Get_all(ob);
            //SchoolContext ob = new SchoolContext();
                           if(all.Count>0)
                           {

                            Assert.AreEqual(expectedResult, all);
                           return Ok(all);
                           }
                           return BadRequest("No references in the table");
        }

        // GET api/values/5
        [HttpGet("{title}")]
        //[Route("api/values/{id}")]
        public ActionResult<string> Get(string title, [FromQuery] string type)
        {

             Function_op F = new Function_op();
            if(type=="title")
            {

                             private IFunction prvGetMockExchangeRateFeed()
        {
            MFunct Other = new MFunct();
            Mock<IFunction> mockObject = new Mock<IFunction>();
            mockObject.Setup(m => m.Get_all_title(SchoolContext ,string )).Returns(Other.Get_all_title());
            return mockObject.Object;
        }
        IFunction feed = prvGetMockExchangeRateFeed();
            List<Student> expectedResult= feed.Get_all();
            List<Student> all=null;
                
                             all = F.Get_all_title(ob,title);
                           if(all.Count>0)
                           {
                                Assert.AreEqual(expectedResult, all);
                           return Ok(all);
                           }
                           return BadRequest("The title does not exist");
                          
            }

            else if(type=="label")
            {
                all=F.Get_all_label(ob,title);
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
               List<Student> all_pin_values = F.Get_all_pinned(ob,title);
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
            Function_op F = new Function_op();
            //SchoolContext ob = new SchoolContext();
            if(o!=null)
            {
               bool val = F.insert_in(ob,o);
       
                return Ok("Data inserted correctly in the database");
            }
            return Ok("null values are not excepted");

        }
       

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put( [FromBody] Student up)
        {
            Function_op F = new Function_op();
            if (up != null)
            {
                bool val = F.update_in(ob,up);
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
                Function_op F = new Function_op();
                bool val =F.remove_in(ob,remove_record ); 
                if(val==true)
                return Ok("Data deleted from table");
           
                return BadRequest("Could not delete as the entry does not exist");
        }
    }
}
