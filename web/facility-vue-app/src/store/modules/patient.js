import { UPDATE_PATIENT, CREATE_PATIENT, DELETE_PATIENT, } from "../MutationTypes";
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
        updatePageCount(context) {
            DbApi.getCountOfPages("Patient", context.rootState.perPage, (data) => { context.commit("setPageCount", { data: data }, { root: true }); }, (_) => console.log("loadErrorPageCount"));
        },
        loadPage(context) {
            DbApi.getItemPage("Patient", context.rootState.perPage, context.rootState.currentPage, (data) => { context.commit("setLoadedPage", { data: data }, { root: true }); }, (_) => console.log("errorOfLoadPage"));
        },
        loadFacilities(context) {
            DbApi.getAll("Patient", (data) => { context.commit("setFacilitiesList", { data: data }); }, (_) => console.log("errorOfLoadFacilityStatuses"));
        },
        [CREATE_PATIENT](context, payload) {
            DbApi.create("Patient", payload.data, async (data) => {
                await context.dispatch("loadPage");
                await context.dispatch("updatePageCount");
            }, (_) => console.log("ErrorOfCreationFacility"));
        },
        [DELETE_PATIENT](context, payload) {
            DbApi.delete("Patient", payload.data, async (data) => {
                await context.dispatch("loadPage");
                await context.dispatch("updatePageCount");
            }, (_) => console.log("ErrorOfDeletion"));
        },
        [UPDATE_PATIENT](context, payload) {
            DbApi.update("Patient", payload.data, async (data) => {
                await context.dispatch("loadPage");
            }, (_) => console.log("ErrorOfUpdateItem"));
        },
    }
};
//# sourceMappingURL=patient.js.map