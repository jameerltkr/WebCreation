using Microsoft.Web.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void hcv_Click(object sender, EventArgs e)
    {
      //  PublishWebSite("");

        ServerManager servManager = new ServerManager();
        Site mySite = servManager.Sites.Add("MyTestSite1", "G:\\my_project01", 8097 );
        servManager.ApplicationPools.Add("MyPool11");
        mySite.ApplicationDefaults.ApplicationPoolName = "MyPool11";
        mySite.TraceFailedRequestsLogging.Enabled = true;
        mySite.TraceFailedRequestsLogging.Directory = "G:\\my_project01";
        servManager.CommitChanges();
        Response.Write("Succeded");
    }
    private bool PublishWebSite(string SiteName)
    {

        try
        {

            string siteName = "YourSiteName";

            string applicationPoolName = "UChat";

            string virtualDirectoryPath = "/";

            //Path to the folder of the published code

            string virtualDirectoryPhysicalPath = "G:\\my_project01";

            //IP address of current machine where the site is to be published

            string ipAddress = "101.221.81.214";

            //Port to be assigned to the site

            string tcpPort = "1109";

            //Site name that appears in the URL

            string hostHeader = string.Format("www.{0}", siteName);

            string applicationPath = "/";

            long highestId = 1;

            using (ServerManager serverManager = new ServerManager())
            {

                Site site = serverManager.Sites[siteName];

                if (site != null)
                {

                    return false;

                }

                ApplicationPool appPool = serverManager.ApplicationPools[applicationPoolName];

                if (appPool == null)
                {

                    throw new Exception(String.Format("Application Pool: {0} does not exist.", applicationPoolName));

                }

                highestId = serverManager.Sites.Max(i => i.Id);

                highestId++;

                site = serverManager.Sites.CreateElement();

                site.SetAttributeValue("name", siteName);

                site.Id = highestId;

                site.Bindings.Clear();

                //Assign the IP address , Port and site URL

                string bind = ipAddress + ":" + tcpPort + ":" + hostHeader;

                Binding binding = site.Bindings.CreateElement();

                binding.Protocol = "http";

                binding.BindingInformation = bind;

                site.Bindings.Add(binding);

                Application application = site.Applications.CreateElement();

                application.Path = applicationPath;

                application.ApplicationPoolName = applicationPoolName;

                //Create a virtual directory in IIS

                VirtualDirectory vdir = application.VirtualDirectories.CreateElement();

                vdir.Path = virtualDirectoryPath;

                //Set the physical path of the folder

                vdir.PhysicalPath = virtualDirectoryPhysicalPath;

                application.VirtualDirectories.Add(vdir);

                site.Applications.Add(application);

                //Add this new site to the pool of sites in IIS

                serverManager.Sites.Add(site);

                serverManager.CommitChanges();

            }

            return true;

        }

        catch (Exception)
        {

            return false;

        }

    }
}