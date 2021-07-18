import React, {useState, useEffect,useContext} from 'react'
import axios from 'axios'
import { UserContext} from '../../App'
import Post from '../Post/Post'


function PostController() {

    const [posts, setPosts] = useState([])
    const [user] = useContext(UserContext)

    const config = { 
        headers: { Authorization: `Bearer ${user.Token}`}
    }

    useEffect( () => 
    {
        axios.get(process.env.REACT_APP_LOCAL_PATH + 'api/Posts',config)
            .then(res => {
            console.log(res)
            setPosts(res.data)
            })
            .catch(err => {
                console.log(err)
            })
    }, [])

    return (
        <div>
            {
                posts.map(post => <Post key={post.postID} value ={post} />)
            }
        </div>
    )
}

export default PostController
