namespace N_TierArchitectureToDoApp.Service.WorksServices.Dtos.RequestDtos
{
    public class WorksUpdateRequest
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}
