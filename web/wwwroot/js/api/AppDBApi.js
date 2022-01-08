import axios from "axios";


class DbAPI {

    create(controllerName, obj) {
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


    delete(controllerName, id) {
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


    update(controllerName, obj) {
        axios({
            method: "PUT",
            url: `/${controllerName}/Update/`,


            data: {
                ...obj
            }
        }).then(_ => this.changePage(this.currentPage));
    }


    getCountOfPages( controllerName ) {
        axios
            .get(`/${controllerName}/GetCountOfPages`)
            .then(response => this.pageCount = response.data);
    }


    getItem(controllerName, id) {
        axios
            .get(`/${controllerName}/${id}`)
            .then(response => this.data = response.data);
    }


    getItemPage(controllerName, perPage, currentPage) {
        axios
            .get(`/${controllerName}/GetPageItemJson`,{
                params: {
                    page: currentPage,
                    perPage : perPage
                }
            })
            .then(response => this.pageItems = response.data);
    }


    getAll(controllerName) {
        axios
            .get(`/${controllerName}/GetAll`)
            .then(response => this.pageItem = response.data);
    }

}