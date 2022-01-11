import { UPDATE_FACILITY, DELETE_FACILITY, CREATE_FACILITY } from "../MutationTypes";
import DbApi from "@/api/AppDBApi";
export default {
    namespaced: true,
    state: {
        statusesList: [],
    },
    mutations: {
        setFacilityStatuses(state, payload) {
            state.statusesList = payload.data;
        }
    },
    actions: {
        updatePageCount(context) {
            DbApi.getCountOfPages("Facility", context.rootState.perPage, (data) => { context.commit("setPageCount", { data: data }, { root: true }); }, (_) => console.log("loadErrorPageCount"));
        },
        loadPage(context) {
            DbApi.getItemPage("Facility", context.rootState.perPage, context.rootState.currentPage, (data) => { context.commit("setLoadedPage", { data: data }, { root: true }); }, (_) => console.log("errorOfLoadPage"));
        },
        loadFacilityStatuses(context) {
            DbApi.getAll("Facility", (data) => { context.commit("setFacilityStatuses", { data: data }); }, (_) => console.log("errorOfLoadFacilityStatuses"));
        },
        [CREATE_FACILITY](context, payload) {
            DbApi.create("Facility", payload.data, async (data) => {
                await context.dispatch("loadPage");
                await context.dispatch("updatePageCount");
            }, (_) => console.log("ErrorOfCreationFacility"));
        },
        [DELETE_FACILITY](context, payload) {
            DbApi.delete("Facility", payload.data, async (data) => {
                await context.dispatch("loadPage");
                await context.dispatch("updatePageCount");
            }, (_) => console.log("ErrorOfDeletion"));
        },
        [UPDATE_FACILITY](context, payload) {
            DbApi.update("Facility", payload.data, async (data) => {
                await context.dispatch("loadPage");
            }, (_) => console.log("ErrorOfUpdateItem"));
        },
    }
};
//# sourceMappingURL=facility.js.map