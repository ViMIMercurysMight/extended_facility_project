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
    [SET_PAGE_COUNT](state: any, payload: any) {
        state.pageCount = payload.data;
    },


    [SET_CURRENT_PAGE](state: any, payload: any) {
        state.currentPage = payload.data;
    },


    [SET_LOADED_PAGE](state: any, payload: any) {
        state.pageItems = payload.data;
    },


    [IS_UPDATE_NOW](state: any, payload: any) {
        state.isUpdateNow = payload.data;
    },


    [IS_CREATE_NOW](state: any, payload: any) {
        state.isCreateNow = payload.data;
    },


    [SET_UPDATE_ITEM](state: any, payload: any) {
        state.updateItem = payload.data;
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