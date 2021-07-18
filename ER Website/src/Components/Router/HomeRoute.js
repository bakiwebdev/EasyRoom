import React from 'react'
import { Link } from 'react-router-dom';
import SideButton from '../Buttons/SideButton'
function HomeRoute() {
    return (
        <div>

            <Link to="/Home/Profile">
                <SideButton iconName="" name="Profile"/>
            </Link>
            <Link to="/Home/Interest">
                <SideButton iconName="" name="Interest"/>
            </Link>
            <Link to="/Home/Friends">
                <SideButton iconName="" name="Friends"/>
            </Link>
            <Link to="/Home/Post">
                <SideButton iconName="" name="Create Post" to="/Home/Post"/>
            </Link>

        </div>
    )
}

export default HomeRoute

