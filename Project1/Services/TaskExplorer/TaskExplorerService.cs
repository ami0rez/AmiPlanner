using Amirez.AmiPlanner.Common.Models;
using Amirez.AmiPlanner.Controllers.TaskExpolrer.Model;
using Amirez.Infrastructure.Repositories.Folder;
using Amirez.Infrastructure.Repositories.Goal;
using Amirez.Infrastructure.Repositories.Project;
using AutoMapper;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Amirez.AmiPlanner.Services.TaskExpolrer
{
    public class TaskExplorerService : ITaskExplorerService
    {
        protected readonly IFolderRepository _folderRepository;
        protected readonly IGoalRepository _goalRepository;
        protected readonly IProjectRepository _projectRepository;
        protected readonly IMapper _mapper;
        public TaskExplorerService(
            IFolderRepository folderRepository,
            IGoalRepository goalRepository,
            IProjectRepository projectRepository,
            IMapper mapper)
        {
            _folderRepository = folderRepository ?? throw new ArgumentNullException(nameof(folderRepository));
            _goalRepository = goalRepository ?? throw new ArgumentNullException(nameof(goalRepository));
            _projectRepository = projectRepository ?? throw new ArgumentNullException(nameof(projectRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Get Task Filter Options
        /// </summary>
        /// <returns></returns>
        public Task<TaskFilterOptions> GetTaskFilterOptions()
        {
            var options = new TaskFilterOptions();
            options.Folders = _mapper.ProjectTo<ListItem>(_folderRepository.FindAll()).ToList();
            options.Goals = _mapper.ProjectTo<ListItem>(_goalRepository.FindAll()).ToList();
            options.Projects = _mapper.ProjectTo<ListItem>(_projectRepository.FindAll()).ToList();

            return Task.FromResult(options);
        }
    }
}
