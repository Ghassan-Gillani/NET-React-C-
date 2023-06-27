import React, { useEffect, useState } from 'react';
import ApiService from './ApiService';

const Home = () => {
  const [quote, setQuote] = useState('');

  useEffect(() => {
    // Fetch a random quote from the API
    const fetchRandomQuote = async () => {
      try {
        const response = await ApiService.getRandomQuote();
        setQuote(response.content);
      } catch (error) {
        console.error('Error fetching random quote:', error);
      }
    };

    fetchRandomQuote();
  }, []);

  return (
    <div>
      <h2>Welcome to the Application</h2>
      <p>Here is a random quote:</p>
      <blockquote>{quote}</blockquote>
    </div>
  );
};

export default Home;
