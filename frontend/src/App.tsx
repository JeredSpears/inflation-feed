import { useEffect, useState } from "react";

interface Price {
  id: number;
  sku: string;
  store: string;
  amount: number;
  date: string;
}

function App() {
  const [prices, setPrices] = useState<Price[]>([]);

  useEffect(() => {
    fetch("/api/prices")
      .then((response) => response.json())
      .then((data) => setPrices(data))
      .catch((error) => console.error("Error fetching prices:", error));
  }, []);

  return (
    <div className="min-h-screen bg-gray-100 p-8">
      <h1 className="text-2xl font-bold mb-4">Prices</h1>
      <ul className="bg-white shadow-md rounded-lg p-4">
        {prices.length > 0 ? (
          prices.map((price) => (
            <li key={price.id} className="mb-2">
              <strong>{price.sku}</strong> - {price.store}: ${price.amount.toFixed(2)}
            </li>
          ))
        ) : (
          <p>No prices available.</p>
        )}
      </ul>
    </div>
  );
}

export default App;