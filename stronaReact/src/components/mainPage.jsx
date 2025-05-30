import { useState, useEffect, useRef } from 'react'
import { useReactToPrint } from "react-to-print"
import { Link, useLocation } from "react-router-dom";
import QRCode from "react-qr-code";

export default function MainPage() {
  const location = useLocation();

  const [pietra, setPietra] = useState([])
  const [loading, setLoading] = useState(true)

  const [error, setError] = useState("")

  useEffect(() => {
    fetch('/api/sala')
        .then((res) => res.json())
        .then((res) => {
          const filteredPietra = [...new Set(res.map((p) => p.pietro))]
          setPietra(filteredPietra)
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

  return (
	<>
    		<div className='p-4 bg-stone-200 shadow-xl/20 flex justify-between'>
          <p className="text-3xl p-2">Strona główna</p>
          { checkAdmin() ? <p className="p-2 text-xl text-gray-700 flex-end">Zalogowany jako Administrator.</p> : <></>}       
        </div>
        {!error && <p className='p-4 text-3xl text-center'>Wybierz piętro.</p>}
        
        <div className='flex justify-center'>
          {error && <p className='m-2 p-4 text-xl bg-red-400 text-white rounded-md text-center'>{String(error)}</p>}
          {loading ? <p className='text-2xl'>Ładowanie...</p> : 
          <>
            {pietra.map(x => <Link key={x} to={`/pietro/${x}`} state={location.state}><p
              className="
              transition-all
              hover:cursor-pointer hover:h-18 hover:bg-indigo-200 hover:text-black
              h-16 w-20 text-xl text-center shadow-xl/6 p-4 m-2 rounded-md bg-indigo-300 text-white
              " 
              key={x}>{x}
              </p></Link> )
            }
          </>
          }
        </div>
	</>
  )
}
