using BlogAPI.Data.Managers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Data.Managers
{
    public class PostTimeManager : IPostTimeManger
    {
        public string GetDefaultTimezone()
        {
            return "EST";
        }

        public DateTime GetCurrentDateAndTime()
        {
            return DateTime.Now;
        }
    }
}
