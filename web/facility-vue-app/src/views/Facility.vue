<template>
    <div class="facility">
        <facility-list :change-page-callback='changePage'
                       :update-callback='showUpdateForm'
                       :create-callback='showCreateForm'
                       :remove-callback='remove'>
        </facility-list>


        <item-form v-if='this.$store.state.isUpdateNow'
                   :item='this.$store.state.updateItem'
                   :status-display='true'
                   :callback='update'>
        </item-form>


        <item-form v-if='this.$store.state.isCreateNow'
                   :item="{}"
                   :status-display='false'
                   :callback="create">
        </item-form>
    </div>
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



        mounted: function () {
            this.$store.commit("reset");
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
                this.$store.commit("isCreateNow", { data: false });
               
            },


            update: function (updatedItem: any) {
                this.$store.dispatch("Facility/updateFacility", { data: updatedItem });
                this.$store.commit("isUpdateNow", { data: false });
            },



            showCreateForm: function () {
                this.$store.commit("isCreateNow", { data: true });
            },


            showUpdateForm: function (updateItem: any) {
                this.$store.commit("setUpdateItem", { data: updateItem });
                this.$store.commit("isUpdateNow", { data: true });
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
