import React, {useContext, useState} from 'react'
import { UserContext} from '../App'
import {NavLink,Route,Redirect,useHistory} from 'react-router-dom';
import {Navbar,Form,FormControl,Nav} from 'react-bootstrap';
import ManIcon from '../icons/avatar01.png'
import WomanIcon from '../icons/avatar02.png'
import '../Style/Navigation.css'

function Navigation() {

    const [user, setUser] = useContext(UserContext)
    const history = useHistory()

    const checkIfLogin = () =>
    {
        if (user.ID <= 0) {
            history.push("/Login")
        }
    }

    function imageRender() 
    {
        if(user.Gender === "Male")
        {
            return  <img src={ManIcon}  width="60" height="60" className="d-inline-block align-top" alt="React Bootstrap logo" />
        }
        return  <img src={WomanIcon} width="60" height="60" className="d-inline-block align-top" alt="React Bootstrap logo" />
    }

    return (
        <div >
            <Navbar className="navigation" expand="lg" >
                {checkIfLogin()}                
                {/* user avatar */}
                <Navbar.Brand className="user" >
                    {imageRender()}
                    {' '}
                    <div className="userName">
                        <p>{user.Firstname + " " + user.Lastname}</p>
                        <i>ID : #{user.ID}</i>
                    </div>
                </Navbar.Brand>
                <Navbar.Toggle aria-controls="basic-navbar-nav" />

                <Navbar.Collapse id="basic-navbar-nav" className="navContaint">                   
                    <Form inline>
                        <FormControl type="text" placeholder="Search" className="search" />
                    </Form>
                    <Nav className="mr-auto">
                        <NavLink className="d-inline p-2 bg-dar link" to="/Home">
                            Home
                        </NavLink>
                        <NavLink className="d-inline p-2 bg-dar link" to="/Message">
                            Message
                        </NavLink>
                        <NavLink className="d-inline p-2 bg-dar link" to="/Notification">
                            Notification
                        </NavLink>
                        <NavLink className="d-inline p-2 bg-dar link" to="/Login">
                            Logout
                        </NavLink>
                    </Nav> 
                </Navbar.Collapse>

            </Navbar>
        </div>
    )
}

export default Navigation
