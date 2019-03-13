using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using DemoHotelDB.DBUtil;
using HotelModels;

namespace HotelRestService.DBUtil
{
    public class ManageGuest : IManageGuest
    {

        private string ConnectionString = DBUtil.ConnectionString.Connection;

        public List<Guest> GetAllGuest()
        {
            List<Guest> guestList = new List<Guest>();

            string query = "SELECT customerID,FirstName,LastName,Address FROM Customer";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        Guest guest = new Guest
                        {
                            CustomerID = reader.GetInt32(0), //Henter fra kolonne 1 - nul indexeret
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            Address = reader.GetString(3)
                        };
                        guestList.Add(guest);
                    }
                }
                finally
                {
                    reader.Close();
                }

                return guestList;
            }
        }

        public Guest GetGuestFromId(int guestNr)
        {
            string query = $"SELECT customerID,FirstName,LastName,Address FROM Customer WHERE CustomerID={guestNr}";

            Guest guest = null;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        guest = new Guest
                        {
                            CustomerID = reader.GetInt32(0), //Henter fra kolonne 1 - nul indexeret
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            Address = reader.GetString(3)
                        };
                    }
                }
                finally
                {
                    reader.Close();
                }
            }

            return guest;
        }

        public bool CreateGuest(Guest guest)
        {
            string query = " ";

            if (guest!=null)
            {
                query = $"INSERT customer (FirstName,LastName,Address,Country,Phone) VALUES ('{guest.FirstName}','{guest.LastName}','{guest.Address}','{guest.Country}','{guest.Phone}')";
            }

            return ExecuteNonQuery(query);
        }

        public bool UpdateGuest(Guest guest, int guestNr)
        {
            string query = " ";

            if (guest != null)
            {
                query = $"UPDATE customer WHERE CustomerID={guestNr}";
            }

            return ExecuteNonQuery(query);
        }

        public bool DeleteGuest(int guestNr)
        {
            string query = " ";

            query = $"DELETE Customer WHERE CustomerID={guestNr}";
            
            return ExecuteNonQuery(query);
        }

        private bool ExecuteNonQuery(string query)
        {
            bool executed = false;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                try
                {
                    command.ExecuteNonQuery(); // Denne command læser Create, Update, Delete, Drop
                    executed = true;
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
                finally
                {
                    connection.Close();
                }
            }

            return executed;
        }
    }
}