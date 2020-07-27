import React from "react"

import "../css/ListItem.css"

const ListItem = ({ result: { Title, AuthorName, PublisherName, Quantity } }) => {
    return (
        <li className="ListItem">
            <div className="card">
                <div className="card-body">
                    <h5 className="card-title">{Title}</h5>
                    <p className="card-text">Author: {AuthorName}</p>
                    <p className="card-text">Publisher: {PublisherName}</p>
                    <p className="card-text">Quantity: {Quantity}</p>
                </div>
            </div>
        </li>
    );
}

export default ListItem