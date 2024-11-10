using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cvProject
{
    [Serializable]
    class cvComponent
    {
        protected string Title;
        protected int DisplayOrder;
        public static List<cvComponent> cvList = new List<cvComponent>();
        
        public cvComponent()
        {
            Title = " ";
            DisplayOrder = 0;
        }
        public cvComponent(string title, int index)
        {
            TITLE = title;
            DISPLAYTORDER = index;            
        }
        public bool checkIfObjectInTheList()
        {
            foreach (cvComponent cv in cvComponent.cvList)
            {
                if (cv.TITLE == this.TITLE)
                    return true;                
            }
            return false;
        }
       
        public string TITLE
        {
            get { return Title; }
            set { this.Title = value; }
        }
        public int DISPLAYTORDER
        {
            get { return DisplayOrder; }
            set { this.DisplayOrder = value; }
        }

        public virtual void addTocvCompList()
        {

        }

    }
   
}
