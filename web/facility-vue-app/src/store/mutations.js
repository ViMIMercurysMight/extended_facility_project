export default {
    setPageCount(state, payload) {
        state.pageCount = payload.data;
    },
    setCurrentPage(state, payload) {
        alert("UPDATE DATA CP+ " + payload.data);
        state.currentPage = payload.data;
    },
    setLoadedPage(state, payload) {
        state.pageItems = payload.data;
    },
};
//# sourceMappingURL=mutations.js.map