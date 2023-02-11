using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class Category:IEntity
    {
        //Çıplak class kalmasın - Interface implementation yap -
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
