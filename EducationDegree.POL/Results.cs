using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationDegree.POL
{
    public class Results<T>
    {
        public T Value { get; set; }
        public bool IsSuccessfull { get; set; }
        public List<T> Val { get; set; }
        public string Message { get; set; }
        public Results()
        {
        }
    }
}
