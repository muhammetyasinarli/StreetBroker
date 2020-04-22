using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreetBroker.Common
{
    public enum RecordStatus:byte
    {
        Active,
        Passive
    }
    public static class RecordStatusExtension
    {
        public static string ToDbString(this RecordStatus recordStatus)
        {
            switch (recordStatus)
            {
                case RecordStatus.Active:
                    return "A";
                case RecordStatus.Passive:
                    return "P";
                default:
                    return "";
            }
        }
    }
}
