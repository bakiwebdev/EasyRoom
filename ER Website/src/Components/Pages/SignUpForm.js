import React from 'react'
import { NavLink } from 'react-router-dom'
import '../../Style/Signup.css'

function SignUpForm() {

    return (
        <div className="SignupContainer" >
            <div className="SignupIntro">
                
                <h1 data-testid="ProductName" className="BrandHeader">Easy Room</h1>

                <p data-testid="ProductExp" className="BrandDetail">Easy Room is a gamer networking site that 
                    makes it easy for you to connect and share 
                    with your friends online.
                </p>
                
            </div>
            <div className="SingupForm">

                <h2 data-testid="AccountHeader">Create your account</h2>
                <p data-testid="AccountP">Welcome to Easy Room!</p>
                <form>
                    <label>
                        <span>First Name</span>
                        <input 
                        data-testid="FirstnameInput"
                        type="text" 
                        name="firstname" />
                    </label>
    
                    <label>
                        <span>Last Name</span>
                        <input 
                        data-testid="LastnameInput"
                        type="text" 
                        name="lasttname" />
                    </label>
    
                    <label>
                        <span>Gendre</span>
                        {/* <input 
                        type="text" 
                        name="gender" /> */}
                        <select name="gender" id="gender">
                            <option value = "Male">Male</option>
                            <option value = "Male">Female</option>
                        </select>
                    </label>
    
                    <label>
                        <span>Email Address</span>
                        <input 
                        data-testid="EmailInput"
                        type="email" 
                        name="emailAddress" />
                    </label>
    
                    <label>
                        <span>Username</span>
                        <input 
                        data-testid="UsernameInput"
                        type="text" 
                        name="username" />
                    </label>
    
                    <label>
                        <span>Date Of Birth</span>
                        <input type="date" name="dateOfBirth" />
                    </label>
    
                    <label>
                        <span>Password</span>
                        <input 
                        data-testid="PasswordInput"
                        type="text" 
                        name="password" />
                    </label>
    
                    <label>
                        <span>Confirm Password</span>
                        <input 
                        data-testid="ConfirmPassInput"
                        type="text" 
                        name="password2" />
                    </label>
    
                    <input type="submit" value="Create" />
                </form>

                <div className="login">
                    <strong data-testid="LoginLinkText">Already have an account ? </strong>
                    <NavLink to="/Login">
                        Login
                    </NavLink>
                </div>
            </div>
        </div>
    )
}

export default SignUpForm
