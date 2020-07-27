import React, { useState, useEffect } from "react";
import { AppContext } from "../../libs/contextLib";
import { Nav, Navbar, NavItem } from "react-bootstrap";
import Routes from "../../Routes";

import "../../css/App.css";

export default function App() {
    const [isAuthenticating, setIsAuthenticating] = useState(true);
    const [isAuthenticated, setisAuthenticated] = useState(false);


    useEffect(() => {
        onLoad();
    }, []);

    async function onLoad() {
        try {
            setisAuthenticated(localStorage.getItem('token') ? true : false);
        }
        catch (e) {
            if (e !== 'No current user') {
                alert(e);
            }
        }
        setIsAuthenticating(false);
    }

    function handleLogout() {
        setisAuthenticated(false);
        localStorage.clear();
    }

    return (
        !isAuthenticating &&
        <div className="App container">
            <Navbar bg="light" expand="lg">
                <Navbar.Brand href="/">Robotics-Library</Navbar.Brand>   
                <Navbar.Toggle aria-controls="basic-navbar-nav" />
                <Navbar.Collapse id="basic-navbar-nav" className="justify-content-end">
                    {isAuthenticated
                        ? <NavItem onClick={handleLogout}>Logout</NavItem>
                        : <>
                            <Nav.Link href="/">Login</Nav.Link>
                        </>
                    }
                </Navbar.Collapse>
            </Navbar>
            <AppContext.Provider value={{ isAuthenticated, setisAuthenticated }}>
                <Routes />
            </AppContext.Provider>
        </div>
    );
}