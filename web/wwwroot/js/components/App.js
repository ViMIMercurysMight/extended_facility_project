new Vue({
    el: '#app',

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
        axios
            .get('/Facility/GetCountOfPages')
            .then(response => this.pageCount = response.data);

        axios
            .get('/Facility/GetPageItemJson')
            .then(response => this.pageItems = response.data);

        axios
            .get("/Facility/GetFacilityStatuseJson")
            .then(response => this.statusesList = response.data);

    },

    methods: {

        updatePageCount: function () {
            axios
                .get('/Facility/GetCountOfPages')
                .then(response => this.pageCount = response.data);
        },

        changePage: function (page) {

            this.currentPage = page;


            axios
                .get('/Facility/GetPageItemJson', {
                    params: {
                        page: page
                    }
                }).then(response => this.pageItems = response.data);

        },

        remove: function (id) {
            axios({
                method: "DELETE",
                url: "/Facility/Delete/",

                params: {
                    id: id
                }
            }).then(_ => {
                this.changePage(this.currentPage);
                this.updatePageCount();
            });
        },


        update: function (updatedItem) {

            axios({
                method: "PUT",
                url: "/Facility/Update/",


                data: {
                    ...updatedItem
                }
            }).then(_ => this.changePage(this.currentPage));

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

            axios({
                method: "POST",
                url: "/Facility/Create/",

                data: {
                    ...data
                }
            }).then(_ => {
                this.changePage(this.currentPage);
                this.updatePageCount();
            });

        }
    }

});