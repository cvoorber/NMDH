using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data.SqlClient;

public class imagesClass
{
    //This File Used by Chris (Built For Last Semester's Final Project)

    //public properties for the images class
    private static readonly string connectionString;
    static imagesClass()
    {
        connectionString = WebConfigurationManager.ConnectionStrings["cvoorberConnectionString1"].ConnectionString;
    }

    private Int32 _imgID;
    public Int32 ImageID
    {
        get { return _imgID; }
        set { _imgID = value; }
    }

    private string _imgName;
    public string ImageName
    {
        get { return _imgName; }
        set { _imgName = value; }
    }

    private string _imgURL;
    public string ImageURL
    {
        get { return _imgURL; }
        set { _imgURL = value; }
    }

    //get all Images from ndmh_uploads table
    public List<imagesClass> getImages()
    {
        List<imagesClass> allImages = new List<imagesClass>();
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand("SELECT * FROM ndmh_uploads", conn);
        try
        {
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                imagesClass objImg = new imagesClass();
                objImg.ImageID = Convert.ToInt32(dr["i_id"].ToString());
                objImg.ImageName = (string)dr["i_name"];
                objImg.ImageURL = (string)dr["i_url"];
                allImages.Add(objImg);
            }
            return allImages;
        }
        catch (Exception ex)
        {
            allImages.Clear();
            imagesClass objImg = new imagesClass();
            objImg.ImageName = "Server Error (DB):" + ex.Message.ToString();
            allImages.Add(objImg);
            return allImages;
        }
        finally
        {
            conn.Close();
        }
    }

    //get images by ID from ndmh_uploads table
    public List<imagesClass> getImagesByID(int id)
    {
        List<imagesClass> allImages = new List<imagesClass>();
        SqlConnection conn = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand("SELECT * FROM ndmh_uploads WHERE i_id=" + id, conn);
        try
        {
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                imagesClass objImg = new imagesClass();
                objImg.ImageID = Convert.ToInt32(dr["i_id"].ToString());
                objImg.ImageURL = (string)dr["i_url"];
                allImages.Add(objImg);
            }
            return allImages;
        }
        catch (Exception ex)
        {
            allImages.Clear();
            imagesClass objImg = new imagesClass();
            objImg.ImageName = "Server Error (DB):" + ex.Message.ToString();
            allImages.Add(objImg);
            return allImages;
        }
        finally
        {
            conn.Close();
        }
    }

    //insert images into the ndmh_uploads table
    public string insertImage()
    {
        SqlConnection conn = new SqlConnection(connectionString);
        string dbCommand = "INSERT INTO ndmh_uploads (i_name, i_url) VALUES (@imgName, @imgURL)";
        SqlCommand cmd = new SqlCommand(dbCommand, conn);
        cmd.Parameters.AddWithValue("@imgName", ImageName);
        cmd.Parameters.AddWithValue("@imgURL", ImageURL);
        try
        {
            conn.Open();
            int num = cmd.ExecuteNonQuery();
            return _checkSuccess(num);
        }
        catch (Exception ex)
        {
            return "Server Error (DB):" + ex.Message.ToString();
        }
        finally
        {
            conn.Close();
        }
    }

    private string _checkSuccess(int value)
    {
        string msg;
        if (value == 1)
        {
            msg = "<span style='color:green;'>Success</span>";
        }
        else
        {
            msg = "<span style='color:red;'>Failed</span>";
        }
        return msg;
    }
}