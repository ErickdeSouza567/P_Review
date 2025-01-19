import React from 'react';
import '../styles/ReviewBox.css';
import ReviewItem from './ReviewItem';

const ReviewBox: React.FC = () => {
    // Exemplo de dados de reviews
    const reviews = [
        {
            imageUrl: 'https://via.placeholder.com/50x75',
            movieName: 'Filme Exemplo 1',
            authorName: 'Autor 1'
        },
        {
            imageUrl: 'https://via.placeholder.com/50x75',
            movieName: 'Filme Exemplo 2',
            authorName: 'Autor 2'
        },
        {
            imageUrl: 'https://via.placeholder.com/50x75',
            movieName: 'Filme Exemplo 3',
            authorName: 'Autor 3'
        },
        {
            imageUrl: 'https://via.placeholder.com/50x75',
            movieName: 'Filme Exemplo 4',
            authorName: 'Autor 4'
        },
        {
            imageUrl: 'https://via.placeholder.com/50x75',
            movieName: 'Filme Exemplo 5',
            authorName: 'Autor 5'
        },
        {
            imageUrl: 'https://via.placeholder.com/50x75',
            movieName: 'Filme Exemplo 6',
            authorName: 'Autor 6'
        },
        {
            imageUrl: 'https://via.placeholder.com/50x75',
            movieName: 'Filme Exemplo 7',
            authorName: 'Autor 7'
        },
        {
            imageUrl: 'https://via.placeholder.com/50x75',
            movieName: 'Filme Exemplo 8',
            authorName: 'Autor 8'
        },
        {
            imageUrl: 'https://via.placeholder.com/50x75',
            movieName: 'Filme Exemplo 9',
            authorName: 'Autor 9'
        },
        {
            imageUrl: 'https://via.placeholder.com/50x75',
            movieName: 'Filme Exemplo 10',
            authorName: 'Autor 10'
        }
    ];

    return (
        <div className="review-box">
            {reviews.map((review, index) => (
                <ReviewItem
                    key={index}
                    imageUrl={review.imageUrl}
                    movieName={review.movieName}
                    authorName={review.authorName}
                />
            ))}
        </div>
    );
};

export default ReviewBox;