import React from 'react';
import ComponentOne from './components/ComponentOne';
import Events from './components/Events';
import Lists from './components/Lists';
import ParentComponent from './components/ParentComponent';
import './App.css';

function App() {
  return (
    <div className="App">
      <ComponentOne />
      <Events />
      <br />
      <Lists />
      <br />
      <ParentComponent />
    </div>
  );
}

export default App;
