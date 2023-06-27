import React from 'react';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import Home from './components/Home';
import ShipperList from './components/ShipperList';
import ShipperDetails from './components/ShipperDetails';

function App() {
  return (
    <Router>
      <div className="App">
        <header>
          <h1>My Application</h1>
        </header>
        <main>
          <Switch>
            <Route exact path="/" component={Home} />
            <Route exact path="/shippers" component={ShipperList} />
            <Route exact path="/shippers/:id" component={ShipperDetails} />
          </Switch>
        </main>
      </div>
    </Router>
  );
}

export default App;
