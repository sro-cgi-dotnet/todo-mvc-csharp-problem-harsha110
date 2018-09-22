using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace harsha {
public class Student
{
    [Key]
    public int NoteId { get; set; }
    [Required]
    public string Title { get; set; }
    public string Plaintext { get; set; }

    public bool Pinned { get; set; }

    public List<Labels> Many_values { get; set; }
    public List<Checklist> Many_values_ch { get; set; }

    //public List<Labels> L1 {get; set;}

   // public List<Checklist> C1 {get; set;}

}

public class Labels
{
    [Key]
    public int Label_Id {get;set;}
    public string Label { get; set; }
    
    public int NoteId{get;set;}
    //public Student student {get;set;}
    //public int NoteId{get ; set;}
}

public class Checklist {
    [Key]
    public int checklist_Id {get;set;}
public string Checklists { get; set; }
public int NoteId {get;set;}
//public Student student {get;set;}

 }


}