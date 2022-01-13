import { UPDATE_PATIENT, CREATE_PATIENT, DELETE_PATIENT, LOAD_PAGE, SET_PAGE_COUNT, SET_LOADED_PAGE, LOAD_FACILITIES } from "../MutationTypes";
import DbApi from "@/api/AppDBApi";
export default {
    namespaced: true,
    state: {
        facilitiList: [],
    },
    mutations: {
        setFacilitiesList(state, payload) {
            state.facilitiList = payload.data;
        }
    },
    actions: {
        [LOAD_PAGE](context) {
            DbApi.getItemPage("Patient", context.rootState.perPage, context.rootState.currentPage, (data) => {
                context.commit(SET_PAGE_COUNT, { data: data.pageCount }, { root: true });
                context.commit(SET_LOADED_PAGE, { data: data.pageItems }, { root: true });
            }, (_) => console.log("errorOfLoadPage"));
        },
        [LOAD_FACILITIES](context) {
            DbApi.getAll("Patient", (data) => { context.commit("setFacilitiesList", { data: data }); }, (_) => console.log("errorOfLoadFacilityStatuses"));
        },
        [CREATE_PATIENT](context, payload) {
            DbApi.create("Patient", payload.data, async (data) => {
                await context.dispatch(LOAD_PAGE);
            }, (_) => console.log("ErrorOfCreationFacility"));
        },
        [DELETE_PATIENT](context, payload) {
            DbApi.delete("Patient", payload.data, async (data) => {
                await context.dispatch(LOAD_PAGE);
            }, (_) => console.log("ErrorOfDeletion"));
        },
        [UPDATE_PATIENT](context, payload) {
            DbApi.update("Patient", payload.data, async (data) => {
                await context.dispatch(LOAD_PAGE);
            }, (_) => console.log("ErrorOfUpdateItem"));
        },
    }
};
//# sourceMappingURL=patient.js.map