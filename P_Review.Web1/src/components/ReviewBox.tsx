import React, { useEffect, useState } from 'react';
import axios from 'axios';
import '../styles/ReviewBox.css';
import ReviewItem from './ReviewItem';

interface Review {
    imageUrl: string;
    movieName: string;
    authorName: string;
}

interface MovieDTO {
    id: number;
    name: string;
    description: string;
    imageURL: string;
    userName: string;
    userID: number;
}

const ReviewBox: React.FC = () => {
    const [reviews, setReviews] = useState<Review[]>([]);

    useEffect(() => {
        // Função para buscar os dados dos reviews do backend
        const fetchReviews = async () => {
            try {
                const response = await axios.get('https://localhost:7250/api/movie'); // Substitua pela URL da sua API
                const movies = response.data.map((movie: MovieDTO) => ({
                    imageUrl: movie.imageURL,
                    movieName: movie.name,
                    authorName: movie.userName
                }));
                setReviews(movies);
            } catch (error) {
                console.error('Erro ao buscar os reviews:', error);
            }
        };

        fetchReviews();
    }, []);

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