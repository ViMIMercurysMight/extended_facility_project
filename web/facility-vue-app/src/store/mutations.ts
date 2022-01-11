export default {
    setPageCount(state: any, payload: any) {
        state.pageCount = payload.data;
    },


    setCurrentPage(state: any, payload: any) {
        state.currentPage = payload.data;
    },


    setLoadedPage(state: any, payload: any) {
        state.pageItems = payload.data;
    },


    isUpdateNow(state: any, payload: any) {
        state.isUpdateNow = payload.data;
    },


    isCreateNow(state: any, payload: any) {
        state.isCreateNow = payload.data;
    },


    setUpdateItem(state: any, payload: any) {
        state.updateItem = payload.data;
    },


    reset(state: any) {
        state.updateItem = {};
        state.isUpdateNow = false;
        state.isCreateNow = false;
        state.currentPage = 0;
        state.pageCount = 10;
        state.pageItems = [];
    }



}