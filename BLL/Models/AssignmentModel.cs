﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class AssignmentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
