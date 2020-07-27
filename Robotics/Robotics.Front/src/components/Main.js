import React from "react";
import Search from "./Search";
import ListResults from "./ListResults";
import * as serviceApi from "../services/serviceApiBooks";

import "../css/Main.css";

export default class Main extends React.Component {
    constructor() {
        super()
        this.state = {
            results: []
        }
    }

    searchBooks(filter, filterValue) {
        serviceApi.retrieve(filter, filterValue)
            .then(results => this.setState({ results }))
    }

    render() {
        return (
            <div className="Home">
                <div className="lander">
                    {/* Crear formulario para filtrar y mostrar resultados
                    <h1>Scratch</h1>
                    <p>A simple React app</p>
                    */}
                    <Search search={this.searchBooks.bind(this)} />
                    <ListResults results={this.state.results} />
                </div>
            </div>
        )
    };
}