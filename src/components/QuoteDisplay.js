import React, { useEffect, useState } from 'react';
import ApiService from '../services/ApiService';

const QuoteDisplay = () => {
  const [quote, setQuote] = useState('');

  useEffect(() => {
    fetchRandomQuote();
  }, []);

  const fetchRandomQuote = async () => {
    try {
      const response = await ApiService.getRandomQuote();
      setQuote(`${response.content} - ${response.author}`);
    } catch (error) {
      console.log('Error fetching random quote:', error);
    }
  };

  return (
    <div>
      <h2>Random Quote</h2>
      <p>{quote}</p>
    </div>
  );
};

export default QuoteDisplay;
