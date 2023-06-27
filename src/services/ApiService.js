const ApiService = {
    getRandomQuote: async () => {
      const response = await fetch('https://api.example.com/quote/random');
      if (!response.ok) {
        throw new Error('Failed to fetch random quote');
      }
      const data = await response.json();
      return data;
    },
  };
  
  export default ApiService;
  