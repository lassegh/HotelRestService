using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using HotelModels;

namespace HotelRestService.DBUtil
{
    public class ManageFacility
    {
        private string ConnectionString = DBUtil.ConnectionString.Connection;

        public List<Facility> GetAllFacilities()
        {
            List<Facility> facilityList = new List<Facility>();

            string query = "SELECT * FROM Facilities";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        Facility facility = new Facility()
                        {
                            FacilityID = reader.GetInt32(0), //Henter fra kolonne 1 - nul indexeret
                            HotelID = reader.GetInt32(1),
                            FacilityName = reader.GetString(2)
                        };
                        facilityList.Add(facility);
                    }
                }
                finally
                {
                    reader.Close();
                }

                return facilityList;
            }
        }

        public List<Facility> GetFacilitiesFromHotelId(int hotelNr)
        {
            List<Facility> facilityList = new List<Facility>();

            string query = $"SELECT * FROM Facilities WHERE HotelID={hotelNr}";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        Facility facility = new Facility()
                        {
                            FacilityID = reader.GetInt32(0), //Henter fra kolonne 1 - nul indexeret
                            HotelID = reader.GetInt32(1),
                            FacilityName = reader.GetString(2)
                        };
                        facilityList.Add(facility);
                    }
                }
                finally
                {
                    reader.Close();
                }
            }

            return facilityList;
        }

        public bool CreateFacility(Facility facility)
        {
            string query = " ";

            if (facility != null)
            {
                query = $"INSERT facilities (HotelID,Facility) VALUES ('{facility.HotelID}','{facility.FacilityName}')";
            }

            return ExecuteNonQuery(query);
        }

        public bool UpdateFacility(Facility facility, int facilityNr)
        {
            string query = " ";

            if (facility != null)
            {
                query = $"UPDATE facilities SET HotelID={facility.HotelID}, Facility='{facility.FacilityName}' WHERE FacilityID={facilityNr}";
            }

            return ExecuteNonQuery(query);
        }

        public bool DeleteFacility(int facilityNr)
        {
            string query = " ";

            query = $"DELETE Facilities WHERE FacilityID={facilityNr}";

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