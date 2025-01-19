import React from 'react';
import '../styles/ReviewItem.css';

interface ReviewItemProps {
    imageUrl: string;
    movieName: string;
    authorName: string;
}

const ReviewItem: React.FC<ReviewItemProps> = ({ imageUrl, movieName, authorName }) => {
    return (
        <div className="review-item">
            <img src={imageUrl} alt={movieName} className="review-item-image" />
            <div className="review-item-content">
                <h3 className="review-item-movie-name">{movieName}</h3>
                <p className="review-item-author-name">por {authorName}</p>
            </div>
        </div>
    );
};

export default ReviewItem;