using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace CRUD_Operation
{
    class CRUD
    {
        public static void insert()
        {
            Console.WriteLine("Enter the Student ID,Name and total_marks");
            int id=int.Parse(Console.ReadLine());   
            string Name=Console.ReadLine();  
            int total_marks=int.Parse(Console.ReadLine());

            SqlConnection con = new SqlConnection("Data Source=DELL\\SQLEXPRESS;Initial Catalog=CRUD_Operation;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = $"insert into tblStudent values({id},'{Name}',{total_marks})";
            int n =cmd.ExecuteNonQuery();
           
            if ( n > 0 )
            {
                Console.WriteLine("Record inserted Successfully");
            }
            else
            {
                Console.WriteLine("Record Not inserted");
            }
            con.Close();
        }


        public static void select()
        {
            SqlConnection con = new SqlConnection("Data Source=DELL\\SQLEXPRESS;Initial Catalog=CRUD_Operation;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from tblStudent";
            SqlDataReader n =cmd.ExecuteReader();
            Console.WriteLine("id Name total_marks");
            while (n.Read())
            {
                Console.WriteLine($"{n[0]} {n[1]} {n[2]}");
            }
            con.Close();
        }
        public static void Update()
        {
            Console.WriteLine("Enter the id and name by student");
            int id=int.Parse(Console.ReadLine());
            string Name=Console.ReadLine();
            SqlConnection con = new SqlConnection("Data Source=DELL\\SQLEXPRESS;Initial Catalog=CRUD_Operation;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = $"update tblStudent set Name='{Name}'where id={id}";
            int n=cmd.ExecuteNonQuery();
            if ( n > 0 )
            {
                Console.WriteLine("Record Updated Successfully");
            }
            else
            {
                Console.WriteLine("Record Not Updated");
            }
            con.Close();
        }
        public static void Delete()
        {
            Console.WriteLine("Enter the Student Id");
            int id = int.Parse(Console.ReadLine());
            SqlConnection con = new SqlConnection("Data Source=DELL\\SQLEXPRESS;Initial Catalog=CRUD_Operation;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = $"delete from tblStudent where Id={id}";
            int n = cmd.ExecuteNonQuery();
            if (n > 0)
            {
                Console.WriteLine("Record Deleted Successfully");
            }
            else
            {
                Console.WriteLine("Record Not Deleted Successfully");
            }
            con.Close();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
           // CRUD.insert();
           //CRUD.select();
           //CRUD.Update();
           CRUD.Delete();
            Console.ReadKey();
        }
    }
}
