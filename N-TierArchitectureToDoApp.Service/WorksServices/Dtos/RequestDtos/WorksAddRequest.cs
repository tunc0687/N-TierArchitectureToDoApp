using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_TierArchitectureToDoApp.Service.WorksServices.Dtos.RequestDtos
{
    public class WorksAddRequest
    {
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}
