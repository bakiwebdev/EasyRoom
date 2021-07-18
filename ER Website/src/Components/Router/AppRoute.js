import React from 'react'
//React dom
import { BrowserRouter, Route, Switch, Redirect } from "react-router-dom";
import LoginForm from '../Pages/LoginForm';
import SignUpForm from '../Pages/SignUpForm';
import Home from '../Pages/Home';
import Message from '../Pages/Message';
import Notification from '../Pages/Notification';
import CreatePost from '../Pages/CreatePost';
import Friends from '../Pages/Friends';
import Interest from '../Pages/Interest';
import Profile from '../Pages/Profile';

function AppRoute() {
    return (
        <div>     
                               
            <BrowserRouter>
                <Switch>
                    
                    <Route exact path="/">
                        <Redirect to="/Login" />
                    </Route>
                    <Route path='/Login' component={LoginForm} exact/>
                    <Route path='/SignUp' component={SignUpForm} exact/>
                    <Route path='/Home' component={Home} exact/>
                    <Route path='/Message' component={Message} exact/>
                    <Route path='/Notification' component={Notification} exact/>

                    <Route path='/Home/Profile' component={Profile} exact/>
                    <Route path='/Home/Interest' component={Interest} exact/>
                    <Route path='/Home/Friends' component={Friends} exact/>
                    <Route path='/Home/Post' component={CreatePost} exact/>

                    {/* Redirect to the login page if the path is not correct */}
                    <Redirect to="/Login" />
                </Switch>
              {/* <Footer /> */}
            </BrowserRouter>
        </div>
    )
}

export default AppRoute
