/*

import {

    UPDATE_PATIENT,
    CREATE_PATIENT,
    DELETE_PATIENT,

} from "../MutationTypes";

import DbApi from "../../api/testAppDBApi";


export default {


    namespaced: true,

    state: {
        patient  : [],
        facility : [],

        page     : [],
    },


    mutations: {
        [UPDATE_PATIENT](state, obj) {
            DbApi.update("Patient", obj);
        },

        [CREATE_PATIENT](state, obj) {
            DbApi.create("Patient", obj);
        },


        [DELETE_PATIENT](state, id) {
            DbApi.delete("Patient", id);
        },


        updatePage(state, perPage, currentPage) {

        }

    },


    actions: {
        [UPDATE_PATIENT](context, obj) {
            context.commit(UPDATE_PATIENT, obj);
            context.commit('updatePage', 10, 1);
        },


        [CREATE_PATIENT](context) {
            context.commit(CREATE_PATIENT);

        },


        [DELETE_PATIENT](context) {
            context.commit(DELETE_PATIENT);
        }
    },


    getters: {
        getPage: state => (perPage, currentPage) => {
            return DbApi.getItemPage("Patient", perPage, currentPage);
        },

        getItem: state => id => {
            return DbApi.getItem("Patient", id);
        },

        getCountOfPage: state => perPage => {
            return DbApi.getCountOfPages("Patient", perPage);
        },

        getFacilities: state => {
            return DbApi.getAll("Facility");
        }

    }


}


*/






/*

    shop.buyProducts(
products,
// обработка успешного исхода
() => commit(types.CHECKOUT_SUCCESS),
// обработка неудачного исхода
() => commit(types.CHECKOUT_FAILURE, savedCartItems)
)

 */
