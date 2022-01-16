<template>
    <div class="patients container">

        <div v-if="this.$store.state.isErrorNow" class="alert alert-danger">
            {{ this.$store.state.errorMessage }}
        </div>


        <div class="row">
            <patient-list :change-page-callback='changePage'
                          :update-callback='showUpdateForm'
                          :create-callback='showCreateForm'
                          :remove-callback='remove'>
            </patient-list>
        </div>


        <div class="row">
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


        SET_CURRENT_PAGE,
        IS_UPDATE_NOW,
        IS_CREATE_NOW,
        SET_UPDATE_ITEM,
        RESET,
        LOAD_PAGE,
        LOAD_FACILITIES,
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
                this.$store.commit(SET_CURRENT_PAGE,  page );
                this.$store.dispatch("Patient/" + LOAD_PAGE);
            },


            remove: function (id: number) {
                this.$store.dispatch("Patient/" + DELETE_PATIENT, id )
            },


            create: function (data: any) {
                this.$store.dispatch("Patient/" + CREATE_PATIENT,  data );
                this.$store.commit(IS_CREATE_NOW, false );
            },


            update: function (updatedItem: any) {
                this.$store.dispatch("Patient/" + UPDATE_PATIENT, updatedItem );
                this.$store.commit(IS_UPDATE_NOW,  false );
            },



            showCreateForm: function () {
                if (this.$store.state.isUpdateNow)
                    this.$store.commit(IS_UPDATE_NOW, false);

                this.$store.commit(IS_CREATE_NOW,  true );
            },


            showUpdateForm: function (updateItem: any) {
                if (this.$store.state.isCreateNow)
                    this.$store.commit(IS_CREATE_NOW, false);

                this.$store.commit(IS_UPDATE_NOW, false);
                this.$store.commit(SET_UPDATE_ITEM, updateItem );
                this.$store.commit(IS_UPDATE_NOW,  true );
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

    input:invalid {
        border-color: red;
    }

    input:valid {
        border-color: green;
    }
</style>