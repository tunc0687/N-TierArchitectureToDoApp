namespace N_TierArchitectureToDoApp.DataDomain.Entities
{
    public partial class Work : BaseEntity
    {
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}
