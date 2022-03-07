using System;
using System.Linq;

namespace WaterProject.Models
{
    public interface IWaterProjectRepository  // interface not a class, its a template for a class. Ensures the class will be used correctly
    {
        // this is replacing our list we used to pass in, but better
        IQueryable<Project> Projects { get; }

        public void SaveProject(Project p);

        public void CreateProject(Project p);

        public void DeleteProject(Project p);

    }
}
