import React from 'react'
import ManIcon from '../../icons/avatar01.png'
import WomanIcon from '../../icons/avatar02.png'
import '../../Style/MessageButton.css'
function MessaageButton(props) {

    function imageRender() 
    {
        if(props.value.gender === "Male")
        {
            return  <img src={ManIcon}  width="40" height="40" className="d-inline-block align-top" alt="React Bootstrap logo" />
        }
        return  <img src={WomanIcon} width="40" height="40" className="d-inline-block align-top" alt="React Bootstrap logo" />
    }


    return (

        <div className="messageButton" >
            {imageRender()}
            {' '}
            <h2>{props.value.firstname} {props.value.lastname}</h2>
        </div>
    )
}

export default MessaageButton
