using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarStoreMVC.Models
{
    public class contact
    {

        //here we use the getter setter method to pass the value from front-end to back-end 

        public String txt_Name { get; set; }
        public String txt_Email { get; set; }
        public String txt_Contact { get; set; }
        public String txt_Msg { get; set; }
    }
}