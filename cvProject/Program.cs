using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cvProject
{
    [Serializable]
    static class Program
    {
        public static List<Education> DataEducationList = new List<Education>();
        public static List<WorkExperience> DataWorkExperinceList = new List<WorkExperience>();
        public static List<Language> langList = new List<Language>();
        public static PersonalInfo per = new PersonalInfo();
        public static Boolean checkValidInputName(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                foreach(char i in str)
                {
                    if (!char.IsLetter(i) && i != ' ')
                        return false;
                }
                return true;
            }
            return false;           
        }
        public static Boolean checkValidInputNumeric(string str)
        {
            if (!string.IsNullOrEmpty(str) && (str.All(char.IsDigit)))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new cvProject());
        }
    }
}
