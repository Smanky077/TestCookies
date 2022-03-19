import {FunctionComponent} from "react";
import Person from "../Models/Person";

type prop={
    pers:Person;
    buyCookies:(id:number)=>void;
    returnDebit:(id:number)=>void;
    loading:boolean;
}
export const PersComponent:FunctionComponent<prop>= ({pers,buyCookies,loading,returnDebit}) =>{
   //const [per,setPer] = useState(pers)
   const buy=()=>{
        buyCookies(pers.id);
    }
    const returnDeps =()=>{
        console.log("id",pers.id);
        returnDebit(pers.id);
    }
    
    const render=()=>{
        if(loading) return <div>Загрузка...</div>
        return <div style={{display:"flex",justifyContent:'space-around'}}>
            <div style={{paddingRight:"5px",marginTop:'5px'}}>{pers.name}</div>
            <div style={{paddingRight:"5px",marginTop:'5px'}}>Деньги:{pers.money}</div>
            <div style={{paddingRight:"5px",marginTop:'5px'}}>Долг:{pers.alldebit}</div>
            <div>
                <button onClick={buy}>Купить печенье</button>
                <button onClick={returnDeps}>Отдать долг</button>
            </div>
        </div>
    }

    return <>{render()}</>
          
    
     
}