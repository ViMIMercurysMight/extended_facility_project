import { createStore } from 'vuex'
import Facility from "./modules/facility";
import Patient from "./modules/patient";

import Actions   from "@/store/actions";
import Mutations from "@/store/mutations";

export default createStore({
    state: {
        pageItems: [],


        errorMessage : "",
        isErrorNow : false,
        isUpdateNow: false,
        isCreateNow: true,


        isUpdateTransited : false,
        updateItem: {},

        pageCount  : 0,
        currentPage: 0,

        perPage: 10
    },

    mutations: {
        ...Mutations
    },


    actions: {
        ...Actions
    },


    modules: {
       Facility,
       Patient,
  }
})
