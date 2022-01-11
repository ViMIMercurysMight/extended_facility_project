
import {

    UPDATE_PATIENT,
    CREATE_PATIENT,
    DELETE_PATIENT,

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

        updatePageCount(context: any) {
            DbApi.getCountOfPages(
                "Patient",
                context.rootState.perPage,
                (data: any) => { context.commit("setPageCount", { data: data }, { root: true }); },
                (_: any) => console.log("loadErrorPageCount")
            );
        },


        loadPage(context: any) {

            DbApi.getItemPage(
                "Patient",
                context.rootState.perPage,
                context.rootState.currentPage,
                (data: any) => { context.commit("setLoadedPage", { data: data }, { root: true }); },
                (_: any) => console.log("errorOfLoadPage")
            );
        },


        loadFacilities(context: any) {
            DbApi.getAll(
                "Patient",
                (data: any) => { context.commit("setFacilitiesList", { data: data }); },
                (_: any) => console.log("errorOfLoadFacilityStatuses")
            );
        },


        [CREATE_PATIENT](context: any, payload: any) {
            DbApi.create("Patient", payload.data, async (data: any) => {
                await context.dispatch("loadPage");
                await context.dispatch("updatePageCount");
            },
                (_: any) => console.log("ErrorOfCreationFacility")
            );
        },


        [DELETE_PATIENT](context: any, payload: any) {
            DbApi.delete("Patient", payload.data,
                async (data: any) => {
                    await context.dispatch("loadPage");
                    await context.dispatch("updatePageCount");
                }, (_: any) => console.log("ErrorOfDeletion"));
        },


        [UPDATE_PATIENT](context: any, payload: any) {
            DbApi.update("Patient", payload.data,
                async (data: any) => {
                    await context.dispatch("loadPage");
                }, (_: any) => console.log("ErrorOfUpdateItem")
            );

        },

    }

}

