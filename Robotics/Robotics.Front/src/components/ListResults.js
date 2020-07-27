import React from "react"
import ListItem from "./ListItem"

import "../css/ListResults.css"

const ListResults = ({ results }) => {
    return (
        <ul className="ListResults">
            {
                results && results.map(result => <ListItem result={result} />)
            }
        </ul>
    );
}

export default ListResults