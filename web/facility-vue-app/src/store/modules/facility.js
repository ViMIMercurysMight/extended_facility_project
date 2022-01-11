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
            DbApi.getCountOfPages("Facility", context.rootState.perPage, (data) => { context.commit("setPageCount", { data: data }, { root: true }); alert(data); }, (_) => alert("loadErrorPageCount"));
        },
        loadPage(context) {
            DbApi.getItemPage("Facility", context.rootState.perPage, context.rootState.currentPage, (data) => { context.commit("setLoadedPage", { data: data }, { root: true }); alert(JSON.stringify(data)); }, (_) => alert("errorOfLoadPage"));
        },
        loadFacilityStatuses(context) {
            DbApi.getAll("Facility", (data) => { context.commit("setFacilityStatuses", { data: data }); alert(JSON.stringify(data)); }, (_) => alert("errorOfLoadFacilityStatuses"));
        },
        [CREATE_FACILITY](context, payload) {
            alert("CREATE ITEM");
            alert(JSON.stringify(payload.data));
            DbApi.create("Facility", payload.data, async (data) => {
                await context.dispatch("loadPage");
                await context.dispatch("updatePageCount");
            }, (_) => alert("ErrorOfCreationFacility"));
        },
        [DELETE_FACILITY](context, payload) {
            alert("DELETE ITEM" + " " + payload.data);
            DbApi.delete("Facility", payload.data, async (data) => {
                await context.dispatch("loadPage");
                await context.dispatch("updatePageCount");
            }, (_) => alert("ErrorOfDeletion"));
        },
        [UPDATE_FACILITY](context, payload) {
            alert("UPDATE FACILITY");
            alert(payload.data);
            DbApi.update("Facility", payload.data, async (data) => {
                await context.dispatch("loadPage");
            }, (_) => alert("ErrorOfUpdateItem"));
        },
    }
};
//# sourceMappingURL=facility.js.map