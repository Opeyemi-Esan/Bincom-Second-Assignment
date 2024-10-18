namespace BincomSecondAssignment.Models
{
    public class MyCvModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string LinkedIn { get; set; }
        public string GitHub { get; set; }
        public string Summary { get; set; }
        public List<string> Skills { get; set; }
        public List<Experience> WorkExperiences { get; set; }
        public List<Project> Projects { get; set; }
        public List<Education> Educations { get; set; }
    }

    public class Experience
    {
        public string JobTitle { get; set; }
        public string CompanyName { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }
    }

    public class Project
    {
        public string ProjectTitle { get; set; }
        public string Description { get; set; }
    }

    public class Education
    {
        public string Degree { get; set; }
        public string Institution { get; set; }
        public string Year { get; set; }
    }
}
