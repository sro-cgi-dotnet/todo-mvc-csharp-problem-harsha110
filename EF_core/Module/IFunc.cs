using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using harsha;
using Microsoft.EntityFrameworkCore;
using data_name;

namespace Ifunc{
    public interface IFunction
    {
         List<Student> Get_all_title(string title);
         List<Student> Get_all();
         List<Student> Get_all_label(string title);

         List<Student> Get_all_pinned(string title);

         bool insert_in(Student o);
         bool update_in(Student up);
         bool remove_in(string remove_record);
         

    }

}