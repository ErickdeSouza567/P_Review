import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import HomePage from './pages/HomePage';
import MainLayout from './layouts/MainLayout';

function App() {
    return (
        <Router>
            <MainLayout>
                <Routes>
                    <Route path="/" element={<HomePage />} />
                    <Route path="/reviews" element={<HomePage />} />
                    <Route path="/about" element={<HomePage />} />
                    <Route path="/login" element={<HomePage />} />
                </Routes>
            </MainLayout>
        </Router>
    );
}

export default App;