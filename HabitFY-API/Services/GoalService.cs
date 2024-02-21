using AutoMapper;
using HabitFY_API.DTOs.Goal;
using HabitFY_API.Interfaces.Repositories;
using HabitFY_API.Interfaces.Services;
using HabitFY_API.Models;
using HabitFY_API.Repositories.UnitOfWork;

namespace HabitFY_API.Services
{
    public class GoalService:IGoalService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GoalService(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IEnumerable<GetGoalDTO> GetGoalsByUserId(string userId)
        {
            return _mapper.Map<IEnumerable<Goal>, IEnumerable<GetGoalDTO>>(_unitOfWork.Goal.GetGoalsByUserId(userId));
        }

        
        // RG: Try Implement this yourself by using _unitOfwork
        public GetGoalDTO GetOneGoalById(int id)
        {
            throw new NotImplementedException();
        }

        //
        public GetGoalDTO CreateGoal(CreateGoalDTO dto)
        {
            var foundUser = _unitOfWork.UserProfile.GetById(dto.ProfileId);
            if (foundUser != null)
            {
                var record = _mapper.Map<CreateGoalDTO, Goal>(dto, opt => opt.Items["UserProfile"] = foundUser);
                #pragma warning disable CS8604 // Possible null reference argument.
                _unitOfWork.Goal.Add(record);
                #pragma warning restore CS8604 // Possible null reference argument.
                _unitOfWork.Save();
                return _mapper.Map<Goal,GetGoalDTO>(record);
            }
            else
            {
                throw new Exception("Resource not found");
            }

        }
    }
}
