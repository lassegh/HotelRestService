using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using HotelModels;

namespace HotelRestService.DBUtil
{
    public class ManageHotel
    {
        private string ConnectionString = DBUtil.ConnectionString.Connection;

        public List<Hotel> GetAllHotels()
        {
            List<Hotel> hotelList = new List<Hotel>();

            string query = "SELECT HotelID,Name,Address,Stars FROM Hotel";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        Hotel hotel = new Hotel()
                        {
                            HotelID = reader.GetInt32(0), //Henter fra kolonne 1 - nul indexeret
                            Name = reader.GetString(1),
                            Address = reader.GetString(2),
                            Stars = reader.GetInt32(3)
                        };
                        hotelList.Add(hotel);
                    }
                }
                finally
                {
                    reader.Close();
                }

                return hotelList;
            }
        }

        public Hotel GetHotelFromId(int hotelNr)
        {
            string query = $"SELECT HotelID,Name,Address,Stars FROM Hotel WHERE HotelID={hotelNr}";

            Hotel hotel = null;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        hotel = new Hotel
                        {
                            HotelID = reader.GetInt32(0), //Henter fra kolonne 1 - nul indexeret
                            Name = reader.GetString(1),
                            Address = reader.GetString(2),
                            Stars = reader.GetInt32(3)
                        };
                    }
                }
                finally
                {
                    reader.Close();
                }
            }

            return hotel;
        }

        public bool CreateHotel(Hotel hotel)
        {
            string query = " ";

            if (hotel != null)
            {
                query = $"INSERT hotel (Name,Address,Stars) VALUES ('{hotel.Name}','{hotel.Address}','{hotel.Stars}')";
            }

            return ExecuteNonQuery(query);
        }

        public bool UpdateHotel(Hotel hotel, int hotelNr)
        {
            string query = " ";

            if (hotel != null)
            {
                query = $"UPDATE hotel SET name='{hotel.Name}', address='{hotel.Address}', stars={hotel.Stars} WHERE HotelID={hotelNr}";
            }

            return ExecuteNonQuery(query);
        }

        public bool DeleteHotel(int hotelNr)
        {
            string query = " ";

            query = $"DELETE Hotel WHERE HotelID={hotelNr}";

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