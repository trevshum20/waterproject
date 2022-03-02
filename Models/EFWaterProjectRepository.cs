using System;
using System.Linq;

// here we are making a "middle-man" in between the controller and the views, to pass info back and forth

namespace WaterProject.Models
{
    public class EFWaterProjectRepository: IWaterProjectRepository // kind of like inheriting from Iwaterprojrepo...
    {
        private WaterProjectContext context { get; set; }

        public EFWaterProjectRepository (WaterProjectContext temp)
        {
            context = temp;  // this is doing what we used to do in the controller
        }

        public IQueryable<Project> Projects => context.Projects;
    }
}
