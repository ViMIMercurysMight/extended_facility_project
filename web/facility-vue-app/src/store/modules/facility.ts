import {

    UPDATE_FACILITY,
    DELETE_FACILITY,
    CREATE_FACILITY,
    LOAD_PAGE,
    SET_PAGE_COUNT,
    SET_LOADED_PAGE,
    LOAD_FACILITY_STATUSES,
    SET_CURRENT_PAGE,
    SET_ERROR_MESSAGE,
    IS_ERROR_NOW,
    SET_TOTAL_RECORDS
} from "../MutationTypes";


import DbApi from "@/api/AppDBApi";


export default {
    
    namespaced : true,

    state: {
        statusesList: [],
    },


    mutations: {


        setFacilityStatuses(state: any, payload : any) {
            state.statusesList = payload;
          
        }


    },


    actions: {
        [LOAD_PAGE](context: any) {
            DbApi.getItemPage(
                "Facility",
                context.rootState.perPage,
                context.rootState.currentPage,
                (data: any) => {
                    if (data.isSucced) {
                        context.commit(IS_ERROR_NOW, false, { root: true });
                        context.commit(SET_LOADED_PAGE, data.data.pageItems, { root: true });
                        context.commit(SET_PAGE_COUNT, data.data.pageCount, { root: true });
                        context.commit(SET_TOTAL_RECORDS, data.data.total, { root: true });
                    } else {

                        context.commit(IS_ERROR_NOW, true, { root: true });
                        context.commit(SET_ERROR_MESSAGE, data.errorMessage, { root: true });
                    }
                },
                (errorMessage: string) => Error(errorMessage)
            );
        },


        [LOAD_FACILITY_STATUSES](context: any) {
            DbApi.getAll(
                "Facility",
                (data: any) => {
                    if (data.isSucced) {
                        console.log(data);
                        context.commit(IS_ERROR_NOW, false, { root: true });
                        context.commit("setFacilityStatuses", data.data);
                    } else {
                        context.commit(IS_ERROR_NOW, true, { root: true });
                        context.commit(SET_ERROR_MESSAGE, data.errorMessage, { root: true });
                    }
                },
                (errorMessage: string) => Error(errorMessage)
            );
        },


        [CREATE_FACILITY](context: any, payload : any ) {
            DbApi.create("Facility", payload, async (data: any) => {
                if (data.isSucced) {
                    context.commit(IS_ERROR_NOW, false, { root: true });
                    await context.dispatch(LOAD_PAGE);
                } else {

                    context.commit(IS_ERROR_NOW, true, { root: true });
                    context.commit(SET_ERROR_MESSAGE, data.errorMessage, { root: true });
                }
            },
                (errorMessage: string) => Error(errorMessage)
            );
        },


        [DELETE_FACILITY](context: any, payload: number) {
            DbApi.delete("Facility", payload,
                async (data: any) => {
                    console.log(data);
                    if (data.isSucced) {
                        context.commit(IS_ERROR_NOW, false, { root: true });
                        await context.dispatch(LOAD_PAGE);
                    } else {

                        context.commit(IS_ERROR_NOW, true, { root: true });
                        context.commit(SET_ERROR_MESSAGE, data.errorMessage, { root: true });
                    }
                }, (errorMessage: string) => Error(errorMessage));
        },


        [UPDATE_FACILITY](context: any, payload: any) {
            DbApi.update("Facility", payload,
                async (data: any) => {
                    if (data.isSucced) {
                        context.commit(IS_ERROR_NOW, false, { root: true });
                        await context.dispatch(LOAD_PAGE);
                    } else {

                        context.commit(IS_ERROR_NOW, true, { root: true });
                        context.commit(SET_ERROR_MESSAGE, data.errorMessage, { root: true });
                    }
                }, (errorMessage: string) => Error(errorMessage)
            );

        },

    }

}