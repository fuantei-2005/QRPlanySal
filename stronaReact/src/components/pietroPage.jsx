import { useState, useEffect } from "react";
import { useParams, Link, useLocation } from "react-router-dom";


export default function PietroPage() {
    const { pietro } = useParams();

      const [sale, setSale] = useState([])
      const [loading, setLoading] = useState(true)
      const [error, setError] = useState("")
    
      const location = useLocation();
      
      useEffect(() => {
        fetch('/api/sala')
            .then((res) => res.json())
            .then((res) => {
                const filteredSale = res.filter((x) => x.pietro === String(pietro))
                setSale(filteredSale)
                setLoading(false)
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
    		<div className='p-4 bg-stone-200 shadow-xl/20 flex justify-between'>
          <div className="flex">
            <Link to={'/'} state={location.state}><p className="transition-all hover:cursor-pointer hover:bg-stone-300 my-auto text-3xl bg-stone-200 w-12 p-2 m-0 rounded-sm">⮨</p></Link>
            <p className="text-3xl p-2">Pietro {pietro}</p>
          </div>
          { checkAdmin() ? <p className="p-2 text-xl text-gray-700 flex-end">Zalogowany jako Administrator.</p> : <></>}       
        </div>
        {!error ? <p className="p-4 text-3xl text-center">Wybierz salę.</p> : <></>}
        
        <div className='flex justify-center'>
          {error && <p className='m-2 p-4 text-xl bg-red-400 text-white rounded-sm text-center'>{String(error)}</p>}
          {!error && <>
            {loading ? <p>Ładowanie</p> : <>{sale.map(x => <Link to={`/sala/${x.pietro}/${x.numer}`} state={location.state}><p
                className="
                transition-all
                hover:cursor-pointer hover:h-18 hover:bg-indigo-200 hover:text-black
                h-16 w-20 text-xl text-center shadow-xl/6 p-4 m-2 rounded-md bg-indigo-300 text-white
                " 
              key={x.id}>{x.pietro}.{x.numer}
              </p></Link> )}
              </>}
            </>}
        </div>
    </>

}