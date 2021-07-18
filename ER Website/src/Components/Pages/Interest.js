import React from 'react'
import { Container } from 'react-bootstrap'
import Navigation from '../Navigation'
import HomeRoute from '../Router/HomeRoute'

function Interest() {
    return (
        <div className="main">
            <Navigation />
            <div className="home">
                <div className="leftSide">
                    <Container className="Container">
                        <HomeRoute />
                    </Container>
                </div>
                <div className="middle">
                    <form>
                    <label>
                        <span>Which related post would like to get ?</span>
                        {/* <input 
                        type="text" 
                        name="gender" /> */}
                        <select name="type" id="type">
                            <option value = "All">Any</option>
                        </select>
                    </label>
                    </form>
                </div>
                <div className="rightSide">
                    right side
                </div>
            </div>
        </div>
    )
}

export default Interest
