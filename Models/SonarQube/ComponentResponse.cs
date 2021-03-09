using System;
using System.Collections.Generic;
using System.Text;

namespace Models.SonarQube
{
    public class ComponentResponse
    {
        public Paging paging { get; set; }
        public List<Component> components { get; set; }
    }

    public class Paging
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public int total { get; set; }
    }

    public class Component
    {
        public string organization { get; set; }
        public string key { get; set; }
        public string name { get; set; }
        public string qualifier { get; set; }
        public string project { get; set; }
    }
}
