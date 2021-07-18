import React from 'react'
import { Container } from 'react-bootstrap'
import Navigation from '../Navigation'
import HomeRoute from '../Router/HomeRoute'
import Detail from '../User/Detail'

function Profile() {
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
                    <Detail />
                </div>
                <div className="rightSide">
                    right side
                </div>
            </div>
        </div>
    )
}

export default Profile
