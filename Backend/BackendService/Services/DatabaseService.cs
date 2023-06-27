using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using BackendService.Models;
using System.Data.SqlClient;

namespace BackendService.Services
{
    public class DatabaseService
    {
        private readonly string _connectionString;

        public DatabaseService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Shipper>> GetShippers()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                // Query to retrieve shippers from the database
                string query = "SELECT * FROM Shippers";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        List<Shipper> shippers = new List<Shipper>();

                        while (reader.Read())
                        {
                            Shipper shipper = new Shipper
                            {
                                ShipperId = (int)reader["ShipperId"],
                                ShipperName = (string)reader["ShipperName"]
                            };

                            shippers.Add(shipper);
                        }

                        return shippers;
                    }
                }
            }
        }

        public async Task<IEnumerable<Shipment>> GetShipmentsByShipper(int shipperId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                // Query to retrieve shipments by shipper from the database
                string query = "SELECT * FROM Shipments WHERE ShipperId = @shipperId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@shipperId", shipperId);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        List<Shipment> shipments = new List<Shipment>();

                        while (reader.Read())
                        {
                            Shipment shipment = new Shipment
                            {
                                ShipmentId = (int)reader["ShipmentId"],
                                ShipperName = (string)reader["ShipperName"],
                                CarrierName = (string)reader["CarrierName"],
                                ShipmentDescription = (string)reader["ShipmentDescription"],
                                ShipmentWeight = (decimal)reader["ShipmentWeight"],
                                RateDescription = (string)reader["RateDescription"]
                            };

                            shipments.Add(shipment);
                        }

                        return shipments;
                    }
                }
            }
        }
    }
}
