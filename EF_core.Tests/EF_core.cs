using System;
using Xunit;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using EF_core.Controllers;
using harsha;
using Ifunc;
using data_name;
using func_op;

namespace EF_core.Tests
{
    public class UnitTest1
    {
          
            public List<Student> DummyMock(){
            return new List<Student>{
                new Student{
                    NoteId = 1,
                    Title = "vvs laxman and me",
                    Plaintext = "Nothing as such",
                    Pinned = false,
                    Many_values_ch = new List<Checklist>{
                        new Checklist{
                            checklist_Id = 1,
                            Checklists = "Laptop",
                            NoteId = 1
                        }, new Checklist{
                            checklist_Id = 2,
                            Checklists = "Bike",
                            NoteId = 1
                        }
                    },
                    Many_values = new List<Labels>{
                        new Labels{
                            Label_Id = 1,
                            Label = "Casual",
                            NoteId = 1
                        }
                    }
                },
                new Student{
                    NoteId = 2,
                    Title = "Courses",
                    Pinned=true,
                    Many_values_ch = new List<Checklist>{
                        new Checklist{
                        checklist_Id = 3,
                            Checklists = "Bootstrap",
                            NoteId = 2
                        }
                    },
                    Many_values = new List<Labels>{
                        new Labels{
                            Label_Id = 2,
                            Label = ".Net",
                            NoteId = 2
                        }, new Labels{
                            Label_Id = 3,
                            Label = "Casual",
                            NoteId = 2
                        }
                    }
                },
                new Student{
                    NoteId = 2,
                    Title = "Courses",
                    Pinned=false,
                    Many_values_ch = new List<Checklist>{
                        new Checklist{
                        checklist_Id = 3,
                            Checklists = "Bootstrap",
                            NoteId = 2
                        }
                    },
                    Many_values = new List<Labels>{
                        new Labels{
                            Label_Id = 2,
                            Label = ".Net",
                            NoteId = 2
                        }, new Labels{
                            Label_Id = 3,
                            Label = "Casual",
                            NoteId = 2
                        }
                    }
                },
                new Student{
                    NoteId = 2,
                    Title = "Courses",
                    Pinned=false,
                    Many_values_ch = new List<Checklist>{
                        new Checklist{
                        checklist_Id = 3,
                            Checklists = "Bootstrap",
                            NoteId = 2
                        }
                    },
                    Many_values = new List<Labels>{
                        new Labels{
                            Label_Id = 2,
                            Label = ".Net",
                            NoteId = 2
                        }, new Labels{
                            Label_Id = 3,
                            Label = "adidas",
                            NoteId = 2
                        }
                    }
                }
            };
        } 



[Fact] 
        public void GetAllNote_PositiveTest(){
            List<Student> dummy = DummyMock();  // Arrange
             IFunction F = new Function_op();
            Mock<IFunction> MockRepository = new Mock<IFunction>(); // Removing Dependency
            MockRepository.Setup(d => d.Get_all()).Returns(DummyMock());
           
             ValuesController controller_m = new ValuesController(MockRepository.Object); // Act
            var dummy1 = controller_m.Get();

            var objresult = dummy1 as OkObjectResult;
            Assert.NotNull(objresult);
            var model = objresult.Value as List<Student>;

               ValuesController controller = new ValuesController(F);  
                var actual = controller.Get();
              var okObjectResult = actual as OkObjectResult;
              var actual_ans = okObjectResult.Value as List<Student>;
             
            //Assert.NotNull(actual); // Assert
            Assert.Equal(actual_ans.Count , model.Count);

        }
[Fact] 
        public void GetAllNoteTitle_PositiveTest(){
            IFunction F = new Function_op();
            string title="vvs laxman and me";
            string Type ="title";
            List<Student> dummy = DummyMock();
            
            Mock<IFunction> MockRepository = new Mock<IFunction>();
            MockRepository.Setup(d => d.Get_all_title(title)).Returns(dummy.FindAll(d=>d.Title==title));
             ValuesController controller_m = new ValuesController(MockRepository.Object);

            var dummy1 = controller_m.Get(title,Type);
             // dummy1 = ModelFromActionResult<SomeViewModelClass>(dummy1);
             var objresult = dummy1 as OkObjectResult;
            Assert.NotNull(objresult);
             var model = objresult.Value as List<Student>;

            Assert.Equal(1 , model.Count);
            
        }
[Fact] 
                public void GetAllNotePinned_PositiveTest(){
                    IFunction F = new Function_op();
                    string pin="true";
                    string title="pinned";
            List<Student> dummy = DummyMock();  // Arrange
            
            Mock<IFunction> MockRepository = new Mock<IFunction>(); // Removing Dependency
            MockRepository.Setup(d => d.Get_all_pinned(pin)).Returns(dummy.FindAll(d=>d.Pinned==true));
             ValuesController controller_m = new ValuesController(MockRepository.Object); 

            var dummy1 = controller_m.Get(pin,title);
             // dummy1 = ModelFromActionResult<SomeViewModelClass>(dummy1);
             var objresult = dummy1 as OkObjectResult;
            Assert.NotNull(objresult);
             var model = objresult.Value as List<Student>;
            Assert.Equal(1 , model.Count);
        }

[Fact] 
                public void GetAllNotelabel_PositiveTest(){
                    IFunction F = new Function_op();
                    string Type="label";
                    string title="adidas";
            List<Student> dummy = DummyMock();
            List<Student> dummy2 = new List<Student>();  // Arrange
            foreach(Student S in dummy )
            {
                foreach(Labels l in S.Many_values)
                {
                if(l.Label==title)
                dummy2.Add(S);
                }
            }
            Mock<IFunction> MockRepository = new Mock<IFunction>(); // Removing Dependency
            MockRepository.Setup(d => d.Get_all_label(title)).Returns (dummy2);
             ValuesController controller_m = new ValuesController(MockRepository.Object);

            var dummy1 = controller_m.Get(title,Type);
             // dummy1 = ModelFromActionResult<SomeViewModelClass>(dummy1);
             var objresult = dummy1 as OkObjectResult;
            Assert.NotNull(objresult);
             var model = objresult.Value as List<Student>;
            Assert.Equal(1 , model.Count);
        }

[Fact] 
                public void Getupdate_PositiveTest(){
                    IFunction F = new Function_op();
            Student S = new Student {
                    NoteId = 6,
                    Title = "vvs laxman and sehwag",
                    Plaintext = "Nothing as such",
                    Pinned=false,
                    Many_values_ch = new List<Checklist>{
                        new Checklist{
                            checklist_Id = 6,
                            Checklists = "Laptop",
                            NoteId = 6
                        }, new Checklist{
                            checklist_Id = 7,
                            Checklists = "Bike",
                            NoteId = 6
                        }
                    },
                    Many_values = new List<Labels>{
                        new Labels{
                            Label_Id = 6,
                            Label = "Casual",
                            NoteId = 6
                        }
                    }
         
            };      
                
 // Arrange
            
            Mock<IFunction> MockRepository = new Mock<IFunction>(); // Removing Dependency
            MockRepository.Setup(d => d.update_in(S)).Returns(true);
             ValuesController controller_m = new ValuesController(MockRepository.Object); 

            var dummy1 = controller_m.Put(S);
             // dummy1 = ModelFromActionResult<SomeViewModelClass>(dummy1);
             var objresult = dummy1 as OkObjectResult;
            Assert.NotNull(objresult);
             var model = objresult.Value as string;

            ValuesController controller = new ValuesController(F);  
            var actual = controller.Put(S);
            var okObjectResult = actual as OkObjectResult;
            var actual_ans = okObjectResult.Value as string;
            Assert.Equal(actual_ans , model);
        }

         public void Getenter_PositiveTest(){
                    IFunction F = new Function_op();
            Student S = null;      
                
 // Arrange
            
            Mock<IFunction> MockRepository = new Mock<IFunction>(); // Removing Dependency
            MockRepository.Setup(d => d.insert_in(S)).Returns(true);
             ValuesController controller_m = new ValuesController(MockRepository.Object); 

            var dummy1 = controller_m.Post(S);
             // dummy1 = ModelFromActionResult<SomeViewModelClass>(dummy1);
             var objresult = dummy1 as OkObjectResult;
            Assert.NotNull(objresult);
             var model = objresult.Value as string;

            ValuesController controller = new ValuesController(F);  
            var actual = controller.Post(S);
            var okObjectResult = actual as OkObjectResult;
            var actual_ans = okObjectResult.Value as string;
            Assert.Equal(actual_ans , model);
        }               
[Fact]         

         public void Getdeleted_PositiveTest(){
                    IFunction F = new Function_op();
                    string title="";
            string dummy = "Data deleted from table"; // Arrange
            
            Mock<IFunction> MockRepository = new Mock<IFunction>(); // Removing Dependency
            MockRepository.Setup(d => d.remove_in(title)).Returns(true);
             ValuesController controller_m = new ValuesController(MockRepository.Object); 

            var dummy1 = controller_m.Delete(title);
             // dummy1 = ModelFromActionResult<SomeViewModelClass>(dummy1);
             var objresult = dummy1 as OkObjectResult;
            Assert.NotNull(objresult);
             var model = objresult.Value as string;
            Assert.Equal(dummy , model);
        }



    }                





    }
