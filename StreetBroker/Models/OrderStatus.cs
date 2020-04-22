using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreetBroker.Models
{
    public enum OrderStatus:byte
    {
        None =0,
        New = 1,
        Waiting = 2,
        Ok =3
    }
}
