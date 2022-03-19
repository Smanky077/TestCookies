import { useEffect ,useState} from 'react';
import './App.css';
import {PersonesTable} from './Components/PersonesTabl';
import Person from "./Models/Person";
import {useApiGet} from './Api';

function App() {
  const {data,setData,loading} = useApiGet<Person[]>('GetAll',false, {}, new Array<Person>());
  console.log('1',data);
  
  const render =()=>{
      if(loading){
        return <div>Загрузка</div>
      }else{
        return <div>
        <PersonesTable persones={data} setPers={setData}/>
      </div>
      }
  }

  return (
    <div className="App">
      <h3>Печенюшная мафия</h3>
      {render()}
    </div>
  );
}

export default App;
