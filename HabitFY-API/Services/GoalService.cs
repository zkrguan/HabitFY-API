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

        
        public GetGoalDTO GetOneGoalById(int id)
        {
            var userGoal = _unitOfWork.Goal.GetById(id);
            var result = _mapper.Map<GetGoalDTO>(userGoal);
            return result;
        }

        //
        public GetGoalDTO CreateGoal(CreateGoalDTO dto)
        {
            var foundUser = _unitOfWork.UserProfile.GetById(dto.ProfileId);
            if (foundUser != null )
            {
                var record = _mapper.Map<CreateGoalDTO, Goal>(dto, opt => opt.Items["UserProfile"] = foundUser);
                _unitOfWork.Goal.Add(record);
                _unitOfWork.Save();
                return _mapper.Map<Goal,GetGoalDTO>(record);
            }
            else
            {
                throw new Exception("Resource not found");
            }

        }

        public GetGoalDTO UpdateGoal(int id,UpdateGoalDTO dto)
        {
            var foundGoal = _unitOfWork.Goal.GetById(id);
            if (foundGoal != null)
            {
                var updatedGoal = _mapper.Map<UpdateGoalDTO, Goal>(dto, foundGoal);
                var finalResult = _mapper.Map<Goal, GetGoalDTO>(updatedGoal);
                _unitOfWork.Save();
                return finalResult;
            }
            else
            {
                throw new Exception("Resource not found");
            }
        }

        public void ActivateGoal(int id, bool activated)
        {
            var foundGoal = _unitOfWork.Goal.GetById(id);
            if (foundGoal != null)
            {
                foundGoal.IsActivated = activated;
                _unitOfWork.Save();
            }
            else
            {
                throw new Exception("Resource not found");
            }
        }
    }
}
