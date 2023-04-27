using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Data_Structure
{
    interface IModel
    {

    }
    internal class Teacher : Person,IModel
    {
        
    }
    internal class Student : Person
    {
        public string Name { get; set; }
    }
    internal class Person
    {

    } 
}
