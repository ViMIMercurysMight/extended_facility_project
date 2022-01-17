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
                        <td>Name            </td>
                        <td>Address         </td>
                        <td>Phone    </td>
                        <td>Email           </td>
                        <td>Status  </td>
                        <td>          </td>
                        <td>          </td>
                    </tr>
                </thead>

                <tbody>
                    <facility-item v-for='item in this.$store.state.pageItems'
                                   :key="item.Id"
                                   :update-callback="updateCallback"
                                   :remove-callback="removeCallback"
                                   :item='item'></facility-item>
                </tbody>
            </table>

            <pagination :page-count='pageCount' :change-page-callback='changePageCallback'></pagination>

        </div>

    </div>
</template>



<script lang="ts">
    import { defineComponent } from "vue";


    import Pagination from "@/components/common/Pagination.vue"
    import FacilityItem from "@/components/facility/TableItem.vue";

    export default defineComponent({
        name: "facility-list",
        props: ["items", "createCallback", 'updateCallback', 'removeCallback', 'pageCount', 'changePageCallback'],

        components: {
            "pagination": Pagination,
            "facility-item": FacilityItem
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

    @media screen and ( max-width : 700px)  {
        table {
            font-size : 2vw;
            padding:0px;
        }
    }




</style>
