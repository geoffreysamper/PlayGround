using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public static class DbHelper
{
    public static DataRow GetCompanyByIsn(string isn)
    {
        string sql = "select * from dbo.company where isincode='" + isn + "'";
        DataTable tbl = new DataTable();
        using (SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["demo"].ConnectionString))
        {
            tbl = new DataTable();

            da.Fill(tbl);

        }
        if (tbl.Rows.Count == 0)
            return null;


        return tbl.Rows[0];
    }

    public static string GetCompanyByIsnGood(string isn)
    {

        string sql = "select * from dbo.company where isincode= @code";

        SqlCommand command = new SqlCommand(sql);
        command.Parameters.Add(new SqlParameter("@code", isn));


        using (SqlDataAdapter da = new SqlDataAdapter(command))
        {
            DataTable tbl = new DataTable();

            da.Fill(tbl);

        }

        return null;
    }


    public static DataTable GetCompanies(string sql)
    {
        DataTable tbl = new DataTable();
        using (SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["demo"].ConnectionString))
        {
            tbl = new DataTable();

            da.Fill(tbl);

        }
        return tbl;
    }

}
