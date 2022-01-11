export default {
    setPageCount(state, payload) {
        state.pageCount = payload.data;
    },
    setCurrentPage(state, payload) {
        state.currentPage = payload.data;
    },
    setLoadedPage(state, payload) {
        state.pageItems = payload.data;
    },
    isUpdateNow(state, payload) {
        state.isUpdateNow = payload.data;
    },
    isCreateNow(state, payload) {
        state.isCreateNow = payload.data;
    },
    setUpdateItem(state, payload) {
        state.updateItem = payload.data;
    },
    reset(state) {
        state.updateItem = {};
        state.isUpdateNow = false;
        state.isCreateNow = false;
        state.currentPage = 0;
        state.pageCount = 10;
        state.pageItems = [];
    }
};
//# sourceMappingURL=mutations.js.map