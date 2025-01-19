import React, { ReactNode } from 'react';

interface MainLayoutProps {
    children: ReactNode;
}

const MainLayout: React.FC<MainLayoutProps> = ({ children }) => {
    return (
        <div className="main-layout">
            <nav className="navbar">
                <ul>
                    <li><a href="/">Home</a></li>
                    <li><a href="/reviews">Reviews</a></li>
                    <li><a href="/about">Sobre</a></li>
                </ul>
            </nav>
            <div className="content">
                {children}
            </div>
        </div>
    );
};

export default MainLayout;