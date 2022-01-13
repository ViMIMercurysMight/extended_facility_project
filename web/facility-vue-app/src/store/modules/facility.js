import { UPDATE_FACILITY, DELETE_FACILITY, CREATE_FACILITY, LOAD_PAGE, SET_PAGE_COUNT, SET_LOADED_PAGE, LOAD_FACILITY_STATUSES } from "../MutationTypes";
import DbApi from "@/api/AppDBApi";
export default {
    namespaced: true,
    state: {
        statusesList: [],
    },
    mutations: {
        setFacilityStatuses(state, payload) {
            state.statusesList = payload;
        }
    },
    actions: {
        [LOAD_PAGE](context) {
            DbApi.getItemPage("Facility", context.rootState.perPage, context.rootState.currentPage, (data) => {
                console.log(data);
                context.commit(SET_LOADED_PAGE, data.pageItems, { root: true });
                context.commit(SET_PAGE_COUNT, data.pageCount, { root: true });
            }, (_) => console.log("errorOfLoadPage"));
        },
        [LOAD_FACILITY_STATUSES](context) {
            DbApi.getAll("Facility", (data) => { context.commit("setFacilityStatuses", data); }, (_) => console.log("errorOfLoadFacilityStatuses"));
        },
        [CREATE_FACILITY](context, payload) {
            DbApi.create("Facility", payload, async (_) => {
                await context.dispatch(LOAD_PAGE);
            }, (_) => console.log("ErrorOfCreationFacility"));
        },
        [DELETE_FACILITY](context, payload) {
            DbApi.delete("Facility", payload, async (data) => {
                await context.dispatch(LOAD_PAGE);
                console.log("DELETE_FACILITY " + payload);
            }, (_) => console.log("ErrorOfDeletion"));
        },
        [UPDATE_FACILITY](context, payload) {
            DbApi.update("Facility", payload, async (data) => {
                await context.dispatch(LOAD_PAGE);
            }, (_) => console.log("ErrorOfUpdateItem"));
        },
    }
};
//# sourceMappingURL=facility.js.map