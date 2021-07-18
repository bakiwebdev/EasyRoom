/* eslint-disable no-unused-vars */
import React from 'react'
import '../../Style/SideButton.css'
import PostIcon from '../../icons/post.png'

function SideButton(props) {

    return (
        <div className="homeButton">
            <img
                src= {PostIcon}
                width="40"
                height="40"
                color= "blue"
                className="d-inline-block align-top"
                alt="icon"
            />
            <h2>{props.name}</h2>
        </div>
    )
}

export default SideButton
