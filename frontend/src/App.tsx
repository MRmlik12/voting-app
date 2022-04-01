import React from 'react';
import {BrowserRouter, Route, Routes} from "react-router-dom";
import IndexView from "./views/IndexView";

const App = () => {
  return (
    <div>
      <Routes>
        <Route index element={<IndexView />} />
      </Routes>
    </div>
  );
}

export default App;
