import React, { useState,useContext } from 'react'
import axios from 'axios';
import { UserContext} from '../../App'
import { Button, Form, Modal } from 'react-bootstrap'

function EditProfileModal(props) {

    const [show, setShow] = useState(false);
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    //input
    const [user] = useContext(UserContext)
    const [state, setState] = useState({
        firstname : user.Firstname,
        lastname : user.Lastname,
        email : user.Email
    })
    //handle changes
    const handleChange = (e) =>
    {
        const {id, value} = e.target
        setState(prevState => ({
            ...prevState,
            [id] : value
        }))
    }

    const requestOptions = {
        id : user.ID,
        firstname : state.firstname,
        lastname : state.lastname,
        email : state.email
    } 

    const config = { 
        headers: { Authorization: `Bearer ${user.Token}`}
    }

    //handle submit
    const handleSubmit = (e) => 
    {
        e.preventDefault()
        axios.post((process.env.REACT_APP_LOCAL_PATH) + 'api/Users/ChangeDetail', requestOptions,config)
        .then(response => {
            alert("Profile Changed")
        })
        .catch(error => {
            alert(error)
        })
    }

    return (
        <>
            <button onClick={handleShow}>
                Edit
            </button>
            <Modal show={show} onHide={handleClose}>
                <Modal.Header closeButton>
                    <Modal.Title>
                        Edit Profile
                    </Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Form>
                        <Form.Group>
                            <Form.Label>Firstname</Form.Label>
                            <Form.Control 
                            type="text" 
                            id="firstname"
                            value={state.firstname}
                            onChange={handleChange} />
                        </Form.Group>
                        <Form.Group>
                            <Form.Label>Lastname</Form.Label>
                            <Form.Control
                            type="text"
                            id="lastname"
                            value={state.lastname}
                            onChange={handleChange} />
                        </Form.Group>
                        <Form.Group>
                            <Form.Label>Email</Form.Label>
                            <Form.Control 
                            id="email"
                            type="email"
                            value={state.email}
                            onChange={handleChange} />
                        </Form.Group>
                    </Form>
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={handleClose}>
                        Close
                    </Button>
                    <Button variant="primary" onClick={handleSubmit}>
                        Save Changes
                    </Button>
                </Modal.Footer>
          </Modal>
        </>
    )
}

export default EditProfileModal
