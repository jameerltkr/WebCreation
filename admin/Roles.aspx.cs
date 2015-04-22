using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Roles : System.Web.UI.Page
{
    admin_management admin_manage = new admin_management();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            Bind_User_and_Roles();// bindind users in drpdown
            Bind_Roles();// bindind roles in dropdown
        }
    }
    public void Bind_User_and_Roles()
    {
        // ddl_users.Items.Clear();
        var q = admin_manage.GetAllSiteUsers();
        //  ddl_users.Items.Insert(0, "Select");
        if (q.Any())
        {
            foreach (var a in q)
            {

                ddl_users.Items.Add(a.Username);
            }
        }
    }
    //   get roles
    public void Bind_Roles()
    {
        //   ddl_roles.Items.Clear();
        string[] roles = Roles.GetAllRoles();
        //   ddl_roles.Items.Insert(0, "Select");
        foreach (var role in roles)
        {

            if (!role.Equals("Administrator") && !role.Equals("Admin"))
            {

                ddl_roles.Items.Add(role);
            }
        }
    }
    protected void btn_create_Click(object sender, EventArgs e)
    {
        if (txt_rolename.Text != "")
        {
            Roles.CreateRole(txt_rolename.Text.Trim());
            lbl_msg.ForeColor = System.Drawing.Color.Green;
            lbl_msg.Text = "Role created successfully...";
            txt_rolename.Text = "";
            Bind_Roles();
        }
        else
        {
            lbl_msg.ForeColor = System.Drawing.Color.Red;
            lbl_msg.Text = "Please enter a role...";
        }
    }
    protected void btn_assign_role_Click(object sender, EventArgs e)
    {
        //!ddl_users.SelectedItem.Text.Equals("Select")
        if (ddl_roles.SelectedItem.Text.Equals("Select"))
        {
            lbl_role_msg.ForeColor = System.Drawing.Color.Red;
            lbl_role_msg.Text = "Please select role.";
        }
        else
            if (ddl_users.SelectedItem.Text.Equals("Select"))
            {
                lbl_role_msg.ForeColor = System.Drawing.Color.Red;
                lbl_role_msg.Text = "Please select user.";
            }
            else
            {
                if (!IsRoleAssigned(ddl_roles.SelectedItem.Text))
                {
                    if (!IsUserInRole(ddl_users.SelectedItem.Text))
                    {
                        Roles.AddUserToRole(ddl_users.SelectedItem.Text, ddl_roles.SelectedItem.Text);
                        lbl_role_msg.ForeColor = System.Drawing.Color.Green;
                        ddl_roles.ClearSelection();
                        ddl_users.ClearSelection();
                        lbl_role_msg.Text = "Role assigned successfully...";
                    }
                    else
                    {
                        lbl_role_msg.ForeColor = System.Drawing.Color.Red;
                        lbl_role_msg.Text = "This user is already in another role.";
                    }
                }
                else
                {
                    lbl_role_msg.ForeColor = System.Drawing.Color.Red;
                    lbl_role_msg.Text = "This role is already assigned for an user.";
                }
                
                

            }
    }
    public bool IsUserInRole(string username)
    {
        string[] roles = Roles.GetRolesForUser(username);
        foreach (string role in roles)
        {
            return true;
        }
        //if (roles != null)
        //{
        //    return true;
        //}
        //else
        //{
        //    return false;
        //}
        return false;
    }
    public bool IsRoleAssigned(string rolename)
    {
        string[] users = Roles.GetUsersInRole(rolename);
        foreach (string user in users)
        {
            return true;
        }
        //if (users != null)
        //{
        //    return true;
        //}
        //else
        //{
        //    return false;
        //}
        return false;
    }
}