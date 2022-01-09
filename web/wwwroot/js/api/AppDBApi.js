import axios from "../../lib/axios";


export default class DbAPI {

   static create(controllerName, obj) {
        axios({
            method: "POST",
            url: `/${controllerName}/Create/`,

            data: {
                ...obj
            }
        }).then(_ => {
            this.changePage(this.currentPage);
            this.updatePageCount();
        });
    }


   static delete(controllerName, id) {
        axios({
            method: "DELETE",
            url: `/${controllerName}/Delete/`,

            params: {
                id: id
            }
        }).then(_ => {
            this.changePage(this.currentPage);
            this.updatePageCount();
        });
    }


    static update(controllerName, obj) {
        axios({
            method: "PUT",
            url: `/${controllerName}/Update/`,


            data: {
                ...obj
            }
        }).then(_ => this.changePage(this.currentPage));
    }


    static getCountOfPages( controllerName ) {
        axios
            .get(`/${controllerName}/GetCountOfPages`)
            .then(response => this.pageCount = response.data);
    }


    static getItem(controllerName, id) {
        axios
            .get(`/${controllerName}/${id}`)
            .then(response => this.data = response.data);
    }


    static getItemPage(controllerName, perPage, currentPage) {
        axios
            .get(`/${controllerName}/GetPageItemJson`,{
                params: {
                    page: currentPage,
                    perPage : perPage
                }
            })
            .then(response => this.pageItems = response.data);
    }


    static getAll(controllerName) {
        axios
            .get(`/${controllerName}/GetAll`)
            .then(response => this.pageItem = response.data);
    }

}