<template>
    <div class="patients container-fluid m-2">
        
        <div v-if="this.$store.state.isErrorNow" class="alert alert-danger row">
            {{ this.$store.state.errorMessage }}
        </div>

        <div class="row">
            <div class="float-left page-title">
                <h1>
                    PATIENT PAGE

                </h1>
            </div>

            <hr class="title-underline" />

        </div>


        <div class="row">
            <div class="col-lg-8 col-md-8 col-sm-12">
                <patient-list :change-page-callback='changePage'
                              :update-callback='showUpdateForm'
                              :create-callback='showCreateForm'
                              :remove-callback='remove'>
                </patient-list>
            </div>

            <div class="col-lg-3 col-md-11 col-sm-12">

                <transition name="fade">

                    <patient-form v-if='this.$store.state.isUpdateNow'
                                  :item='this.$store.state.updateItem'
                                  :facility-display='true'
                                  :callback='update'
                                  title='Update Form'>
                    </patient-form>
                </transition>

                    <patient-form v-if='this.$store.state.isCreateNow'
                                  :facility-display='true'
                                  :item="{}"
                                  :callback="create"
                                  title='Create From'>
                    </patient-form>
            </div>


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
            },


            update: function (updatedItem: any) {
                this.$store.dispatch("Patient/" + UPDATE_PATIENT, updatedItem );
            },



            showCreateForm: function () {
                if (this.$store.state.isUpdateNow)
                    this.$store.commit(IS_UPDATE_NOW, false);

                setTimeout(() =>
                    this.$store.commit(IS_CREATE_NOW, true), 700);
            },


            showUpdateForm: function (updateItem: any) {
                if (this.$store.state.isCreateNow)
                    this.$store.commit(IS_CREATE_NOW, false);

                this.$store.commit(IS_UPDATE_NOW, false);
                setTimeout(() => {
                    this.$store.commit(SET_UPDATE_ITEM, updateItem);
                    this.$store.commit(IS_UPDATE_NOW, true);
                }, 500);
            },



        }
    });

</script>


<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">

    .page-title {
        width:auto;
    }

    .title-underline {
        width:90%;
    }

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


    .fade-enter-active, .fade-leave-active {
        transition: opacity .5s;
    }

    .fade-enter, .fade-leave-to /* .fade-leave-active до версии 2.1.8 */ {
        opacity: 0;
    }
 
</style>