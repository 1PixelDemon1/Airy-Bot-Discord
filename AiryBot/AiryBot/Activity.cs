using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AiryBot
{
    internal class Activity
    {
        public delegate void act(List<object> parametres);

        private string keyword;
        private List<object> parametres;
        private act action;

        public Activity(string keyword_, List <object> parametres_, act action_) {
            keyword = keyword_;
            parametres = parametres_;
            action = action_;
        }
        public void perform() => action(parametres);

        public string getKeyword() => keyword;
    }
}
