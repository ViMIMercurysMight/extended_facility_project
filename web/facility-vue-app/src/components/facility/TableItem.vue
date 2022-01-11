<template>
    <tr>
        <td> {{ item.id ? item.id : 0 }}                 </td>
        <td> {{ item.name ? item.name : "" }}               </td>
        <td> {{ item.address ? item.address : ""}}             </td>
        <td> {{ item.phoneNumber ? item.phoneNumber : ""}}         </td>
        <td> {{ item.email ? item.email : ""}}               </td>
        <td> {{ item.facilityStatus ? item.facilityStatus.name : ""}} </td>
        <td> <button v-on:click='removeCallback(item.id ? item.id : 0)' class='btn btn-danger'> Delete </button></td>
        <td> <button v-on:click='updateCallback(item ? item : {})' class='btn btn-warning'>    Update </button></td>
    </tr>
</template>


<script lang="ts">
    import { defineComponent } from "vue";

    export default defineComponent({
        name : "facility-item",
        props: ["item", "updateCallback", "removeCallback"],
    });

</script>
