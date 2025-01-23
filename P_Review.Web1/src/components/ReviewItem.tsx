import React from 'react';
import '../styles/ReviewItem.css';
import { IReviewItemProps } from '../types/IReviewItemProps';


const ReviewItem: React.FC<IReviewItemProps> = ({ imageUrl, movieName, authorName }) => {
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