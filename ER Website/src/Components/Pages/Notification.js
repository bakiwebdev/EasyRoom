import React from 'react'
import '../../Style/Home.css'
import '../../Style/Notification.css'
import SideButton from '../Buttons/SideButton'
import Navigation from '../Navigation'
import Post from '../Post/Post'

function Notification() {

    const post = 
    {
        createdDate: "2021-05-13T22:49:26.814834",
        title: "string",
        body: "string",
        game: 
        {
            id: 1,
            name: "COD"
        },
        user: 
        {
            id: 1,
            firstname: "Biruk",
            lastname: "Endris",
            gender: 0,
            username: null,
            email: null,
            dateOfBirth: null
        }
    }


    return (
        <div className="main">
            <Navigation />
            <div className="home">
                <div className="leftSide">
                    <div className="left">
                        <h1>Recent Notifications</h1>

                        <div className="notificationList">
                            <SideButton name="helloadsfadfadfadfasd" />
                            <SideButton name="world" />
                            <SideButton name="world" />
                            <SideButton name="world" />
                            <SideButton name="world" />
                            <SideButton name="world" />
                        </div>
                    </div>

                </div>
                <div className="middle">
                    <Post data={post} />
                </div>
                <div className="rightSide">
                    right side notification
                </div>
            </div>
        </div>
    )
}

export default Notification
