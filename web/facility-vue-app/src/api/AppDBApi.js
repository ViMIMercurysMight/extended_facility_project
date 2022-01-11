import axios from "axios";
export default class DbAPI {
    static SERVER_BASE = "https://localhost:44303";
    static create(controllerName, obj, sucessCallBack, rejectCallBack) {
        axios({
            method: "POST",
            url: `${DbAPI.SERVER_BASE}/${controllerName}/Post${controllerName}/`,
            data: {
                ...obj
            }
        }).then(_ => sucessCallBack()).catch(_ => rejectCallBack());
    }
    static delete(controllerName, id, successCallBack, rejectCallBack) {
        axios({
            method: "DELETE",
            url: `${DbAPI.SERVER_BASE}/${controllerName}/Delete${controllerName}/`,
            params: {
                id: id
            }
        }).then(_ => successCallBack()).catch(_ => rejectCallBack());
    }
    static update(controllerName, obj, successCallBack, rejectCallBack) {
        axios({
            method: "PUT",
            url: `${DbAPI.SERVER_BASE}/${controllerName}/Put${controllerName}/`,
            data: {
                ...obj
            }
        }).then(_ => successCallBack()).catch(_ => rejectCallBack());
    }
    static getCountOfPages(controllerName, perPage, successCallBack, rejectCallBack) {
        axios
            .get(`${DbAPI.SERVER_BASE}/${controllerName}/GetCountOfPages`, { params: { perPage: perPage } })
            .then(response => successCallBack(response.data)).catch(_ => rejectCallBack());
    }
    static getItem(controllerName, id, sucessCallBack, rejectCallBack) {
        axios
            .get(`${DbAPI.SERVER_BASE}/${controllerName}/${id}`)
            .then(response => sucessCallBack(response.data)).catch(_ => rejectCallBack());
    }
    static getItemPage(controllerName, perPage, currentPage, sucessCallBack, rejectCallBack) {
        axios
            .get(`${DbAPI.SERVER_BASE}/${controllerName}/Get${controllerName}`, {
            params: {
                page: currentPage,
                pageSize: perPage
            }
        })
            .then(response => sucessCallBack(response.data)).catch(_ => rejectCallBack());
    }
    static getAll(controllerName, sucessCallBack, rejectCallBack) {
        axios
            .get(`${DbAPI.SERVER_BASE}/${controllerName}/GetAll`)
            .then(response => sucessCallBack(response.data)).catch(_ => rejectCallBack());
    }
}
//# sourceMappingURL=AppDBApi.js.map