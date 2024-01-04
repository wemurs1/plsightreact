import { BrowserRouter, Route, Routes } from 'react-router-dom';
import HouseList from '../house/HouseList';
import './App.css';
import Header from './Header';

function App() {
  return (
    <BrowserRouter>
      <div className='container'>
        <Header subtitle='Providing houses all over the world'></Header>
        <Routes>
          <Route path='/' element={<HouseList />} />
        </Routes>
      </div>
    </BrowserRouter>
  );
}

export default App;
