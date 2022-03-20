import { FunctionComponent,  useState } from "react";
import Person from "../Models/Person";
import {PersComponent} from "./PersonesComponent";
import {http} from '../Api';
import {InputComponent} from './InputComponent';


type prop={
 persones:Person[];
 setPers?:React.Dispatch<React.SetStateAction<Person[]>>;
}

export const PersonesTable:FunctionComponent<prop>=({persones,setPers})=>{

    //const {put,data,loading}= useApiGet<Person[]>('UpdatePersones', false, {}, new Array<Person>(),true);
    const [loading,setLoading] = useState(false);
    const [price,setPrice] = useState(0);
    const buyCookies=(id:number)=>{
        setLoading(true);
        let pList = persones;
        pList.forEach(p=>{
            if(p.id!==id){
                p.alldebit += 30/pList.length;
                p.debites.push({borrowerId:id,debSum:30/pList.length,personId:p.id});
            }
            if(p.id===id){
                p.money-=30;
            }
        });
        const resp = http({method:'PUT',url:"UpdatePersones",data:persones})
        resp.then(r=>{
            console.log('2',r);
            if(r.data !== null||r.data!=="")setPers&&setPers([...r.data]);
            setLoading(false);
        
        });         
    }

    const returnDebs=(id:number)=>{
        setLoading(true);
       const resp = http({method:'POST',url:"ReturnDebs",data:{id:id}})
         resp.then(r=>{
            if(r.data !== null&&r.data!==''){
                setPers&&setPers([...r.data]);
            }
             setLoading(false);
            });   
    }

        
    
    return (
    <div style={{border:"2px solid #606060",width:"1200px"}}>
        {/* <InputComponent title={"Цена печенья"} onChange={e=>{setPrice(e.target.valueAsNumber)}}/> */}
        {persones.map(item=>{  
            return <PersComponent key={item.id} pers={item} buyCookies={buyCookies} returnDebit={returnDebs} loading={loading}/>   
        })}
    </div>);
}