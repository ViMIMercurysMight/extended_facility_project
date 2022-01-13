﻿import {

    UPDATE_FACILITY,
    DELETE_FACILITY,
    CREATE_FACILITY,
    LOAD_PAGE,
    SET_PAGE_COUNT,
    SET_LOADED_PAGE,
    LOAD_FACILITY_STATUSES,
    SET_CURRENT_PAGE
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
                    console.log(data);
                    context.commit(SET_LOADED_PAGE,  data.pageItems , { root: true });
                    context.commit(SET_PAGE_COUNT,  data.pageCount, { root: true });
                },
                (_: any) => console.log("errorOfLoadPage")
            );
        },


        [LOAD_FACILITY_STATUSES](context: any) {
            DbApi.getAll(
                "Facility",
                (data: any) => { context.commit("setFacilityStatuses",  data );  },
                (_: any) => console.log("errorOfLoadFacilityStatuses")
            );
        },


        [CREATE_FACILITY](context: any, payload : any ) {
            DbApi.create("Facility", payload, async (_: any) => {
                await context.dispatch(LOAD_PAGE);
            },
                (_: any) => console.log("ErrorOfCreationFacility")
            );
        },


        [DELETE_FACILITY](context: any, payload: number) {
            DbApi.delete("Facility", payload,
               async (data: any) => {
                   await context.dispatch(LOAD_PAGE);
                   console.log("DELETE_FACILITY " + payload);
                }, (_: any) => console.log("ErrorOfDeletion"));
        },


        [UPDATE_FACILITY](context: any, payload: any) {
            DbApi.update("Facility", payload,
               async (data: any) => {
                   await context.dispatch(LOAD_PAGE);
                }, (_: any) => console.log("ErrorOfUpdateItem")
            );

        },

    }

}