using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Data.Managers.Interfaces
{
    public interface IPostTimeManger
    {
        public string GetDefaultTimezone();
        public DateTime GetCurrentDateAndTime();
    }
}
