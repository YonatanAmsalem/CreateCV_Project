using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cvProject
{
    [Serializable]
    class PersonalInfo : cvComponent
    {
        protected string FirstName, LastName, DateOfBirth, Email, Adrress;  
        protected string imagepath, id, Phone;

        public PersonalInfo() : base("Personal Information", 0)
        {
            FirstName = "";
            LastName = "";
            DateOfBirth = "";
            Email = "";
            Adrress = "";
            id = "";
            imagepath = "";
            Phone = "";
        }
        public PersonalInfo(string FirstName, string LastName, string DateOfBirth, string Email, string Adrress, string id, string title, int displayOrder, string phone, string imagepath) : base(title, displayOrder)
        {
            firstNAME = FirstName;
            LastNAME = LastName;
            dateofBIRTH = DateOfBirth;
            EMAIL = Email;
            ADDRESS = Adrress;
            ID = id;          
            PHONE = phone;
            IMAGEPATH = imagepath;
        }
        public string firstNAME
        {
            get
            { return FirstName; }

            set { this.FirstName = value; }
        }
        public string LastNAME
        {
            get { return LastName; }

            set { this.LastName = value; }
        }
        public string dateofBIRTH
        {
            get { return DateOfBirth; }

            set { this.DateOfBirth = value; }
        }
        public string EMAIL
        {
            get { return Email; }

            set { this.Email = value; }

        }
        public string ADDRESS
        {
            get { return Adrress; }

            set { this.Adrress = value; }

        }
        public string ID
        {
            get { return id; }

            set { this.id = value; }
        }
        public string IMAGEPATH
        {
            get { return imagepath; }

            set { this.imagepath = value; }
        }
        public string PHONE
        {
            get { return Phone; }

            set { this.Phone = value; }
        }
        public override void addTocvCompList()
        {
            cvList.Add(new cvComponent(base.Title, base.DisplayOrder));
        }
    }


}
