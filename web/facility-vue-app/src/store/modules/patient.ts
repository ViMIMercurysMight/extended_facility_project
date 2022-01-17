
import {

    UPDATE_PATIENT,
    CREATE_PATIENT,
    DELETE_PATIENT,
    LOAD_PAGE,
    SET_PAGE_COUNT,
    SET_LOADED_PAGE,
    LOAD_FACILITIES,
    SET_CURRENT_PAGE,
    IS_ERROR_NOW,
    SET_ERROR_MESSAGE
} from "../MutationTypes";

import DbApi from "@/api/AppDBApi";


export default {


    namespaced: true,

    state: {
        facilitiList: [],
    },


    mutations: {

        setFacilitiesList(state: any, payload: any) {
            state.facilitiList = payload;
        }

    },


    actions: {
        [LOAD_PAGE](context: any) {
            DbApi.getItemPage(
                "Patient",
                context.rootState.perPage,
                context.rootState.currentPage,
                (data: any) => {
                    if (data.isSucced) {
                        context.commit(IS_ERROR_NOW, false, { root: true });
                        context.commit(SET_PAGE_COUNT, data.data.pageCount, { root: true });
                        context.commit(SET_LOADED_PAGE, data.data.pageItems, { root: true });
                    } else {

                        context.commit(IS_ERROR_NOW, true, { root: true });
                        context.commit(SET_ERROR_MESSAGE, data.errorMessage, { root: true });
                    }
                },
                (errorMessage: string) => Error(errorMessage)
            );
        },


        [LOAD_FACILITIES](context: any) {
            DbApi.getAll(
                "Patient",
                (data: any) => {
                    if (data.isSucced) {
                        context.commit(IS_ERROR_NOW, false, { root: true });
                        context.commit("setFacilitiesList", data.data);
                    } else {

                        context.commit(IS_ERROR_NOW, true, { root: true });
                        context.commit(SET_ERROR_MESSAGE, data.errorMessage, { root: true });
                    }
                },
                (errorMessage: string) => Error(errorMessage)
            );
        },


        [CREATE_PATIENT](context: any, payload: any) {
            DbApi.create("Patient", payload, async (data: any) => {

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


        [DELETE_PATIENT](context: any, payload: number) {
            DbApi.delete("Patient", payload,
                async (data: any) => {
                    if (data.isSucced) {
                        context.commit(IS_ERROR_NOW, false, { root: true });
                        await context.dispatch(LOAD_PAGE);
                    } else {
                        context.commit(IS_ERROR_NOW, true, { root: true });
                        context.commit(SET_ERROR_MESSAGE, data.errorMessage, { root: true });
                    }
                }, (errorMessage: string) => Error(errorMessage));
        },


        [UPDATE_PATIENT](context: any, payload: any) {
            DbApi.update("Patient", payload,
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

