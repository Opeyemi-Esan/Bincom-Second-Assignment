using BincomSecondAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BincomFirstAssignment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MyCV()
        {
            var Cv = new MyCvModel
            {
                Name = "Opeyemi Esan",
                Email = "tolulopejossyp@gmail.com",
                Phone = "08162947156",
                LinkedIn = "https://www.linkedin.com/in/opeyemiesan/",
                GitHub = "https://github.com/Opeyemi-Esan",
                Skills = new List<string> { "C#", ".NET Core", "Entity Framework", "React.js", "SQL Server", 
                    "MySQL", "JavaScript", "Visual Studio", "VS Code", "Git/GitHub", "Azure DevOps", "JIRA", 
                    "Postman", "RESTful APIs", "Microservices", "LINQ", "Docker", "Entity Framework", 
                    "Mssql/Postgresql", "Mongodb" },
                Summary = "I am a Backend .NET Developer with 3 years of experience in designing, " +
                "developing, and maintaining robust server-side applications. \r\nProficient in .NET " +
                "technologies, database management, and API development. Adept at collaborating with " +
                "cross-functional teams to deliver high-quality software solutions that meet business " +
                "requirements. \r\nCommitted to continuous learning and applying best practices in " +
                "software development.\r\n",
                WorkExperiences = new List<Experience>
                {
                    new Experience { JobTitle = "BAckend Developer", CompanyName = "Mercyland Group", Duration = "January 2024 - Present", Description = "表tDeveloped and maintained web applications using .NET\r\n表tOptimized application performance, resulting in a 90% increase in load speed.\r\n表tImplemented RESTful APIs to facilitate communication between front-end and back-end systems.\r\n表tParticipated in code reviews and contributed to team knowledge sharing.\r\n表tWrote clean, maintainable code and conducted unit testing to ensure software quality.\r\n表tWorked closely with product managers to gather requirements and translate them into technical specifications.\r\n表tContributed to the migration of legacy systems to modern web applications.\r\n表tImplementing payments gateway\r\n" },
                    new Experience { JobTitle = "Backend Developer", CompanyName = "Enop-Tech Solutions", Duration = "June 2022 - December 2023", Description = "表tDeveloped and maintained enterprise-level web applications using ASP.NET MVC and Web API.\r\n表tCollaborated with UI/UX designers to implement responsive and user-friendly interfaces.\r\n表tDesigned and optimized SQL Server databases, improving query performance by 30%.\r\n表tImplemented RESTful services for seamless integration with front-end applications.\r\n表tParticipated in Agile ceremonies, including sprint planning and daily stand-ups.\r\n" },
                    new Experience { JobTitle = "Backend Developer", CompanyName = "Signal 7000 Digitals", Duration = "January 2022 - June 2022", Description = "表tAssisted in the development of internal tools and applications using .NET technologies.\r\n表tWrote clean, maintainable code and performed unit testing to ensure software quality.\r\n表tSupported the migration of legacy applications to .NET Core, enhancing performance and security.\r\n表tDocumented development processes and maintained technical documentation for future reference.\r\n" }
                },
                Projects = new List<Project>
                {
                    new Project {ProjectTitle = "Book Store Backend", Description = "Features include:\r\n表tCreating Account: This feature allows users to create a new bank account by providing necessary details such as name, email, and other necessary details with initial deposit amount. The API would validate the input and store the account information in a database.\r\n表tAccount Number Generating: When a new account is created, the API generates a unique account number. \r\n表tTransferring Funds: This functionality enables users to transfer money between accounts. The API would handle the validation of the accounts involved, check for sufficient funds, and update the balances accordingly.\r\n表tDepositing Funds: Users can deposit money into their accounts through this feature. The API would update the account balance and log the transaction for record-keeping.\r\n"},
                    new Project {ProjectTitle = "Real Estate Website Admin Panel", Description = "Built and maintained a real estate admin web app, creating CRUD operations where admins can login, upload, read, update and delete properties, to and from the client app. I used .NET Framework to integrate the backend. I used SQL for database."},
                    new Project {ProjectTitle = "E-Library", Description = "I created backend code for a library website where I implemented the Entity Framework Core relationship (Many-to-many relationship, One-to-many relationship and One-to-one relationship) between the Books, Authors and the publishers. "},
                    new Project {ProjectTitle = "E-Comerce Platform", Description = "Created a scalable e-commerce platform with user authentication, product management, and payment processing using ASP.Net Core and SQL.\r\nDeveloped RESTful APIs for product and order management, integrated payment gateways, and optimized performance.\r\n"}
                },
                Educations = new List<Education>
                {
                    new Education {Degree = "B-Tech", Institution = "Federal University of Technology, Akure", Year = "2018"}
                }

            };
            return View(Cv);
        }

        public IActionResult CalculateTax(TaxModel model)
        {
            model.Tax = NigeriaTax(model.Income);
            return View(model);
        }

        private decimal NigeriaTax(decimal income)
        {
            decimal tax = 0;
 
            if (income <= 300000)
            {
                tax = income * 0.07m;
            }
            else if (income <= 600000)
            {
                tax = (300000 * 0.07m) + ((income - 300000) * 0.11m);
            }
            else if (income <= 1100000)
            {
                tax = (300000 * 0.07m) + (300000 * 0.11m) + ((income - 600000) * 0.15m);
            }
            else if (income <= 2700000)
            {
                tax = (300000 * 0.07m) + (300000 * 0.11m) + (500000 * 0.15m) + ((income - 1100000) * 0.19m);
            }
            else
            {
                tax = (300000 * 0.07m) + (300000 * 0.11m) + (500000 * 0.15m) + (1600000 * 0.19m) + ((income - 2700000) * 0.24m);
            }
            return tax;
        }

    }
}
