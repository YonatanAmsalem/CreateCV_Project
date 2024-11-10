using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cvProject
{
    [Serializable]
    class cvSections : cvComponent
    {        
        protected string startdate, enddate, index;
        public cvSections() 
        {
            startdate = "";
            enddate = "";
            index = "";
        }
        public cvSections(string startdate, string enddate, string index)
        {
            STARTDATE = startdate;
            ENDDATE = enddate;
            INDEX = index;
        }
        public virtual void addToList() { }

        public virtual void RemoveItemFromList() { }

        public void SetTitleAndOrder(string title, int order)
        {            
            //Polymorphism
            cvComponent cvObj = new cvSections();           
            cvObj.TITLE = title;
            cvObj.DISPLAYTORDER = order;
            if(!cvObj.checkIfObjectInTheList())
                cvObj.addTocvCompList();
        }
        public override void addTocvCompList()
        {
            cvList.Add(new cvComponent(Title, base.DisplayOrder));            
        }

        //properties
        public string STARTDATE
        {
            get { return startdate; }

            set { this.startdate = value; }

        }
        public string ENDDATE
        {
            get { return enddate; }

            set { this.enddate = value; }

        }
        public string INDEX
        {
            get { return index; }

            set { this.index = value; }

        }
    }

}
