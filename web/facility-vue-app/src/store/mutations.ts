import {
    SET_PAGE_COUNT,
    SET_CURRENT_PAGE,
    SET_LOADED_PAGE,
    IS_UPDATE_NOW,
    IS_CREATE_NOW,
    SET_UPDATE_ITEM,
    RESET,
    IS_ERROR_NOW,
    SET_ERROR_MESSAGE,
    IS_UPDATE_TRANSITED,
    SET_TOTAL_RECORDS,
    SET_MODAL_DISPLAY,
 
    SET_MODAL_DATA,

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


    [IS_ERROR_NOW](state: any, payload: boolean) {
        state.isErrorNow = payload;
    },

    [SET_ERROR_MESSAGE](state: any, payload: string) {
        state.errorMessage = payload;
    },

    [IS_UPDATE_TRANSITED](state: any, payload: boolean) {
        state.isUpdateTransited = payload;
    },


    [SET_TOTAL_RECORDS](state: any, payload: number) {
        state.totalRecords = payload;
    },

    [SET_MODAL_DISPLAY](state: any, payload: boolean) {
        state.displayRemoveModal = payload;
    },

    [SET_MODAL_DATA](state: any, payload: number) {
        state.modalData = payload;
    },


    [RESET](state: any) {
        state.updateItem = {};
        state.isUpdateNow = false;
        state.isCreateNow = true;
        state.currentPage = 0;
        state.pageCount = 0;
        state.pageItems = [];
        state.isErrorNow = false;
        state.isUpdateTransited = false;
        state.errorMessage = "";
        state.totalRecords = 0;
        state.displayRemoveModal = false;
        state.modalData = -1;
    }



}