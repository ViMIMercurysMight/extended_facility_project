import {

    UPDATE_FACILITY,
    DELETE_FACILITY,
    CREATE_FACILITY

} from "../MutationTypes";


import DbApi from "@/api/AppDBApi";


export default {
    
    namespaced : true,

    state: {
        statusesList: [],
    },


    mutations: {


        setFacilityStatuses(state: any, payload : any) {
            state.statusesList = payload.data;
          
        }


    },


    actions: {


        loadPage(context: any) {
            DbApi.getItemPage(
                "Facility",
                context.rootState.perPage,
                context.rootState.currentPage,
                (data: any) => {
                    console.log(data);
                    context.commit("setLoadedPage", { data: data.pageItems }, { root: true });
                    context.commit("setPageCount", { data: data.pageCount }, { root: true });
                },
                (_: any) => console.log("errorOfLoadPage")
            );
        },


        loadFacilityStatuses(context: any) {
            DbApi.getAll(
                "Facility",
                (data: any) => { context.commit("setFacilityStatuses", { data: data });  },
                (_: any) => console.log("errorOfLoadFacilityStatuses")
            );
        },


        [CREATE_FACILITY](context: any, payload : any ) {
            DbApi.create("Facility", payload.data, async (data: any) => {
                await context.dispatch("loadPage");
            },
                (_: any) => console.log("ErrorOfCreationFacility")
            );
        },


        [DELETE_FACILITY](context: any, payload: any) {
            DbApi.delete("Facility", payload.data,
               async (data: any) => {
                   await context.dispatch("loadPage");
                }, (_: any) => console.log("ErrorOfDeletion"));
        },


        [UPDATE_FACILITY](context: any, payload: any) {
            DbApi.update("Facility", payload.data,
               async (data: any) => {
                    await context.dispatch("loadPage");
                }, (_: any) => console.log("ErrorOfUpdateItem")
            );

        },

    }

}