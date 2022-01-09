import {

    UPDATE_FACILITY,
    DELETE_FACILITY,
    CREATE_FACILITY

} from "../MutationTypes";


import DbApi from "@/api/TestAppDBApi";

export default {
    
    namespaced : true,

    state: {
        facilities       : [],
        facilityStatuses : [],
    },


    mutations: {

        [UPDATE_FACILITY](state : any) {
            DbApi.update("Facility", {});
        },


        [DELETE_FACILITY](state : any) {
            DbApi.delete("Facility", 1);
        },


        [CREATE_FACILITY](state : any) {
            DbApi.create("Facility", {});
        }
    },


    actions: {
        [CREATE_FACILITY](context : any) {
            context.commit(CREATE_FACILITY);
        },

        [DELETE_FACILITY](context : any) {
            context.commit(DELETE_FACILITY);
        },

        [UPDATE_FACILITY](context : any) {
            context.commit(UPDATE_FACILITY);
        }

    },


    getters: {
        getPage: (state : any ) => (perPage : number, currentPage : number) => {
            return DbApi.getItemPage("Facility", perPage, currentPage);
        },

        getItem: (state : any) => (id : number) => {
            return DbApi.getItem("Facility", id);
        },

        getCountOfPage: (state : any) => (perPage : number) => {
            return DbApi.getCountOfPages("Facility", perPage);
        },

        getFacilityStatuses: (state : any) => {
            return DbApi.getAll("FacilityStatuses");
        }

    }

}