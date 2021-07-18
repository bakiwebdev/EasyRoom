import React from 'react'
import { Container } from 'react-bootstrap';
import Navigation from '../Navigation';
import PostForm from '../Post/PostForm';
import HomeRoute from '../Router/HomeRoute';

function CreatePost() {
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
                    <PostForm />
                </div>
                <div className="rightSide">
                    right side
                </div>
            </div>
        </div>
    )
}

export default CreatePost
