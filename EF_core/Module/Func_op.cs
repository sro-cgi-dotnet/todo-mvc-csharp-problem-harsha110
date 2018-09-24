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
    public class Function_op:IFunction
    {
         public List<Student> Get_all()
         {
              List<Student> all;
            SchoolContext ob = new SchoolContext();
                             all = ob.Students
                           .Include(s => s.Many_values)
                           .Include(s => s.Many_values_ch).ToList();
                            return all;
         }

         public List<Student> Get_all_title(string title)
         {
             SchoolContext ob = new SchoolContext();
              List<Student> all=null;
              all = ob.Students
                            .Where(s=>s.Title==title)
                           .Include(s => s.Many_values)
                           .Include(s => s.Many_values_ch).ToList();
                           return all;
         }

         public List<Student> Get_all_label(string title)
         {
                SchoolContext ob = new SchoolContext();
               List<Student> all_labels = null;
                List<Student> all_ans = new List<Student>();
             all_labels = ob.Students
            .Include(s => s.Many_values)
            .Include(l => l.Many_values_ch).ToList();
            foreach(Student S in all_labels)
                {
                    foreach(Labels each_one in S.Many_values)
                        {
                            if(each_one.Label==title)
                                {
                                    all_ans.Add(S);
                                }
                        }              
                }
            return all_ans;    
         }

          public List<Student> Get_all_pinned(string title)
         {
             SchoolContext ob = new SchoolContext();
               List<Student> all_pin_values = ob.Students
                            .Where(s=>s.Pinned==true)
                           .Include(s => s.Many_values)
                           .Include(s => s.Many_values_ch).ToList();
                           return all_pin_values;
         }


          public bool insert_in(Student o)
         {
             SchoolContext ob = new SchoolContext();
            ob.Students.Add(o);
            if(o.Many_values_ch.Count>0)
           {
               foreach(Checklist One_ch in o.Many_values_ch)
               {
                   ob.Ch1.Add(One_ch);
               }
                
           }
           
           if(o.Many_values.Count>0)
           {
               foreach(Labels One in o.Many_values)
               {
                   ob.L1.Add(One);
               }
                   
           }
           ob.SaveChanges();
           return true;
         }

         public bool update_in(Student up)
         {
             SchoolContext ob = new SchoolContext();
                ob.Update<Student>(up);
                ob.SaveChanges();
                //Student update_value = new Student();
                 //update_value.NoteId=id;
                 
                foreach(Labels L in up.Many_values)
                {
                       
                    ob.Update<Labels>(L);
                    ob.SaveChanges();
                  
                 }

                 foreach(Checklist C in up.Many_values_ch)
                {
                       
                    ob.Update<Checklist>(C);
                    ob.SaveChanges();
                  
                 }
           return true;
         }

       public bool remove_in(string remove_record)
         {
             SchoolContext ob = new SchoolContext();
            List<Student> all=null;
            all = ob.Students
            .Where(s=>s.Title==remove_record)
            .Include(s => s.Many_values)
            .Include(s => s.Many_values_ch).ToList();
            if(all.Count>0)
            {
                ob.RemoveRange(all);
                ob.SaveChanges();
                return true;
            }  
            return false;
         }


    }


}