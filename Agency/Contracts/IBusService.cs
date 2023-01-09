using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgencyServices.Contracts
{
    public interface IBusService
    {
        JsonResult CreateBus();
        JsonResult UpdateBus();
        JsonResult DeleteBus();
        JsonResult GetBus();
        JsonResult GetAllBuses();
    }
}
