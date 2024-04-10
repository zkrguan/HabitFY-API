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


        public async Task<GetProgressRecordDTO> CreateProgressRecord(CreateProgressRecordDTO dto)
        {
            var foundGoal = await _unitOfWork.Goal.GetById(dto.GoalId);
            if (foundGoal != null)
            {
                var record = _mapper.Map<CreateProgressRecordDTO, ProgressRecord>(dto, opt => opt.Items["Goal"] = foundGoal);
                if(record!=null)
                    await _unitOfWork.ProgressRecord.AddAsync(record);
                    await _unitOfWork.SaveAsync(); 
                // Other business to do //
                return _mapper.Map<ProgressRecord, GetProgressRecordDTO>(record);
            }
            else
            {
                throw new Exception("The goal was not found");
            }
        }

        public async Task<GetProgressRecordDTO> GetProgressRecord(int id)
        {
            return _mapper.Map<ProgressRecord,GetProgressRecordDTO>(await _unitOfWork.ProgressRecord.GetById(id));
        }

        public async Task<IEnumerable<GetProgressRecordDTO>> GetProgressRecordsByGoalId(int goalId, DateTime queryDate)
        {
            return _mapper.Map<IEnumerable<ProgressRecord>, IEnumerable<GetProgressRecordDTO>>(await _unitOfWork.ProgressRecord.GetRecordsByGoalId(goalId,queryDate));
        }
    }
}
