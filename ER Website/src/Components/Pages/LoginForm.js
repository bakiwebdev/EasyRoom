import React, {useContext, useState} from 'react'
import { useHistory, NavLink  } from "react-router-dom";
import { UserContext} from '../../App'
import '../../Style/Login.css'
import axios from 'axios'

function LoginForm() {

    const [user, setUser] = useContext(UserContext)
    const history = useHistory()

    const [state, setState] = useState({
        username : "",
        password : ""
    })

    const [isLogin, setIsLogin] = useState(false);

    const renderRedirect = () => {
        if(isLogin === true)
        {
            //<NavLink to="/Home" />
            alert(user.ID)
            return <NavLink to="/Home" />
        }
    }

    const requestOptions = {
        username : state.username,
        password : state.password
    }

    const handleChange = (e) =>
    {
        const {id, value} = e.target
        setState(prevState => ({
            ...prevState,
            [id] : value
        }))
    }

    const handleSubmit = (e) =>
    {
        e.preventDefault()
        axios.post( (process.env.REACT_APP_LOCAL_PATH + 'api/Account/AccountLogin'), requestOptions)
        .then(async response => 
            {
                if(response.data != null)
                {
                    setUser(
                        {
                            ID: response.data.id,
                            Token: response.data.token,
                            Firstname : response.data.firstname,
                            Lastname : response.data.lastname,
                            Username : response.data.username,
                            Email : response.data.email,
                            BirthDate : response.data.birthDate,
                            Gender : response.data.gender
                        }
                    )
                    alert("You logged in successfully")
                    history.push("/Home")
                }

                else
                {
                    alert("Username and password not correct,pleast try again!")
                }
                
                
            }
            
            )
        .catch(error => {
            alert("Something goes wrong, please try later!")
        })
    }
    return (
        
        <div className="LoginContainer">
            { renderRedirect }
            <div className="LoginIntro" >
                <div className="Containt">
                    <h1 data-testid="ProductHeader1">Easy Room</h1>
                    <h2 data-testid="ProductHeader2">Enjoy our free online Chat App</h2>
                    <p data-testid="ProductParagraph">Fast, Secure and Forever free</p>
                </div>
            </div>
            <div className="LoginForm">
                <h2 data-testid="GreatingHeader">Welcome Back!</h2>
                <hr />
                <p data-testid="LoginParagraph">Sign into your account</p>

                <form onSubmit={handleSubmit}>
                    <label>
                        Username :   
                    </label>
                    <input 
                        data-testid="UsernameInput"
                        id="username"
                        value={state.username}
                        type="text" 
                        onChange={handleChange}
                        name="username" />
                    <label>
                        Password :
                    </label>
                    <input 
                        data-testid="PasswordInput"
                        id="password"
                        value={state.password}
                        type="password" 
                        onChange={handleChange}
                        name="password" />
                    <input 
                    className="Button"
                    type="submit" 
                    value="Login" />
                </form>
                <div className="NewAccountLink">
                    <p>Don't have an account ? </p>
                    <NavLink to="/SignUp">
                        Create
                    </NavLink>
                </div>
                
            </div>
        </div>
    )
}

export default LoginForm
