import React, { Component } from 'react';
import { Route } from 'react-router';
import CreateUser from './components/CreateUser';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import AuthorizeRoute from './components/api-authorization/AuthorizeRoute';
import ApiAuthorizationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { ApplicationPaths } from './components/api-authorization/ApiAuthorizationConstants';

import './custom.css'

export default class App extends Component {
    static displayName = App.name;

    state = {
        user: {},
        users: [],
        numberOfUsers: 0
    }

    createUser = (e) => {
        createUser(this.state.user)
            .then(response => {
                console.log(response);
                this.setState({ numberOfUsers: this.state.numberOfUsers + 1 })
            });
    }

    onChangeForm = (e) => {
        let user = this.state.user
        if (e.target.name === 'firstname') {
            user.firstName = e.target.value;
        } else if (e.target.name === 'lastname') {
            user.lastName = e.target.value;
        } else if (e.target.name === 'email') {
            user.email = e.target.value;
        }
        this.setState({ user })
    }

    render() {

        return (
            <div className="App">
                <Header></Header>
                <div className="container mrgnbtm">
                    <div className="row">
                        <div className="col-md-8">
                            <CreateUser
                                onChangeForm={this.onChangeForm}
                                createUser={this.createUser}
                            >
                            </CreateUser>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}
