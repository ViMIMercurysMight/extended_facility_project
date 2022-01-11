<template>
    <tr>
        <td> {{ item.id ? item.id : 0 }}                 </td>
        <td> {{ item.firstName ? item.firstName : "" }}               </td>
        <td> {{ item.lastName ? item.lastName : ""}}             </td>
        <td> {{ item.dateOfBirth ? item.dateOfBirth : ""}}         </td>
        <td> {{ item.email ? item.email : ""}}               </td>
        <td> {{ item.facility ? item.facility.name : ""}} </td>
        <td> <button v-on:click='removeCallback(item.id ? item.id : -1)' class='btn btn-danger'> Delete </button></td>
        <td> <button v-on:click='updateCallback(item ? item : {})' class='btn btn-warning'>    Update </button></td>
    </tr>
</template>


<script lang="ts">
    import { defineComponent } from "vue";

    export default defineComponent({
        name: "patient-item",
        props: ["item", "updateCallback", "removeCallback"],
    });

</script>
