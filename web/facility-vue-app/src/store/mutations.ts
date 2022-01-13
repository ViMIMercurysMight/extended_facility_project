import {
    SET_PAGE_COUNT,
    SET_CURRENT_PAGE,
    SET_LOADED_PAGE,
    IS_UPDATE_NOW,
    IS_CREATE_NOW,
    SET_UPDATE_ITEM,
    RESET,

} from "@/store/MutationTypes";


export default {
    [SET_PAGE_COUNT](state: any, payload: number) {
        state.pageCount = payload;
    },


    [SET_CURRENT_PAGE](state: any, payload: number) {
        state.currentPage = payload;
    },


    [SET_LOADED_PAGE](state: any, payload: any) {
        state.pageItems = payload;
    },


    [IS_UPDATE_NOW](state: any, payload: boolean) {
        state.isUpdateNow = payload;
    },


    [IS_CREATE_NOW](state: any, payload: boolean) {
        state.isCreateNow = payload;
    },


    [SET_UPDATE_ITEM](state: any, payload: any) {
        state.updateItem = payload;
    },


    [RESET](state: any) {
        state.updateItem = {};
        state.isUpdateNow = false;
        state.isCreateNow = false;
        state.currentPage = 0;
        state.pageCount = 10;
        state.pageItems = [];
    }



}