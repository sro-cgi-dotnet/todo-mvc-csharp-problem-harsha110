using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using harsha;
using Microsoft.EntityFrameworkCore;
using data_name;
using Ifunc;
namespace func_op
{
    public class MFunct
    {
        IFunction feed;
        public List<Student> Get_all()
        {
            List<Student> S = new List<Student>{
                new Student{
        NoteId= 6,
        Title= "sehwag",
        Plaintext= "lists",
        Pinned= true,
        Many_values = null,
        Many_values_ch=null
                            }
            };
        return S;
        }
         public List<Student> Get_all_title(SchoolContext ob,string title)
         {
              List<Student> all=null;
            
                           return all;
         }

         public List<Student> Get_all_label(SchoolContext ob,string title)
         {
               List<Student> all_ans = null;

            return all_ans;    
         }

          public List<Student> Get_all_pinned(SchoolContext ob,string title)
         {
               List<Student> all_pin_values = null;
                           return all_pin_values;
         }


          public bool insert_in(SchoolContext ob,Student o)
         {
           
           return true;
         }

         public bool update_in(SchoolContext ob,Student up)
         {
               
           return true;
         }

       public bool remove_in(SchoolContext ob,string remove_record)
         {
            
            return false;
         }


    }


}