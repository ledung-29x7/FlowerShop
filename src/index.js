import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import 'flowbite';
import App from './App';
import { Provider } from 'react-redux';
import reduxConfig from './reduxs';

const store = reduxConfig();

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <Provider store={store}>
    <App />
  </Provider>
);


