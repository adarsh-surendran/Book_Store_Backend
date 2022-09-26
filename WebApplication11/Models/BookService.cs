﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication11.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication11.Models
{
    public class BookService : ICategory
    {
        SqlConnection conn;
        SqlCommand comm;
        public BookService()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }
        public Category AddCategory(Category category)
        {
            comm.Connection = conn;
            conn.Open();
            comm.CommandText = "insert into Category values(" + category.CategoryId + ",'" + category.CategoryName + "','" + category.Description + "','" + category.Image + "','" + category.Status + "'," + category.Position + ",'" + category.CreatedAt + "')";
            int row = comm.ExecuteNonQuery();
            conn.Close();
            if(row > 0)
            {
                return category;
            }
            return null;

        }

        public void DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAllCategory()
        {
            List<Category> list = new List<Category>();
            comm.CommandText = "select * from Category";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int cId = Convert.ToInt32(reader["CategoryId"]);
                string cName = reader["categoryName"].ToString();
                string des = reader["Description"].ToString();
                string img = reader["Image"].ToString();
                string status = reader["Status"].ToString();
                int pos = Convert.ToInt32(reader["Position"]);
                string crAt = reader["CreatedAt"].ToString();
                list.Add(new Category(cId,cName,des,img,status,pos,crAt));
            }
            conn.Close();
            return list;
        }

        public void UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}