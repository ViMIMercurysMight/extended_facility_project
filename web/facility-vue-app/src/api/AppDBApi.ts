import axios from "axios";


export default class DbAPI {

    static SERVER_BASE = "https://localhost:44303";

    static create(
         controllerName : string 
        ,obj            : any    
        ,sucessCallBack : any    
        ,rejectCallBack : any    
    ) {
        axios({
            method: "POST",
            url: `${DbAPI.SERVER_BASE}/${controllerName}/Post${controllerName}/`,

            data: {
                ...obj
            }
        }).then(_ => sucessCallBack()).catch(_ => rejectCallBack());
    }


    static delete(
         controllerName  : string
        ,id              : number
        ,successCallBack : any   
        ,rejectCallBack  : any   
    ) {
        axios({
            method: "DELETE",
            url: `${DbAPI.SERVER_BASE}/${controllerName}/Delete${controllerName}/`,

            params: {
                id: id
            }
        }).then(_ => successCallBack()).catch(_ => rejectCallBack());
    }


    static update(
         controllerName  : string
        ,obj             : any
        ,successCallBack : any
        ,rejectCallBack  : any
    ) {
        axios({
            method: "PUT",
            url: `${DbAPI.SERVER_BASE}/${controllerName}/Put${controllerName}/`,


            data: {
                ...obj
            }
        }).then(_ => successCallBack()).catch(_ => rejectCallBack());
    }



    static getItem(
         controllerName  : string
        ,id              : number
        ,sucessCallBack  : any
        ,rejectCallBack  : any
    ) {
        axios
            .get(`${DbAPI.SERVER_BASE}/${controllerName}/${id}`)
            .then(response => sucessCallBack(response.data)).catch(_ => rejectCallBack());
    }


    static getItemPage(
         controllerName  : string
        ,perPage         : number
        ,currentPage     : number
        ,sucessCallBack  : any
        ,rejectCallBack  : any
    ) {
        axios
            .get(`${DbAPI.SERVER_BASE}/${controllerName}/Get${controllerName}`,{
                params: {
                    page: currentPage,
                    pageSize : perPage
                }
            })
            .then(response => sucessCallBack(response.data)).catch(_ => rejectCallBack());
    }


    static getAll(
         controllerName: string
        ,sucessCallBack: any
        ,rejectCallBack: any
    ) {
        axios
            .get(`${DbAPI.SERVER_BASE}/${controllerName}/GetAll`)
            .then(response => sucessCallBack(response.data)).catch(_ => rejectCallBack());
    }
    
}