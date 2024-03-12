using HabitFY_API.DTOs.ProgressRecord;

namespace HabitFY_API.Interfaces.Services
{
    public interface IProgressRecordService
    {
        public IEnumerable<GetProgressRecordDTO> GetProgressRecordsByGoalId(int goalId);

        public GetProgressRecordDTO GetProgressRecord(int id);

        public GetProgressRecordDTO CreateProgressRecord (CreateProgressRecordDTO dto);

        // Don't let user to change the ProgressRecord, so they can take this seriously
        // Otherwise, they could lie to themselves. 
        // Also, frontend should make them understand, once confirmed, there is no way to change. 
    }
}
