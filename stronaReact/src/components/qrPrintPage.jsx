import { useRef, useEffect } from "react";
import QRCode from "react-qr-code";
import { useReactToPrint } from "react-to-print";
import { useLocation, useNavigate, Link } from "react-router-dom";

export default function QrPrintPage() {
      const componentRef = useRef(null);
    
      const reactToPrintContent = () => {
        return componentRef.current;
      }

      const handlePrint = useReactToPrint({
        documentTitle: "Kod QR"
      })

      const location = useLocation();
      const navigate = useNavigate();

      useEffect(() => {
        if (!location.state)
          navigate('/', {state:null})
      },[])

      function checkAdmin() {
        if (!location)
            return false
        else {
            if (location.state)
                    return true
            }
        }

    return (<>
      {location.length > 0 && <>
          <div className='p-4 bg-stone-200 shadow-xl/20 flex justify-between'>
            <div className="flex">
              <Link to={`/sala/${location.state.pietro}/${location.state.sala}`} state={location.state}><p className="transition-all hover:cursor-pointer hover:bg-stone-300 my-auto text-3xl bg-stone-200 w-12 p-2 m-0 rounded-sm">⮨</p></Link>
              <p className="text-3xl p-2">Drukowanie kodu QR</p>
            </div>
            { checkAdmin() ? <p className="p-2 text-xl text-gray-700 flex-end">Zalogowany jako Administrator.</p> : <></>}       
          </div>
          <div className="bg-gray-300 w-3/4 mx-auto my-4 rounded-md">
            <p className="bg-indigo-400 text-3xl text-white w-full p-4 text-center rounded-tl-md rounded-tr-md">Podglad</p>
              <div className="flex justify-center p-4 bg-gray-300" ref={componentRef}>
                <div className="flex flex-col bg-white p-4 rounded-sm width-200">
                  <QRCode size={128} value={`${window.location.origin}/sala/${location.state.pietro}/${location.state.sala}`}/>
                </div>
                <div className="flex flex-col p-4 justify-center">
                  <p className="text-5xl font-bold"> Sala {location.state.pietro}.{location.state.sala}</p>
                  <p className="text-xl">
                    Zeskanuj kod aby zobaczyć plan lekcji sali.
                  </p>
                </div>
              </div>
              <button className="bg-gray-200 hover:cursor-pointer hover:bg-gray-100 p-4 text-xl rounded-bl-md rounded-br-md w-full transition-all" onClick={() => handlePrint(reactToPrintContent)}>Drukuj</button>
          </div>
        </>}
    </>)
}