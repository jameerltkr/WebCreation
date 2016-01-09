using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DatabaseManagement
/// </summary>
public class DatabaseManagement
{
    private static MyProjectDataContext dbContext = new MyProjectDataContext();
    public bool Save(string dbname, int websiteid, string websitename, Guid userid, string username)
    {
        DatabaseDetail dbdetail = new DatabaseDetail();
        dbdetail.CreatedBy = username;
        dbdetail.CreatedOn = DateTime.Now;
        dbdetail.DatabaseName = dbname;
        dbdetail.DbForWebsiteId = websiteid;
        dbdetail.UpdatedOn = DateTime.Now;
        dbdetail.UserId = userid;
        dbdetail.Username = username;
        dbdetail.WebsiteName = websitename;
        try
        {
            dbContext.DatabaseDetails.InsertOnSubmit(dbdetail);
            dbContext.SubmitChanges();
            return true;
        }
        catch
        {
            return false;
        }

    }
    public IEnumerable<DatabaseDetail> GetDatabaseListByUsername(string username)
    {
        var q = from a in dbContext.DatabaseDetails
                where a.Username == username
                select a;
        return q;
    }
    public IEnumerable<DatabaseDetail> GetDatabaseListByDbId(int dbid)
    {
        var q = from a in dbContext.DatabaseDetails
                where a.DatabaseId == dbid
                select a;
        return q;
    }
    public bool CheckDatabaseByDbNameAndWebsite(string dbname, string websitename)
    {
        var q = from a in dbContext.DatabaseDetails
                where a.DatabaseName == dbname && a.WebsiteName == websitename
                select a;
        if (q.Any())
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static int GetWebsiteId(Guid userid, string username, string websitename)
    {
        MyProjectDataContext da = new MyProjectDataContext();
        int id = 0;
        var q = from a in da.Websites
                where a.UserId == userid && a.Username == username && a.WebsiteName == websitename
                select a.WebsiteId;
        if (q.Any())
        {
            id = Convert.ToInt32(q.Single());
        }
        return id;
    }
    public int GetDbIdByWebsiteName(string websitename)
    {
        var q = from a in dbContext.DatabaseDetails
                where a.WebsiteName == websitename
                select a.DatabaseId;
        if (q.Any())
        {
            return Convert.ToInt32(q.Single());
        }
        else
        {
            return 0;
        }
    }
    public string GetWebsiteNameByDbId(int dbid)
    {
        var q = from a in dbContext.DatabaseDetails
                where a.DatabaseId == dbid
                select a;
        if (q.Any())
        {
            foreach (var a in q)
            {
                return a.WebsiteName;
            }
            return "";
        }
        else
        {
            return "";
        }
    }
    public bool UpdateDbByDBId(int dbid, string dbname, int websiteid, Guid userid, string websitename, string username)
    {
       // int websiteid=GetWebsiteId(userid,username,websitename);
        var q = from a in dbContext.DatabaseDetails
                where a.DatabaseId == dbid
                select a;
        if (q.Any())
        {
            foreach (var a in q)
            {
                a.DatabaseName = dbname;
                a.DbForWebsiteId = websiteid;
                a.UpdatedOn = DateTime.Now;
                a.UserId = userid;
                a.Username = username;
                a.WebsiteName = websitename;
            }
        }
        try
        {
        //    dbContext.DatabaseDetails.InsertOnSubmit(dbdetail);
            dbContext.SubmitChanges();
            return true;
        }
        catch
        {
            return false;
        }
        return false;
    }
    public bool UpdateDbRecord(string dbname, string websitename)
    {
        var q = from a in dbContext.DatabaseDetails
                where a.DatabaseName == dbname && a.WebsiteName == websitename
                select a;
        if (q.Any())
        {
            foreach (var a in q)
            {
                a.WebsiteName = websitename;
                a.DatabaseName = dbname;
                a.UpdatedOn = DateTime.Now;
            }
            try
            {
                dbContext.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        return false;
    }
    public bool IsDbCreatedForWebsite(string websitename)
    {
        var q = from a in dbContext.DatabaseDetails
                where a.WebsiteName == websitename
                select a;
        if (q.Any())
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool DeleteDatabaseById(int dbid)
    {
        var q = from a in dbContext.DatabaseDetails
                where a.DatabaseId == dbid
                select a;
        if (q.Any())
        {
            foreach (var a in q)
            {
                dbContext.DatabaseDetails.DeleteOnSubmit(a);
               // return true;
            }
            try
            {
                dbContext.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        return false;
    }
    public void DeleteDatabaseByWebsiteName(Guid userid, string websitename, string username)
    {
        var q = from a in dbContext.DatabaseDetails
                where a.UserId == userid && a.WebsiteName == websitename && a.Username == username
                select a;
        if (q.Any())
        {
            foreach (var a in q)
            {
                dbContext.DatabaseDetails.DeleteOnSubmit(a);
            }
            try
            {
                dbContext.SubmitChanges();
              //  return true;
            }
            catch(Exception ex)
            {
                throw ex;
               // return false;
            }
        }
        //return false;
    }


    // ==================================================================================
    //   table management
    //management of table will goes here
    //
    public bool SaveTable(string tablename, int dbid, string websitename, string createdby, Guid userid)
    {
        TableDetail tbdetail = new TableDetail();
        tbdetail.CreatedBy = createdby;
        tbdetail.CreatedOn = DateTime.Now;
        tbdetail.DatabaseId = dbid;
        tbdetail.TableName = tablename;
        tbdetail.UpdatedOn = DateTime.Now;
        tbdetail.UserId = userid;
        tbdetail.WebsiteName = websitename;
        try
        {
            dbContext.TableDetails.InsertOnSubmit(tbdetail);
            dbContext.SubmitChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
    public int GetNumberOfTotalTableByDbId(int dbid)
    {
        int totaltable = 0;
        var q = from a in dbContext.TableDetails
                where a.DatabaseId == dbid
                select a;
        if (q.Any())
        {
            totaltable = q.Count();
            return totaltable;
        }
        return totaltable;
    }
    public bool SaveTableColumnDetails(int tableid, string tablename, string columnname, string columndatatype, Guid userid)
    {
        TableColumnDetail tbcolumndetails = new TableColumnDetail();
        tbcolumndetails.ColumnDataType = columndatatype;
        tbcolumndetails.ColumnName = columnname;
        tbcolumndetails.TableId = tableid;
        tbcolumndetails.TableName = tablename;
        tbcolumndetails.UserId = userid;
        dbContext.TableColumnDetails.InsertOnSubmit(tbcolumndetails);
        try
        {
            dbContext.SubmitChanges();
            return true;
        }
        catch
        {
            return false;
        }
        return false;
    }
    public int GetTableId(int dbid, string websitename, Guid userid)
    {
        var q = from a in dbContext.TableDetails
                where a.DatabaseId == dbid && a.WebsiteName == websitename && a.UserId == userid
                select a.TableId;
        if (q.Any())
        {
            return Convert.ToInt32(q.Max());
        }
        else
        {
            return 0;
        }
    }
    public IEnumerable<TableDetail> GetTableRecords(int dbid, Guid userid)
    {
        var q = from a in dbContext.TableDetails
                where a.UserId == userid && a.DatabaseId == dbid
                select a;
        return q;
    }
    public bool DeleteTableByTableId(int tableid)
    {
        var q = from a in dbContext.TableDetails
                where a.TableId == tableid
                select a;
        if (q.Any())
        {
            foreach (var a in q)
            {
                dbContext.TableDetails.DeleteOnSubmit(a);
            }
            try
            {
                dbContext.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        return false;
    }
    public bool DeleteTableColumnByTableId(int tableid)
    {
        var q = from a in dbContext.TableDetails
                where a.TableId == tableid
                select a;
        if (q.Any())
        {
            foreach (var a in q)
            {
                dbContext.TableDetails.DeleteOnSubmit(a);
            }
            try
            {
                dbContext.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        return false;
    }
}
