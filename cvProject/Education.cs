using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cvProject
{
    [Serializable]
    class Education : cvSections
    {
        protected string institution, degree, major, description; 
        public Education() 
        {
            institution = "";
            degree = "";
            major = "";            
        }
        public Education(string institution, string degree, string major, string description, string startdate, string enddate, string index) : base(startdate, enddate, index)
        {
            INSTITUTION = institution;
            DEGREE = degree;
            MAJOR = major;
            DESCRIPTION = description;            
        }
        public override void addToList()
        {
            Program.DataEducationList.Add(this);
        }
        public override void RemoveItemFromList()
        {
            Program.DataEducationList.Remove(this);
        }
        public string INSTITUTION
        {
            get { return institution; }

            set { this.institution = value; }

        }
        public string DEGREE
        {
            get { return degree; }

            set { this.degree = value; }

        }
        public string MAJOR
        {
            get { return major; }

            set { this.major = value; }

        }
        public string DESCRIPTION
        {
            get { return description; }

            set { this.description = value; }

        }

    }
}
