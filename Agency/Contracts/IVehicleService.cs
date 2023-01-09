using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgencyServices.Contracts
{
     public interface IVehicleService
    {
        JsonResult DeleteVehicle();
        JsonResult GetVehicle();
        JsonResult GetAllVehicles();
    }
}
