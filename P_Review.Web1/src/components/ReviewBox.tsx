import React, { useEffect, useState } from 'react';
import axios from 'axios';
import '../styles/ReviewBox.css';
import ReviewItem from './ReviewItem';
import { IReviewBoxItem } from '../types/IReviewBoxItem';
import { IMovieDTO } from '../types/IMovieDTO';

const ReviewBox: React.FC = () => {
    const [reviews, setReviews] = useState<IReviewBoxItem[]>([]);

    useEffect(() => {
        // Função para buscar os dados dos reviews do backend
        const fetchReviews = async () => {
            try {
                const response = await axios.get('https://localhost:7250/api/movie');
                // Verifique a estrutura da resposta da API
                console.log(response.data);

                // Acesse o array dentro de $values
                const movies = response.data.$values.map((movie: IMovieDTO) => ({
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