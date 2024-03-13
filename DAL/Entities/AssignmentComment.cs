using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class AssignmentComment : IEntity
    {
        public int Id { get ; set ; }
        public string Text { get; set; }
        public Assignment Assignment { get; set; }
    }
}
