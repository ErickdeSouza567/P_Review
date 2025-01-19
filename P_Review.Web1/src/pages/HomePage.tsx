import React from 'react';
import '../styles/HomePage.css';

const HomePage: React.FC = () => {
    return (
        <div className="home-page">
            <header className="header">
                <h1>Bem-vindo ao P_Review</h1>
                <p>Seu site de reviews de filmes favoritos!</p>
            </header>
            <main className="main-content">
                <section className="reviews">
                    <h2>Últimos Reviews</h2>
                    {/* Adicione aqui os componentes de review */}
                </section>
            </main>
            <footer className="footer">
                <p>&copy; 2023 P_Review. Todos os direitos reservados.</p>
            </footer>
        </div>
    );
};

export default HomePage;