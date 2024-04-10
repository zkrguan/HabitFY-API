using HabitFY_API.DTOs.ProgressRecord;

namespace HabitFY_API.Interfaces.Services
{
    public interface IProgressRecordService
    {
        public Task<IEnumerable<GetProgressRecordDTO>>  GetProgressRecordsByGoalId(int goalId, DateTime queryDate);
        public Task<GetProgressRecordDTO> GetProgressRecord(int id);
        public Task<GetProgressRecordDTO> CreateProgressRecord (CreateProgressRecordDTO dto);
    }
}
