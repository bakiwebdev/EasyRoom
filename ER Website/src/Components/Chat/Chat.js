import React, { useState, useEffect, useContext} from 'react'
import { UserContext} from '../../App'
import axios from 'axios'
import '../../Style/Chat.css'
import ManIcon from '../../icons/avatar01.png'
function Chat(props) {

    const [chats, setChats] = useState([])
    const [body, setBody] = useState("")
    const [user, setUser] = useContext(UserContext)

    useEffect(() => {

        const requestOptions = {
            fromID : user.ID,
            toID : 2
        }

        const config = { 
            headers: { Authorization: `Bearer ${user.Token}`}
        }

        axios.post( (process.env.REACT_APP_LOCAL_PATH + 'api/Messages/GetMessages'),requestOptions, config)
        .then(res => {
            setChats(res.data)
        })
        .catch(err => {
            console.log(err)
        })
    }, [user.ID])

    const handleMessage = (e) => 
    {
        e.preventDefault()

        const requestOptions = {
            fromID : user.ID,
            toID : 2,
            body : e.target.value
        }

        

        alert(body)
        
        // axios.post( (process.env.REACT_APP_LOCAL_PATH + 'api/Messages'), requestOptions)
        // .then(res => {
        //     alert(res)
        // })
        // .catch(err => {
        //     console.log(err)
        // })
    }

    return (
        <div className="mainChat">
            <div className="chatHeader">
                <img
                    src={ManIcon}
                    width="40"
                    height="40"
                    className="d-inline-block align-top"
                    alt="React Bootstrap logo"
                />

                <h2>Lamrot Endris</h2>
            </div>
            <div className="chatBody">
            {
                chats.map(chat => 
                    {
                        if(chat.sender === user.ID)
                        {
                            return (<div className="user">{chat.body}</div>)
                        }
                        else
                        {
                            return (<div className="from">{chat.body}</div>)
                        }
                    })
                
                // dummyChat.map(chat =>

                //     {
                //         if(chat.id === 1)
                //         {
                //             return (<div className="from">{chat.body}</div>)
                //         }
                //         else
                //         {
                //             return (<div className="user">{chat.body}</div>)
                //         }
                //     }
                // )
            }
            </div>
            <div className="chatFooter">
                <form onSubmit={handleMessage}>
                    <input 
                    type="text"
                    name="body"
                    placeholder="say something ..."
                    onChange = {e => setBody({...body, body: e.target.value })}
                    />
                    {/* <input type="submit" value="Send" /> */}
                </form>
            </div>

        </div>
    )
}

export default Chat
