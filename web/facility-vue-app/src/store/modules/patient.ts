
import {

    UPDATE_PATIENT,
    CREATE_PATIENT,
    DELETE_PATIENT,
    LOAD_PAGE,
    SET_PAGE_COUNT,
    SET_LOADED_PAGE,
    LOAD_FACILITIES,
    SET_CURRENT_PAGE
} from "../MutationTypes";

import DbApi from "@/api/AppDBApi";


export default {


    namespaced: true,

    state: {
        facilitiList: [],
    },


    mutations: {

        setFacilitiesList(state: any, payload: any) {
            state.facilitiList = payload.data;
        }

    },


    actions: {
        [LOAD_PAGE](context: any) {
            DbApi.getItemPage(
                "Patient",
                context.rootState.perPage,
                context.rootState.currentPage,
                (data: any) => {
                    context.commit(SET_PAGE_COUNT, { data: data.pageCount }, { root: true });
                    context.commit(SET_LOADED_PAGE, { data: data.pageItems }, { root: true });
                },
                (_: any) => console.log("errorOfLoadPage")
            );
        },


        [LOAD_FACILITIES](context: any) {
            DbApi.getAll(
                "Patient",
                (data: any) => { context.commit("setFacilitiesList", { data: data }); },
                (_: any) => console.log("errorOfLoadFacilityStatuses")
            );
        },


        [CREATE_PATIENT](context: any, payload: any) {
            DbApi.create("Patient", payload.data, async (data: any) => {
                await context.dispatch(LOAD_PAGE);
            },
                (_: any) => console.log("ErrorOfCreationFacility")
            );
        },


        [DELETE_PATIENT](context: any, payload: any) {
            DbApi.delete("Patient", payload.data,
                async (data: any) => {
                    await context.dispatch(LOAD_PAGE);
                }, (_: any) => console.log("ErrorOfDeletion"));
        },


        [UPDATE_PATIENT](context: any, payload: any) {
            DbApi.update("Patient", payload.data,
                async (data: any) => {
                    await context.dispatch(LOAD_PAGE);
                }, (_: any) => console.log("ErrorOfUpdateItem")
            );

        },

    }

}

