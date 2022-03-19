import {useState,useEffect} from 'react';
import axios, { AxiosRequestConfig } from 'axios';

export const ApiConfig:AxiosRequestConfig={
    baseURL: 'https://localhost:5001/Cookie/',

    withCredentials: true,
    headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json; charset=UTF-8'          
     }
}
export const http = axios.create(ApiConfig);

interface IUseApiResponse<T>{
    data:T;
    loading:boolean;
    error?:string|null;
    setData?: React.Dispatch<React.SetStateAction<T>>;
    put?:(item:T)=>void;
    post?:(item:T)=>void;
}

export const useApiGet = <T extends {}>(baseUrl:string , urlParams:any|boolean,params:{},initial:T,withOutStart?:boolean):IUseApiResponse<T>=>{
    const url = baseUrl;
    const [data,setData]=useState<T>(initial);
    const [loading,setLoading] = useState(false);
    const [error,setError] = useState<string|null>(null);
    const [config,setConfig] = useState<AxiosRequestConfig>({method: 'get', url:urlParams?url+urlParams:url,params:params});
    const [withOutStarting,setStart] = useState<boolean>(withOutStart||false);
    const fetchData = async (conf:AxiosRequestConfig) =>{
        setLoading(true);
        try{
            const res = await http(conf)
            if(conf.method==="PUT"||conf.method==="POST"){
                //successSave('Сохранено');
                console.log("res",res.data);
                setData((res.data.value || res.data) as T);
                console.log("Сохранено",data);
            }else{
                setData((res.data.value || res.data) as T);
            }
                
        }catch(error:any){
            //errorSave("Что то пошло не так");
            setError(error.toString());
        }finally{
            setLoading(false);
        }
    }
    const put = (item: T)=>{
       setStart(false);
        setConfig({method:'PUT',url,data:item});
    }
    const post =(item: T)=>{
        setStart(false);
        setConfig({method:'POST',url,data:item});
    }

    useEffect(()=>{
        if(!withOutStarting){
            fetchData(config);   
        }   
    },[config]);

    return {data,loading,error,setData,put,post};
}