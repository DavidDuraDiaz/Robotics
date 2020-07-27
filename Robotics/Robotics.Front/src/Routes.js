import React from "react";
import { Route, Switch } from "react-router-dom";
import { PrivateRoute } from './components/PrivateRoute';
import Main from "./components/Main";
import Login from "./components/Login";
import NotFound from "./components/NotFound";

export default function Routes() {
    return (
        <Switch>
            <PrivateRoute exact path="/" component={Main} />
            <Route path="/login" component={Login} />
            <Route component={NotFound} />
        </Switch>
    );
}