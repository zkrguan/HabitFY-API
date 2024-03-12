using AutoMapper;
using HabitFY_API.DTOs.ProgressRecord;
using HabitFY_API.Interfaces.Services;
using HabitFY_API.Models;
using HabitFY_API.Repositories.UnitOfWork;

namespace HabitFY_API.Services
{
    public class ProgressRecordService : IProgressRecordService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        public ProgressRecordService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public GetProgressRecordDTO CreateProgressRecord(CreateProgressRecordDTO dto)
        {
            var foundGoal = _unitOfWork.Goal.GetById(dto.GoalId);
            if (foundGoal != null)
            {
                var record = _mapper.Map<CreateProgressRecordDTO, ProgressRecord>(dto, opt => opt.Items["Goal"] = foundGoal);
                _unitOfWork.ProgressRecord.Add(record);
                _unitOfWork.Save();
                return _mapper.Map<ProgressRecord, GetProgressRecordDTO>(record);
            }
            else
            {
                throw new Exception("The goal was not found");
            }
        }

        public GetProgressRecordDTO GetProgressRecord(int id)
        {
            return _mapper.Map<ProgressRecord,GetProgressRecordDTO>(_unitOfWork.ProgressRecord.GetById(id));
        }

        public IEnumerable<GetProgressRecordDTO> GetProgressRecordsByGoalId(int goalId)
        {
            return _mapper.Map<IEnumerable<ProgressRecord>, IEnumerable<GetProgressRecordDTO>>(_unitOfWork.ProgressRecord.GetRecordsByGoalId(goalId));
        }
    }
}
