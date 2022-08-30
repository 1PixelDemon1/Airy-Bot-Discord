using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiryBot
{
    internal class Respond
    {
        private List<Activity> activities;

        public Respond() 
        {
            activities = new List<Activity>();
        }

        public bool isActivity(string message) => (message.StartsWith('!'));
        public void addActivity(Activity activity) => activities.Add(activity);
        public void performActivity(string message) 
        {
            foreach (var activity in activities) 
            {
                if (message.ToLower().Contains(activity.getKeyword()))
                {
                    activity.perform();
                }
            }
        }
    }

}
