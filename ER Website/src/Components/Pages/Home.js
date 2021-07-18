import React from 'react'
import '../../Style/Home.css'
import { Container } from 'react-bootstrap';
import PostController from '../Controller/PostController';
import Navigation from '../Navigation';
import HomeRoute from '../Router/HomeRoute';

function Home() {
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
                    <PostController />
                </div>
                <div className="rightSide">
                    right side
                </div>
            </div>
        </div>
    )
}

export default Home
