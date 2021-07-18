import React from 'react'
import '../../Style/main.css'

//React dom
import { BrowserRouter, Route, Switch} from "react-router-dom";
import Navigation from '../Navigation';
import Home from './Home';
import Message from './Message';
import Notification from './Notification';


function Main() {
    return (
        <div className="main">
            <Navigation />
            <BrowserRouter>
                <Switch>
                    <Route path='App/Home' component={Home} />
                    <Route path='App/Message' component={Message} />
                    <Route path='App/Notification' component={Notification} />
                </Switch>
            </BrowserRouter>
        </div>
    )
}

export default Main
