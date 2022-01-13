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

    import {
        UPDATE_FACILITY,
        DELETE_FACILITY,
        CREATE_FACILITY,


        SET_CURRENT_PAGE,
        IS_UPDATE_NOW,
        IS_CREATE_NOW,
        SET_UPDATE_ITEM,
        RESET,
        LOAD_PAGE,
        LOAD_FACILITY_STATUSES
    } from "@/store/MutationTypes";


    export default defineComponent({
        name: "Facility",

        components: {
            "item-form": ItemForm,
            "facility-list": Table,
        },



        mounted: function () {
            this.$store.commit(RESET);
            this.$store.dispatch("Facility/" + LOAD_PAGE);
            this.$store.dispatch("Facility/" + LOAD_FACILITY_STATUSES);
        },

        updated: function () {
            console.log(this.$store.state);
        },

        methods: {

            changePage: function (page: number) {
                this.$store.commit(SET_CURRENT_PAGE,  page );
                this.$store.dispatch("Facility/" + LOAD_PAGE);
            },


            remove: function (id: number) {
                this.$store.dispatch("Facility/" + DELETE_FACILITY,  id )
            },


            create: function (data: any) {
                this.$store.dispatch("Facility/" + CREATE_FACILITY,  data );
                this.$store.commit(IS_CREATE_NOW,  false );
               
            },


            update: function (updatedItem: any) {
                this.$store.dispatch("Facility/" + UPDATE_FACILITY,  updatedItem );
                this.$store.commit(IS_UPDATE_NOW, false );
            },



            showCreateForm: function () {
                this.$store.commit(IS_CREATE_NOW,  true );
            },


            showUpdateForm: function (updateItem: any) {
                this.$store.commit(SET_UPDATE_ITEM, updateItem );
                this.$store.commit(IS_UPDATE_NOW, true );
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
