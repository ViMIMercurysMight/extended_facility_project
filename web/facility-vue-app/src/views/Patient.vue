<template>
    <patient-list :items='pageItems'
                   :page-count='pageCount'
                   :change-page-callback='changePage'
                   :update-callback='showUpdateForm'
                   :create-callback='showCreateForm'
                   :remove-callback='remove'>
    </patient-list>


    <patient-form v-show='isUpdateNow'
               :item='updateItem'
               :statuses='statusesList'
               v-bind:status-display='true'
               :callback='update'>
    </patient-form>


    <patient-form v-show='isCreateNow'
               :item='{}'
               :statuses='statusesList'
               v-bind:status-display='false'
               :callback="create">
    </patient-form>
</template>


<script lang="ts">

    import { defineComponent } from 'vue';


    import ItemForm from "@/components/patient/PatientForm.vue";
    import Table    from "@/components/patient/PatientTable.vue";
    


    export default defineComponent({
        name: 'Patient',

        components: {
            "patient-form": ItemForm,
            "patient-list": Table,
        },

        data() {
            return {
                pageCount: 0,
                pageItems: [],
                statusesList: [],
                isUpdateNow: false,
                updateItem: {},
                isCreateNow: false,
                currentPage: 0,
            }
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

            changePage: function (page: number) {

                //    this.currentPage = page;

                // 1-- GetPageItemJson { params page: currentPage }

            },

            remove: function (id: number) {
                // 1-- Delete { params id : id }
            },


            update: function (updatedItem: any) {
                // 1-- Update data : { ....updatedItem }


                //   this.isUpdateNow = false;

            },


            showCreateForm: function () {
                //     this.isCreateNow = true;
            },


            showUpdateForm: function (updateItem: any) {
                //     this.updateItem = updateItem;
                //      this.isUpdateNow = true;
            },


            create: function (data: any) {
                //    this.isCreateNow = false;



            }

        }
    });

</script>


<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
    h3 {
        margin: 40px 0 0;
    }

    ul {
        list-style-type: none;
        padding: 0;
    }

    li {
        display: inline-block;
        margin: 0 10px;
    }

    a {
        color: #42b983;
    }
</style>