import React from 'react';
import App from './App.tsx'; // Assuming your main component is App.tsx
import './index.css'; // Or './index.scss', './index.sass', etc. for global styles

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <App />
  </React.StrictMode>,
);