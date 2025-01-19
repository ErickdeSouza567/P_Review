import React from 'react';
import '../styles/HomePage.css';
import ReviewBox from '../components/ReviewBox';

const HomePage: React.FC = () => {
    return (
        <div className="home-page">
            <header className="header">
                <div className="header-content">
                    <h1 className="header-title">🎬 Bem-vindo ao <span className="highlight">P_Review</span>!</h1>
                    <p className="header-subtitle">Descubra, avalie e compartilhe opiniões sobre seus filmes favoritos.</p>
                </div>
            </header>

            <main className="main-content">
                <section className="reviews">
                    <h2 className="section-title">📖 Últimos Reviews</h2>
                    <p className="section-description">Confira o que está em alta na nossa comunidade.</p>
                    <div className="reviews-list">
                        <ReviewBox />
                        {/* Adicione aqui os componentes de review */}
                        <p className="placeholder-text">Nenhum review disponível. Seja o primeiro a publicar!</p>
                    </div>
                </section>
            </main>

            <footer className="footer">
                <div className="footer-content">
                    <p>&copy; {new Date().getFullYear()} <span className="highlight">P_Review</span>. Todos os direitos reservados.</p>
                    <p className="footer-credits">Desenvolvido com ❤️ por Erick De Souza.</p>
                </div>
            </footer>
        </div>
    );
};

export default HomePage;