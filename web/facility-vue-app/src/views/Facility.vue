<template>
    <facility-list :items='pageItems'
                   :page-count='pageCount'
                   :change-page-callback='changePage'
                   :update-callback='showUpdateForm'
                   :create-callback='showCreateForm'
                   :remove-callback='remove'>
    </facility-list>


    <item-form v-if='isUpdateNow'
               :item='updateItem'
               :status-display='true'
               :callback='update'>
    </item-form>


    <item-form v-if='isCreateNow'
               :item='{}'
               :statuses='statusesList'
               :status-display='false'
               :callback="create">
    </item-form>
</template>


<script lang="ts">
    import { defineComponent } from 'vue';


    import ItemForm from "@/components/facility/ItemForm.vue";
    import Table from "@/components/facility/Table.vue";
    
    export default defineComponent({
        name: "Facility",

        components: {
            "item-form": ItemForm,
            "facility-list": Table,
        },


        data() {
            return {
                isUpdateNow  : false,
                isCreateNow: false,

                updateItem: {},
            }
        },

        mounted: function () {
            this.$store.dispatch("Facility/updatePageCount");
            this.$store.dispatch("Facility/loadPage");
            this.$store.dispatch("Facility/loadFacilityStatuses");
        },

        updated: function () {
            console.log(this.$store.state);
        },

        methods: {

            updatePageCount: function () {
                this.$store.dispatch("Facility/updatePageCount");
            },


            changePage: function (page: number) {
                this.$store.commit("setCurrentPage", { data: page });
                this.$store.dispatch("Facility/loadPage");
            },


            remove: function (id: number) {
                this.$store.dispatch("Facility/deleteFacility", { data: id })
            },


            create: function (data: any) {
                this.$store.dispatch("Facility/createFacility", { data: data });
                this.isCreateNow = false;
            },


            update: function (updatedItem: any) {
                this.$store.dispatch("Facility/updateFacility", { data: updatedItem });
                this.isUpdateNow = false; 
            },



            showCreateForm: function () {
                     this.isCreateNow = true;
            },


            showUpdateForm: function (updateItem: any) {
                     this.updateItem = updateItem;
                     this.isUpdateNow = true;
            },



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
