using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class CompanyDepartmentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }
        public int CellPhone { get; set; }
        public string Description { get; set; }
    }
}
