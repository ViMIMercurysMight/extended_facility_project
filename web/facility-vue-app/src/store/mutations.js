import { SET_PAGE_COUNT, SET_CURRENT_PAGE, SET_LOADED_PAGE, IS_UPDATE_NOW, IS_CREATE_NOW, SET_UPDATE_ITEM, RESET, } from "@/store/MutationTypes";
export default {
    [SET_PAGE_COUNT](state, payload) {
        state.pageCount = payload.data;
    },
    [SET_CURRENT_PAGE](state, payload) {
        state.currentPage = payload.data;
    },
    [SET_LOADED_PAGE](state, payload) {
        state.pageItems = payload.data;
    },
    [IS_UPDATE_NOW](state, payload) {
        state.isUpdateNow = payload.data;
    },
    [IS_CREATE_NOW](state, payload) {
        state.isCreateNow = payload.data;
    },
    [SET_UPDATE_ITEM](state, payload) {
        state.updateItem = payload.data;
    },
    [RESET](state) {
        state.updateItem = {};
        state.isUpdateNow = false;
        state.isCreateNow = false;
        state.currentPage = 0;
        state.pageCount = 10;
        state.pageItems = [];
    }
};
//# sourceMappingURL=mutations.js.map