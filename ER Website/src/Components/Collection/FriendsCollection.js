import React, {useState, useEffect, useContext} from 'react'
import { UserContext} from '../../App'
import axios from 'axios'
import '../../Style/FriendCollection.css'
import FollowedFriend from './FollowedFriend'

function FriendsCollection() {
    //friends state
    const [friends, setFriends] = useState([])
    const [user, setUser] = useContext(UserContext)

    //api request body
    const requestOptions = {
        userID : user.ID
    }
    const config = { 
        headers: { Authorization: `Bearer ${user.Token}`}
    }

    //get friends list
    useEffect( () => 
    {
        axios.post(process.env.REACT_APP_LOCAL_PATH + 'api/Friends/GetUserFriends', requestOptions, config)
            .then(res => {
            console.log(res)
            setFriends(res.data)
            })
            .catch(err => {
                console.log(err)
            })
    }, [])


    return (
        <div className="FriendCollection">
            <div className="header">
                <h3>Friends you follow</h3>
            </div>
            <div className="body">
                {
                    friends.map(friend => <FollowedFriend key={friend.id} data = {friend} />)
                }
            </div>
        </div>
    )
}

export default FriendsCollection
