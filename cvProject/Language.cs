using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cvProject
{
    [Serializable]
    class Language:cvComponent
    {
        protected string language;
        protected int level;

        public Language() :base("Language", 3)
        {
            language = "";
            level = 0;
        }
        public Language(string language , int level, string title, int index) : base(title, index)
        {
            LANGUAGE = language;
            LEVEL = level;
        }

        public string LANGUAGE
        {
            get { return language; }
            set { this.language = value; }
        }
        public int LEVEL
        {
            get { return level; }
            set { this.level = value; }
        }
        public override void addTocvCompList()
        {
            cvList.Add(new cvComponent(base.Title, base.DisplayOrder));
        }

    }
}
