using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SinglePageTestTask.Data 
{
    public class UserLogin
    {
        [Key, Required(ErrorMessage = "Поле должно быть установлено")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено"), /*DateTime(),*/ DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateRegistration { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено"), DataType(DataType.DateTime)]
        public DateTime DateLastActivity { get; set; } 

    }
   
}
