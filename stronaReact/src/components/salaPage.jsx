import { useState, useEffect } from "react";
import { useParams, Link, useLocation, useNavigate } from "react-router-dom";
import Data from "../data/data.js";

export default function SalaPage() {
    const { pietro, sala } = useParams();
    const [ loading, setLoading ] = useState(true);
    const [ error, setError ] = useState("");

    const [ resSalaPlan, setResSalaPlan ] = useState({})
    const [ plan, setPlan ] = useState([])

    const location = useLocation();
    const navigate = useNavigate();

    useEffect(() => {
        fetch(`/api/sala/p0,${pietro},${sala}`)
            .then((res) => res.json())
            .then((res) => {
                setResSalaPlan(res)
                setLoading(false)
                setPlan(res.plan)
                
                })
            .catch((error) => {
                setLoading(false)
                setError(error)
            })
    },[])

    function checkAdmin() {
        if (!location)
            return false
        else {
            if (location.state)
                    return true
        }
    }

    return <>
        

            <div className="p-4 flex justify-between bg-stone-200 shadow-xl/20">
                <div className="flex">
                    <Link to={`/pietro/${pietro}`} state={location.state}><p className="transition-all hover:cursor-pointer hover:bg-stone-300 my-auto text-3xl bg-stone-200 w-12 p-2 m-0 rounded-sm">⮨</p></Link>
                    <p className='p-2 text-3xl'>Sala {pietro}.{sala}</p>
                </div>
                { checkAdmin() ? <p className="p-2 text-xl text-gray-700 flex-end">Zalogowany jako Administrator.</p> : <></>}                
            </div>
        { loading ? <p className="text-center p-4 w-full">Ładowanie</p> : 
        <> 
            <div className="w-full flex flex-col justify-center">
                {error && <p className='m-2 p-4 text-xl bg-red-400 text-white rounded-md text-center mx-auto'>{String(error)}</p>}
                    {error.length == 0 && <>
                    <div className="mx-auto flex flex-col justify-center w-3/4 my-4">
                        <p className="p-4 text-2xl rounded-tl-md rounded-tr-md bg-indigo-400 text-white">Wychowawca</p>
                        <p className="p-4 text-2xl rounded-bl-md rounded-br-md bg-gray-200">{resSalaPlan.sala.nauczyciel.imie} {resSalaPlan.sala.nauczyciel.nazwisko}</p>
                    </div>
                    {resSalaPlan.sala.dodatkoweInfo.length > 0 && <div className="mx-auto flex justify-center w-3/4 flex-col my-4">
                        <p className="p-4 text-2xl rounded-tl-md rounded-tr-md bg-indigo-400 text-white">Dodatkowe informacje</p>
                        <p className="p-4 text-2xl rounded-bl-md rounded-br-md bg-gray-200">{resSalaPlan.sala.dodatkoweInfo}</p>
                    </div>}
                    

                
                <table className="mx-auto p-4 text-center w-3/4 my-4">
                    <tbody>
                        <tr>
                            <th colSpan={5} className="bg-indigo-400 p-4 text-white text-2xl text-left font-normal rounded-tl-md rounded-tr-md">
                                Lekcje
                            </th>
                        </tr>
                        <tr>
                            <th className="bg-indigo-300 p-4 text-white">
                                Nr. Lekcji
                            </th>   
                            <th className="bg-indigo-300 p-4 text-white">
                                Czas Lekcji
                            </th>
                            <th className="bg-indigo-300 p-4 text-white">
                                Lekcja
                            </th>
                            <th className="bg-indigo-300 p-4 text-white">
                                Nauczyciel  
                            </th>
                            <th className="bg-indigo-300 p-4 text-white">
                                Klasa  
                            </th>
                        </tr>

                        {plan.length == 0 ? <tr>
                            <td colSpan={5} className="bg-gray-100 p-4 rounded-md">Brak lekcji dla tej sali.</td>
                        </tr> : <></>

                        }

                        {plan.map(x => 
                            
                            <tr key={x.id}>
                                <td className={x.zastepstwo ? "bg-yellow-200 p-4 m-4 rounded-tl-md rounded-bl-md" : "bg-gray-200 p-4 m-4 rounded-tl-md rounded-bl-md"}>
                                    {x.godzinaLekcyjna}
                                </td>
                                <td className={x.zastepstwo ? "bg-yellow-100 p-4 m-4 rounded-tl-md rounded-bl-md" : "bg-gray-100 p-4 m-4 rounded-tl-md rounded-bl-md"}>
                                    {Data.czasLekcji[x.godzinaLekcyjna-1]}
                                </td>
                                <td className={x.zastepstwo ? "bg-yellow-200 p-4 m-4 rounded-tl-md rounded-bl-md" : "bg-gray-200 p-4 m-4 rounded-tl-md rounded-bl-md"}>
                                    {x.przedmiot.nazwa}
                                </td>
                                <td className={x.zastepstwo ? "bg-yellow-100 p-4 m-4 rounded-tl-md rounded-bl-md" : "bg-gray-100 p-4 m-4 rounded-tl-md rounded-bl-md"}>
                                    {x.nauczyciel.imie} {x.nauczyciel.nazwisko}
                                </td>
                                <td className={x.zastepstwo ? "bg-yellow-200 p-4 m-4 rounded-tl-md rounded-bl-md" : "bg-gray-200 p-4 m-4 rounded-tl-md rounded-bl-md"}>
                                    {x.klasa.nazwa}
                                </td>
                            </tr>
                        )}
                    </tbody>
                </table>

                {checkAdmin() ? <div colSpan={6} className="mx-auto w-3/4 flex flex-col justify-center my-4">
                        <p className="p-4 bg-indigo-400 text-white rounded-tl-md rounded-tr-md text-2xl">Dodatkowe funkcje</p>
                        <Link className="hover:bg-gray-100 p-4 rounded-bl-md rounded-br-md transition-all bg-gray-200" to={"/qrprint"} state={{
                            pietro: resSalaPlan.sala.pietro,
                            sala: resSalaPlan.sala.numer,
                            admin: location.state.isAdmin
                        }}>Wydrukuj kod QR</Link>
                    </div> : <></>}</>}
            </div>

        </>
        }

    </>

}