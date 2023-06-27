namespace BackendService.Models
{
    public class Shipment
    {
        public int ShipmentId { get; set; }
        public string ShipperName { get; set; }
        public string CarrierName { get; set; }
        public string ShipmentDescription { get; set; }
        public decimal ShipmentWeight { get; set; }
        public string RateDescription { get; set; }
    }
}
