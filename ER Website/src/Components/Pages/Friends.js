import React from 'react'
import { Container } from 'react-bootstrap';
import FriendsCollection from '../Collection/FriendsCollection';
import Navigation from '../Navigation';
import HomeRoute from '../Router/HomeRoute';

function Friends() {
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
                    <FriendsCollection />
                </div>
                <div className="rightSide">
                    right side
                </div>
            </div>
        </div>
    )
}

export default Friends
