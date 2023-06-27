using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BackendService.Models;
using BackendService.Services;

namespace BackendService.Controllers
{
    [ApiController]
    [Route("api/shipments")]
    public class ShipmentsController : ControllerBase
    {
        private readonly DatabaseService _databaseService;

        public ShipmentsController(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        [HttpGet("shippers")]
        public async Task<ActionResult<IEnumerable<Shipper>>> GetShippers()
        {
            var shippers = await _databaseService.GetShippers();
            if (shippers == null)
                return NotFound();

            return shippers;
        }

        [HttpGet("shippers/{shipperId}")]
        public async Task<ActionResult<IEnumerable<Shipment>>> GetShipmentsByShipper(int shipperId)
        {
            var shipments = await _databaseService.GetShipmentsByShipper(shipperId);
            if (shipments == null)
                return NotFound();

            return shipments;
        }
    }
}
