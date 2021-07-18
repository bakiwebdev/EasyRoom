import React, {useState, useEffect, useContext} from 'react'
import { UserContext} from '../../App'
import axios from 'axios'
import '../../Style/Home.css'
import '../../Style/Message.css'
import MessaageButton from '../Buttons/MessaageButton'
import Chat from '../Chat/Chat'
import Navigation from '../Navigation'

function Message() {

    //friends state
    const [friends, setFriends] = useState([])
    const [friendID, setFriendID] = useState([])
    const [user] = useContext(UserContext)
    
    const onButtonHandler = (id) =>
    {
        alert(id)
        setFriendID(id)
        console.log(id)
    }

    const config = { 
        headers: { Authorization: `Bearer ${user.Token}`}
    }

    //get friends list
    useEffect( () => 
    {
        //api request body
        const requestOptions = {
            userID : user.ID
        }
        

        axios.post(process.env.REACT_APP_LOCAL_PATH + 'api/Friends/GetUserFriends', requestOptions, config)
            .then(res => {
            console.log(res)
            setFriends(res.data)
            })
            .catch(err => {
                console.log(err)
            })
    })

    const friendButtonHandler = () =>
    {
        alert("On Button Clicked")
    }

    return (
        <div className="main">
            <Navigation />
            <div className="home">
                <div className="leftSide">
                <div className="left">
                        <h1>Recent Messages</h1>
                        <div className="messageList">
                            {
                               friends.map(friend => <MessaageButton onButtonHandler={friendButtonHandler} key={friend.id} value = {friend} />)                                
                            }
                        </div>
                    </div>
                </div>
                <div className="middle">
                    <Chat data={friendID}/>
                </div>
                <div className="rightSide">
                    right side Message
                </div>
            </div>
        </div>
    )
}

export default Message
