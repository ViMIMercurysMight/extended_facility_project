import Pagination from "./common";

import FacilityRoot from "./facility/FacilityRootComponent";
import PatientRoot  from "./patient/PatientRootComponent";


export default {
    el: '#app',

    components: {
        "pagination": Pagination,
        "facility"   : FacilityRoot,
        "patient"    : PatientRoot,
    },

    data: {

        pageCount: 0,
        pageItems: [],


        statusesList: [],

        isUpdateNow: false,
        updateItem: {},

        isCreateNow: false,
        currentPage: 0,
    },

    mounted: function () {

        // 1--GetCountOfPage
        // 2--GetPageItemJson
        // 3--GetFacilityStatusesJson

    },

    methods: {

        updatePageCount: function () {
            // 1-- GetCountOfPage

        },

        changePage: function (page) {

            this.currentPage = page;

            // 1-- GetPageItemJson { params page: currentPage }

        },

        remove: function (id) {
            // 1-- Delete { params id : id }
        },


        update: function (updatedItem) {
            // 1-- Update data : { ....updatedItem }


            this.isUpdateNow = false;

        },


        showCreateForm: function () {
            this.isCreateNow = true;
        },


        showUpdateForm: function (updateItem) {
            this.updateItem = updateItem;
            this.isUpdateNow = true;
        },


        create: function (data) {
            this.isCreateNow = false;



        }
    }

};
