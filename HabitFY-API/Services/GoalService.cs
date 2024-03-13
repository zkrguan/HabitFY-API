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
        public async Task<IEnumerable<GetGoalDTO>> GetGoalsByUserId(string userId)
        {
            return _mapper.Map<IEnumerable<Goal>, IEnumerable<GetGoalDTO>>(await _unitOfWork.Goal.GetGoalsByUserId(userId));
        }
        public async Task<GetGoalDTO?> GetOneGoalById(int id)
        {
            return _mapper.Map<GetGoalDTO>(await _unitOfWork.Goal.GetById(id));
        }
        public async Task<GetGoalDTO> CreateGoal(CreateGoalDTO dto)
        {
            var foundUser = await _unitOfWork.UserProfile.GetById(dto.ProfileId);
            if (foundUser != null)
            {
                var record = _mapper.Map<CreateGoalDTO, Goal>(dto, opt => opt.Items["UserProfile"] = foundUser);
                await _unitOfWork.Goal.AddAsync(record);
                await _unitOfWork.SaveAsync();
                return _mapper.Map<Goal,GetGoalDTO>(record);
            }
            else
            {
                throw new Exception("Resource not found");
            }

        }
        public async Task<GetGoalDTO> UpdateGoal(int id,UpdateGoalDTO dto)
        {
            var foundGoal = await _unitOfWork.Goal.GetById(id);
            if (foundGoal != null)
            {
                var updatedGoal = _mapper.Map<UpdateGoalDTO, Goal>(dto, foundGoal);
                var finalResult = _mapper.Map<Goal, GetGoalDTO>(updatedGoal);
                await _unitOfWork.SaveAsync();
                return finalResult;
            }
            else
            {
                throw new Exception("Resource not found");
            }
        }
        public async Task ActivateGoal(int id, bool activated)
        {
            var foundGoal = await _unitOfWork.Goal.GetById(id);
            if (foundGoal != null)
            {
                foundGoal.IsActivated = activated;
                foundGoal.LastUpdated = DateTime.Now;
                await _unitOfWork.SaveAsync();
            }
            else
            {
                throw new Exception("Resource not found");
            }
        }
    }
}
