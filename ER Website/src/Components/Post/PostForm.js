import axios from 'axios'
import React, { useState, useContext} from 'react'
import { UserContext} from '../../App'
import '../../Style/PostForm.css'

function PostForm() {

    const [user, setUser] = useContext(UserContext)
    const [post, setPost] = useState({
        title : "",
        body : ""
    })

    const handleChange = (e) =>
    {
        const {id, value} = e.target
        setPost(prevState => ({
            ...prevState,
            [id] : value
        }))
    }

    const handleSubmit = (e) =>
    {
        e.preventDefault()
        const requestOptions = 
        {
            userID : user.ID,
            title: post.title,
            body: post.body
        }
        const config = { 
            headers: { Authorization: `Bearer ${user.Token}`}
        }
        axios.post(process.env.REACT_APP_LOCAL_PATH + 'api/Posts',requestOptions,config)
        .then(res => {
            alert(res.data)
        })
        .catch(error => 
            {
                console.log("Unable to create post " + {error})
            })
    }


    return (
        <div className="postForm">
            <form onSubmit={handleSubmit}>
                <label className="titleInput">
                    <h2>Title</h2>
                    <input 
                    onChange={handleChange}
                    data-testid="TitleInput"
                    id = "title"
                    type="text" 
                    name="title"/>
                </label>

                <label className="typeInput">
                    <h2>Type</h2>
                    <select name="Type" id="Type">
                        <option value = "All">All</option>
                        <option value = "Male">COD</option>
                    </select>
                </label>

                <label className="subjectInput">
                    <h2>Body</h2>
                    <textarea
                    id="body"
                    onChange={handleChange}
                    name="body"
                    placeholder="Write something"
                    >

                    </textarea>
                </label>
                
                <button type="submit">Post</button>
            </form>
        </div>
    )
}

export default PostForm
