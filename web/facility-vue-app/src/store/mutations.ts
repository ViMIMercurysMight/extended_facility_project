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

}