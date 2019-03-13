using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using HotelModels;

namespace HotelRestService.DBUtil
{
    public class ManageBooking
    {
        private string ConnectionString = DBUtil.ConnectionString.Connection;

        public List<Booking> GetAllBookings()
        {
            List<Booking> bookingList = new List<Booking>();

            string query = "SELECT * FROM Booking";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        Booking booking = new Booking()
                        {
                            BookingID = reader.GetInt32(0), //Henter fra kolonne 1 - nul indexeret
                            CustomerID = reader.GetInt32(1),
                            RoomNumber = reader.GetInt32(2),
                            HotelID = reader.GetInt32(3),
                            FromDate = reader.GetDateTime(4).Date,
                            ToDate = reader.GetDateTime(5).Date
                        };
                        bookingList.Add(booking);
                    }
                }
                finally
                {
                    reader.Close();
                }

                return bookingList;
            }
        }

        public List<Booking> GetBookingsFromHotelId(int hotelNr)
        {
            List<Booking> bookingList = new List<Booking>();

            string query = $"SELECT * FROM Booking WHERE HotelID={hotelNr}";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        Booking booking = new Booking()
                        {
                            BookingID = reader.GetInt32(0), //Henter fra kolonne 1 - nul indexeret
                            CustomerID = reader.GetInt32(1),
                            RoomNumber = reader.GetInt32(2),
                            HotelID = reader.GetInt32(3),
                            FromDate = reader.GetDateTime(4).Date,
                            ToDate = reader.GetDateTime(5).Date
                        };
                        bookingList.Add(booking);
                    }
                }
                finally
                {
                    reader.Close();
                }

                return bookingList;
            }
        }

        public bool CreateBooking(Booking booking)
        {
            string query = " ";

            if (booking != null)
            {
                query = $"INSERT booking (CustomerID,RoomNumber,HotelID,StartDate,EndDate) VALUES ('{booking.CustomerID}','{booking.RoomNumber}','{booking.HotelID}','{booking.FromDate}','{booking.ToDate}')";
            }

            return ExecuteNonQuery(query);
        }

        public bool UpdateBooking(Booking booking, int bookingID)
        {
            string query = " ";

            if (booking != null)
            {
                query = $"UPDATE booking WHERE BookingID={bookingID}";
            }

            return ExecuteNonQuery(query);
        }

        public bool DeleteBooking(int bookingID)
        {
            string query = " ";

            query = $"DELETE booking WHERE BookingID={bookingID}";

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