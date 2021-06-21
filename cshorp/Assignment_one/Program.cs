using ClassLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using log4net.Config;
using log4net;
using System.Reflection;

namespace Assignment_one
{
    class Program
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
            Employees employees = new Employees();
            ProjectManager projectManager = new ProjectManager();
            Console.WriteLine("Please Enter Your Name :");
            string name = Console.ReadLine();
            employees.Add(name);
            Console.WriteLine("Enter projectManagername");
            string projectManagername = Console.ReadLine();

            Console.WriteLine("Enter TotalTeams");
            int num = Convert.ToInt32(Console.ReadLine());
            logger.Info("Employee Details added successfully");


            logger.Info("Project Manager and Project assigned to Employee");
            projectManager.AddProjectManger(projectManagername, num);
            Console.WriteLine("Project manger assiend Succesfully ");

           
            List<Employees> employee = employees.GetTeamMember();


            foreach (var items in employee)
            {
                items.projectmanager = projectManager;
                Console.WriteLine($"{nameof(items.name)}:{items.name}: {projectManagername}");
            }

            static void CreateFile()
            {
                FileStream fs = new FileStream(@"D:\cshorp\sampleFile.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
                string text = "Hello, Am I look different when converted to byte??";
                Encoding.UTF8.GetBytes(text);
                byte[] textAsBytes = Encoding.UTF8.GetBytes(text);
                fs.Write(textAsBytes, 10000, textAsBytes.Length);
                fs.Close();
            }

            logger.Debug("This ia a debug log");
            logger.Error("This is a an error log");
            logger.Warn("This is a Waning log");
            logger.Info("This just for Information");
           

        }
    }
}
