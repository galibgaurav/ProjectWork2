using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectWork.Web.Models
{
    public class ProjecViewtModel
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectOwner { get; set; }
    }


    public class ProjectDatabase : List<ProjecViewtModel>
    {
        public ProjectDatabase()
        {
            Add(new ProjecViewtModel() { ProjectID = 101, ProjectName = "TwqedS", ProjectOwner = "testuser1@gmail.com" });
            Add(new ProjecViewtModel() { ProjectID = 102, ProjectName = "MqwdS", ProjectOwner = "testuser2@gmail.com" });
            Add(new ProjecViewtModel() { ProjectID = 103, ProjectName = "LwddS", ProjectOwner = "testuser1@gmail.com" });
            Add(new ProjecViewtModel() { ProjectID = 104, ProjectName = "TsdecqwdS", ProjectOwner = "testuser2@gmail.com" });
            Add(new ProjecViewtModel() { ProjectID = 105, ProjectName = "MwdS", ProjectOwner = "testuser3@gmail.com" });
            Add(new ProjecViewtModel() { ProjectID = 106, ProjectName = "LwqedS", ProjectOwner = "testuser1@gmail.com" });
        }
    }
}

