import React, { useEffect, useState } from 'react';
import BackendService from '../services/BackendService';

const ShipperDetails = ({ shipperId }) => {
  const [shipments, setShipments] = useState([]);

  useEffect(() => {
    if (shipperId) {
      fetchShipperDetails();
    }
  }, [shipperId]);

  const fetchShipperDetails = async () => {
    try {
      const response = await BackendService.getShipperDetails(shipperId);
      setShipments(response);
    } catch (error) {
      console.log('Error fetching shipper details:', error);
    }
  };

  return (
    <div>
      <h2>Shipper Details</h2>
      <table>
        <thead>
          <tr>
            <th>Shipment ID</th>
            <th>Shipper Name</th>
            <th>Carrier Name</th>
            <th>Shipment Description</th>
            <th>Shipment Weight</th>
            <th>Shipment Rate Description</th>
          </tr>
        </thead>
        <tbody>
          {shipments.map((shipment) => (
            <tr key={shipment.shipment_id}>
              <td>{shipment.shipment_id}</td>
              <td>{shipment.shipper_name}</td>
              <td>{shipment.carrier_name}</td>
              <td>{shipment.shipment_description}</td>
              <td>{shipment.shipment_weight}</td>
              <td>{shipment.shipment_rate_description}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default ShipperDetails;
