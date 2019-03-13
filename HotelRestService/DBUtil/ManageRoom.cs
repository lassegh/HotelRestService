using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using HotelModels;

namespace HotelRestService.DBUtil
{
    public class ManageRoom
    {
        private string ConnectionString = DBUtil.ConnectionString.Connection;

        public List<Room> GetAllRooms()
        {
            List<Room> roomList = new List<Room>();

            string query = "SELECT HotelID,RoomNumber,RoomType,Price FROM Room";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        Room room = new Room();

                        room.HotelID = reader.GetInt32(0); //Henter fra kolonne 1 - nul indexeret
                        room.RoomNumber = reader.GetInt32(1);
                        var buffer = new char[1];
                        reader.GetChars(2, 0, buffer, 0, 1);
                        room.RoomType = buffer[0];
                        room.Price = reader.GetDouble(3);

                        roomList.Add(room);
                    }
                }
                finally
                {
                    reader.Close();
                }

                return roomList;
            }
        }

        public List<Room> GetRoomsFromHotelId(int hotelNr)
        {
            List<Room> roomList = new List<Room>();

            string query = $"SELECT * FROM Room WHERE HotelID={hotelNr}";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        Room room = new Room();

                        room.HotelID = reader.GetInt32(0); //Henter fra kolonne 1 - nul indexeret
                        room.RoomNumber = reader.GetInt32(1);
                        var buffer = new char[1];
                        reader.GetChars(2, 0, buffer, 0, 1);
                        room.RoomType = buffer[0];
                        room.Price = reader.GetDouble(3);

                        roomList.Add(room);
                    }
                }
                finally
                {
                    reader.Close();
                }

                return roomList;
            }
        }

        public bool CreateRoom(Room room)
        {
            string query = " ";

            if (room != null)
            {
                query = $"INSERT room (HotelID,RoomNumber,RoomType,Price) VALUES ('{room.HotelID}','{room.RoomNumber}','{room.RoomType}','{room.Price}')";
            }

            return ExecuteNonQuery(query);
        }

        public bool UpdateRoom(Room room, int HotelID, int RoomNumber)
        {
            string query = " ";

            if (room != null)
            {
                query = $"UPDATE room WHERE HotelID={HotelID} AND RoomNumber={RoomNumber}";
            }

            return ExecuteNonQuery(query);
        }

        public bool DeleteRoom(int HotelID, int RoomNumber)
        {
            string query = " ";

            query = $"DELETE room WHERE HotelID={HotelID} AND RoomNumber={RoomNumber}";

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