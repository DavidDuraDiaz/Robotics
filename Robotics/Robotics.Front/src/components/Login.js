import React, { useState } from "react";
import { useHistory } from "react-router-dom";
import { useAppContext } from "../libs/contextLib";
import { Button, FormGroup, FormControl, FormLabel } from "react-bootstrap";
import * as serviceApi from "../services/serviceApiLogin";

import "../css/Login.css";

export default function Login() {
    const { setisAuthenticated } = useAppContext();
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const history = useHistory();

    function validateForm() {
        return username.length > 0 && password.length > 0;
    }

    async function handleSubmit(event) {
        event.preventDefault();

        try {
            await serviceApi.login(username, password);
            setisAuthenticated(localStorage.getItem('token') ? true : false);
            history.push("/");
        } catch (e) {
            alert(e.message);
        }
    }

    return (
        <div className="Login">
            <form onSubmit={handleSubmit}>
                <FormGroup controlId="username" size="large">
                    <FormLabel>Username</FormLabel>
                    <FormControl
                        autoFocus
                        value={username}
                        onChange={e => setUsername(e.target.value)}
                    />
                </FormGroup>
                <FormGroup controlId="password" size="large">
                    <FormLabel>Password</FormLabel>
                    <FormControl
                        value={password}
                        onChange={e => setPassword(e.target.value)}
                        type="password"
                    />
                </FormGroup>
                <Button block size="large" disabled={!validateForm()} type="submit">
                    Login
        </Button>
            </form>
        </div>
    );
}