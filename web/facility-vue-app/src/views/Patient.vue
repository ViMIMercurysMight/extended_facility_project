<template>
    <div class="patients">
        <patient-list :change-page-callback='changePage'
                      :update-callback='showUpdateForm'
                      :create-callback='showCreateForm'
                      :remove-callback='remove'>
        </patient-list>


        <patient-form v-if='this.$store.state.isUpdateNow'
                      :item='this.$store.state.updateItem'
                      :facility-display='true'
                      :callback='update'>
        </patient-form>


        <patient-form v-if='this.$store.state.isCreateNow'
                      :facility-display='true'
                      :item="{}"
                      :callback="create">
        </patient-form>
    </div>
</template>


<script lang="ts">

    import { defineComponent } from 'vue';


    import ItemForm from "@/components/patient/PatientForm.vue";
    import Table    from "@/components/patient/PatientTable.vue";
    

    import {

        UPDATE_PATIENT,
        DELETE_PATIENT,
        CREATE_PATIENT,

        SET_PAGE_COUNT,
        SET_CURRENT_PAGE,
        SET_LOADED_PAGE,
        IS_UPDATE_NOW,
        IS_CREATE_NOW,
        SET_UPDATE_ITEM,
        RESET,
        LOAD_PAGE,
        LOAD_FACILITIES,
        LOAD_FACILITY_STATUSES
    } from "@/store/MutationTypes";



    export default defineComponent({
        name: 'Patient',

        components: {
            "patient-form": ItemForm,
            "patient-list": Table,
        },
        mounted: function () {
            this.$store.commit(RESET);
            this.$store.dispatch("Patient/" + LOAD_PAGE);
            this.$store.dispatch("Patient/" + LOAD_FACILITIES);
        },

        updated: function () {
            console.log(this.$store.state);
        },

        methods: {

  
            changePage: function (page: number) {
                this.$store.commit(SET_CURRENT_PAGE, { data: page });
                this.$store.dispatch("Patient/" + LOAD_PAGE);
            },


            remove: function (id: number) {
                this.$store.dispatch("Patient/" + DELETE_PATIENT, { data: id })
            },


            create: function (data: any) {
                this.$store.dispatch("Patient/" + CREATE_PATIENT, { data: data });
                this.$store.commit(IS_CREATE_NOW, { data: false });

            },


            update: function (updatedItem: any) {
                this.$store.dispatch("Patient/" + UPDATE_PATIENT, { data: updatedItem });
                this.$store.commit(IS_UPDATE_NOW, { data: false });
            },



            showCreateForm: function () {
                this.$store.commit(IS_CREATE_NOW, { data: true });
            },


            showUpdateForm: function (updateItem: any) {
                this.$store.commit(SET_UPDATE_ITEM, { data: updateItem });
                this.$store.commit(IS_UPDATE_NOW, { data: true });
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