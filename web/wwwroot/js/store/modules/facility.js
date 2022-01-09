import {

    UPDATE_FACILITY,
    DELETE_FACILITY,
    CREATE_FACILITY

} from "../MutationTypes";


import DbApi from "../../api/testAppDBApi";

export default {

    namespaced : true,

    state: {
        facilities       : [],
        facilityStatuses : [],
    },


    mutations: {

        [UPDATE_FACILITY](state) {
            DbApi.update("Facility", {});
        },


        [DELETE_FACILITY](state) {
            DbApi.delete("Facility", 1);
        },


        [CREATE_FACILITY](state) {
            DbApi.create("Facility", {});
        }
    },


    actions: {
        [CREATE_FACILITY](context) {
            context.commit(CREATE_FACILITY);
        },

        [DELETE_FACILITY](context) {
            context.commit(DELETE_FACILITY);
        },

        [UPDATE_FACILITY](context) {
            context.commit(UPDATE_FACILITY);
        }

    },


    getters: {
        getPage: state => (perPage, currentPage) => {
            return DbApi.getItemPage("Facility", perPage, currentPage);
        },

        getItem: state => id => {
            return DbApi.getItem("Facility", id);
        },

        getCountOfPage: state => perPage => {
            return DbApi.getCountOfPages("Facility", perPage);
        },

        getFacilityStatuses: state => {
            return DbApi.getAll("FacilityStatuses");
        }

    }

}