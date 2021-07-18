import React, {useContext, useState} from 'react'
import { UserContext} from '../../App'
import '../../Style/Detail.css'
import ManIcon from '../../icons/avatar01.png'
import WomanIcon from '../../icons/avatar02.png'
import EditProfileModal from '../Modal/EditProfileModal'

function Detail() {

    const [user, setUser] = useContext(UserContext)

    function imageRender() 
    {
        if(user.Gender === "Male")
        {
            return  <img src={ManIcon} className="d-inline-block align-top" alt="React Bootstrap logo" />
        }
        return  <img src={WomanIcon} className="d-inline-block align-top" alt="React Bootstrap logo" />
    }

    return (
        <div className="userDetail">
            <div className="userPicture">
                {imageRender()}
                <div className="userName">
                    <h3>{user.Firstname + " " + user.Lastname}</h3>
                    <p>{user.Email}</p>
                </div>
            </div>
            <div className="userProfile">

                <div className="detail">
                    <h2>ID</h2>
                    <h4>#{user.ID}</h4>
                </div>

                <div className="detail">
                    <h2>Username</h2>
                    <h4>{user.Username}</h4>
                </div>

                <div className="detail">
                    <h2>Gender</h2>
                    <h4>{user.Gender}</h4>
                </div>

                <div className="detail">
                    <h2>Date of Birth</h2>
                    <h4>{user.BirthDate}</h4>
                </div>

                <EditProfileModal />
            </div>
        </div>
    )
}

export default Detail
