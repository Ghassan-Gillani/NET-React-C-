import React, { useEffect, useState } from 'react';
import BackendService from '../services/BackendService';

const ShipperList = ({ onShipperClick }) => {
  const [shippers, setShippers] = useState([]);

  useEffect(() => {
    fetchShippers();
  }, []);

  const fetchShippers = async () => {
    try {
      const response = await BackendService.getShippers();
      setShippers(response);
    } catch (error) {
      console.log('Error fetching shippers:', error);
    }
  };

  return (
    <div>
      <h2>Shippers</h2>
      <ul>
        {shippers.map((shipper) => (
          <li key={shipper.shipper_id} onClick={() => onShipperClick(shipper.shipper_id)}>
            {shipper.shipper_name}
          </li>
        ))}
      </ul>
    </div>
  );
};

export default ShipperList;
