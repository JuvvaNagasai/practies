using System;
using System.Collections.Generic;

namespace ClassLib
{
    public class Employees
    {
       

        static protected List<Employees> _employees = new List<Employees>();
        public string EmployeeId { get; set; }
        public string name { get; set; }
        public DateTime dateOfJoin { get; set; }
        public ProjectManager projectmanager { get; set; }
        public string project { get; set; }
       

        public virtual bool Add(string Name)
        {

            name = Name;
           Guid  employeeId = Guid.NewGuid();
            dateOfJoin = DateTime.Now;
           
            _employees.Add(this);
          
           
            Console.WriteLine($"Name : {name}  /n EmployeeId : {EmployeeId}   /n DateOfJoini: {dateOfJoin}");
            return true;

        }
        public bool Remove()
        {

            _employees.Remove(this);
            return true;

        }
        public bool Assign(string projectName)
        {
            project = projectName;
            return true;
        }

        public ProjectManager GetPM()
        {
            return projectmanager;
        }

        public List<Employees> GetTeamMember()
        {
            return _employees;
        }
        public virtual string Works(string[] tasks)
        {
            Console.WriteLine("Task are :");
            foreach (var items in tasks)
            {
                Console.WriteLine(items);

            }
            return "Done";
        }


    }

    class Company
    {
        
        public Guid CompanyId{ get; set; }
        public string Name{ get; set; }
        public int TotalEmployees{ get; set; }
        public string FounderName{ get; set; }
        
    }

    public class ProjectManager : Employees
    {
        public int totalTeams { get; set; }

        public override string Works(string[] tasks)
        {
          return "Work TO be Done";
        }

        public void AddProjectManger(string name, int totalteam)
        {
            
        }
    }
}
