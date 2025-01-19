import React, { ReactNode } from 'react';
import '../styles/HomePage.css';

interface MainLayoutProps {
    children: ReactNode;
}

const MainLayout: React.FC<MainLayoutProps> = ({ children }) => {
    return (
        <div className="main-layout">
            <nav className="navbar">
                <div className="navbar-logo">
                    <a href="/">🎥 P_Review</a>
                </div>
                <ul className="navbar-links">
                    <li><a href="/">Home</a></li>
                    <li><a href="/reviews">Reviews</a></li>
                    <li><a href="/about">Sobre</a></li>
                    <li><a href="" className="login-link">Login</a></li>
                </ul>
            </nav>
            <div className="content">
                {children}
            </div>
            <footer className="footer">
                <p>&copy; {new Date().getFullYear()} P_Review. Todos os direitos reservados.</p>
            </footer>
        </div>
    );
};

export default MainLayout;