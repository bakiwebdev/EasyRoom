import axios from 'axios'
import React, {useContext} from 'react'
import { UserContext} from '../../App'
import ManIcon from '../../icons/avatar01.png'
import WomanIcon from '../../icons/avatar02.png'


function FollowedFriend(props) {

    const [user] = useContext(UserContext)
    function imageRender() 
    {
        if(props.data.gender === "Male")
        {
            return  <img src={ManIcon}  width="40" height="40" className="d-inline-block align-top" alt="React Bootstrap logo" />
        }
        return  <img src={WomanIcon} width="40" height="40" className="d-inline-block align-top" alt="React Bootstrap logo" />
    }

    const handleStatusChanges = (e) =>
    {
        const requestOptions = 
        {
            id: props.data.id,
            status: false
        }

        const config = { 
            headers: { Authorization: `Bearer ${user.Token}`}
        }

        axios.post(process.env.REACT_APP_LOCAL_PATH + 'api/Friends/ChangeFriendStatus',requestOptions, config)
        .then(res => {
            alert(res.data)
        })
        .catch(error =>
            {
                console.log("unable to remove friend " + {error})
            })
    }

    return (
        <div className="followedFriend">
            <div className="name">
                { imageRender()}
                {' '}
                <h3>{props.data.firstname} {props.data.lastname}</h3>
            </div>
            <div className="status">
                <button onClick={handleStatusChanges}> Unfollow </button>
                <button> Send Message </button>
            </div>
        </div>
    )
}

export default FollowedFriend
