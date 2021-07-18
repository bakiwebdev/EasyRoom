import React, {useState} from 'react'
import './App.css';
//React Bootstarp stylesheet link
import 'bootstrap/dist/css/bootstrap.min.css';
import AppRoute from './Components/Router/AppRoute';


//context
export const UserContext = React.createContext()

function App() {

  //const [user, setUser] = useState("state with out changing")
  //user instance
  const [user, setUser] = useState({
    ID: 0,
    Token: "Unknown",
    Firstname : "Unknown",
    Lastname : "Unknown",
    Username : "Unknown",
    Email : "Unknown",
    BirthDate : "Unknown",
    Gender : "Unknown"
  })

  return (
    <UserContext.Provider value = {[user , setUser]} >
      <AppRoute />
    </UserContext.Provider>
  );
}

export default App;
