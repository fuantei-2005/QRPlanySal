import { useState } from "react"
import { Link, useNavigate } from "react-router-dom"

export default function AdminLogin() {

    const [ isLogged, setIsLogged ] = useState(false)

    const [ loginInputValue, setLoginInputValue] = useState("")
    const [ hasloInputValue, setHasloInputValue] = useState("")

    const [ loggedUser, setLoggedUser ] = useState({})

    const userData = [
        {
            login: "admin",
            password: "admin",
            isAdmin: true
        }   
    ]

    const navigate = useNavigate();
    
    function handleSubmit(e) {
        e.preventDefault();
        var user = userData.find(x => x.login == loginInputValue)
        if (!user)
            alert("Sprawdź login lub hasło.")
        else
            if (user.password == hasloInputValue)
            {
                alert("Pomyślnie zalogowano.")
                setIsLogged(true)
                setLoggedUser(user)
                navigate('/', {state:user})
            }
            else
                alert("Sprawdź login lub hasło.")
    }

    

    return (<>
    	<div className='p-4 bg-stone-200 shadow-xl/20 flex'>
          <p className="text-3xl p-2">Admin Login</p>
        </div>
        <div className="flex justify-center items-center w-full">
            { !isLogged ? <>
            <form className="bg-gray-300 rounded-sm p-6 m-6 flex flex-col"
            onSubmit={(e) => handleSubmit(e)}>
                <p className="text-2xl p-2">Login</p>
                <input className="bg-white rounded-md w-100 h-10 p-2"
                onChange={(e) => setLoginInputValue(e.target.value)}
                value={loginInputValue}></input>

                <p className="text-2xl p-2">Hasło</p>
                <input className="bg-white rounded-md w-100 h-10 p-2"
                type="password"
                onChange={(e) => setHasloInputValue(e.target.value)}
                value={hasloInputValue}></input>

                <button onClick={(e) => handleSubmit(e)}
                className="bg-indigo-400 rounded-md w-100 p-2 my-4 text-2xl text-white">Login</button>
            </form>
            </> : <>
            <div className="bg-gray-300 rounded-sm p-6 m-6 flex flex-col">
                <p className="text-2xl p-2 text-center">Pomyślnie zalogowano.</p>

                <Link to={{
                    pathname: "/",
                    state: loggedUser
                }}
                className="text-center bg-indigo-400 rounded-md w-100 p-2 my-4 text-2xl text-white">Przenieś do strony głównej</Link>
            </div>
            </>}
        </div>
    </>)
}