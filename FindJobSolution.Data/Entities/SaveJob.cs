using FindJobSolution.Data.Enums;

namespace FindJobSolution.Data.Entities
{
    public class SaveJob
    {
        public int JobSeekerId { get; set; }
        public JobSeeker JobSeeker { get; set; }
        public int JobInformationId { get; set; }
        public JobInformation JobInformation { get; set; }
        public Status Status { get; set; }
        public DateTime TimeSave { get; set; }
    }
}
