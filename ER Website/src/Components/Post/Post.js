import { Button } from 'react-bootstrap'
import React, {useContext, useState} from 'react'
import { UserContext} from '../../App'
import axios from 'axios'
import '../../Style/Post.css'
import WomanIcon from '../../icons/avatar02.png'
import ManIcon from '../../icons/avatar01.png'

function Post(props) {

    const [user, setUser] = useContext(UserContext)
    const [state, setState] = useState({
        id : "",
        status : ""
    })

    function imageRender() 
    {        
        if(props.value.gender === "Male")
        {
            return  <img src={ManIcon} className="d-inline-block align-top" alt="React Bootstrap logo" />
        }
        return  <img src={WomanIcon} className="d-inline-block align-top" alt="React Bootstrap logo" />
    }

    function registerRender()
    {
        if(state.status === true)
        {
            return <h3>Unregister</h3>
        }

        return <h3>Register</h3>
    }

    //to check for the firstime if the user register to the post.

    // function checkStatus()
    // {
    //     if(state == null)
    //     {
    //         const requestOptions = {
    //             userID : user.ID,
    //             postID : props.value.postID,
    //             status : state.status
    //         }
    //         axios.post( (process.env.REACT_APP_LOCAL_PATH + 'api/Registers/GetRegisterStatus' ), requestOptions)
    //         .then(response => {
    //             if(response != null)
    //             {
    //                 setState(
    //                 {
    //                     id : response.data.id,
    //                     status : response.data.status
    //                 })
    //             }
    //         })
    //     }
        
    // }

    //post handle to check the staus fo the post
    
    // const handleClick = (e) =>
    // {
    //     e.preventDefault()

    //     const requestOptions = {
    //         userID : user.ID,
    //         postID : props.value.postID
    //     }
    //     axios.post( (process.env.REACT_APP_LOCAL_PATH + 'api/Registers/ChangePostStatus'), requestOptions)
    //     .then(response => 
    //         {
    //             if(response.data != null)
    //             {
    //                 setState(
    //                     {
    //                         id : response.data.id,
    //                         status : response.data.status
    //                     }
    //                 )
    //             }
    //             else
    //             {
    //                 alert("can not display ")
    //             }
    //         }
            
    //         )
    //     .catch(error => {
    //         alert("Something goes wrong, please try later!")
    //     })
    // }


    return (
        // post container 
        <div className="post">
        {/* post header  */}
        <div className="postHeader">
            {/* owner of post content */}
            <div className="postOwner">
                { imageRender() }
                <h3>{props.value.firstname} {props.value.lastname}</h3> 
            </div>
            {/* date and time */}
            <div className="postDateTime">
                <p>{props.value.date}</p>
            </div>
        </div>
        <div className="postBody">
            <h2>{props.value.title}</h2>
            <p>{props.value.body}</p>
        </div>
        {/* post footer */}
        <div className="postFooter">
            <Button 
            className="btn"
            // onClick ={handleClick}
            >
                {registerRender()}                   
            </Button>
        </div>
    </div>
    )
}

export default Post
