
import {

    UPDATE_PATIENT,
    CREATE_PATIENT,
    DELETE_PATIENT,

} from "../MutationTypes";

import DbApi from "@/api/AppDBApi";


export default {


    namespaced: true,

    state: {
        patient  : [],
        facility : [],

        page     : [],
    },


    mutations: {
        [UPDATE_PATIENT](state : any, obj : any) {
          //  DbApi.update("Patient", obj);
        },

        [CREATE_PATIENT](state : any, obj : any ) {
         //   DbApi.create("Patient", obj);
        },


        [DELETE_PATIENT](state : any, id : number) {
         //   DbApi.delete("Patient", id);
        },


     //   updatePage(state : any, perPage : number, currentPage : number) {

//        }

    },


    actions: {
        [UPDATE_PATIENT](context : any, obj : any) {
            context.commit(UPDATE_PATIENT, obj);
            context.commit('updatePage', 10, 1);
        },


        [CREATE_PATIENT](context : any) {
            context.commit(CREATE_PATIENT);

        },


        [DELETE_PATIENT](context : any) {
            context.commit(DELETE_PATIENT);
        }
    },


    getters: {
        getPage: (state : any) => (perPage : number, currentPage : number) => {
          //  return DbApi.getItemPage("Patient", perPage, currentPage);
        },

        getItem: (state : any ) => (id : number ) => {
        //    return DbApi.getItem("Patient", id);
        },

        getCountOfPage: (state:any) => (perPage:number) => {
         //   return DbApi.getCountOfPages("Patient", perPage);
        },

        getFacilities: (state:any) => {
          //  return DbApi.getAll("Facility");
        }

    }


}





/*

    shop.buyProducts(
products,
// обработка успешного исхода
() => commit(types.CHECKOUT_SUCCESS),
// обработка неудачного исхода
() => commit(types.CHECKOUT_FAILURE, savedCartItems)
)

 */
