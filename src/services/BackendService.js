const BackendService = {
    getShippers: async () => {
      const response = await fetch('https://api.example.com/shippers');
      if (!response.ok) {
        throw new Error('Failed to fetch shippers');
      }
      const data = await response.json();
      return data;
    },
  
    getShipperDetails: async (shipperId) => {
      const response = await fetch(`https://api.example.com/shippers/${shipperId}/details`);
      if (!response.ok) {
        throw new Error('Failed to fetch shipper details');
      }
      const data = await response.json();
      return data;
    },
  };
  
  export default BackendService;
  