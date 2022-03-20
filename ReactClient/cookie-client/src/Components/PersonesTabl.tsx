import { FunctionComponent,  useState } from "react";
import Person from "../Models/Person";
import {PersComponent} from "./PersonesComponent";
import {http, useApiGet} from '../Api';
import {InputComponent} from './InputComponent';


type prop={
 persones:Person[];
 setPers?:React.Dispatch<React.SetStateAction<Person[]>>;
}

export const PersonesTable:FunctionComponent<prop>=({persones,setPers})=>{

    const {post,data}= useApiGet<Person[]>('UpdatePersones', false, {}, new Array<Person>(),true);
    const [loading,setLoading] = useState(false);
    const [price,setPrice] = useState(0);
    const buyCookies=(id:number)=>{
        if(price===0||isNaN(price)) return;
        setLoading(true);
        let pList = persones;
        pList.forEach(p=>{
            if(p.id!==id){
                p.alldebit += price/pList.length;
                p.debites.push({borrowerId:id,debSum:price/pList.length,personId:p.id});
            }
            if(p.id===id){
                p.money-=price;
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
        if(persones[id].alldebit===0)return;
        setLoading(true);
       const resp = http({method:'POST',url:"ReturnDebs",data:{id:id}})
         resp.then(r=>{
            if(r.data !== null&&r.data!==''){
                setPers&&setPers([...r.data]);
            }
             setLoading(false);
            });   
    }
    const addPersone = ()=>{
        console.log("Добавление пользователя");
    }

        
    
    return (
    <div style={{border:"2px solid #606060",width:"1200px"}}>
        <InputComponent title={"Цена печенья"} onChange={e=>{setPrice(e.target.valueAsNumber)}}/>
        <div style={{borderTop:"1px solid #606060"}}/>
        {persones.map(item=>{  
            return <PersComponent key={item.id} pers={item} buyCookies={buyCookies} returnDebit={returnDebs} loading={loading}/>   
        })}
        <div style={{borderTop:"1px solid #606060"}}/>
        <button style={{display:'block',margin:'10px'}} onClick={addPersone}>Добавить работника</button> 
    </div>);
}