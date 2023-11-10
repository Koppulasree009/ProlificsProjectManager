using System;
using System.Collections.Generic;
namespace PPM.Model
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<int> ProjectEmployeeList{get;set;} = new List<int>();
    }
}