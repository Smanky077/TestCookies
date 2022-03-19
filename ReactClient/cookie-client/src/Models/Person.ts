import Debit from "./Debit";

export default class Person{
    public id:number = 0;
    public name:string = ""; 
    public money:number = 0; 
    public debites:Debit[] =[];
    public borrowes:Debit[] =[];
    public alldebit:number=0;
    
}