using System;
using System.Collections.Generic;

namespace N_TierArchitectureToDoApp.DataDomain.Entities
{
    public partial class Work
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public bool IsCompleted { get; set; }
    }
}
