<template>
    <tr>
        <td> {{ item.id }}                 </td>
        <td> {{ item.name }}               </td>
        <td> {{ item.address}}             </td>
        <td> {{ item.phoneNumber}}         </td>
        <td> {{ item.email}}               </td>
        <td> {{ item.facilityStatus.name}} </td>
        <td> <button v-on:click='removeCallback(item.id)' class='btn btn-danger'> Delete </button></td>
        <td> <button v-on:click='updateCallback(item)' class='btn btn-warning'>    Update </button></td>
    </tr>
</template>


<script lang="ts">
    import { defineComponent } from "vue";

    export default defineComponent({
        name : "facility-item",
        props: ["item", "updateCallback", "removeCallback"],
    });

</script>
