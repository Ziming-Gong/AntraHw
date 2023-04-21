using System;
namespace ApplicationCore.Models
{
	public class JobRequirementResponseModel
	{
		public int Id { get; set; }
		public int NumberOfPosition;
		public string? Title { get; set; }
        public string? Description { get; set; }
        public int? HiringManagerId { get; set; }
        public string? HiringManagerName { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CloseOn { get; set; }
        public string? ClosedReason { get; set; }
        public DateTime CreateOn { get; set; }
		public int? JobCategoryId { get; set; }
        public string ActionRoute { get; set; }

    }
}

