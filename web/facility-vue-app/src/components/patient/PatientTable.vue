<template>

    <div>
        <div class="float-right create-btn-container">
            <button v-on:click='createCallback' class='btn btn-outline-info'> Create </button>
        </div>

        <div>
            <table class='table thead-dark'>
                <thead>
                    <tr>
                        <td>Id              </td>
                        <td>FirstName       </td>
                        <td>LastName        </td>
                        <td>Date Of Birth   </td>
                        <td>FacilityName    </td>
                        <td>          </td>
                        <td>          </td>
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

        </div>

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


<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
    .create-btn-container {
        width: 10%;
        margin: 16px;
    }
</style>


<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">


    @media screen and (max-width:800px) {
        table {
            font-size: 2.7vw;

        }

    }


    @media screen and (min-width:1440px) {
        table {
            font-size : 1vw;
        }
    }
</style>
