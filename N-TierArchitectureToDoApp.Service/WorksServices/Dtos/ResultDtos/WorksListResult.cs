﻿namespace N_TierArchitectureToDoApp.Service.WorksServices.Dtos.ResultDtos
{
    public class WorksListResult
    {
        public int Id { get; set; }
        public string? Description { get; set; } = null!;
        public bool IsCompleted { get; set; }
    }
}
