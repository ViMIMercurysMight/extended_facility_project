<template>
    <div>
        <table class='table thead-dark'>
            <thead>
                <tr>
                    <td>Id              </td>
                    <td>FirstName       </td>
                    <td>LastName        </td>
                    <td>Date Of Birth   </td>
                    <td>FacilityName    </td>
                    <td>remove          </td>
                    <td>update          </td>
                </tr>
            </thead>

            <tbody>
                <patient-item v-for='item in this.$store.state.pageItems'
                               :key="item.Id"
                               :update-callback="updateCallback"
                               :remove-callback="removeCallback"
                               :item='item'></patient-item>
            </tbody>
        </table>

        <pagination :page-count='pageCount' :change-page-callback='changePageCallback'></pagination>
        <button v-on:click='createCallback' class='btn btn-info'> Create </button>

    </div>
</template>



<script lang="ts">
    import { defineComponent } from "vue";


    import Pagination from "@/components/common/Pagination.vue"
    import PatientItem from "@/components/patient/PatientItem.vue";

    export default defineComponent({
        name: "patient-list",
        props: ["items", "createCallback", 'updateCallback', 'removeCallback', 'pageCount', 'changePageCallback'],

        components: {
            "pagination": Pagination,
            "patient-item": PatientItem
        },

        data() {
            return {
                showUpdate: false,
                updatedItemId: -1,
            }
        },
    })

</script>
