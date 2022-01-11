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
    


    export default defineComponent({
        name: 'Patient',

        components: {
            "patient-form": ItemForm,
            "patient-list": Table,
        },
        mounted: function () {
            this.$store.commit("reset");
            this.$store.dispatch("Patient/updatePageCount");
            this.$store.dispatch("Patient/loadPage");
            this.$store.dispatch("Patient/loadFacilities");
        },

        updated: function () {
            console.log(this.$store.state);
        },

        methods: {

            updatePageCount: function () {
                this.$store.dispatch("Patient/updatePageCount");
            },


            changePage: function (page: number) {
                this.$store.commit("setCurrentPage", { data: page });
                this.$store.dispatch("Patient/loadPage");
            },


            remove: function (id: number) {
                this.$store.dispatch("Patient/deletePatient", { data: id })
            },


            create: function (data: any) {
                this.$store.dispatch("Patient/createPatient", { data: data });
                this.$store.commit("isCreateNow", { data: false });

            },


            update: function (updatedItem: any) {
                this.$store.dispatch("Patient/updatePatient", { data: updatedItem });
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